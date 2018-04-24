namespace Autorization {
	partial class AutorizationForm {
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
			this.components = new System.ComponentModel.Container();
			this.grpAutorizInfo = new System.Windows.Forms.GroupBox();
			this.lbAutorizLogin = new System.Windows.Forms.Label();
			this.tbAutorizLogin = new System.Windows.Forms.TextBox();
			this.lbAutorizPass = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.tbAutorizPass = new System.Windows.Forms.TextBox();
			this.tlpAutiriz = new System.Windows.Forms.TableLayoutPanel();
			this.picAutoriz = new System.Windows.Forms.PictureBox();
			this.lnkPassFogot = new System.Windows.Forms.LinkLabel();
			this.lnkReg = new System.Windows.Forms.LinkLabel();
			this.prbAutorizCheck = new System.Windows.Forms.ProgressBar();
			this.tbAutorizStatus = new System.Windows.Forms.TextBox();
			this.lnkAutorizLoadMsg = new System.Windows.Forms.LinkLabel();
			this.timerCheckPassword = new System.Windows.Forms.Timer(this.components);
			this.grpAutorizInfo.SuspendLayout();
			this.tlpAutiriz.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picAutoriz)).BeginInit();
			this.SuspendLayout();
			// 
			// grpAutorizInfo
			// 
			this.grpAutorizInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpAutorizInfo.Controls.Add(this.lbAutorizLogin);
			this.grpAutorizInfo.Controls.Add(this.tbAutorizLogin);
			this.grpAutorizInfo.Controls.Add(this.lbAutorizPass);
			this.grpAutorizInfo.Controls.Add(this.btnLogin);
			this.grpAutorizInfo.Controls.Add(this.tbAutorizPass);
			this.grpAutorizInfo.Location = new System.Drawing.Point(188, 3);
			this.grpAutorizInfo.Name = "grpAutorizInfo";
			this.grpAutorizInfo.Size = new System.Drawing.Size(271, 172);
			this.grpAutorizInfo.TabIndex = 1;
			this.grpAutorizInfo.TabStop = false;
			this.grpAutorizInfo.Text = "Параметры авторизации";
			// 
			// lbAutorizLogin
			// 
			this.lbAutorizLogin.AutoSize = true;
			this.lbAutorizLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbAutorizLogin.Location = new System.Drawing.Point(6, 27);
			this.lbAutorizLogin.Name = "lbAutorizLogin";
			this.lbAutorizLogin.Size = new System.Drawing.Size(150, 16);
			this.lbAutorizLogin.TabIndex = 0;
			this.lbAutorizLogin.Text = "Имя пользователя:";
			this.lbAutorizLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbAutorizLogin
			// 
			this.tbAutorizLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbAutorizLogin.ForeColor = System.Drawing.SystemColors.GrayText;
			this.tbAutorizLogin.Location = new System.Drawing.Point(6, 46);
			this.tbAutorizLogin.Name = "tbAutorizLogin";
			this.tbAutorizLogin.Size = new System.Drawing.Size(254, 26);
			this.tbAutorizLogin.TabIndex = 0;
			this.tbAutorizLogin.Tag = "Имя пользователя";
			this.tbAutorizLogin.Text = "Имя пользователя";
			this.tbAutorizLogin.Enter += new System.EventHandler(this.tb_GotFocus);
			this.tbAutorizLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_GotFocus);
			this.tbAutorizLogin.Leave += new System.EventHandler(this.tb_LostFocus);
			this.tbAutorizLogin.MouseLeave += new System.EventHandler(this.tb_LostFocus);
			// 
			// lbAutorizPass
			// 
			this.lbAutorizPass.AutoSize = true;
			this.lbAutorizPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbAutorizPass.Location = new System.Drawing.Point(6, 88);
			this.lbAutorizPass.Name = "lbAutorizPass";
			this.lbAutorizPass.Size = new System.Drawing.Size(67, 16);
			this.lbAutorizPass.TabIndex = 0;
			this.lbAutorizPass.Text = "Пароль:";
			this.lbAutorizPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnLogin
			// 
			this.btnLogin.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnLogin.ForeColor = System.Drawing.Color.Red;
			this.btnLogin.Location = new System.Drawing.Point(175, 139);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(88, 29);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "Войти";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// tbAutorizPass
			// 
			this.tbAutorizPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbAutorizPass.ForeColor = System.Drawing.SystemColors.GrayText;
			this.tbAutorizPass.Location = new System.Drawing.Point(6, 107);
			this.tbAutorizPass.Name = "tbAutorizPass";
			this.tbAutorizPass.Size = new System.Drawing.Size(254, 26);
			this.tbAutorizPass.TabIndex = 1;
			this.tbAutorizPass.Tag = "Пароль";
			this.tbAutorizPass.Text = "Пароль";
			this.tbAutorizPass.Enter += new System.EventHandler(this.tbPass_GotFocus);
			this.tbAutorizPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPass_GotFocus);
			this.tbAutorizPass.Leave += new System.EventHandler(this.tbPass_LostFocus);
			this.tbAutorizPass.MouseLeave += new System.EventHandler(this.tbPass_LostFocus);
			// 
			// tlpAutiriz
			// 
			this.tlpAutiriz.ColumnCount = 2;
			this.tlpAutiriz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
			this.tlpAutiriz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpAutiriz.Controls.Add(this.picAutoriz, 0, 0);
			this.tlpAutiriz.Controls.Add(this.grpAutorizInfo, 1, 0);
			this.tlpAutiriz.Location = new System.Drawing.Point(9, 8);
			this.tlpAutiriz.Margin = new System.Windows.Forms.Padding(0);
			this.tlpAutiriz.Name = "tlpAutiriz";
			this.tlpAutiriz.RowCount = 1;
			this.tlpAutiriz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpAutiriz.Size = new System.Drawing.Size(462, 178);
			this.tlpAutiriz.TabIndex = 2;
			// 
			// picAutoriz
			// 
			this.picAutoriz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picAutoriz.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picAutoriz.Image = global::Autorization.Properties.Resources._3;
			this.picAutoriz.Location = new System.Drawing.Point(3, 3);
			this.picAutoriz.Name = "picAutoriz";
			this.picAutoriz.Size = new System.Drawing.Size(179, 172);
			this.picAutoriz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picAutoriz.TabIndex = 0;
			this.picAutoriz.TabStop = false;
			// 
			// lnkPassFogot
			// 
			this.lnkPassFogot.AutoSize = true;
			this.lnkPassFogot.Location = new System.Drawing.Point(6, 209);
			this.lnkPassFogot.Name = "lnkPassFogot";
			this.lnkPassFogot.Size = new System.Drawing.Size(91, 13);
			this.lnkPassFogot.TabIndex = 3;
			this.lnkPassFogot.TabStop = true;
			this.lnkPassFogot.Text = "Забыли пароль?";
			this.lnkPassFogot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPassFogot_LinkClicked);
			// 
			// lnkReg
			// 
			this.lnkReg.AutoSize = true;
			this.lnkReg.Location = new System.Drawing.Point(399, 209);
			this.lnkReg.Name = "lnkReg";
			this.lnkReg.Size = new System.Drawing.Size(72, 13);
			this.lnkReg.TabIndex = 4;
			this.lnkReg.TabStop = true;
			this.lnkReg.Text = "Регистрация";
			this.lnkReg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReg_LinkClicked);
			// 
			// prbAutorizCheck
			// 
			this.prbAutorizCheck.Location = new System.Drawing.Point(9, 185);
			this.prbAutorizCheck.Name = "prbAutorizCheck";
			this.prbAutorizCheck.Size = new System.Drawing.Size(462, 21);
			this.prbAutorizCheck.TabIndex = 4;
			this.prbAutorizCheck.Visible = false;
			// 
			// tbAutorizStatus
			// 
			this.tbAutorizStatus.BackColor = System.Drawing.Color.DarkSalmon;
			this.tbAutorizStatus.Enabled = false;
			this.tbAutorizStatus.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbAutorizStatus.Location = new System.Drawing.Point(12, 185);
			this.tbAutorizStatus.Name = "tbAutorizStatus";
			this.tbAutorizStatus.Size = new System.Drawing.Size(456, 22);
			this.tbAutorizStatus.TabIndex = 5;
			this.tbAutorizStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbAutorizStatus.Visible = false;
			// 
			// lnkAutorizLoadMsg
			// 
			this.lnkAutorizLoadMsg.AutoSize = true;
			this.lnkAutorizLoadMsg.BackColor = System.Drawing.Color.Transparent;
			this.lnkAutorizLoadMsg.DisabledLinkColor = System.Drawing.SystemColors.ActiveBorder;
			this.lnkAutorizLoadMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(204)));
			this.lnkAutorizLoadMsg.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.lnkAutorizLoadMsg.Location = new System.Drawing.Point(171, 190);
			this.lnkAutorizLoadMsg.Name = "lnkAutorizLoadMsg";
			this.lnkAutorizLoadMsg.Size = new System.Drawing.Size(132, 12);
			this.lnkAutorizLoadMsg.TabIndex = 6;
			this.lnkAutorizLoadMsg.TabStop = true;
			this.lnkAutorizLoadMsg.Text = "И д е т   п р о в е р к а ...";
			this.lnkAutorizLoadMsg.Visible = false;
			// 
			// timerCheckPassword
			// 
			this.timerCheckPassword.Tick += new System.EventHandler(this.timerCheckPassword_Tick);
			// 
			// AutorizationForm
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(475, 231);
			this.Controls.Add(this.lnkAutorizLoadMsg);
			this.Controls.Add(this.tbAutorizStatus);
			this.Controls.Add(this.prbAutorizCheck);
			this.Controls.Add(this.lnkReg);
			this.Controls.Add(this.lnkPassFogot);
			this.Controls.Add(this.tlpAutiriz);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AutorizationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Авторизация";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutorizationForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.grpAutorizInfo.ResumeLayout(false);
			this.grpAutorizInfo.PerformLayout();
			this.tlpAutiriz.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picAutoriz)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox grpAutorizInfo;
		private System.Windows.Forms.TextBox tbAutorizPass;
		private System.Windows.Forms.TextBox tbAutorizLogin;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Label lbAutorizPass;
		private System.Windows.Forms.Label lbAutorizLogin;
		private System.Windows.Forms.TableLayoutPanel tlpAutiriz;
		private System.Windows.Forms.LinkLabel lnkPassFogot;
		private System.Windows.Forms.LinkLabel lnkReg;
		private System.Windows.Forms.PictureBox picAutoriz;
		private System.Windows.Forms.ProgressBar prbAutorizCheck;
		private System.Windows.Forms.TextBox tbAutorizStatus;
		private System.Windows.Forms.LinkLabel lnkAutorizLoadMsg;
		private System.Windows.Forms.Timer timerCheckPassword;
	}
}

