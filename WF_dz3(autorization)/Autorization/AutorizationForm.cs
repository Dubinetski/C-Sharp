/*
Разработать приложение «Авторизация».
При запуске программы открывается окно «Авторизация…».
Пользователь вводит логин и пароль, которые сверяются со значениями, хранящимися файле. 
Если пользователь забыл пароль, то он переходит по ссылке в окно «Восстановление пароля». После успешного восстановления пароля пользователь может войти в систему. 
Если пользователь не зарегистрирован в системе, то переходит по ссылке в окно «Регистрация пользователя».
После успешной регистрации пользователь может войти в систему.
Если пользователь ввел правильные (имеющиеся) логин и пароль, то ему разрешается доступ к приложению, иначе выдается соответствующее сообщение.

Сохранять пользователей в файл с использованием бинарной сериализации. 
Реализовать шифрование пароля и  email  пользователя с  использованием хеш-кода строки (по алгоритму MD5).
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Autorization {
	public partial class AutorizationForm : Form {
		ClientInfo client = null;

		public AutorizationForm() {
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			ClientsRepository.Load();
		}

		private void lnkPassFogot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			this.Visible = false;
			tbAutorizPass.Text = "";
			PassRecoveryForm recoveryForm = new PassRecoveryForm(ClientsRepository.Clients.GetClient(tbAutorizLogin.Text));
			recoveryForm.ShowDialog();
			this.Visible = true;
		}

		private void lnkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			this.Visible = false;
			tbAutorizPass.Text = "";
			RegForm regForm = new RegForm();
			regForm.ShowDialog();
			this.Visible = true;
		}
		private void AutorizationForm_FormClosing(object sender, FormClosingEventArgs e) {
			ClientsRepository.Save();
		}

		private void btnLogin_Click(object sender, EventArgs e) {
			prbAutorizCheck.Value = 0;
			tbAutorizStatus.Visible = false;
			lnkAutorizLoadMsg.Visible = true;
			prbAutorizCheck.Visible = true;
			timerCheckPassword.Enabled = true;
			client = ClientsRepository.Clients.GetClient(tbAutorizLogin.Text);
		}

		private void timerCheckPassword_Tick(object sender, EventArgs e) {
			prbAutorizCheck.PerformStep();
			if (prbAutorizCheck.Value == prbAutorizCheck.Maximum) {
				timerCheckPassword.Enabled = false;
				prbAutorizCheck.Visible = false;
				lnkAutorizLoadMsg.Visible = false;

				if (tbAutorizLogin.Text != "" && tbAutorizPass.Text != "") {
					if (client != null) {
						if (client.CheckPassword(tbAutorizPass.Text)) {
							this.Visible = false;
							tbAutorizPass.Text = "";
							MainUserForm userForm = new MainUserForm(client);
							userForm.ShowDialog();
							this.Visible = true;
							return;
						} else {
							tbAutorizStatus.Text = "Пароль указан неверно";
						}
					} else {
						tbAutorizStatus.Text = "Логин указан неверно";
					}
				} else {
					tbAutorizStatus.Text = "Для входа укажите логин и пароль";
				}
				tbAutorizStatus.Visible = true;
			}
		}

		private void tb_GotFocus(object sender, EventArgs e) {
			TextBox tb = sender as TextBox;
			if ((tb != null) && (tb.Text == tb.Tag.ToString()) && (tb.ForeColor == SystemColors.GrayText)) {
				tb.Text = "";
				tb.ForeColor = Color.Black;
			}
		}
		private void tb_LostFocus(object sender, EventArgs e) {
			TextBox tb = sender as TextBox;
			if ((tb != null) && tb.Text.Length == 0) {
				tb.Text = tb.Tag.ToString();
				tb.ForeColor = SystemColors.GrayText;
			}
		}
		private void tbPass_GotFocus(object sender, EventArgs e) {
			TextBox tb = sender as TextBox;
			if ((tb != null) && (tb.Text == tb.Tag.ToString()) && (tb.ForeColor == SystemColors.GrayText)) {
				tb.PasswordChar = '*';
				tb.Text = "";
				tb.ForeColor = Color.Black;
			}
		}
		private void tbPass_LostFocus(object sender, EventArgs e) {
			TextBox tb = sender as TextBox;
			if ((tb != null) && tb.Text.Length == 0) {
				tb.PasswordChar = '\0';
				tb.Text = tb.Tag.ToString();
				tb.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
