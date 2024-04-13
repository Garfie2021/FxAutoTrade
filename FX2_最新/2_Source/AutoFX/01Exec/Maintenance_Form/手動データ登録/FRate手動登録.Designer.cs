namespace Maintenance_Form
{
	partial class FRate手動登録
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.connectDBダウンロード対象通貨ペア = new Maintenance_Form.ConnectDB();
            this.btnRateダウンロード対象通貨ペア確認 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn取り込み済みデータを全て削除 = new System.Windows.Forms.Button();
            this.txtインポート先フォルダ_Day1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtインポート先フォルダ_Min15 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFXCMデータベースへインポート = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.connectDBエクスポート先 = new Maintenance_Form.ConnectDB();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb対象テーブル = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnエクスポート = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.connectDB再計算先 = new Maintenance_Form.ConnectDB();
            this.btnMin1再計算 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMonth1再計算 = new System.Windows.Forms.Button();
            this.btnWeek1再計算 = new System.Windows.Forms.Button();
            this.btnDay1再計算 = new System.Windows.Forms.Button();
            this.btnHour1再計算 = new System.Windows.Forms.Button();
            this.btnMin15再計算 = new System.Windows.Forms.Button();
            this.btnMin5再計算 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn時間調整実行 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtMin15Tsv = new System.Windows.Forms.TextBox();
            this.txtMin15Excel = new System.Windows.Forms.TextBox();
            this.txtDay1Tsv = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnTsvファイルの内容チェック = new System.Windows.Forms.Button();
            this.txtDay1Excel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.connectDBダウンロード対象通貨ペア);
            this.groupBox1.Controls.Add(this.btnRateダウンロード対象通貨ペア確認);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(627, 152);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. FXCMからRateファイルを手動でダウンロード";
            // 
            // connectDBダウンロード対象通貨ペア
            // 
            this.connectDBダウンロード対象通貨ペア.BackColor = System.Drawing.Color.DimGray;
            this.connectDBダウンロード対象通貨ペア.Location = new System.Drawing.Point(9, 21);
            this.connectDBダウンロード対象通貨ペア.Name = "connectDBダウンロード対象通貨ペア";
            this.connectDBダウンロード対象通貨ペア.Size = new System.Drawing.Size(381, 35);
            this.connectDBダウンロード対象通貨ペア.TabIndex = 17;
            // 
            // btnRateダウンロード対象通貨ペア確認
            // 
            this.btnRateダウンロード対象通貨ペア確認.ForeColor = System.Drawing.Color.Black;
            this.btnRateダウンロード対象通貨ペア確認.Location = new System.Drawing.Point(11, 58);
            this.btnRateダウンロード対象通貨ペア確認.Margin = new System.Windows.Forms.Padding(4);
            this.btnRateダウンロード対象通貨ペア確認.Name = "btnRateダウンロード対象通貨ペア確認";
            this.btnRateダウンロード対象通貨ペア確認.Size = new System.Drawing.Size(265, 36);
            this.btnRateダウンロード対象通貨ペア確認.TabIndex = 16;
            this.btnRateダウンロード対象通貨ペア確認.Text = "Rateダウンロード対象通貨ペア確認";
            this.btnRateダウンロード対象通貨ペア確認.UseVisualStyleBackColor = true;
            this.btnRateダウンロード対象通貨ペア確認.Click += new System.EventHandler(this.btnRateダウンロード対象通貨ペア確認_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(163, 104);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(455, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "C:\\work\\3_FX\\2_FX2\\trunk2\\4_Data\\1_Rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ダウンロード先フォルダ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn取り込み済みデータを全て削除);
            this.groupBox2.Controls.Add(this.txtインポート先フォルダ_Day1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtインポート先フォルダ_Min15);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnFXCMデータベースへインポート);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(13, 529);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(627, 137);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. ダウンロードしたファイルをFXCMデータベースへインポート";
            // 
            // btn取り込み済みデータを全て削除
            // 
            this.btn取り込み済みデータを全て削除.ForeColor = System.Drawing.Color.Black;
            this.btn取り込み済みデータを全て削除.Location = new System.Drawing.Point(14, 86);
            this.btn取り込み済みデータを全て削除.Margin = new System.Windows.Forms.Padding(4);
            this.btn取り込み済みデータを全て削除.Name = "btn取り込み済みデータを全て削除";
            this.btn取り込み済みデータを全て削除.Size = new System.Drawing.Size(236, 36);
            this.btn取り込み済みデータを全て削除.TabIndex = 20;
            this.btn取り込み済みデータを全て削除.Text = "取り込み済みデータを全て削除";
            this.btn取り込み済みデータを全て削除.UseVisualStyleBackColor = true;
            this.btn取り込み済みデータを全て削除.Click += new System.EventHandler(this.btn取り込み済みデータを全て削除_Click);
            // 
            // txtインポート先フォルダ_Day1
            // 
            this.txtインポート先フォルダ_Day1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtインポート先フォルダ_Day1.Location = new System.Drawing.Point(197, 56);
            this.txtインポート先フォルダ_Day1.Margin = new System.Windows.Forms.Padding(4);
            this.txtインポート先フォルダ_Day1.Name = "txtインポート先フォルダ_Day1";
            this.txtインポート先フォルダ_Day1.Size = new System.Drawing.Size(422, 22);
            this.txtインポート先フォルダ_Day1.TabIndex = 19;
            this.txtインポート先フォルダ_Day1.Text = "D:\\work\\3_FX\\2_FX2\\trunk2\\4_Data\\1_Rate\\Day1\\tsv";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "インポート先フォルダ（Day1）";
            // 
            // txtインポート先フォルダ_Min15
            // 
            this.txtインポート先フォルダ_Min15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtインポート先フォルダ_Min15.Location = new System.Drawing.Point(197, 26);
            this.txtインポート先フォルダ_Min15.Margin = new System.Windows.Forms.Padding(4);
            this.txtインポート先フォルダ_Min15.Name = "txtインポート先フォルダ_Min15";
            this.txtインポート先フォルダ_Min15.Size = new System.Drawing.Size(422, 22);
            this.txtインポート先フォルダ_Min15.TabIndex = 17;
            this.txtインポート先フォルダ_Min15.Text = "D:\\work\\3_FX\\2_FX2\\trunk2\\4_Data\\1_Rate\\Min15\\20170126\\tsv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "インポート先フォルダ（Min15）";
            // 
            // btnFXCMデータベースへインポート
            // 
            this.btnFXCMデータベースへインポート.ForeColor = System.Drawing.Color.Black;
            this.btnFXCMデータベースへインポート.Location = new System.Drawing.Point(269, 86);
            this.btnFXCMデータベースへインポート.Margin = new System.Windows.Forms.Padding(4);
            this.btnFXCMデータベースへインポート.Name = "btnFXCMデータベースへインポート";
            this.btnFXCMデータベースへインポート.Size = new System.Drawing.Size(144, 36);
            this.btnFXCMデータベースへインポート.TabIndex = 15;
            this.btnFXCMデータベースへインポート.Text = "インポート";
            this.btnFXCMデータベースへインポート.UseVisualStyleBackColor = true;
            this.btnFXCMデータベースへインポート.Click += new System.EventHandler(this.btnFXCMデータベースへインポート_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.connectDBエクスポート先);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cmb対象テーブル);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnエクスポート);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(13, 797);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(627, 134);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "4. FXCMデータベースへインポートしたRateを別データベースへエクスポート";
            // 
            // connectDBエクスポート先
            // 
            this.connectDBエクスポート先.BackColor = System.Drawing.Color.DimGray;
            this.connectDBエクスポート先.Location = new System.Drawing.Point(168, 18);
            this.connectDBエクスポート先.Name = "connectDBエクスポート先";
            this.connectDBエクスポート先.Size = new System.Drawing.Size(381, 35);
            this.connectDBエクスポート先.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "対象テーブル";
            // 
            // cmb対象テーブル
            // 
            this.cmb対象テーブル.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb対象テーブル.FormattingEnabled = true;
            this.cmb対象テーブル.Location = new System.Drawing.Point(172, 54);
            this.cmb対象テーブル.Margin = new System.Windows.Forms.Padding(4);
            this.cmb対象テーブル.Name = "cmb対象テーブル";
            this.cmb対象テーブル.Size = new System.Drawing.Size(369, 23);
            this.cmb対象テーブル.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "エクスポート先DB（To）";
            // 
            // btnエクスポート
            // 
            this.btnエクスポート.ForeColor = System.Drawing.Color.Black;
            this.btnエクスポート.Location = new System.Drawing.Point(11, 85);
            this.btnエクスポート.Margin = new System.Windows.Forms.Padding(4);
            this.btnエクスポート.Name = "btnエクスポート";
            this.btnエクスポート.Size = new System.Drawing.Size(144, 36);
            this.btnエクスポート.TabIndex = 15;
            this.btnエクスポート.Text = "エクスポート";
            this.btnエクスポート.UseVisualStyleBackColor = true;
            this.btnエクスポート.Click += new System.EventHandler(this.btnエクスポート_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.connectDB再計算先);
            this.groupBox4.Controls.Add(this.btnMin1再計算);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnMonth1再計算);
            this.groupBox4.Controls.Add(this.btnWeek1再計算);
            this.groupBox4.Controls.Add(this.btnDay1再計算);
            this.groupBox4.Controls.Add(this.btnHour1再計算);
            this.groupBox4.Controls.Add(this.btnMin15再計算);
            this.groupBox4.Controls.Add(this.btnMin5再計算);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(13, 939);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(627, 150);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "5. 再計算";
            // 
            // connectDB再計算先
            // 
            this.connectDB再計算先.BackColor = System.Drawing.Color.DimGray;
            this.connectDB再計算先.Location = new System.Drawing.Point(110, 17);
            this.connectDB再計算先.Name = "connectDB再計算先";
            this.connectDB再計算先.Size = new System.Drawing.Size(381, 35);
            this.connectDB再計算先.TabIndex = 24;
            // 
            // btnMin1再計算
            // 
            this.btnMin1再計算.ForeColor = System.Drawing.Color.Black;
            this.btnMin1再計算.Location = new System.Drawing.Point(11, 51);
            this.btnMin1再計算.Margin = new System.Windows.Forms.Padding(4);
            this.btnMin1再計算.Name = "btnMin1再計算";
            this.btnMin1再計算.Size = new System.Drawing.Size(144, 36);
            this.btnMin1再計算.TabIndex = 23;
            this.btnMin1再計算.Text = "Min1再計算以降";
            this.btnMin1再計算.UseVisualStyleBackColor = true;
            this.btnMin1再計算.Click += new System.EventHandler(this.btnMin1再計算_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "再計算先DB";
            // 
            // btnMonth1再計算
            // 
            this.btnMonth1再計算.ForeColor = System.Drawing.Color.Black;
            this.btnMonth1再計算.Location = new System.Drawing.Point(317, 95);
            this.btnMonth1再計算.Margin = new System.Windows.Forms.Padding(4);
            this.btnMonth1再計算.Name = "btnMonth1再計算";
            this.btnMonth1再計算.Size = new System.Drawing.Size(144, 36);
            this.btnMonth1再計算.TabIndex = 20;
            this.btnMonth1再計算.Text = "Month1再計算以降";
            this.btnMonth1再計算.UseVisualStyleBackColor = true;
            this.btnMonth1再計算.Click += new System.EventHandler(this.btnMonth1再計算_Click);
            // 
            // btnWeek1再計算
            // 
            this.btnWeek1再計算.ForeColor = System.Drawing.Color.Black;
            this.btnWeek1再計算.Location = new System.Drawing.Point(165, 95);
            this.btnWeek1再計算.Margin = new System.Windows.Forms.Padding(4);
            this.btnWeek1再計算.Name = "btnWeek1再計算";
            this.btnWeek1再計算.Size = new System.Drawing.Size(144, 36);
            this.btnWeek1再計算.TabIndex = 19;
            this.btnWeek1再計算.Text = "Week1再計算以降";
            this.btnWeek1再計算.UseVisualStyleBackColor = true;
            this.btnWeek1再計算.Click += new System.EventHandler(this.btnWeek1再計算_Click);
            // 
            // btnDay1再計算
            // 
            this.btnDay1再計算.ForeColor = System.Drawing.Color.Black;
            this.btnDay1再計算.Location = new System.Drawing.Point(11, 95);
            this.btnDay1再計算.Margin = new System.Windows.Forms.Padding(4);
            this.btnDay1再計算.Name = "btnDay1再計算";
            this.btnDay1再計算.Size = new System.Drawing.Size(144, 36);
            this.btnDay1再計算.TabIndex = 18;
            this.btnDay1再計算.Text = "Day1再計算以降";
            this.btnDay1再計算.UseVisualStyleBackColor = true;
            this.btnDay1再計算.Click += new System.EventHandler(this.btnDay1再計算_Click);
            // 
            // btnHour1再計算
            // 
            this.btnHour1再計算.ForeColor = System.Drawing.Color.Black;
            this.btnHour1再計算.Location = new System.Drawing.Point(470, 51);
            this.btnHour1再計算.Margin = new System.Windows.Forms.Padding(4);
            this.btnHour1再計算.Name = "btnHour1再計算";
            this.btnHour1再計算.Size = new System.Drawing.Size(144, 36);
            this.btnHour1再計算.TabIndex = 17;
            this.btnHour1再計算.Text = "Hour1再計算以降";
            this.btnHour1再計算.UseVisualStyleBackColor = true;
            this.btnHour1再計算.Click += new System.EventHandler(this.btnHour1再計算_Click);
            // 
            // btnMin15再計算
            // 
            this.btnMin15再計算.ForeColor = System.Drawing.Color.Black;
            this.btnMin15再計算.Location = new System.Drawing.Point(318, 51);
            this.btnMin15再計算.Margin = new System.Windows.Forms.Padding(4);
            this.btnMin15再計算.Name = "btnMin15再計算";
            this.btnMin15再計算.Size = new System.Drawing.Size(144, 36);
            this.btnMin15再計算.TabIndex = 16;
            this.btnMin15再計算.Text = "Min15再計算以降";
            this.btnMin15再計算.UseVisualStyleBackColor = true;
            this.btnMin15再計算.Click += new System.EventHandler(this.btnMin15再計算_Click);
            // 
            // btnMin5再計算
            // 
            this.btnMin5再計算.ForeColor = System.Drawing.Color.Black;
            this.btnMin5再計算.Location = new System.Drawing.Point(165, 51);
            this.btnMin5再計算.Margin = new System.Windows.Forms.Padding(4);
            this.btnMin5再計算.Name = "btnMin5再計算";
            this.btnMin5再計算.Size = new System.Drawing.Size(144, 36);
            this.btnMin5再計算.TabIndex = 15;
            this.btnMin5再計算.Text = "Min5再計算以降";
            this.btnMin5再計算.UseVisualStyleBackColor = true;
            this.btnMin5再計算.Click += new System.EventHandler(this.btnMin5再計算_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(10, 15);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(312, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "※インポート対象のRateは1分おきのみ";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.btn時間調整実行);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(13, 674);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(627, 115);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "3. 時間補正";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(163, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(562, 30);
            this.label9.TabIndex = 18;
            this.label9.Text = "※FXCMからダウンロードしたDay1の過去Rateは、日本時間と比較して11時間進んでいるので、\r\nインポート済みレコードに11時間を引く。";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(569, 30);
            this.label8.TabIndex = 17;
            this.label8.Text = "※FXCMからダウンロードしたMin15の過去Rateは、日本時間と比較して14時間遅れているので、\r\nインポート済みレコードに14時間を足す。";
            // 
            // btn時間調整実行
            // 
            this.btn時間調整実行.ForeColor = System.Drawing.Color.Black;
            this.btn時間調整実行.Location = new System.Drawing.Point(9, 24);
            this.btn時間調整実行.Margin = new System.Windows.Forms.Padding(4);
            this.btn時間調整実行.Name = "btn時間調整実行";
            this.btn時間調整実行.Size = new System.Drawing.Size(144, 36);
            this.btn時間調整実行.TabIndex = 15;
            this.btn時間調整実行.Text = "時間調整実行";
            this.btn時間調整実行.UseVisualStyleBackColor = true;
            this.btn時間調整実行.Click += new System.EventHandler(this.btn時間調整実行_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.txtMin15Tsv);
            this.groupBox6.Controls.Add(this.txtMin15Excel);
            this.groupBox6.Controls.Add(this.txtDay1Tsv);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.btnTsvファイルの内容チェック);
            this.groupBox6.Controls.Add(this.txtDay1Excel);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(14, 286);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(626, 209);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "3. 手動変換済みtsvファイルの内容チェック";
            // 
            // txtMin15Tsv
            // 
            this.txtMin15Tsv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMin15Tsv.Location = new System.Drawing.Point(103, 104);
            this.txtMin15Tsv.Margin = new System.Windows.Forms.Padding(4);
            this.txtMin15Tsv.Name = "txtMin15Tsv";
            this.txtMin15Tsv.Size = new System.Drawing.Size(454, 22);
            this.txtMin15Tsv.TabIndex = 22;
            this.txtMin15Tsv.Text = "D:\\work\\3_FX\\2_FX2\\trunk2\\4_Data\\1_Rate\\Min15\\20170126\\tsv";
            // 
            // txtMin15Excel
            // 
            this.txtMin15Excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMin15Excel.Location = new System.Drawing.Point(104, 79);
            this.txtMin15Excel.Margin = new System.Windows.Forms.Padding(4);
            this.txtMin15Excel.Name = "txtMin15Excel";
            this.txtMin15Excel.Size = new System.Drawing.Size(454, 22);
            this.txtMin15Excel.TabIndex = 21;
            this.txtMin15Excel.Text = "D:\\work\\3_FX\\2_FX2\\trunk2\\4_Data\\1_Rate\\Min15\\20170126\\Excel";
            // 
            // txtDay1Tsv
            // 
            this.txtDay1Tsv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDay1Tsv.Location = new System.Drawing.Point(103, 53);
            this.txtDay1Tsv.Margin = new System.Windows.Forms.Padding(4);
            this.txtDay1Tsv.Name = "txtDay1Tsv";
            this.txtDay1Tsv.Size = new System.Drawing.Size(454, 22);
            this.txtDay1Tsv.TabIndex = 20;
            this.txtDay1Tsv.Text = "D:\\work\\3_FX\\2_FX2\\trunk2\\4_Data\\1_Rate\\Day1\\tsv";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 109);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "Min15 Tsv";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 84);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 15);
            this.label13.TabIndex = 18;
            this.label13.Text = "Min15 Excel";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "Day1 Tsv";
            // 
            // btnTsvファイルの内容チェック
            // 
            this.btnTsvファイルの内容チェック.ForeColor = System.Drawing.Color.Black;
            this.btnTsvファイルの内容チェック.Location = new System.Drawing.Point(16, 151);
            this.btnTsvファイルの内容チェック.Margin = new System.Windows.Forms.Padding(4);
            this.btnTsvファイルの内容チェック.Name = "btnTsvファイルの内容チェック";
            this.btnTsvファイルの内容チェック.Size = new System.Drawing.Size(265, 36);
            this.btnTsvファイルの内容チェック.TabIndex = 16;
            this.btnTsvファイルの内容チェック.Text = "tsvファイルの内容チェック";
            this.btnTsvファイルの内容チェック.UseVisualStyleBackColor = true;
            this.btnTsvファイルの内容チェック.Click += new System.EventHandler(this.btnTsvファイルの内容チェック_Click);
            // 
            // txtDay1Excel
            // 
            this.txtDay1Excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDay1Excel.Location = new System.Drawing.Point(104, 28);
            this.txtDay1Excel.Margin = new System.Windows.Forms.Padding(4);
            this.txtDay1Excel.Name = "txtDay1Excel";
            this.txtDay1Excel.Size = new System.Drawing.Size(454, 22);
            this.txtDay1Excel.TabIndex = 1;
            this.txtDay1Excel.Text = "D:\\work\\3_FX\\2_FX2\\trunk2\\4_Data\\1_Rate\\Day1\\Excel";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Day1 Excel";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(14, 207);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(647, 71);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "2. ExcelファイルをTSVファイルへ変換";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 24);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(357, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "ダウンロードしたExcelファイルをTSVへ変換するのは手作業。";
            // 
            // FRate手動登録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(845, 750);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRate手動登録";
            this.Text = "FRate手動登録";
            this.Load += new System.EventHandler(this.FRate手動登録_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnFXCMデータベースへインポート;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btnエクスポート;
		private System.Windows.Forms.TextBox txtインポート先フォルダ_Min15;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmb対象テーブル;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnMin5再計算;
		private System.Windows.Forms.Button btnMonth1再計算;
		private System.Windows.Forms.Button btnWeek1再計算;
		private System.Windows.Forms.Button btnDay1再計算;
		private System.Windows.Forms.Button btnHour1再計算;
		private System.Windows.Forms.Button btnMin15再計算;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMin1再計算;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRateダウンロード対象通貨ペア確認;
        private System.Windows.Forms.TextBox txtインポート先フォルダ_Day1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn時間調整実行;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn取り込み済みデータを全て削除;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnTsvファイルの内容チェック;
        private System.Windows.Forms.TextBox txtDay1Excel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMin15Tsv;
        private System.Windows.Forms.TextBox txtMin15Excel;
        private System.Windows.Forms.TextBox txtDay1Tsv;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label14;
        private ConnectDB connectDB再計算先;
        private ConnectDB connectDBエクスポート先;
        private ConnectDB connectDBダウンロード対象通貨ペア;
    }
}