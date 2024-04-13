namespace Maintenance_Form
{
	partial class FSwap手動登録
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn登録 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt買いSwap = new System.Windows.Forms.TextBox();
            this.txt売りSwap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb通貨ペア = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt最新買いSwap = new System.Windows.Forms.TextBox();
            this.txt最新売りSwap = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv最新Swap一覧 = new System.Windows.Forms.DataGridView();
            this.btn表示 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv最新Swap一覧)).BeginInit();
            this.SuspendLayout();
            // 
            // btn登録
            // 
            this.btn登録.ForeColor = System.Drawing.Color.Black;
            this.btn登録.Location = new System.Drawing.Point(289, 180);
            this.btn登録.Margin = new System.Windows.Forms.Padding(4);
            this.btn登録.Name = "btn登録";
            this.btn登録.Size = new System.Drawing.Size(168, 39);
            this.btn登録.TabIndex = 3;
            this.btn登録.Text = "登録";
            this.btn登録.UseVisualStyleBackColor = true;
            this.btn登録.Click += new System.EventHandler(this.btn登録_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "買いSwap";
            // 
            // txt買いSwap
            // 
            this.txt買いSwap.Location = new System.Drawing.Point(105, 142);
            this.txt買いSwap.Margin = new System.Windows.Forms.Padding(4);
            this.txt買いSwap.Name = "txt買いSwap";
            this.txt買いSwap.Size = new System.Drawing.Size(132, 22);
            this.txt買いSwap.TabIndex = 1;
            this.txt買いSwap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt売りSwap
            // 
            this.txt売りSwap.Location = new System.Drawing.Point(325, 141);
            this.txt売りSwap.Margin = new System.Windows.Forms.Padding(4);
            this.txt売りSwap.Name = "txt売りSwap";
            this.txt売りSwap.Size = new System.Drawing.Size(132, 22);
            this.txt売りSwap.TabIndex = 2;
            this.txt売りSwap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(252, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "売りSwap";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "通貨ペア";
            // 
            // cmb通貨ペア
            // 
            this.cmb通貨ペア.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb通貨ペア.FormattingEnabled = true;
            this.cmb通貨ペア.Location = new System.Drawing.Point(89, 26);
            this.cmb通貨ペア.Margin = new System.Windows.Forms.Padding(4);
            this.cmb通貨ペア.Name = "cmb通貨ペア";
            this.cmb通貨ペア.Size = new System.Drawing.Size(160, 23);
            this.cmb通貨ペア.TabIndex = 0;
            this.cmb通貨ペア.SelectedIndexChanged += new System.EventHandler(this.cmb通貨ペア_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txt買いSwap);
            this.groupBox1.Controls.Add(this.btn登録);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb通貨ペア);
            this.groupBox1.Controls.Add(this.txt売りSwap);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(518, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 234);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Swapを一件づつ登録";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt最新買いSwap);
            this.groupBox3.Controls.Add(this.txt最新売りSwap);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 62);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "手動登録済み最新Swap";
            // 
            // txt最新買いSwap
            // 
            this.txt最新買いSwap.Location = new System.Drawing.Point(114, 22);
            this.txt最新買いSwap.Margin = new System.Windows.Forms.Padding(4);
            this.txt最新買いSwap.Name = "txt最新買いSwap";
            this.txt最新買いSwap.ReadOnly = true;
            this.txt最新買いSwap.Size = new System.Drawing.Size(132, 22);
            this.txt最新買いSwap.TabIndex = 0;
            this.txt最新買いSwap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt最新売りSwap
            // 
            this.txt最新売りSwap.Location = new System.Drawing.Point(363, 21);
            this.txt最新売りSwap.Margin = new System.Windows.Forms.Padding(4);
            this.txt最新売りSwap.Name = "txt最新売りSwap";
            this.txt最新売りSwap.ReadOnly = true;
            this.txt最新売りSwap.Size = new System.Drawing.Size(132, 22);
            this.txt最新売りSwap.TabIndex = 1;
            this.txt最新売りSwap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(9, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "最新買いSwap";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(261, 23);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "最新売りSwap";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dgv最新Swap一覧);
            this.groupBox2.Controls.Add(this.btn表示);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 507);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "最新Swap一覧";
            // 
            // dgv最新Swap一覧
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            this.dgv最新Swap一覧.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv最新Swap一覧.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv最新Swap一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv最新Swap一覧.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv最新Swap一覧.Location = new System.Drawing.Point(9, 56);
            this.dgv最新Swap一覧.Name = "dgv最新Swap一覧";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            this.dgv最新Swap一覧.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv最新Swap一覧.RowTemplate.Height = 24;
            this.dgv最新Swap一覧.Size = new System.Drawing.Size(479, 436);
            this.dgv最新Swap一覧.TabIndex = 5;
            // 
            // btn表示
            // 
            this.btn表示.ForeColor = System.Drawing.Color.Black;
            this.btn表示.Location = new System.Drawing.Point(9, 22);
            this.btn表示.Margin = new System.Windows.Forms.Padding(4);
            this.btn表示.Name = "btn表示";
            this.btn表示.Size = new System.Drawing.Size(144, 27);
            this.btn表示.TabIndex = 4;
            this.btn表示.Text = "表示";
            this.btn表示.UseVisualStyleBackColor = true;
            this.btn表示.Click += new System.EventHandler(this.btn表示_Click);
            // 
            // FSwap手動登録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1311, 579);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FSwap手動登録";
            this.Text = "FSwap手動登録";
            this.Load += new System.EventHandler(this.FSwap手動登録_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv最新Swap一覧)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn登録;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt買いSwap;
		private System.Windows.Forms.TextBox txt売りSwap;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmb通貨ペア;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt最新買いSwap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt最新売りSwap;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn表示;
        private System.Windows.Forms.DataGridView dgv最新Swap一覧;
    }
}