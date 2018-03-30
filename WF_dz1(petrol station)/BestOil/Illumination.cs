using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil {
	public partial class Illumination : Form {
		public Illumination() {
			InitializeComponent();
		}

		private void timer1_Tick(object sender, EventArgs e) {
			ActiveForm.Opacity += 0.1;
			if (ActiveForm.Opacity == 1) {
				ActiveForm.Close();
			}
		}
	}
}
