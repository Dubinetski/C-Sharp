using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LinqToXml {
	public partial class MainForm : Form {
		XElement mondialDoc;
		public MainForm() {
			InitializeComponent();
			mondialDoc = XElement.Load(@".\countries.xml");
		}

		//1. Вывести список всех стран	
		//Вывод: <название страны>  <количество человек>   			
		private void btnQuery1_Click(object sender, EventArgs e) {
			dgwRezult.DataSource = mondialDoc.Elements("country")
				.Select(p => new {
					Country = p.Attribute("name")?.Value,
					Population = Convert.ToInt32(p.Attribute("population")?.Value)
				})
				.OrderBy(p => p.Country)
				.ToList();
		}
		//2. Вывести информацию о городах с населением больше 100000 человек.  
		//Вывод: <название города>  <количество человек>						 
		private void btnQuery2_Click(object sender, EventArgs e) {
			dgwRezult.DataSource = mondialDoc.Descendants("city")
			   .Where(p => Convert.ToInt32(p.Element("population")?.Value) > 100000)     //если значение population отсутствует, элвис-оператор вернет null, а Convert.ToInt32() вернет 0 и строка не попадет в выборку
			   .Select(p => new {
				   City = p.Element("name").Value.Trim(),
				   Population = Convert.ToInt32(p.Element("population").Value)
			   })
			   .OrderBy(p => p.Population)
			   .ToList();
		}
		//3. Вывести информацию о континентах и обобщенную информацию по странам.  
		//Вывод: <название континента>  <количество стран на континенте<суммарное количество проживающих>   <суммарная площадь стран>
		private void btnQuery3_Click(object sender, EventArgs e) {
			dgwRezult.DataSource = mondialDoc.Descendants("country")
				.SelectMany(p => p.Elements("encompassed"),     // некоторые страны расположены одновременно на нескольких континентах (отношение один ко многим) 
				(c, enc) => new {
					Country = c.Attribute("name").Value,
					Country_Area = Convert.ToInt32(c.Attribute("population").Value) * Convert.ToInt32(enc.Attribute("percentage").Value) / 100,	 // площадь страны вычисляем с учетом процента нахождения на данном континенте
					Country_Population = Convert.ToInt32(c.Attribute("population").Value) * Convert.ToInt32(enc.Attribute("percentage").Value) / 100,
					Continent = enc.Attribute("continent").Value,
				})
				.GroupBy(key => key.Continent, (key, g) => new {
					Continent = key,
					Countries = g.Count(),
					Population = g.Sum(p => p.Country_Population),
					Area = g.Sum(p => p.Country_Area)
				})
				.OrderBy(p => p.Continent)
			.ToList();
		}
		//4. Вывести список стран со столицами.	  
		//Вывод: <название страны>  <название столицы>	  
		private void btnQuery4_Click(object sender, EventArgs e) {
			dgwRezult.DataSource = mondialDoc.Descendants("city")
				.Select(p => new {
					CityName = p.Element("name")?.Value.Trim(),
					CityId = p.Attribute("id")?.Value })
				.Join(mondialDoc.Descendants("country"), 
				o => o.CityId, i => i.Attribute("capital")?.Value,	  //критерий объединения "таблиц": id столицы страны соответствует id города
				(o, i) => new {
					Country = i.Attribute("name").Value,
					Capital = o.CityName })
				.Select(p => p)
				.OrderBy(p => p.Country)
				.ToList();
		}
		//5. Вывести название страны, которая граничит с наибольшим количеством стран, и названия этих стран.	 
		//Вывод: <название страны>  <количество граничащих стран> <название стран>.
		private void btnQuery5_Click(object sender, EventArgs e) {
			dgwRezult.DataSource = mondialDoc.Descendants("country")
				.Where(p => p.Elements("border").Count() == mondialDoc.Descendants("country").Max(c => c.Elements("border").Count()))  // оставляем только страну с максимальным числом соседей
				.Select(p => new {
					Country = p.Attribute("name").Value,				// Страна
					BordersCount = p.Elements("border").Count(),		// Количество граничащих стран
					BorderCountriesNames = string.Join(", ",			// Названия граничащих стран (для вывода формируем в виде строки)
					p.Elements("border")
					.Select(b => new { CountryId = b.Attribute("country").Value }) // находим id соседних стран
					.Join(mondialDoc.Descendants("country"),
					o => o.CountryId, i => i.Attribute("id").Value, 			   // находим страны у которых id совпадает с id соседей
					(o, i) => new { CountryName = i.Attribute("name").Value })	   // получаем названия стран-соседей
					.Select(c => c.CountryName))
				})
				.ToList();
		}
	}
}