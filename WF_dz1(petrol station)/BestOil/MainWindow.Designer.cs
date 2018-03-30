namespace BestOil {
	partial class MainWindow {
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
			this.grpFuel = new System.Windows.Forms.GroupBox();
			this.rbDT = new System.Windows.Forms.RadioButton();
			this.tbFuelCost = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbFuelCost = new System.Windows.Forms.Label();
			this.rbA80 = new System.Windows.Forms.RadioButton();
			this.grpFuelSum = new System.Windows.Forms.GroupBox();
			this.lbFuelSumDim = new System.Windows.Forms.Label();
			this.tbFuelSum = new System.Windows.Forms.TextBox();
			this.grpFuelChoise = new System.Windows.Forms.GroupBox();
			this.lbFuelSummDim = new System.Windows.Forms.Label();
			this.lbFuelCountDim = new System.Windows.Forms.Label();
			this.tbFuelCount = new System.Windows.Forms.TextBox();
			this.tbFuelSumm = new System.Windows.Forms.TextBox();
			this.rbFuelSumm = new System.Windows.Forms.RadioButton();
			this.rbFuelCount = new System.Windows.Forms.RadioButton();
			this.rbA92 = new System.Windows.Forms.RadioButton();
			this.rbA95 = new System.Windows.Forms.RadioButton();
			this.grpCafe = new System.Windows.Forms.GroupBox();
			this.numCocaColaCount = new System.Windows.Forms.NumericUpDown();
			this.numCheeseburgerCount = new System.Windows.Forms.NumericUpDown();
			this.numGamburgerCount = new System.Windows.Forms.NumericUpDown();
			this.numHotDogCount = new System.Windows.Forms.NumericUpDown();
			this.lbCafeCount = new System.Windows.Forms.Label();
			this.lbCafeCost = new System.Windows.Forms.Label();
			this.tbCocaColaCost = new System.Windows.Forms.TextBox();
			this.tbCheeseburgerCost = new System.Windows.Forms.TextBox();
			this.tbGamburgerCost = new System.Windows.Forms.TextBox();
			this.tbHotDogCost = new System.Windows.Forms.TextBox();
			this.chbCocaCola = new System.Windows.Forms.CheckBox();
			this.chbCheeseburger = new System.Windows.Forms.CheckBox();
			this.chbGamburger = new System.Windows.Forms.CheckBox();
			this.chbHotDog = new System.Windows.Forms.CheckBox();
			this.grpCafeSum = new System.Windows.Forms.GroupBox();
			this.lbCafeSumDim = new System.Windows.Forms.Label();
			this.tbCafeSum = new System.Windows.Forms.TextBox();
			this.btnCheck = new System.Windows.Forms.Button();
			this.tbTotalSum = new System.Windows.Forms.TextBox();
			this.lbTotalSum = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.grpFuel.SuspendLayout();
			this.grpFuelSum.SuspendLayout();
			this.grpFuelChoise.SuspendLayout();
			this.grpCafe.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCocaColaCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCheeseburgerCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numGamburgerCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHotDogCount)).BeginInit();
			this.grpCafeSum.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpFuel
			// 
			this.grpFuel.Controls.Add(this.rbDT);
			this.grpFuel.Controls.Add(this.tbFuelCost);
			this.grpFuel.Controls.Add(this.label1);
			this.grpFuel.Controls.Add(this.lbFuelCost);
			this.grpFuel.Controls.Add(this.rbA80);
			this.grpFuel.Controls.Add(this.grpFuelSum);
			this.grpFuel.Controls.Add(this.grpFuelChoise);
			this.grpFuel.Controls.Add(this.rbA92);
			this.grpFuel.Controls.Add(this.rbA95);
			this.grpFuel.Location = new System.Drawing.Point(3, 3);
			this.grpFuel.Name = "grpFuel";
			this.grpFuel.Size = new System.Drawing.Size(207, 243);
			this.grpFuel.TabIndex = 0;
			this.grpFuel.TabStop = false;
			this.grpFuel.Text = "Топливо";
			// 
			// rbDT
			// 
			this.rbDT.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbDT.Location = new System.Drawing.Point(158, 16);
			this.rbDT.Name = "rbDT";
			this.rbDT.Size = new System.Drawing.Size(39, 31);
			this.rbDT.TabIndex = 5;
			this.rbDT.TabStop = true;
			this.rbDT.Tag = "1,34";
			this.rbDT.Text = "ДТ";
			this.rbDT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbDT.UseVisualStyleBackColor = true;
			this.rbDT.CheckedChanged += new System.EventHandler(this.rbFuel_CheckedChanged);
			// 
			// tbFuelCost
			// 
			this.tbFuelCost.ForeColor = System.Drawing.SystemColors.WindowText;
			this.tbFuelCost.Location = new System.Drawing.Point(75, 56);
			this.tbFuelCost.Name = "tbFuelCost";
			this.tbFuelCost.ReadOnly = true;
			this.tbFuelCost.Size = new System.Drawing.Size(44, 20);
			this.tbFuelCost.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(125, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "руб.";
			// 
			// lbFuelCost
			// 
			this.lbFuelCost.AutoSize = true;
			this.lbFuelCost.ForeColor = System.Drawing.Color.Red;
			this.lbFuelCost.Location = new System.Drawing.Point(36, 59);
			this.lbFuelCost.Name = "lbFuelCost";
			this.lbFuelCost.Size = new System.Drawing.Size(33, 13);
			this.lbFuelCost.TabIndex = 1;
			this.lbFuelCost.Text = "Цена";
			// 
			// rbA80
			// 
			this.rbA80.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbA80.Location = new System.Drawing.Point(113, 16);
			this.rbA80.Name = "rbA80";
			this.rbA80.Size = new System.Drawing.Size(39, 31);
			this.rbA80.TabIndex = 5;
			this.rbA80.TabStop = true;
			this.rbA80.Tag = "1,1";
			this.rbA80.Text = "А-80";
			this.rbA80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbA80.UseVisualStyleBackColor = true;
			this.rbA80.CheckedChanged += new System.EventHandler(this.rbFuel_CheckedChanged);
			// 
			// grpFuelSum
			// 
			this.grpFuelSum.Controls.Add(this.lbFuelSumDim);
			this.grpFuelSum.Controls.Add(this.tbFuelSum);
			this.grpFuelSum.Location = new System.Drawing.Point(6, 161);
			this.grpFuelSum.Name = "grpFuelSum";
			this.grpFuelSum.Size = new System.Drawing.Size(194, 70);
			this.grpFuelSum.TabIndex = 0;
			this.grpFuelSum.TabStop = false;
			this.grpFuelSum.Text = "К оплате";
			// 
			// lbFuelSumDim
			// 
			this.lbFuelSumDim.AutoSize = true;
			this.lbFuelSumDim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbFuelSumDim.Location = new System.Drawing.Point(143, 27);
			this.lbFuelSumDim.Name = "lbFuelSumDim";
			this.lbFuelSumDim.Size = new System.Drawing.Size(46, 24);
			this.lbFuelSumDim.TabIndex = 4;
			this.lbFuelSumDim.Text = "руб.";
			// 
			// tbFuelSum
			// 
			this.tbFuelSum.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbFuelSum.Location = new System.Drawing.Point(6, 19);
			this.tbFuelSum.Name = "tbFuelSum";
			this.tbFuelSum.ReadOnly = true;
			this.tbFuelSum.Size = new System.Drawing.Size(133, 39);
			this.tbFuelSum.TabIndex = 0;
			this.tbFuelSum.TabStop = false;
			this.tbFuelSum.Text = "0";
			this.tbFuelSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbFuelSum.TextChanged += new System.EventHandler(this.tbFuelSum_TextChanged);
			// 
			// grpFuelChoise
			// 
			this.grpFuelChoise.Controls.Add(this.lbFuelSummDim);
			this.grpFuelChoise.Controls.Add(this.lbFuelCountDim);
			this.grpFuelChoise.Controls.Add(this.tbFuelCount);
			this.grpFuelChoise.Controls.Add(this.tbFuelSumm);
			this.grpFuelChoise.Controls.Add(this.rbFuelSumm);
			this.grpFuelChoise.Controls.Add(this.rbFuelCount);
			this.grpFuelChoise.Location = new System.Drawing.Point(6, 82);
			this.grpFuelChoise.Name = "grpFuelChoise";
			this.grpFuelChoise.Size = new System.Drawing.Size(194, 73);
			this.grpFuelChoise.TabIndex = 0;
			this.grpFuelChoise.TabStop = false;
			// 
			// lbFuelSummDim
			// 
			this.lbFuelSummDim.AutoSize = true;
			this.lbFuelSummDim.Location = new System.Drawing.Point(164, 49);
			this.lbFuelSummDim.Name = "lbFuelSummDim";
			this.lbFuelSummDim.Size = new System.Drawing.Size(27, 13);
			this.lbFuelSummDim.TabIndex = 4;
			this.lbFuelSummDim.Text = "руб.";
			// 
			// lbFuelCountDim
			// 
			this.lbFuelCountDim.AutoSize = true;
			this.lbFuelCountDim.Location = new System.Drawing.Point(165, 21);
			this.lbFuelCountDim.Name = "lbFuelCountDim";
			this.lbFuelCountDim.Size = new System.Drawing.Size(16, 13);
			this.lbFuelCountDim.TabIndex = 4;
			this.lbFuelCountDim.Text = "л.";
			// 
			// tbFuelCount
			// 
			this.tbFuelCount.Location = new System.Drawing.Point(96, 15);
			this.tbFuelCount.Name = "tbFuelCount";
			this.tbFuelCount.Size = new System.Drawing.Size(58, 20);
			this.tbFuelCount.TabIndex = 0;
			this.tbFuelCount.Text = "0";
			this.tbFuelCount.TextChanged += new System.EventHandler(this.tbFuelCount_TextChanged);
			// 
			// tbFuelSumm
			// 
			this.tbFuelSumm.Location = new System.Drawing.Point(96, 42);
			this.tbFuelSumm.Name = "tbFuelSumm";
			this.tbFuelSumm.Size = new System.Drawing.Size(58, 20);
			this.tbFuelSumm.TabIndex = 3;
			this.tbFuelSumm.Text = "0";
			this.tbFuelSumm.Visible = false;
			this.tbFuelSumm.TextChanged += new System.EventHandler(this.tbFuelSumm_TextChanged);
			// 
			// rbFuelSumm
			// 
			this.rbFuelSumm.AutoSize = true;
			this.rbFuelSumm.Location = new System.Drawing.Point(6, 39);
			this.rbFuelSumm.Name = "rbFuelSumm";
			this.rbFuelSumm.Size = new System.Drawing.Size(59, 17);
			this.rbFuelSumm.TabIndex = 0;
			this.rbFuelSumm.Text = "Сумма";
			this.rbFuelSumm.UseVisualStyleBackColor = true;
			this.rbFuelSumm.CheckedChanged += new System.EventHandler(this.rbFuelSumm_CheckedChanged);
			// 
			// rbFuelCount
			// 
			this.rbFuelCount.AutoSize = true;
			this.rbFuelCount.Checked = true;
			this.rbFuelCount.Location = new System.Drawing.Point(6, 16);
			this.rbFuelCount.Name = "rbFuelCount";
			this.rbFuelCount.Size = new System.Drawing.Size(84, 17);
			this.rbFuelCount.TabIndex = 0;
			this.rbFuelCount.TabStop = true;
			this.rbFuelCount.Text = "Количество";
			this.rbFuelCount.UseVisualStyleBackColor = true;
			this.rbFuelCount.CheckedChanged += new System.EventHandler(this.rbFuelCount_CheckedChanged);
			// 
			// rbA92
			// 
			this.rbA92.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbA92.Location = new System.Drawing.Point(68, 16);
			this.rbA92.Name = "rbA92";
			this.rbA92.Size = new System.Drawing.Size(39, 32);
			this.rbA92.TabIndex = 5;
			this.rbA92.TabStop = true;
			this.rbA92.Tag = "1,23";
			this.rbA92.Text = "А-92";
			this.rbA92.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbA92.UseVisualStyleBackColor = true;
			this.rbA92.CheckedChanged += new System.EventHandler(this.rbFuel_CheckedChanged);
			// 
			// rbA95
			// 
			this.rbA95.Appearance = System.Windows.Forms.Appearance.Button;
			this.rbA95.Location = new System.Drawing.Point(23, 16);
			this.rbA95.Name = "rbA95";
			this.rbA95.Size = new System.Drawing.Size(39, 32);
			this.rbA95.TabIndex = 5;
			this.rbA95.Tag = "1,31";
			this.rbA95.Text = "А-95";
			this.rbA95.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.rbA95.UseVisualStyleBackColor = true;
			this.rbA95.CheckedChanged += new System.EventHandler(this.rbFuel_CheckedChanged);
			// 
			// grpCafe
			// 
			this.grpCafe.Controls.Add(this.numCocaColaCount);
			this.grpCafe.Controls.Add(this.numCheeseburgerCount);
			this.grpCafe.Controls.Add(this.numGamburgerCount);
			this.grpCafe.Controls.Add(this.numHotDogCount);
			this.grpCafe.Controls.Add(this.lbCafeCount);
			this.grpCafe.Controls.Add(this.lbCafeCost);
			this.grpCafe.Controls.Add(this.tbCocaColaCost);
			this.grpCafe.Controls.Add(this.tbCheeseburgerCost);
			this.grpCafe.Controls.Add(this.tbGamburgerCost);
			this.grpCafe.Controls.Add(this.tbHotDogCost);
			this.grpCafe.Controls.Add(this.chbCocaCola);
			this.grpCafe.Controls.Add(this.chbCheeseburger);
			this.grpCafe.Controls.Add(this.chbGamburger);
			this.grpCafe.Controls.Add(this.chbHotDog);
			this.grpCafe.Controls.Add(this.grpCafeSum);
			this.grpCafe.Location = new System.Drawing.Point(216, 3);
			this.grpCafe.Name = "grpCafe";
			this.grpCafe.Size = new System.Drawing.Size(204, 243);
			this.grpCafe.TabIndex = 0;
			this.grpCafe.TabStop = false;
			this.grpCafe.Text = "Мини-кафе";
			// 
			// numCocaColaCount
			// 
			this.numCocaColaCount.Enabled = false;
			this.numCocaColaCount.Location = new System.Drawing.Point(138, 112);
			this.numCocaColaCount.Name = "numCocaColaCount";
			this.numCocaColaCount.Size = new System.Drawing.Size(37, 20);
			this.numCocaColaCount.TabIndex = 5;
			this.numCocaColaCount.ValueChanged += new System.EventHandler(this.numCocaColaCount_ValueChanged);
			// 
			// numCheeseburgerCount
			// 
			this.numCheeseburgerCount.Enabled = false;
			this.numCheeseburgerCount.Location = new System.Drawing.Point(138, 85);
			this.numCheeseburgerCount.Name = "numCheeseburgerCount";
			this.numCheeseburgerCount.Size = new System.Drawing.Size(38, 20);
			this.numCheeseburgerCount.TabIndex = 5;
			this.numCheeseburgerCount.ValueChanged += new System.EventHandler(this.numCheeseburgerCount_ValueChanged);
			// 
			// numGamburgerCount
			// 
			this.numGamburgerCount.Enabled = false;
			this.numGamburgerCount.Location = new System.Drawing.Point(138, 56);
			this.numGamburgerCount.Name = "numGamburgerCount";
			this.numGamburgerCount.Size = new System.Drawing.Size(37, 20);
			this.numGamburgerCount.TabIndex = 5;
			this.numGamburgerCount.ValueChanged += new System.EventHandler(this.numGamburgerCount_ValueChanged);
			// 
			// numHotDogCount
			// 
			this.numHotDogCount.Enabled = false;
			this.numHotDogCount.Location = new System.Drawing.Point(138, 31);
			this.numHotDogCount.Name = "numHotDogCount";
			this.numHotDogCount.Size = new System.Drawing.Size(37, 20);
			this.numHotDogCount.TabIndex = 5;
			this.numHotDogCount.ValueChanged += new System.EventHandler(this.numHotDogCount_ValueChanged);
			// 
			// lbCafeCount
			// 
			this.lbCafeCount.AutoSize = true;
			this.lbCafeCount.ForeColor = System.Drawing.Color.Blue;
			this.lbCafeCount.Location = new System.Drawing.Point(130, 12);
			this.lbCafeCount.Name = "lbCafeCount";
			this.lbCafeCount.Size = new System.Drawing.Size(66, 13);
			this.lbCafeCount.TabIndex = 4;
			this.lbCafeCount.Text = "Количество";
			// 
			// lbCafeCost
			// 
			this.lbCafeCost.AutoSize = true;
			this.lbCafeCost.ForeColor = System.Drawing.Color.Red;
			this.lbCafeCost.Location = new System.Drawing.Point(72, 12);
			this.lbCafeCost.Name = "lbCafeCost";
			this.lbCafeCost.Size = new System.Drawing.Size(62, 13);
			this.lbCafeCost.TabIndex = 4;
			this.lbCafeCost.Text = "Цена (руб.)";
			// 
			// tbCocaColaCost
			// 
			this.tbCocaColaCost.Location = new System.Drawing.Point(78, 112);
			this.tbCocaColaCost.Name = "tbCocaColaCost";
			this.tbCocaColaCost.ReadOnly = true;
			this.tbCocaColaCost.Size = new System.Drawing.Size(53, 20);
			this.tbCocaColaCost.TabIndex = 3;
			this.tbCocaColaCost.Tag = "2,01";
			this.tbCocaColaCost.Text = "0";
			// 
			// tbCheeseburgerCost
			// 
			this.tbCheeseburgerCost.Location = new System.Drawing.Point(78, 85);
			this.tbCheeseburgerCost.Name = "tbCheeseburgerCost";
			this.tbCheeseburgerCost.ReadOnly = true;
			this.tbCheeseburgerCost.Size = new System.Drawing.Size(54, 20);
			this.tbCheeseburgerCost.TabIndex = 3;
			this.tbCheeseburgerCost.Tag = "2,05";
			this.tbCheeseburgerCost.Text = "0";
			// 
			// tbGamburgerCost
			// 
			this.tbGamburgerCost.Location = new System.Drawing.Point(77, 59);
			this.tbGamburgerCost.Name = "tbGamburgerCost";
			this.tbGamburgerCost.ReadOnly = true;
			this.tbGamburgerCost.Size = new System.Drawing.Size(54, 20);
			this.tbGamburgerCost.TabIndex = 3;
			this.tbGamburgerCost.Tag = "1,75";
			this.tbGamburgerCost.Text = "0";
			// 
			// tbHotDogCost
			// 
			this.tbHotDogCost.Location = new System.Drawing.Point(78, 31);
			this.tbHotDogCost.Name = "tbHotDogCost";
			this.tbHotDogCost.ReadOnly = true;
			this.tbHotDogCost.Size = new System.Drawing.Size(53, 20);
			this.tbHotDogCost.TabIndex = 3;
			this.tbHotDogCost.Tag = "1,5";
			this.tbHotDogCost.Text = "0";
			// 
			// chbCocaCola
			// 
			this.chbCocaCola.Appearance = System.Windows.Forms.Appearance.Button;
			this.chbCocaCola.Location = new System.Drawing.Point(4, 109);
			this.chbCocaCola.Name = "chbCocaCola";
			this.chbCocaCola.Size = new System.Drawing.Size(70, 25);
			this.chbCocaCola.TabIndex = 1;
			this.chbCocaCola.Text = "Кока-кола";
			this.chbCocaCola.UseVisualStyleBackColor = true;
			this.chbCocaCola.CheckedChanged += new System.EventHandler(this.chbCocaCola_CheckedChanged);
			// 
			// chbCheeseburger
			// 
			this.chbCheeseburger.Appearance = System.Windows.Forms.Appearance.Button;
			this.chbCheeseburger.Location = new System.Drawing.Point(4, 82);
			this.chbCheeseburger.Margin = new System.Windows.Forms.Padding(0);
			this.chbCheeseburger.Name = "chbCheeseburger";
			this.chbCheeseburger.Size = new System.Drawing.Size(70, 25);
			this.chbCheeseburger.TabIndex = 1;
			this.chbCheeseburger.Text = "Чизбургер";
			this.chbCheeseburger.UseVisualStyleBackColor = true;
			this.chbCheeseburger.CheckedChanged += new System.EventHandler(this.chbCheeseburger_CheckedChanged);
			// 
			// chbGamburger
			// 
			this.chbGamburger.Appearance = System.Windows.Forms.Appearance.Button;
			this.chbGamburger.Location = new System.Drawing.Point(4, 56);
			this.chbGamburger.Margin = new System.Windows.Forms.Padding(0);
			this.chbGamburger.Name = "chbGamburger";
			this.chbGamburger.Size = new System.Drawing.Size(70, 25);
			this.chbGamburger.TabIndex = 1;
			this.chbGamburger.Text = "Гамбургер";
			this.chbGamburger.UseVisualStyleBackColor = true;
			this.chbGamburger.CheckedChanged += new System.EventHandler(this.chbGamburger_CheckedChanged);
			// 
			// chbHotDog
			// 
			this.chbHotDog.Appearance = System.Windows.Forms.Appearance.Button;
			this.chbHotDog.Location = new System.Drawing.Point(4, 28);
			this.chbHotDog.Name = "chbHotDog";
			this.chbHotDog.Size = new System.Drawing.Size(70, 25);
			this.chbHotDog.TabIndex = 1;
			this.chbHotDog.Text = "Хот-дог";
			this.chbHotDog.UseVisualStyleBackColor = true;
			this.chbHotDog.CheckedChanged += new System.EventHandler(this.chbHotDog_CheckedChanged);
			// 
			// grpCafeSum
			// 
			this.grpCafeSum.Controls.Add(this.lbCafeSumDim);
			this.grpCafeSum.Controls.Add(this.tbCafeSum);
			this.grpCafeSum.Location = new System.Drawing.Point(6, 161);
			this.grpCafeSum.Name = "grpCafeSum";
			this.grpCafeSum.Size = new System.Drawing.Size(190, 70);
			this.grpCafeSum.TabIndex = 0;
			this.grpCafeSum.TabStop = false;
			this.grpCafeSum.Text = "К оплате";
			// 
			// lbCafeSumDim
			// 
			this.lbCafeSumDim.AutoSize = true;
			this.lbCafeSumDim.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbCafeSumDim.Location = new System.Drawing.Point(134, 27);
			this.lbCafeSumDim.Name = "lbCafeSumDim";
			this.lbCafeSumDim.Size = new System.Drawing.Size(46, 24);
			this.lbCafeSumDim.TabIndex = 4;
			this.lbCafeSumDim.Text = "руб.";
			// 
			// tbCafeSum
			// 
			this.tbCafeSum.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbCafeSum.Location = new System.Drawing.Point(6, 19);
			this.tbCafeSum.Name = "tbCafeSum";
			this.tbCafeSum.ReadOnly = true;
			this.tbCafeSum.Size = new System.Drawing.Size(122, 39);
			this.tbCafeSum.TabIndex = 0;
			this.tbCafeSum.TabStop = false;
			this.tbCafeSum.Text = "0";
			this.tbCafeSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbCafeSum.TextChanged += new System.EventHandler(this.tbCafeSum_TextChanged);
			// 
			// btnCheck
			// 
			this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnCheck.ForeColor = System.Drawing.Color.Red;
			this.btnCheck.Location = new System.Drawing.Point(317, 252);
			this.btnCheck.Name = "btnCheck";
			this.btnCheck.Size = new System.Drawing.Size(103, 66);
			this.btnCheck.TabIndex = 1;
			this.btnCheck.Text = "Чек";
			this.btnCheck.UseVisualStyleBackColor = true;
			this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
			// 
			// tbTotalSum
			// 
			this.tbTotalSum.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbTotalSum.Location = new System.Drawing.Point(116, 260);
			this.tbTotalSum.Name = "tbTotalSum";
			this.tbTotalSum.ReadOnly = true;
			this.tbTotalSum.Size = new System.Drawing.Size(143, 53);
			this.tbTotalSum.TabIndex = 0;
			this.tbTotalSum.TabStop = false;
			this.tbTotalSum.Text = "0";
			this.tbTotalSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lbTotalSum
			// 
			this.lbTotalSum.AutoSize = true;
			this.lbTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbTotalSum.ForeColor = System.Drawing.Color.Blue;
			this.lbTotalSum.Location = new System.Drawing.Point(3, 269);
			this.lbTotalSum.Name = "lbTotalSum";
			this.lbTotalSum.Size = new System.Drawing.Size(116, 31);
			this.lbTotalSum.TabIndex = 1;
			this.lbTotalSum.Text = "ИТОГО:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(265, 277);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "руб.";
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(428, 325);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbTotalSum);
			this.Controls.Add(this.btnCheck);
			this.Controls.Add(this.grpCafe);
			this.Controls.Add(this.grpFuel);
			this.Controls.Add(this.lbTotalSum);
			this.MaximizeBox = false;
			this.Name = "MainWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Автозаправка";
			this.grpFuel.ResumeLayout(false);
			this.grpFuel.PerformLayout();
			this.grpFuelSum.ResumeLayout(false);
			this.grpFuelSum.PerformLayout();
			this.grpFuelChoise.ResumeLayout(false);
			this.grpFuelChoise.PerformLayout();
			this.grpCafe.ResumeLayout(false);
			this.grpCafe.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numCocaColaCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCheeseburgerCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numGamburgerCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHotDogCount)).EndInit();
			this.grpCafeSum.ResumeLayout(false);
			this.grpCafeSum.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpFuel;
		private System.Windows.Forms.GroupBox grpFuelSum;
		private System.Windows.Forms.GroupBox grpFuelChoise;
		private System.Windows.Forms.GroupBox grpCafe;
		private System.Windows.Forms.GroupBox grpCafeSum;
		private System.Windows.Forms.TextBox tbFuelCost;
		private System.Windows.Forms.Label lbFuelCost;
		private System.Windows.Forms.TextBox tbFuelSum;
		private System.Windows.Forms.Label lbFuelSummDim;
		private System.Windows.Forms.Label lbFuelCountDim;
		private System.Windows.Forms.TextBox tbFuelSumm;
		private System.Windows.Forms.RadioButton rbFuelSumm;
		private System.Windows.Forms.RadioButton rbFuelCount;
		private System.Windows.Forms.CheckBox chbCocaCola;
		private System.Windows.Forms.CheckBox chbCheeseburger;
		private System.Windows.Forms.CheckBox chbGamburger;
		private System.Windows.Forms.CheckBox chbHotDog;
		private System.Windows.Forms.Label lbCafeCount;
		private System.Windows.Forms.Label lbCafeCost;
		private System.Windows.Forms.NumericUpDown numCocaColaCount;
		private System.Windows.Forms.NumericUpDown numCheeseburgerCount;
		private System.Windows.Forms.NumericUpDown numGamburgerCount;
		private System.Windows.Forms.NumericUpDown numHotDogCount;
		private System.Windows.Forms.TextBox tbCocaColaCost;
		private System.Windows.Forms.TextBox tbCheeseburgerCost;
		private System.Windows.Forms.TextBox tbGamburgerCost;
		private System.Windows.Forms.TextBox tbHotDogCost;
		private System.Windows.Forms.TextBox tbCafeSum;
		private System.Windows.Forms.Button btnCheck;
		private System.Windows.Forms.TextBox tbTotalSum;
		private System.Windows.Forms.Label lbTotalSum;
		private System.Windows.Forms.TextBox tbFuelCount;
		private System.Windows.Forms.Label lbFuelSumDim;
		private System.Windows.Forms.Label lbCafeSumDim;
		private System.Windows.Forms.RadioButton rbDT;
		private System.Windows.Forms.RadioButton rbA80;
		private System.Windows.Forms.RadioButton rbA92;
		private System.Windows.Forms.RadioButton rbA95;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

