using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autorization {
	public partial class MainUserForm : Form {
		ClientInfo client;
		public MainUserForm(ClientInfo client) {
			InitializeComponent();

			this.client = client;
			lbUserName.Text = client.Surname + " " + client.Name;
		}
	}
}
