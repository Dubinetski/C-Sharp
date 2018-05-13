namespace LinqToXml {
	partial class MainForm {
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.dgwRezult = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.btnQuery1 = new System.Windows.Forms.Button();
			this.btnQuery2 = new System.Windows.Forms.Button();
			this.btnQuery3 = new System.Windows.Forms.Button();
			this.btnQuery4 = new System.Windows.Forms.Button();
			this.btnQuery5 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgwRezult)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.dgwRezult, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnQuery1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnQuery2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnQuery3, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.btnQuery4, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnQuery5, 0, 5);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// dgwRezult
			// 
			this.dgwRezult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgwRezult.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dgwRezult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgwRezult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgwRezult.Location = new System.Drawing.Point(300, 0);
			this.dgwRezult.Margin = new System.Windows.Forms.Padding(0);
			this.dgwRezult.Name = "dgwRezult";
			this.dgwRezult.RowHeadersVisible = false;
			this.tableLayoutPanel1.SetRowSpan(this.dgwRezult, 7);
			this.dgwRezult.Size = new System.Drawing.Size(500, 450);
			this.dgwRezult.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(294, 40);
			this.label1.TabIndex = 1;
			this.label1.Text = "Выберите запрос";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnQuery1
			// 
			this.btnQuery1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQuery1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuery1.Location = new System.Drawing.Point(0, 40);
			this.btnQuery1.Margin = new System.Windows.Forms.Padding(0);
			this.btnQuery1.Name = "btnQuery1";
			this.btnQuery1.Size = new System.Drawing.Size(300, 40);
			this.btnQuery1.TabIndex = 2;
			this.btnQuery1.Text = "1. Список всех стран с их населением";
			this.btnQuery1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQuery1.UseVisualStyleBackColor = true;
			this.btnQuery1.Click += new System.EventHandler(this.btnQuery1_Click);
			// 
			// btnQuery2
			// 
			this.btnQuery2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQuery2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuery2.Location = new System.Drawing.Point(0, 80);
			this.btnQuery2.Margin = new System.Windows.Forms.Padding(0);
			this.btnQuery2.Name = "btnQuery2";
			this.btnQuery2.Size = new System.Drawing.Size(300, 40);
			this.btnQuery2.TabIndex = 2;
			this.btnQuery2.Text = "2. Города и их население (более 100 тыс человек)";
			this.btnQuery2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQuery2.UseVisualStyleBackColor = true;
			this.btnQuery2.Click += new System.EventHandler(this.btnQuery2_Click);
			// 
			// btnQuery3
			// 
			this.btnQuery3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQuery3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuery3.Location = new System.Drawing.Point(0, 120);
			this.btnQuery3.Margin = new System.Windows.Forms.Padding(0);
			this.btnQuery3.Name = "btnQuery3";
			this.btnQuery3.Size = new System.Drawing.Size(300, 40);
			this.btnQuery3.TabIndex = 2;
			this.btnQuery3.Text = "3. Количество стран, население и площадь стран каждого из континентов";
			this.btnQuery3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQuery3.UseVisualStyleBackColor = true;
			this.btnQuery3.Click += new System.EventHandler(this.btnQuery3_Click);
			// 
			// btnQuery4
			// 
			this.btnQuery4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQuery4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuery4.Location = new System.Drawing.Point(0, 160);
			this.btnQuery4.Margin = new System.Windows.Forms.Padding(0);
			this.btnQuery4.Name = "btnQuery4";
			this.btnQuery4.Size = new System.Drawing.Size(300, 40);
			this.btnQuery4.TabIndex = 2;
			this.btnQuery4.Text = "4. Список стран с их стролицами";
			this.btnQuery4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQuery4.UseVisualStyleBackColor = true;
			this.btnQuery4.Click += new System.EventHandler(this.btnQuery4_Click);
			// 
			// btnQuery5
			// 
			this.btnQuery5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnQuery5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnQuery5.Location = new System.Drawing.Point(0, 200);
			this.btnQuery5.Margin = new System.Windows.Forms.Padding(0);
			this.btnQuery5.Name = "btnQuery5";
			this.btnQuery5.Size = new System.Drawing.Size(300, 40);
			this.btnQuery5.TabIndex = 2;
			this.btnQuery5.Text = "5. Страну, граничащую с наибольшим количеством стран, и названия этих стран";
			this.btnQuery5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQuery5.UseVisualStyleBackColor = true;
			this.btnQuery5.Click += new System.EventHandler(this.btnQuery5_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MainForm";
			this.Text = "Linq To Xml";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgwRezult)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView dgwRezult;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnQuery1;
		private System.Windows.Forms.Button btnQuery2;
		private System.Windows.Forms.Button btnQuery3;
		private System.Windows.Forms.Button btnQuery4;
		private System.Windows.Forms.Button btnQuery5;
	}
}

