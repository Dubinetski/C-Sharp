using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LinqToObjects {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();

			Repository.Load();
		}
		//1. Список всех артистов, который выпустили свои альбомы после распада СССР.
		private void btnQuery1_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   where cd.Year > 1991
								   select new { cd.Artist }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs.Where(p => p.Year > 1991).Select(p => new { p.Artist }).ToList();
			}
		}
		//2. Список стран(без повторений).
		private void btnQuery2_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   select new { cd.Country }).Distinct().ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.Select(p => new { p.Country })
					.Distinct().ToList();
			}
		}
		//3. Список наименований альбомов, выпущенных в США, упорядоченных по году выпуска.
		private void btnQuery3_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   orderby cd.Year
								   where cd.Country == "USA"
								   select new { cd.Title }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.Where(p => p.Country == "USA").OrderBy(p => p.Year)
					.Select(p => new { p.Title }).ToList();
			}
		}
		//4. Суммарную стоимость альбомов за страну.
		private void btnQuery4_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   group cd by cd.Country into gr
								   select new { Country = gr.Key, SummCostCD = gr.Sum(p => p.Price) }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.GroupBy(p => p.Country)
					.Select(p => new { Country = p.Key, SummCostCD = p.Sum(c => c.Price) }).ToList();
			}
		}
		//5. Список: компания и количество альбомов за год, года упорядочены по возрастанию. 
		private void btnQuery5_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   group cd by new { cd.Company, cd.Year } into gr
								   orderby gr.Key.Year
								   select new { gr.Key.Year, gr.Key.Company, Summ = gr.Count() }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.GroupBy(p => new { p.Company, p.Year }, (key, group) => new { key.Year, key.Company, AlbomCount = group.Count() })
					.OrderBy(p => p.Year).ToList();
			}
		}
		//6. Наименование альбомов и имя продюсера, получившего самое большое вознаграждение за вклад в развитие.
		private void btnQuery6_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   join pr in Repository.Producers.ProducersList on cd.Producer equals pr.Id
								   where pr.Fee == Repository.Producers.ProducersList.Max(p => p.Fee)
								   select new { Albom = cd.Title, Producer = pr.Name }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.Join(Repository.Producers.ProducersList, cd => cd.Producer, pr => pr.Id, (cd, pr) => new { cd.Title, pr.Name, pr.Fee })
					.Where(p => p.Fee == Repository.Producers.ProducersList.Max(pr => pr.Fee))
					.Select(p => new { p.Title, p.Name }).ToList();
			}
		}
		//7. Количество альбомов каждого продюсера в период  между годами выхода альбома 1988 – 1990 гг.
		private void btnQuery7_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   join pr in Repository.Producers.ProducersList on cd.Producer equals pr.Id
								   where cd.Year >= 1988
								   where cd.Year <= 1990
								   group cd by pr.Name into gr
								   select new { Producer = gr.Key, AlbomsCount = gr.Count() }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.Join(Repository.Producers.ProducersList, cd => cd.Producer, pr => pr.Id, (cd, pr) => new { cd.Title, cd.Year, pr.Name })
					.Where(p => p.Year >= 1988 && p.Year <= 1990)
					.GroupBy(p => p.Name)
					.Select(p => new { Producer = p.Key, AlbomsCount = p.Count() })
					.ToList();
			}
		}
		//8. Фамилию продюсера получившего вознаграждение последним.
		private void btnQuery8_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   join pr in Repository.Producers.ProducersList on cd.Producer equals pr.Id
								   where cd.Year == Repository.CdCatalog.CDs.Max(p => p.Year)
								   select new { Producer = pr.Name }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.Join(Repository.Producers.ProducersList, cd => cd.Producer, pr => pr.Id, (cd, pr) => new { pr.Name, cd.Year })
					.Where(p => p.Year == Repository.CdCatalog.CDs.Max(q => q.Year))
					.Select(p => new { Producer = p.Name }).ToList();
			}
		}
		//9. Информацию о самом дешевом альбоме(название альбома, исполнителя и продюсера).
		private void btnQuery9_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   join pr in Repository.Producers.ProducersList on cd.Producer equals pr.Id
								   where cd.Price == Repository.CdCatalog.CDs.Min(p => p.Price)
								   select new { Albom = cd.Title, cd.Artist, Producer = pr.Name }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.Join(Repository.Producers.ProducersList, cd => cd.Producer, pr => pr.Id, (cd, pr) => new { cd.Title, cd.Artist, pr.Name, cd.Price })
					.Where(cd => cd.Price == Repository.CdCatalog.CDs.Min(p => p.Price))
					.Select(r => new { Albom = r.Title, r.Artist, Producer = r.Name }).ToList();
			}
		}
		//10. Полную информацию об альбомах, отсортированную по следующим критериям: год выхода альбома, стоимость альбома, наименование альбома.
		private void btnQuery10_Click(object sender, EventArgs e) {
			if (rbQueries.Checked) {
				dgw1.DataSource = (from cd in Repository.CdCatalog.CDs
								   join pr in Repository.Producers.ProducersList on cd.Producer equals pr.Id
								   orderby cd.Year, cd.Price, cd.Title
								   select new { Albom = cd.Title, cd.Year, cd.Artist, cd.Country, cd.Company, Producer = pr.Name, cd.Price }).ToList();
			} else {
				dgw1.DataSource = Repository.CdCatalog.CDs
					.Join(Repository.Producers.ProducersList, cd => cd.Producer, pr => pr.Id, (cd, pr) => new { cd.Title, cd.Year, cd.Artist, cd.Country, cd.Company, pr.Name, cd.Price })
					.OrderBy(o => o.Year).ThenBy(o => o.Price).ThenBy(o => o.Title)
					.Select(r => new { Albom = r.Title, r.Year, r.Artist, r.Country, r.Company, Producer = r.Name, r.Price }).ToList();
			}
		}
	}
}
