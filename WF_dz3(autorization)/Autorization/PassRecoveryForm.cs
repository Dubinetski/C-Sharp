using System;
using System.Windows.Forms;

namespace Autorization {
	public partial class PassRecoveryForm : Form {
		ClientInfo client;

		public PassRecoveryForm(ClientInfo client) {
			InitializeComponent();
			this.client = client;
			if (client != null) {
				tbRecoveryLogin.Text = client.Login;
				tbRecoveryLogin.ReadOnly = true;
			}
		}

		private void btnRecovery_OK_Click(object sender, EventArgs e) {
			client = ClientsRepository.Clients.GetClient(tbRecoveryLogin.Text);

			if (client != null) {
				if (client.CheckEmail(tbRecoveryEmail.Text)) {
					if (tbRecoveryPass.Text == tbRecoveryPassRepeat.Text) {
						client.SetPassword(tbRecoveryPass.Text);
						this.DialogResult = DialogResult.OK;
					} else {
						MessageBox.Show("Пароли не совпадают");
					}
				} else {
					MessageBox.Show("Указан неверный E-mail");
					this.DialogResult = DialogResult.Cancel;
				}
			} else {
				MessageBox.Show("Данный логин не найден");
				this.DialogResult = DialogResult.Cancel;
			}
		}
	}
}
