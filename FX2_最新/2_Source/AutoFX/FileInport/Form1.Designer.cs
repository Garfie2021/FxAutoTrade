namespace FileInport
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.btnFXCMフォルダ選択 = new System.Windows.Forms.Button();
			this.txtFXCMフォルダ = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnTSVコンバート開始 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtColCnt = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTSVファイル保存フォルダ = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDB取込み対象フォルダ = new System.Windows.Forms.TextBox();
			this.btnDBインポート開始 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDB接続先 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmb時間区分 = new System.Windows.Forms.ComboBox();
			this.cmbデータ区分 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmb通貨ペア = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txt実行ストアド = new System.Windows.Forms.TextBox();
			this.btn実行ストアド = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label13 = new System.Windows.Forms.Label();
			this.btnファイル_FXCMファイル選択 = new System.Windows.Forms.Button();
			this.txtファイル_FXCMファイル = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtファイル_ColCnt = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtファイル_TSVファイル保存フォルダ = new System.Windows.Forms.TextBox();
			this.btnファイル_TSVコンバート開始 = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtファイル_DB接続先 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtファイル_DB取込み対象ファイル = new System.Windows.Forms.TextBox();
			this.btnファイル_DBインポート開始 = new System.Windows.Forms.Button();
			this.cmbIndicator = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.cmbDB接続先 = new System.Windows.Forms.ComboBox();
			this.label16 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnFXCMフォルダ選択
			// 
			this.btnFXCMフォルダ選択.ForeColor = System.Drawing.Color.Black;
			this.btnFXCMフォルダ選択.Location = new System.Drawing.Point(634, 10);
			this.btnFXCMフォルダ選択.Name = "btnFXCMフォルダ選択";
			this.btnFXCMフォルダ選択.Size = new System.Drawing.Size(126, 23);
			this.btnFXCMフォルダ選択.TabIndex = 0;
			this.btnFXCMフォルダ選択.Text = "FXCMフォルダ選択";
			this.btnFXCMフォルダ選択.UseVisualStyleBackColor = true;
			this.btnFXCMフォルダ選択.Click += new System.EventHandler(this.btnフォルダ選択_Click);
			// 
			// txtFXCMフォルダ
			// 
			this.txtFXCMフォルダ.Location = new System.Drawing.Point(92, 12);
			this.txtFXCMフォルダ.Name = "txtFXCMフォルダ";
			this.txtFXCMフォルダ.Size = new System.Drawing.Size(536, 19);
			this.txtFXCMフォルダ.TabIndex = 1;
			this.txtFXCMフォルダ.Text = "C:\\work\\11_FX\\3_Data";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "FXCMフォルダ：";
			// 
			// btnTSVコンバート開始
			// 
			this.btnTSVコンバート開始.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTSVコンバート開始.ForeColor = System.Drawing.Color.Black;
			this.btnTSVコンバート開始.Location = new System.Drawing.Point(682, 39);
			this.btnTSVコンバート開始.Name = "btnTSVコンバート開始";
			this.btnTSVコンバート開始.Size = new System.Drawing.Size(126, 23);
			this.btnTSVコンバート開始.TabIndex = 3;
			this.btnTSVコンバート開始.Text = "TSVコンバート開始";
			this.btnTSVコンバート開始.UseVisualStyleBackColor = true;
			this.btnTSVコンバート開始.Click += new System.EventHandler(this.btnTSVコンバート開始_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtColCnt);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtTSVファイル保存フォルダ);
			this.groupBox1.Controls.Add(this.btnTSVコンバート開始);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox1.Location = new System.Drawing.Point(6, 60);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(814, 79);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "TSVファイルへコンバート";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 23);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 12);
			this.label7.TabIndex = 7;
			this.label7.Text = "ColCnt：";
			// 
			// txtColCnt
			// 
			this.txtColCnt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtColCnt.Location = new System.Drawing.Point(148, 18);
			this.txtColCnt.Name = "txtColCnt";
			this.txtColCnt.Size = new System.Drawing.Size(95, 19);
			this.txtColCnt.TabIndex = 6;
			this.txtColCnt.Text = "9";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 47);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 12);
			this.label2.TabIndex = 5;
			this.label2.Text = "TSVファイル保存フォルダ：";
			// 
			// txtTSVファイル保存フォルダ
			// 
			this.txtTSVファイル保存フォルダ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTSVファイル保存フォルダ.Location = new System.Drawing.Point(148, 42);
			this.txtTSVファイル保存フォルダ.Name = "txtTSVファイル保存フォルダ";
			this.txtTSVファイル保存フォルダ.Size = new System.Drawing.Size(528, 19);
			this.txtTSVファイル保存フォルダ.TabIndex = 4;
			this.txtTSVファイル保存フォルダ.Text = "C:\\work\\11_FX\\3_Data";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtDB取込み対象フォルダ);
			this.groupBox2.Controls.Add(this.btnDBインポート開始);
			this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox2.Location = new System.Drawing.Point(6, 145);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(814, 50);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "TSVファイルをDBへインポート";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "DB取込み対象フォルダ：";
			// 
			// txtDB取込み対象フォルダ
			// 
			this.txtDB取込み対象フォルダ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDB取込み対象フォルダ.Location = new System.Drawing.Point(148, 18);
			this.txtDB取込み対象フォルダ.Name = "txtDB取込み対象フォルダ";
			this.txtDB取込み対象フォルダ.Size = new System.Drawing.Size(528, 19);
			this.txtDB取込み対象フォルダ.TabIndex = 4;
			this.txtDB取込み対象フォルダ.Text = "C:\\work\\11_FX\\3_Data";
			// 
			// btnDBインポート開始
			// 
			this.btnDBインポート開始.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDBインポート開始.ForeColor = System.Drawing.Color.Black;
			this.btnDBインポート開始.Location = new System.Drawing.Point(682, 16);
			this.btnDBインポート開始.Name = "btnDBインポート開始";
			this.btnDBインポート開始.Size = new System.Drawing.Size(126, 23);
			this.btnDBインポート開始.TabIndex = 3;
			this.btnDBインポート開始.Text = "DBインポート開始";
			this.btnDBインポート開始.UseVisualStyleBackColor = true;
			this.btnDBインポート開始.Click += new System.EventHandler(this.btnDBインポート開始_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 12);
			this.label4.TabIndex = 7;
			this.label4.Text = "DB接続先：";
			// 
			// txtDB接続先
			// 
			this.txtDB接続先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDB接続先.Location = new System.Drawing.Point(92, 35);
			this.txtDB接続先.Name = "txtDB接続先";
			this.txtDB接続先.Size = new System.Drawing.Size(536, 19);
			this.txtDB接続先.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(380, 12);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 12);
			this.label5.TabIndex = 8;
			this.label5.Text = "時間区分：";
			// 
			// cmb時間区分
			// 
			this.cmb時間区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb時間区分.FormattingEnabled = true;
			this.cmb時間区分.Items.AddRange(new object[] {
            "Monthly",
            "Weekly",
            "Daily",
            "Hourly",
            "30minutes",
            "15minutes",
            "5minutes",
            "1minutes"});
			this.cmb時間区分.Location = new System.Drawing.Point(444, 7);
			this.cmb時間区分.Name = "cmb時間区分";
			this.cmb時間区分.Size = new System.Drawing.Size(82, 20);
			this.cmb時間区分.TabIndex = 9;
			this.cmb時間区分.SelectedIndexChanged += new System.EventHandler(this.cmb時間区分_SelectedIndexChanged);
			// 
			// cmbデータ区分
			// 
			this.cmbデータ区分.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbデータ区分.FormattingEnabled = true;
			this.cmbデータ区分.Items.AddRange(new object[] {
            "Rate",
            "Indicator"});
			this.cmbデータ区分.Location = new System.Drawing.Point(261, 7);
			this.cmbデータ区分.Name = "cmbデータ区分";
			this.cmbデータ区分.Size = new System.Drawing.Size(97, 20);
			this.cmbデータ区分.TabIndex = 11;
			this.cmbデータ区分.SelectedIndexChanged += new System.EventHandler(this.cmbデータ区分_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(195, 11);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 12);
			this.label6.TabIndex = 10;
			this.label6.Text = "データ区分：";
			// 
			// cmb通貨ペア
			// 
			this.cmb通貨ペア.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb通貨ペア.FormattingEnabled = true;
			this.cmb通貨ペア.Items.AddRange(new object[] {
            "ALL",
            "AUD_CAD",
            "AUD_CHF",
            "AUD_JPY",
            "AUD_NZD",
            "AUD_USD",
            "CAD_CHF",
            "CAD_JPY",
            "CHF_JPY",
            "EUR_AUD",
            "EUR_CAD",
            "EUR_CHF",
            "EUR_GBP",
            "EUR_JPY",
            "EUR_NZD",
            "EUR_TRY",
            "EUR_USD",
            "GBP_AUD",
            "GBP_CAD",
            "GBP_CHF",
            "GBP_JPY",
            "GBP_NZD",
            "GBP_USD",
            "HKD_JPY",
            "NOK_JPY",
            "NZD_CAD",
            "NZD_CHF",
            "NZD_JPY",
            "NZD_USD",
            "SEK_JPY",
            "SGD_JPY",
            "TRY_JPY",
            "USD_CAD",
            "USD_CHF",
            "USD_HKD",
            "USD_JPY",
            "USD_SGD",
            "USD_TRY",
            "USD_ZAR",
            "ZAR_JPY",
            "XAU_USD",
            "JPN225",
            "US30",
            "USDOLLAR",
            "USOil"});
			this.cmb通貨ペア.Location = new System.Drawing.Point(605, 8);
			this.cmb通貨ペア.Name = "cmb通貨ペア";
			this.cmb通貨ペア.Size = new System.Drawing.Size(78, 20);
			this.cmb通貨ペア.TabIndex = 13;
			this.cmb通貨ペア.SelectedIndexChanged += new System.EventHandler(this.cmb通貨ペア_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(547, 13);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(54, 12);
			this.label8.TabIndex = 12;
			this.label8.Text = "通貨ペア：";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(8, 39);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(864, 326);
			this.tabControl1.TabIndex = 14;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.groupBox5);
			this.tabPage1.Controls.Add(this.txtDB接続先);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.btnFXCMフォルダ選択);
			this.tabPage1.Controls.Add(this.txtFXCMフォルダ);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.ForeColor = System.Drawing.Color.White;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(856, 300);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "フォルダ単位";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.txt実行ストアド);
			this.groupBox5.Controls.Add(this.btn実行ストアド);
			this.groupBox5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox5.Location = new System.Drawing.Point(6, 201);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(814, 59);
			this.groupBox5.TabIndex = 6;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "本テーブルへインポート";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(16, 23);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(70, 12);
			this.label15.TabIndex = 5;
			this.label15.Text = "実行ストアド：";
			// 
			// txt実行ストアド
			// 
			this.txt実行ストアド.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txt実行ストアド.Location = new System.Drawing.Point(148, 18);
			this.txt実行ストアド.Name = "txt実行ストアド";
			this.txt実行ストアド.Size = new System.Drawing.Size(528, 19);
			this.txt実行ストアド.TabIndex = 4;
			this.txt実行ストアド.Text = "fxcm.SP_InsertRateHistory_15m_fromFXCM";
			// 
			// btn実行ストアド
			// 
			this.btn実行ストアド.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn実行ストアド.ForeColor = System.Drawing.Color.Black;
			this.btn実行ストアド.Location = new System.Drawing.Point(682, 16);
			this.btn実行ストアド.Name = "btn実行ストアド";
			this.btn実行ストアド.Size = new System.Drawing.Size(126, 23);
			this.btn実行ストアド.TabIndex = 3;
			this.btn実行ストアド.Text = "ストアド実行";
			this.btn実行ストアド.UseVisualStyleBackColor = true;
			this.btn実行ストアド.Click += new System.EventHandler(this.btn実行ストアド_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.btnファイル_FXCMファイル選択);
			this.tabPage2.Controls.Add(this.txtファイル_FXCMファイル);
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Controls.Add(this.groupBox4);
			this.tabPage2.ForeColor = System.Drawing.Color.White;
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(856, 300);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "ファイル単位";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(8, 13);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(76, 12);
			this.label13.TabIndex = 10;
			this.label13.Text = "FXCMファイル：";
			// 
			// btnファイル_FXCMファイル選択
			// 
			this.btnファイル_FXCMファイル選択.ForeColor = System.Drawing.Color.Black;
			this.btnファイル_FXCMファイル選択.Location = new System.Drawing.Point(633, 8);
			this.btnファイル_FXCMファイル選択.Name = "btnファイル_FXCMファイル選択";
			this.btnファイル_FXCMファイル選択.Size = new System.Drawing.Size(126, 23);
			this.btnファイル_FXCMファイル選択.TabIndex = 8;
			this.btnファイル_FXCMファイル選択.Text = "FXCMフォルダ選択";
			this.btnファイル_FXCMファイル選択.UseVisualStyleBackColor = true;
			// 
			// txtファイル_FXCMファイル
			// 
			this.txtファイル_FXCMファイル.Location = new System.Drawing.Point(91, 10);
			this.txtファイル_FXCMファイル.Name = "txtファイル_FXCMファイル";
			this.txtファイル_FXCMファイル.Size = new System.Drawing.Size(536, 19);
			this.txtファイル_FXCMファイル.TabIndex = 9;
			this.txtファイル_FXCMファイル.Text = "C:\\work\\11_FX\\3_Data";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.txtファイル_ColCnt);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Controls.Add(this.txtファイル_TSVファイル保存フォルダ);
			this.groupBox3.Controls.Add(this.btnファイル_TSVコンバート開始);
			this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox3.Location = new System.Drawing.Point(9, 36);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(814, 96);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "TSVファイルへコンバート";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 23);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 12);
			this.label9.TabIndex = 7;
			this.label9.Text = "ColCnt：";
			// 
			// txtファイル_ColCnt
			// 
			this.txtファイル_ColCnt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtファイル_ColCnt.Location = new System.Drawing.Point(148, 18);
			this.txtファイル_ColCnt.Name = "txtファイル_ColCnt";
			this.txtファイル_ColCnt.Size = new System.Drawing.Size(95, 19);
			this.txtファイル_ColCnt.TabIndex = 6;
			this.txtファイル_ColCnt.Text = "9";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 47);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(126, 12);
			this.label10.TabIndex = 5;
			this.label10.Text = "TSVファイル保存フォルダ：";
			// 
			// txtファイル_TSVファイル保存フォルダ
			// 
			this.txtファイル_TSVファイル保存フォルダ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtファイル_TSVファイル保存フォルダ.Location = new System.Drawing.Point(148, 42);
			this.txtファイル_TSVファイル保存フォルダ.Name = "txtファイル_TSVファイル保存フォルダ";
			this.txtファイル_TSVファイル保存フォルダ.Size = new System.Drawing.Size(528, 19);
			this.txtファイル_TSVファイル保存フォルダ.TabIndex = 4;
			this.txtファイル_TSVファイル保存フォルダ.Text = "C:\\work\\11_FX\\3_Data";
			// 
			// btnファイル_TSVコンバート開始
			// 
			this.btnファイル_TSVコンバート開始.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnファイル_TSVコンバート開始.ForeColor = System.Drawing.Color.Black;
			this.btnファイル_TSVコンバート開始.Location = new System.Drawing.Point(682, 39);
			this.btnファイル_TSVコンバート開始.Name = "btnファイル_TSVコンバート開始";
			this.btnファイル_TSVコンバート開始.Size = new System.Drawing.Size(126, 23);
			this.btnファイル_TSVコンバート開始.TabIndex = 3;
			this.btnファイル_TSVコンバート開始.Text = "TSVコンバート開始";
			this.btnファイル_TSVコンバート開始.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label11);
			this.groupBox4.Controls.Add(this.txtファイル_DB接続先);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.txtファイル_DB取込み対象ファイル);
			this.groupBox4.Controls.Add(this.btnファイル_DBインポート開始);
			this.groupBox4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox4.Location = new System.Drawing.Point(9, 138);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(814, 76);
			this.groupBox4.TabIndex = 7;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "TSVファイルをDBへインポート";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(17, 23);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 12);
			this.label11.TabIndex = 7;
			this.label11.Text = "DB接続先：";
			// 
			// txtファイル_DB接続先
			// 
			this.txtファイル_DB接続先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtファイル_DB接続先.Location = new System.Drawing.Point(149, 18);
			this.txtファイル_DB接続先.Name = "txtファイル_DB接続先";
			this.txtファイル_DB接続先.Size = new System.Drawing.Size(528, 19);
			this.txtファイル_DB接続先.TabIndex = 6;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(16, 50);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(120, 12);
			this.label12.TabIndex = 5;
			this.label12.Text = "DB取込み対象ファイル：";
			// 
			// txtファイル_DB取込み対象ファイル
			// 
			this.txtファイル_DB取込み対象ファイル.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtファイル_DB取込み対象ファイル.Location = new System.Drawing.Point(148, 45);
			this.txtファイル_DB取込み対象ファイル.Name = "txtファイル_DB取込み対象ファイル";
			this.txtファイル_DB取込み対象ファイル.Size = new System.Drawing.Size(528, 19);
			this.txtファイル_DB取込み対象ファイル.TabIndex = 4;
			this.txtファイル_DB取込み対象ファイル.Text = "C:\\work\\11_FX\\3_Data";
			// 
			// btnファイル_DBインポート開始
			// 
			this.btnファイル_DBインポート開始.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnファイル_DBインポート開始.ForeColor = System.Drawing.Color.Black;
			this.btnファイル_DBインポート開始.Location = new System.Drawing.Point(682, 40);
			this.btnファイル_DBインポート開始.Name = "btnファイル_DBインポート開始";
			this.btnファイル_DBインポート開始.Size = new System.Drawing.Size(126, 23);
			this.btnファイル_DBインポート開始.TabIndex = 3;
			this.btnファイル_DBインポート開始.Text = "DBインポート開始";
			this.btnファイル_DBインポート開始.UseVisualStyleBackColor = true;
			// 
			// cmbIndicator
			// 
			this.cmbIndicator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIndicator.FormattingEnabled = true;
			this.cmbIndicator.Items.AddRange(new object[] {
            "ADX",
            "DMI",
            "ASI",
            "WMA"});
			this.cmbIndicator.Location = new System.Drawing.Point(758, 8);
			this.cmbIndicator.Name = "cmbIndicator";
			this.cmbIndicator.Size = new System.Drawing.Size(121, 20);
			this.cmbIndicator.TabIndex = 16;
			this.cmbIndicator.SelectedIndexChanged += new System.EventHandler(this.cmbIndicator_SelectedIndexChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(700, 13);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(55, 12);
			this.label14.TabIndex = 15;
			this.label14.Text = "Indicator：";
			// 
			// cmbDB接続先
			// 
			this.cmbDB接続先.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDB接続先.FormattingEnabled = true;
			this.cmbDB接続先.Items.AddRange(new object[] {
            "DemoA_FX",
            "RealA_FX",
            "RealB_FX",
            "DemoA_Kabu",
            "RealA_Kabu",
            "RealB_Kabu",
            "DemoA_XAU",
            "RealA_XAU",
            "RealB_XAU"});
			this.cmbDB接続先.Location = new System.Drawing.Point(76, 7);
			this.cmbDB接続先.Name = "cmbDB接続先";
			this.cmbDB接続先.Size = new System.Drawing.Size(97, 20);
			this.cmbDB接続先.TabIndex = 18;
			this.cmbDB接続先.SelectedIndexChanged += new System.EventHandler(this.cmbDB接続先_SelectedIndexChanged);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(10, 11);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(63, 12);
			this.label16.TabIndex = 17;
			this.label16.Text = "DB接続先：";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(888, 402);
			this.Controls.Add(this.cmbDB接続先);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.cmbIndicator);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.cmb通貨ペア);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cmbデータ区分);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cmb時間区分);
			this.Controls.Add(this.label5);
			this.ForeColor = System.Drawing.Color.White;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnFXCMフォルダ選択;
		private System.Windows.Forms.TextBox txtFXCMフォルダ;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnTSVコンバート開始;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTSVファイル保存フォルダ;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDB取込み対象フォルダ;
		private System.Windows.Forms.Button btnDBインポート開始;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDB接続先;
		private System.Windows.Forms.ComboBox cmb時間区分;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbデータ区分;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtColCnt;
		private System.Windows.Forms.ComboBox cmb通貨ペア;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnファイル_FXCMファイル選択;
		private System.Windows.Forms.TextBox txtファイル_FXCMファイル;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtファイル_ColCnt;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtファイル_TSVファイル保存フォルダ;
		private System.Windows.Forms.Button btnファイル_TSVコンバート開始;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtファイル_DB接続先;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtファイル_DB取込み対象ファイル;
		private System.Windows.Forms.Button btnファイル_DBインポート開始;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txt実行ストアド;
		private System.Windows.Forms.Button btn実行ストアド;
		private System.Windows.Forms.ComboBox cmbIndicator;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cmbDB接続先;
		private System.Windows.Forms.Label label16;
	}
}

