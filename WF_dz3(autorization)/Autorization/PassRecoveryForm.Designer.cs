namespace Autorization {
	partial class PassRecoveryForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbRecoveryPassRepeat = new System.Windows.Forms.TextBox();
			this.tbRecoveryPass = new System.Windows.Forms.TextBox();
			this.tbRecoveryLogin = new System.Windows.Forms.TextBox();
			this.tbRecoveryEmail = new System.Windows.Forms.TextBox();
			this.lbRecoveryPassAgain = new System.Windows.Forms.Label();
			this.lbRecoveryPass = new System.Windows.Forms.Label();
			this.lbRecoveryLogin = new System.Windows.Forms.Label();
			this.lbRecoveryEmail = new System.Windows.Forms.Label();
			this.btnRecovery_OK = new System.Windows.Forms.Button();
			this.btnRecovery_Cancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbRecoveryPassRepeat);
			this.groupBox1.Controls.Add(this.tbRecoveryPass);
			this.groupBox1.Controls.Add(this.tbRecoveryLogin);
			this.groupBox1.Controls.Add(this.tbRecoveryEmail);
			this.groupBox1.Controls.Add(this.lbRecoveryPassAgain);
			this.groupBox1.Controls.Add(this.lbRecoveryPass);
			this.groupBox1.Controls.Add(this.lbRecoveryLogin);
			this.groupBox1.Controls.Add(this.lbRecoveryEmail);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(294, 183);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// tbRecoveryPassRepeat
			// 
			this.tbRecoveryPassRepeat.Location = new System.Drawing.Point(9, 149);
			this.tbRecoveryPassRepeat.Name = "tbRecoveryPassRepeat";
			this.tbRecoveryPassRepeat.PasswordChar = '*';
			this.tbRecoveryPassRepeat.Size = new System.Drawing.Size(270, 20);
			this.tbRecoveryPassRepeat.TabIndex = 3;
			// 
			// tbRecoveryPass
			// 
			this.tbRecoveryPass.Location = new System.Drawing.Point(9, 110);
			this.tbRecoveryPass.Name = "tbRecoveryPass";
			this.tbRecoveryPass.PasswordChar = '*';
			this.tbRecoveryPass.Size = new System.Drawing.Size(270, 20);
			this.tbRecoveryPass.TabIndex = 2;
			// 
			// tbRecoveryLogin
			// 
			this.tbRecoveryLogin.Location = new System.Drawing.Point(9, 32);
			this.tbRecoveryLogin.Name = "tbRecoveryLogin";
			this.tbRecoveryLogin.Size = new System.Drawing.Size(270, 20);
			this.tbRecoveryLogin.TabIndex = 0;
			// 
			// tbRecoveryEmail
			// 
			this.tbRecoveryEmail.Location = new System.Drawing.Point(9, 71);
			this.tbRecoveryEmail.Name = "tbRecoveryEmail";
			this.tbRecoveryEmail.Size = new System.Drawing.Size(270, 20);
			this.tbRecoveryEmail.TabIndex = 1;
			// 
			// lbRecoveryPassAgain
			// 
			this.lbRecoveryPassAgain.AutoSize = true;
			this.lbRecoveryPassAgain.Location = new System.Drawing.Point(6, 133);
			this.lbRecoveryPassAgain.Name = "lbRecoveryPassAgain";
			this.lbRecoveryPassAgain.Size = new System.Drawing.Size(145, 13);
			this.lbRecoveryPassAgain.TabIndex = 2;
			this.lbRecoveryPassAgain.Text = "Повторите пароль еще раз";
			// 
			// lbRecoveryPass
			// 
			this.lbRecoveryPass.AutoSize = true;
			this.lbRecoveryPass.Location = new System.Drawing.Point(6, 94);
			this.lbRecoveryPass.Name = "lbRecoveryPass";
			this.lbRecoveryPass.Size = new System.Drawing.Size(80, 13);
			this.lbRecoveryPass.TabIndex = 1;
			this.lbRecoveryPass.Text = "Новый пароль";
			// 
			// lbRecoveryLogin
			// 
			this.lbRecoveryLogin.AutoSize = true;
			this.lbRecoveryLogin.Location = new System.Drawing.Point(6, 16);
			this.lbRecoveryLogin.Name = "lbRecoveryLogin";
			this.lbRecoveryLogin.Size = new System.Drawing.Size(38, 13);
			this.lbRecoveryLogin.TabIndex = 0;
			this.lbRecoveryLogin.Text = "Логин";
			// 
			// lbRecoveryEmail
			// 
			this.lbRecoveryEmail.AutoSize = true;
			this.lbRecoveryEmail.Location = new System.Drawing.Point(6, 55);
			this.lbRecoveryEmail.Name = "lbRecoveryEmail";
			this.lbRecoveryEmail.Size = new System.Drawing.Size(35, 13);
			this.lbRecoveryEmail.TabIndex = 0;
			this.lbRecoveryEmail.Text = "E-mail";
			// 
			// btnRecovery_OK
			// 
			this.btnRecovery_OK.Location = new System.Drawing.Point(38, 201);
			this.btnRecovery_OK.Name = "btnRecovery_OK";
			this.btnRecovery_OK.Size = new System.Drawing.Size(75, 23);
			this.btnRecovery_OK.TabIndex = 4;
			this.btnRecovery_OK.Text = "ОК";
			this.btnRecovery_OK.UseVisualStyleBackColor = true;
			this.btnRecovery_OK.Click += new System.EventHandler(this.btnRecovery_OK_Click);
			// 
			// btnRecovery_Cancel
			// 
			this.btnRecovery_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnRecovery_Cancel.Location = new System.Drawing.Point(191, 201);
			this.btnRecovery_Cancel.Name = "btnRecovery_Cancel";
			this.btnRecovery_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btnRecovery_Cancel.TabIndex = 5;
			this.btnRecovery_Cancel.Text = "Отмена";
			this.btnRecovery_Cancel.UseVisualStyleBackColor = true;
			// 
			// PassRecoveryForm
			// 
			this.AcceptButton = this.btnRecovery_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.CancelButton = this.btnRecovery_Cancel;
			this.ClientSize = new System.Drawing.Size(316, 235);
			this.Controls.Add(this.btnRecovery_Cancel);
			this.Controls.Add(this.btnRecovery_OK);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PassRecoveryForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Восстановление пароля";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbRecoveryPassRepeat;
		private System.Windows.Forms.TextBox tbRecoveryPass;
		private System.Windows.Forms.TextBox tbRecoveryEmail;
		private System.Windows.Forms.Label lbRecoveryPassAgain;
		private System.Windows.Forms.Label lbRecoveryPass;
		private System.Windows.Forms.Label lbRecoveryEmail;
		private System.Windows.Forms.Button btnRecovery_OK;
		private System.Windows.Forms.Button btnRecovery_Cancel;
		private System.Windows.Forms.TextBox tbRecoveryLogin;
		private System.Windows.Forms.Label lbRecoveryLogin;
	}
}