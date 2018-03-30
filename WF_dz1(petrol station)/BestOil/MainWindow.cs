using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace BestOil {
	public partial class MainWindow : Form {

		private Word.Application wordApp;

		public MainWindow() {
			InitializeComponent();
			rbA92.Checked = true;
		}
		private void rbFuelCount_CheckedChanged(object sender, EventArgs e) {
			tbFuelSumm.Visible = false;
			tbFuelCount.Visible = true;
			grpFuelSum.Text = "К оплате";
			lbFuelSumDim.Text = "руб.";
			if (tbFuelCount.Text != "") {
				tbFuelSum.Text = Math.Round((Decimal.Parse(tbFuelCount.Text) * Decimal.Parse(tbFuelCost.Text)), 2).ToString();
			}
		}
		private void rbFuelSumm_CheckedChanged(object sender, EventArgs e) {
			tbFuelSumm.Visible = true;
			tbFuelCount.Visible = false;
			grpFuelSum.Text = "К выдаче";
			lbFuelSumDim.Text = "л";
			if (tbFuelSumm.Text != "") {
				tbFuelSum.Text = Math.Round((Decimal.Parse(tbFuelSumm.Text) / Decimal.Parse(tbFuelCost.Text)), 2).ToString();
			}
		}
		private void tbFuelSumm_TextChanged(object sender, EventArgs e) {
			if (tbFuelSumm.Text != "") {
				decimal fuelSumm, fuelCost;
				if (Decimal.TryParse(tbFuelSumm.Text, out fuelSumm) && Decimal.TryParse(tbFuelCost.Text, out fuelCost)) {
					tbFuelSum.Text = Math.Round(fuelSumm / fuelCost, 2).ToString();
				} else {
					tbFuelSumm.Text = tbFuelSumm.Text.Substring(0, tbFuelSumm.Text.Length - 1);
					tbFuelSumm.SelectionStart = tbFuelSumm.Text.Length;
				}
			} else {
				tbFuelSum.Text = "0";
			}
		}
		private void tbFuelCount_TextChanged(object sender, EventArgs e) {
			if (tbFuelCount.Text != "") {
				decimal fuelCount, fuelCost;
				if (Decimal.TryParse(tbFuelCount.Text, out fuelCount) && Decimal.TryParse(tbFuelCost.Text, out fuelCost)) {
					tbFuelSum.Text = Math.Round(fuelCount * fuelCost, 2).ToString();
				} else {
					tbFuelCount.Text = tbFuelCount.Text.Substring(0, tbFuelCount.Text.Length - 1);
					tbFuelCount.SelectionStart = tbFuelCount.Text.Length;
				}
			} else {
				tbFuelSum.Text = "0";
			}
		}
		private void chbHotDog_CheckedChanged(object sender, EventArgs e) {
			if (chbHotDog.Checked) {
				numHotDogCount.Enabled = true;
				tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) + Decimal.Parse(tbHotDogCost.Text)).ToString();
			} else {
				numHotDogCount.Enabled = false;
				tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) - Decimal.Parse(tbHotDogCost.Text)).ToString();
			}
		}
		private void chbGamburger_CheckedChanged(object sender, EventArgs e) {
			if (chbGamburger.Checked) {
				numGamburgerCount.Enabled = true;
				tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) + Decimal.Parse(tbGamburgerCost.Text)).ToString();
			} else {
				numGamburgerCount.Enabled = false;
				tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) - Decimal.Parse(tbGamburgerCost.Text)).ToString();
			}
		}
		private void chbCheeseburger_CheckedChanged(object sender, EventArgs e) {
			if (chbCheeseburger.Checked) {
				numCheeseburgerCount.Enabled = true;
				tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) + Decimal.Parse(tbCheeseburgerCost.Text)).ToString();
			} else {
				numCheeseburgerCount.Enabled = false;
				tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) - Decimal.Parse(tbCheeseburgerCost.Text)).ToString();
			}
		}
		private void chbCocaCola_CheckedChanged(object sender, EventArgs e) {
			if (chbCocaCola.Checked) {
				numCocaColaCount.Enabled = true;
				tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) + Decimal.Parse(tbCocaColaCost.Text)).ToString();
			} else {
				numCocaColaCount.Enabled = false;
				tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) - Decimal.Parse(tbCocaColaCost.Text)).ToString();
			}
		}
		private void numHotDogCount_ValueChanged(object sender, EventArgs e) {
			tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) - Decimal.Parse(tbHotDogCost.Text)).ToString();
			tbHotDogCost.Text = (Decimal.Parse(tbHotDogCost.Tag.ToString()) * numHotDogCount.Value).ToString();
			tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) + Decimal.Parse(tbHotDogCost.Text)).ToString();
		}
		private void numGamburgerCount_ValueChanged(object sender, EventArgs e) {
			tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) - Decimal.Parse(tbGamburgerCost.Text)).ToString();
			tbGamburgerCost.Text = (Decimal.Parse(tbGamburgerCost.Tag.ToString()) * numGamburgerCount.Value).ToString();
			tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) + Decimal.Parse(tbGamburgerCost.Text)).ToString();
		}
		private void numCheeseburgerCount_ValueChanged(object sender, EventArgs e) {
			tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) - Decimal.Parse(tbCheeseburgerCost.Text)).ToString();
			tbCheeseburgerCost.Text = (Decimal.Parse(tbCheeseburgerCost.Tag.ToString()) * numCheeseburgerCount.Value).ToString();
			tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) + Decimal.Parse(tbCheeseburgerCost.Text)).ToString();
		}
		private void numCocaColaCount_ValueChanged(object sender, EventArgs e) {
			tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) - Decimal.Parse(tbCocaColaCost.Text)).ToString();
			tbCocaColaCost.Text = (Decimal.Parse(tbCocaColaCost.Tag.ToString()) * numCocaColaCount.Value).ToString();
			tbCafeSum.Text = (Decimal.Parse(tbCafeSum.Text) + Decimal.Parse(tbCocaColaCost.Text)).ToString();
		}
		private void tbFuelSum_TextChanged(object sender, EventArgs e) {
			if (rbFuelCount.Checked) {
				tbTotalSum.Text = (Decimal.Parse(tbFuelSum.Text) + Decimal.Parse(tbCafeSum.Text)).ToString();
			} else {
				if (tbFuelSumm.Text != "") {
					tbTotalSum.Text = (Decimal.Parse(tbFuelSumm.Text) + Decimal.Parse(tbCafeSum.Text)).ToString();
				}
			}
		}
		private void tbCafeSum_TextChanged(object sender, EventArgs e) {
			if (rbFuelCount.Checked) {
				tbTotalSum.Text = (Decimal.Parse(tbFuelSum.Text) + Decimal.Parse(tbCafeSum.Text)).ToString();
			} else {
				tbTotalSum.Text = (Decimal.Parse(tbFuelSumm.Text) + Decimal.Parse(tbCafeSum.Text)).ToString();
			}
		}
		private void rbFuel_CheckedChanged(object sender, EventArgs e) {
			RadioButton rb = (RadioButton)sender;
			tbFuelCost.Text = rb.Tag.ToString();
			if (rbFuelCount.Checked)
				rbFuelCount_CheckedChanged(sender, e);
			else
				rbFuelSumm_CheckedChanged(sender, e);
		}
		private void btnCheck_Click(object sender, EventArgs e) {
			wordApp = new Word.Application();
			wordApp.Visible = true;

			Word.Document doc = wordApp.Documents.Add();
			Word.Paragraph wParagraph = doc.Content.Paragraphs.Add();

			wParagraph.Range.Text = "ООО \"BestOil\"\nДобро пожаловать";
			wParagraph.Range.InsertParagraphAfter();
			wParagraph.Range.InsertDateTime(DateTime.Now.ToString());
			wParagraph.Range.InsertParagraphAfter();
			wParagraph.Range.Text = "Покупки:";
			wParagraph.Range.InsertParagraphAfter();
			Word.Table tbl1 = doc.Content.Tables.Add(wParagraph.Range, 1, 3, Word.WdDefaultTableBehavior.wdWord9TableBehavior);
			tbl1.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPoints;
			tbl1.PreferredWidth = 200;

			if (tbFuelSum.Text != "0") {
				foreach (var item in grpFuel.Controls) {
					RadioButton rb = item as RadioButton;
					if (rb != null && rb.Checked) {
						tbl1.Cell(1, 1).Range.Text = rb.Text;
						break;
					}
				}
				tbl1.Cell(1, 2).Range.Text = (rbFuelCount.Checked ? tbFuelCount.Text : tbFuelSum.Text) + " л";
				tbl1.Cell(1, 3).Range.Text = (rbFuelCount.Checked ? tbFuelSum.Text : tbFuelSumm.Text) + " руб.";
			}
			Word.Row row;
			if (chbHotDog.Checked) {
				row = tbl1.Rows.Add();
				row.Cells[1].Range.Text = chbHotDog.Text;
				row.Cells[2].Range.Text = numHotDogCount.Text + " шт.";
				row.Cells[3].Range.Text = tbHotDogCost.Text + " руб.";
			}
			if (chbGamburger.Checked) {
				row = tbl1.Rows.Add();
				row.Cells[1].Range.Text = chbGamburger.Text;
				row.Cells[2].Range.Text = numGamburgerCount.Text + " шт.";
				row.Cells[3].Range.Text = tbGamburgerCost.Text + " руб.";
			}
			if (chbCheeseburger.Checked) {
				row = tbl1.Rows.Add();
				row.Cells[1].Range.Text = chbCheeseburger.Text;
				row.Cells[2].Range.Text = numCheeseburgerCount.Text + " шт.";
				row.Cells[3].Range.Text = tbCheeseburgerCost.Text + " руб.";
			}
			if (chbCocaCola.Checked) {
				row = tbl1.Rows.Add();
				row.Cells[1].Range.Text = chbCocaCola.Text;
				row.Cells[2].Range.Text = numCocaColaCount.Text + " шт.";
				row.Cells[3].Range.Text = tbCocaColaCost.Text + " руб.";
			}

			tbl1.Borders.Enable = 0;
		}
	}
}
