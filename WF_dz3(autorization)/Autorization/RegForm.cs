using System;
using System.Windows.Forms;

namespace Autorization {
	public partial class RegForm : Form {
		ClientInfo newClient;

		public RegForm() {
			InitializeComponent();
		}

		private void btnRegOK_Click(object sender, EventArgs e) {
			if (tbRegLogin.Text == "" || tbRegPass.Text == "" || tbRegPassRepeat.Text == "" || tbRegEmail.Text == "") {
				MessageBox.Show("Заполните все поля отмеченные *");
				return;
			}
			try {
				if (tbRegPass.Text == tbRegPassRepeat.Text) {
					newClient = new ClientInfo(tbRegLogin.Text, tbRegPass.Text, tbRegEmail.Text, tbRegSurname.Text, tbRegName.Text);
					ClientsRepository.Clients.Add(newClient);
					this.DialogResult = DialogResult.OK;
				} else {
					MessageBox.Show("Пароли не совпадают");
				}
			} catch (LoginDataExeption ex) {
				MessageBox.Show(ex.Message);
			}
		}
	}
}
