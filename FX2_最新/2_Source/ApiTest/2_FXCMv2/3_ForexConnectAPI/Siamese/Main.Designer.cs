namespace Siamese
{
    partial class Main
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
			this.components = new System.ComponentModel.Container();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btn損失開始 = new System.Windows.Forms.Button();
			this.dgv注文 = new System.Windows.Forms.DataGridView();
			this.通貨 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.取引状況 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtConnection = new System.Windows.Forms.TextBox();
			this.label70 = new System.Windows.Forms.Label();
			this.txt口座種別 = new System.Windows.Forms.TextBox();
			this.txtDB接続先 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.ToolStripStsLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkRate記録以降の処理をスキップ = new System.Windows.Forms.CheckBox();
			this.chk余剰金確保の自動ポジションCloseはMSG確認する = new System.Windows.Forms.CheckBox();
			this.txtn日以上前のポジションは決済 = new System.Windows.Forms.TextBox();
			this.chkn日以上前のポジション決済をスキップ = new System.Windows.Forms.CheckBox();
			this.chk余剰金確保の自動ポジションCloseはしない = new System.Windows.Forms.CheckBox();
			this.chkポジション更新_成行_をスキップ = new System.Windows.Forms.CheckBox();
			this.txtロスカット余剰金 = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txt出金可能額で調整したロスカット余剰金 = new System.Windows.Forms.TextBox();
			this.txt有効証拠金 = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.txt取引証拠金_現在 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txt当日約定金額 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txt余剰金の割合 = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.txt維持証拠金 = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.txtOrder状況 = new System.Windows.Forms.TextBox();
			this.txtAuto = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.txtシステム設定_Trade時間内 = new System.Windows.Forms.TextBox();
			this.txtログイン表示 = new System.Windows.Forms.TextBox();
			this.txt取引モード表示 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.txtシステム設定_秒 = new System.Windows.Forms.TextBox();
			this.txtシステム設定_分 = new System.Windows.Forms.TextBox();
			this.txtシステム設定_曜日 = new System.Windows.Forms.TextBox();
			this.txtシステム設定_時 = new System.Windows.Forms.TextBox();
			this.txtシステム設定_日 = new System.Windows.Forms.TextBox();
			this.txtシステム設定_月 = new System.Windows.Forms.TextBox();
			this.txtシステム設定_年 = new System.Windows.Forms.TextBox();
			this.label67 = new System.Windows.Forms.Label();
			this.txtログフォルダ = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.txtシステム設定_日付はn時くぎり = new System.Windows.Forms.TextBox();
			this.timer_日時曜日更新 = new System.Windows.Forms.Timer(this.components);
			this.timer_Order = new System.Windows.Forms.Timer(this.components);
			this.txt基準注文単位 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv注文)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(453, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "ターゲット余剰金（円）：";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(462, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 12);
			this.label4.TabIndex = 3;
			this.label4.Text = "現在の余剰金（円）：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(578, 50);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 19);
			this.textBox1.TabIndex = 4;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(578, 75);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(100, 19);
			this.textBox2.TabIndex = 5;
			// 
			// btn損失開始
			// 
			this.btn損失開始.BackColor = System.Drawing.SystemColors.Control;
			this.btn損失開始.ForeColor = System.Drawing.Color.Black;
			this.btn損失開始.Location = new System.Drawing.Point(8, 105);
			this.btn損失開始.Name = "btn損失開始";
			this.btn損失開始.Size = new System.Drawing.Size(75, 23);
			this.btn損失開始.TabIndex = 6;
			this.btn損失開始.Text = "処理開始";
			this.btn損失開始.UseVisualStyleBackColor = false;
			this.btn損失開始.Click += new System.EventHandler(this.btn損失開始_Click);
			// 
			// dgv注文
			// 
			this.dgv注文.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.通貨,
            this.取引状況});
			this.dgv注文.Location = new System.Drawing.Point(3, 134);
			this.dgv注文.Name = "dgv注文";
			this.dgv注文.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.dgv注文.RowHeadersVisible = false;
			this.dgv注文.RowTemplate.Height = 21;
			this.dgv注文.Size = new System.Drawing.Size(428, 435);
			this.dgv注文.TabIndex = 7;
			// 
			// 通貨
			// 
			this.通貨.Frozen = true;
			this.通貨.HeaderText = "通貨";
			this.通貨.Name = "通貨";
			this.通貨.ReadOnly = true;
			// 
			// 取引状況
			// 
			this.取引状況.Frozen = true;
			this.取引状況.HeaderText = "取引状況";
			this.取引状況.Name = "取引状況";
			this.取引状況.ReadOnly = true;
			this.取引状況.Width = 300;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtConnection);
			this.groupBox1.Controls.Add(this.label70);
			this.groupBox1.Controls.Add(this.txt口座種別);
			this.groupBox1.Controls.Add(this.txtDB接続先);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.txtUsername);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.txtPassword);
			this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox1.ForeColor = System.Drawing.Color.White;
			this.groupBox1.Location = new System.Drawing.Point(3, 33);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(428, 66);
			this.groupBox1.TabIndex = 48;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "買い口座ログイン";
			// 
			// txtConnection
			// 
			this.txtConnection.Location = new System.Drawing.Point(7, 16);
			this.txtConnection.Name = "txtConnection";
			this.txtConnection.Size = new System.Drawing.Size(38, 18);
			this.txtConnection.TabIndex = 8;
			this.txtConnection.Text = "Demo";
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Location = new System.Drawing.Point(56, 17);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(27, 11);
			this.label70.TabIndex = 6;
			this.label70.Text = "口座";
			// 
			// txt口座種別
			// 
			this.txt口座種別.Location = new System.Drawing.Point(83, 14);
			this.txt口座種別.Name = "txt口座種別";
			this.txt口座種別.Size = new System.Drawing.Size(38, 18);
			this.txt口座種別.TabIndex = 7;
			this.txt口座種別.Text = "個人";
			// 
			// txtDB接続先
			// 
			this.txtDB接続先.Location = new System.Drawing.Point(7, 39);
			this.txtDB接続先.Name = "txtDB接続先";
			this.txtDB接続先.Size = new System.Drawing.Size(405, 18);
			this.txtDB接続先.TabIndex = 5;
			this.txtDB接続先.Text = "DB接続先";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(130, 17);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(25, 11);
			this.label5.TabIndex = 1;
			this.label5.Text = "U/N";
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(157, 14);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(85, 18);
			this.txtUsername.TabIndex = 2;
			this.txtUsername.Text = "JDM462923001";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(253, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 11);
			this.label8.TabIndex = 3;
			this.label8.Text = "P/W";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(283, 14);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(56, 18);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.Text = "138";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ToolStripStsLbl});
			this.statusStrip1.Location = new System.Drawing.Point(0, 614);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1309, 22);
			this.statusStrip1.TabIndex = 49;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(114, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// ToolStripStsLbl
			// 
			this.ToolStripStsLbl.Name = "ToolStripStsLbl";
			this.ToolStripStsLbl.Size = new System.Drawing.Size(114, 17);
			this.ToolStripStsLbl.Text = "toolStripStatusLabel2";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(0, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1309, 591);
			this.tabControl1.TabIndex = 50;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.txtロスカット余剰金);
			this.tabPage1.Controls.Add(this.label24);
			this.tabPage1.Controls.Add(this.txt出金可能額で調整したロスカット余剰金);
			this.tabPage1.Controls.Add(this.txt有効証拠金);
			this.tabPage1.Controls.Add(this.label28);
			this.tabPage1.Controls.Add(this.txt取引証拠金_現在);
			this.tabPage1.Controls.Add(this.label12);
			this.tabPage1.Controls.Add(this.txt当日約定金額);
			this.tabPage1.Controls.Add(this.label22);
			this.tabPage1.Controls.Add(this.txt余剰金の割合);
			this.tabPage1.Controls.Add(this.label26);
			this.tabPage1.Controls.Add(this.txt維持証拠金);
			this.tabPage1.Controls.Add(this.label30);
			this.tabPage1.Controls.Add(this.txtOrder状況);
			this.tabPage1.Controls.Add(this.txtAuto);
			this.tabPage1.Controls.Add(this.label61);
			this.tabPage1.Controls.Add(this.txtシステム設定_Trade時間内);
			this.tabPage1.Controls.Add(this.txtログイン表示);
			this.tabPage1.Controls.Add(this.txt取引モード表示);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.dgv注文);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.btn損失開始);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.ForeColor = System.Drawing.Color.White;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1301, 565);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "注文設定　　";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chkRate記録以降の処理をスキップ);
			this.groupBox3.Controls.Add(this.chk余剰金確保の自動ポジションCloseはMSG確認する);
			this.groupBox3.Controls.Add(this.txtn日以上前のポジションは決済);
			this.groupBox3.Controls.Add(this.chkn日以上前のポジション決済をスキップ);
			this.groupBox3.Controls.Add(this.chk余剰金確保の自動ポジションCloseはしない);
			this.groupBox3.Controls.Add(this.chkポジション更新_成行_をスキップ);
			this.groupBox3.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.groupBox3.Location = new System.Drawing.Point(494, 105);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(256, 117);
			this.groupBox3.TabIndex = 147;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "重要設定";
			// 
			// chkRate記録以降の処理をスキップ
			// 
			this.chkRate記録以降の処理をスキップ.AutoSize = true;
			this.chkRate記録以降の処理をスキップ.Checked = true;
			this.chkRate記録以降の処理をスキップ.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkRate記録以降の処理をスキップ.ForeColor = System.Drawing.Color.White;
			this.chkRate記録以降の処理をスキップ.Location = new System.Drawing.Point(7, 13);
			this.chkRate記録以降の処理をスキップ.Name = "chkRate記録以降の処理をスキップ";
			this.chkRate記録以降の処理をスキップ.Size = new System.Drawing.Size(184, 15);
			this.chkRate記録以降の処理をスキップ.TabIndex = 132;
			this.chkRate記録以降の処理をスキップ.Text = "15mデータ生成以降の処理をスキップ";
			this.chkRate記録以降の処理をスキップ.UseVisualStyleBackColor = true;
			// 
			// chk余剰金確保の自動ポジションCloseはMSG確認する
			// 
			this.chk余剰金確保の自動ポジションCloseはMSG確認する.AutoSize = true;
			this.chk余剰金確保の自動ポジションCloseはMSG確認する.ForeColor = System.Drawing.Color.White;
			this.chk余剰金確保の自動ポジションCloseはMSG確認する.Location = new System.Drawing.Point(7, 90);
			this.chk余剰金確保の自動ポジションCloseはMSG確認する.Name = "chk余剰金確保の自動ポジションCloseはMSG確認する";
			this.chk余剰金確保の自動ポジションCloseはMSG確認する.Size = new System.Drawing.Size(247, 15);
			this.chk余剰金確保の自動ポジションCloseはMSG確認する.TabIndex = 131;
			this.chk余剰金確保の自動ポジションCloseはMSG確認する.Text = "余剰金確保の自動ポジションCloseはMSG確認する";
			this.chk余剰金確保の自動ポジションCloseはMSG確認する.UseVisualStyleBackColor = true;
			// 
			// txtn日以上前のポジションは決済
			// 
			this.txtn日以上前のポジションは決済.Location = new System.Drawing.Point(22, 49);
			this.txtn日以上前のポジションは決済.Name = "txtn日以上前のポジションは決済";
			this.txtn日以上前のポジションは決済.Size = new System.Drawing.Size(19, 18);
			this.txtn日以上前のポジションは決済.TabIndex = 130;
			this.txtn日以上前のポジションは決済.Text = "90";
			// 
			// chkn日以上前のポジション決済をスキップ
			// 
			this.chkn日以上前のポジション決済をスキップ.AutoSize = true;
			this.chkn日以上前のポジション決済をスキップ.Checked = true;
			this.chkn日以上前のポジション決済をスキップ.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkn日以上前のポジション決済をスキップ.ForeColor = System.Drawing.Color.White;
			this.chkn日以上前のポジション決済をスキップ.Location = new System.Drawing.Point(7, 52);
			this.chkn日以上前のポジション決済をスキップ.Name = "chkn日以上前のポジション決済をスキップ";
			this.chkn日以上前のポジション決済をスキップ.Size = new System.Drawing.Size(200, 15);
			this.chkn日以上前のポジション決済をスキップ.TabIndex = 129;
			this.chkn日以上前のポジション決済をスキップ.Text = "       日以上前のポジション決済をスキップ";
			this.chkn日以上前のポジション決済をスキップ.UseVisualStyleBackColor = true;
			// 
			// chk余剰金確保の自動ポジションCloseはしない
			// 
			this.chk余剰金確保の自動ポジションCloseはしない.AutoSize = true;
			this.chk余剰金確保の自動ポジションCloseはしない.ForeColor = System.Drawing.Color.White;
			this.chk余剰金確保の自動ポジションCloseはしない.Location = new System.Drawing.Point(7, 73);
			this.chk余剰金確保の自動ポジションCloseはしない.Name = "chk余剰金確保の自動ポジションCloseはしない";
			this.chk余剰金確保の自動ポジションCloseはしない.Size = new System.Drawing.Size(212, 15);
			this.chk余剰金確保の自動ポジションCloseはしない.TabIndex = 128;
			this.chk余剰金確保の自動ポジションCloseはしない.Text = "余剰金確保の自動ポジションCloseはしない";
			this.chk余剰金確保の自動ポジションCloseはしない.UseVisualStyleBackColor = true;
			// 
			// chkポジション更新_成行_をスキップ
			// 
			this.chkポジション更新_成行_をスキップ.AutoSize = true;
			this.chkポジション更新_成行_をスキップ.Checked = true;
			this.chkポジション更新_成行_をスキップ.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkポジション更新_成行_をスキップ.ForeColor = System.Drawing.Color.White;
			this.chkポジション更新_成行_をスキップ.Location = new System.Drawing.Point(7, 32);
			this.chkポジション更新_成行_をスキップ.Name = "chkポジション更新_成行_をスキップ";
			this.chkポジション更新_成行_をスキップ.Size = new System.Drawing.Size(198, 15);
			this.chkポジション更新_成行_をスキップ.TabIndex = 127;
			this.chkポジション更新_成行_をスキップ.Text = "「CTrade.ポジション更新_成行」をスキップ";
			this.chkポジション更新_成行_をスキップ.UseVisualStyleBackColor = true;
			// 
			// txtロスカット余剰金
			// 
			this.txtロスカット余剰金.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtロスカット余剰金.BackColor = System.Drawing.SystemColors.Window;
			this.txtロスカット余剰金.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtロスカット余剰金.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtロスカット余剰金.ForeColor = System.Drawing.Color.Black;
			this.txtロスカット余剰金.Location = new System.Drawing.Point(809, 67);
			this.txtロスカット余剰金.Name = "txtロスカット余剰金";
			this.txtロスカット余剰金.ReadOnly = true;
			this.txtロスカット余剰金.Size = new System.Drawing.Size(65, 18);
			this.txtロスカット余剰金.TabIndex = 145;
			this.txtロスカット余剰金.TabStop = false;
			this.txtロスカット余剰金.Text = "0";
			this.txtロスカット余剰金.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label24
			// 
			this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label24.ForeColor = System.Drawing.SystemColors.Info;
			this.label24.Location = new System.Drawing.Point(905, 70);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(179, 11);
			this.label24.TabIndex = 144;
			this.label24.Text = "出金可能額で調整したロスカット余剰金";
			// 
			// txt出金可能額で調整したロスカット余剰金
			// 
			this.txt出金可能額で調整したロスカット余剰金.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt出金可能額で調整したロスカット余剰金.BackColor = System.Drawing.SystemColors.Window;
			this.txt出金可能額で調整したロスカット余剰金.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt出金可能額で調整したロスカット余剰金.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txt出金可能額で調整したロスカット余剰金.ForeColor = System.Drawing.Color.Black;
			this.txt出金可能額で調整したロスカット余剰金.Location = new System.Drawing.Point(1084, 65);
			this.txt出金可能額で調整したロスカット余剰金.Name = "txt出金可能額で調整したロスカット余剰金";
			this.txt出金可能額で調整したロスカット余剰金.ReadOnly = true;
			this.txt出金可能額で調整したロスカット余剰金.Size = new System.Drawing.Size(65, 18);
			this.txt出金可能額で調整したロスカット余剰金.TabIndex = 143;
			this.txt出金可能額で調整したロスカット余剰金.TabStop = false;
			this.txt出金可能額で調整したロスカット余剰金.Text = "0";
			this.txt出金可能額で調整したロスカット余剰金.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txt有効証拠金
			// 
			this.txt有効証拠金.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt有効証拠金.BackColor = System.Drawing.SystemColors.Window;
			this.txt有効証拠金.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt有効証拠金.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txt有効証拠金.ForeColor = System.Drawing.Color.Black;
			this.txt有効証拠金.Location = new System.Drawing.Point(1084, 47);
			this.txt有効証拠金.Name = "txt有効証拠金";
			this.txt有効証拠金.ReadOnly = true;
			this.txt有効証拠金.Size = new System.Drawing.Size(65, 18);
			this.txt有効証拠金.TabIndex = 142;
			this.txt有効証拠金.TabStop = false;
			this.txt有効証拠金.Text = "0";
			this.txt有効証拠金.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label28
			// 
			this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label28.ForeColor = System.Drawing.SystemColors.Info;
			this.label28.Location = new System.Drawing.Point(1023, 50);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(60, 11);
			this.label28.TabIndex = 141;
			this.label28.Text = "有効証拠金";
			// 
			// txt取引証拠金_現在
			// 
			this.txt取引証拠金_現在.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt取引証拠金_現在.BackColor = System.Drawing.SystemColors.Window;
			this.txt取引証拠金_現在.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt取引証拠金_現在.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txt取引証拠金_現在.ForeColor = System.Drawing.Color.Black;
			this.txt取引証拠金_現在.Location = new System.Drawing.Point(948, 48);
			this.txt取引証拠金_現在.Name = "txt取引証拠金_現在";
			this.txt取引証拠金_現在.ReadOnly = true;
			this.txt取引証拠金_現在.Size = new System.Drawing.Size(65, 18);
			this.txt取引証拠金_現在.TabIndex = 140;
			this.txt取引証拠金_現在.TabStop = false;
			this.txt取引証拠金_現在.Text = "0";
			this.txt取引証拠金_現在.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label12.ForeColor = System.Drawing.SystemColors.Info;
			this.label12.Location = new System.Drawing.Point(855, 52);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(94, 11);
			this.label12.TabIndex = 139;
			this.label12.Text = "取引証拠金（現在）";
			// 
			// txt当日約定金額
			// 
			this.txt当日約定金額.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt当日約定金額.BackColor = System.Drawing.SystemColors.Window;
			this.txt当日約定金額.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt当日約定金額.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txt当日約定金額.ForeColor = System.Drawing.Color.Black;
			this.txt当日約定金額.Location = new System.Drawing.Point(1227, 43);
			this.txt当日約定金額.Name = "txt当日約定金額";
			this.txt当日約定金額.ReadOnly = true;
			this.txt当日約定金額.Size = new System.Drawing.Size(66, 18);
			this.txt当日約定金額.TabIndex = 129;
			this.txt当日約定金額.TabStop = false;
			this.txt当日約定金額.Text = "0";
			this.txt当日約定金額.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label22
			// 
			this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label22.ForeColor = System.Drawing.SystemColors.Info;
			this.label22.Location = new System.Drawing.Point(1155, 47);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(71, 11);
			this.label22.TabIndex = 128;
			this.label22.Text = "当日約定金額";
			// 
			// txt余剰金の割合
			// 
			this.txt余剰金の割合.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt余剰金の割合.BackColor = System.Drawing.SystemColors.Window;
			this.txt余剰金の割合.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt余剰金の割合.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txt余剰金の割合.ForeColor = System.Drawing.Color.Black;
			this.txt余剰金の割合.Location = new System.Drawing.Point(1227, 79);
			this.txt余剰金の割合.Name = "txt余剰金の割合";
			this.txt余剰金の割合.ReadOnly = true;
			this.txt余剰金の割合.Size = new System.Drawing.Size(65, 18);
			this.txt余剰金の割合.TabIndex = 127;
			this.txt余剰金の割合.TabStop = false;
			this.txt余剰金の割合.Text = "0";
			this.txt余剰金の割合.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label26
			// 
			this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label26.ForeColor = System.Drawing.SystemColors.Info;
			this.label26.Location = new System.Drawing.Point(1158, 82);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(69, 11);
			this.label26.TabIndex = 126;
			this.label26.Text = "余剰金の割合";
			// 
			// txt維持証拠金
			// 
			this.txt維持証拠金.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt維持証拠金.BackColor = System.Drawing.SystemColors.Window;
			this.txt維持証拠金.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt維持証拠金.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txt維持証拠金.ForeColor = System.Drawing.Color.Black;
			this.txt維持証拠金.Location = new System.Drawing.Point(1227, 61);
			this.txt維持証拠金.Name = "txt維持証拠金";
			this.txt維持証拠金.ReadOnly = true;
			this.txt維持証拠金.Size = new System.Drawing.Size(65, 18);
			this.txt維持証拠金.TabIndex = 125;
			this.txt維持証拠金.TabStop = false;
			this.txt維持証拠金.Text = "0";
			this.txt維持証拠金.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label30
			// 
			this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label30.ForeColor = System.Drawing.SystemColors.Info;
			this.label30.Location = new System.Drawing.Point(1167, 64);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(60, 11);
			this.label30.TabIndex = 124;
			this.label30.Text = "維持証拠金";
			// 
			// txtOrder状況
			// 
			this.txtOrder状況.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrder状況.Location = new System.Drawing.Point(793, 18);
			this.txtOrder状況.Name = "txtOrder状況";
			this.txtOrder状況.Size = new System.Drawing.Size(179, 19);
			this.txtOrder状況.TabIndex = 103;
			this.txtOrder状況.Text = "取引中 or 取引停止中(事由)";
			// 
			// txtAuto
			// 
			this.txtAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAuto.BackColor = System.Drawing.SystemColors.Window;
			this.txtAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAuto.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.txtAuto.Location = new System.Drawing.Point(981, 6);
			this.txtAuto.Name = "txtAuto";
			this.txtAuto.ReadOnly = true;
			this.txtAuto.Size = new System.Drawing.Size(56, 31);
			this.txtAuto.TabIndex = 108;
			this.txtAuto.TabStop = false;
			this.txtAuto.Text = "Auto";
			this.txtAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label61
			// 
			this.label61.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label61.AutoSize = true;
			this.label61.ForeColor = System.Drawing.Color.White;
			this.label61.Location = new System.Drawing.Point(667, 24);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(70, 12);
			this.label61.TabIndex = 107;
			this.label61.Text = "Trade時間内";
			// 
			// txtシステム設定_Trade時間内
			// 
			this.txtシステム設定_Trade時間内.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtシステム設定_Trade時間内.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_Trade時間内.ForeColor = System.Drawing.Color.Black;
			this.txtシステム設定_Trade時間内.Location = new System.Drawing.Point(739, 18);
			this.txtシステム設定_Trade時間内.Name = "txtシステム設定_Trade時間内";
			this.txtシステム設定_Trade時間内.ReadOnly = true;
			this.txtシステム設定_Trade時間内.Size = new System.Drawing.Size(51, 19);
			this.txtシステム設定_Trade時間内.TabIndex = 106;
			// 
			// txtログイン表示
			// 
			this.txtログイン表示.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtログイン表示.BackColor = System.Drawing.SystemColors.Window;
			this.txtログイン表示.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtログイン表示.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtログイン表示.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.txtログイン表示.Location = new System.Drawing.Point(1038, 6);
			this.txtログイン表示.Name = "txtログイン表示";
			this.txtログイン表示.ReadOnly = true;
			this.txtログイン表示.Size = new System.Drawing.Size(120, 31);
			this.txtログイン表示.TabIndex = 105;
			this.txtログイン表示.TabStop = false;
			this.txtログイン表示.Text = "ログイン中";
			this.txtログイン表示.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txt取引モード表示
			// 
			this.txt取引モード表示.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txt取引モード表示.BackColor = System.Drawing.SystemColors.Window;
			this.txt取引モード表示.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txt取引モード表示.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txt取引モード表示.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.txt取引モード表示.Location = new System.Drawing.Point(1159, 6);
			this.txt取引モード表示.Name = "txt取引モード表示";
			this.txt取引モード表示.ReadOnly = true;
			this.txt取引モード表示.Size = new System.Drawing.Size(135, 31);
			this.txt取引モード表示.TabIndex = 104;
			this.txt取引モード表示.TabStop = false;
			this.txt取引モード表示.Text = "自動取引中";
			this.txt取引モード表示.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tabPage2.Controls.Add(this.txt基準注文単位);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.groupBox8);
			this.tabPage2.Controls.Add(this.label67);
			this.tabPage2.Controls.Add(this.txtログフォルダ);
			this.tabPage2.Controls.Add(this.label66);
			this.tabPage2.Controls.Add(this.label21);
			this.tabPage2.Controls.Add(this.txtシステム設定_日付はn時くぎり);
			this.tabPage2.ForeColor = System.Drawing.Color.White;
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1301, 565);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "システム設定　";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.txtシステム設定_秒);
			this.groupBox8.Controls.Add(this.txtシステム設定_分);
			this.groupBox8.Controls.Add(this.txtシステム設定_曜日);
			this.groupBox8.Controls.Add(this.txtシステム設定_時);
			this.groupBox8.Controls.Add(this.txtシステム設定_日);
			this.groupBox8.Controls.Add(this.txtシステム設定_月);
			this.groupBox8.Controls.Add(this.txtシステム設定_年);
			this.groupBox8.ForeColor = System.Drawing.Color.White;
			this.groupBox8.Location = new System.Drawing.Point(8, 6);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new System.Drawing.Size(318, 49);
			this.groupBox8.TabIndex = 110;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "システム日時曜日";
			// 
			// txtシステム設定_秒
			// 
			this.txtシステム設定_秒.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_秒.Location = new System.Drawing.Point(166, 18);
			this.txtシステム設定_秒.Name = "txtシステム設定_秒";
			this.txtシステム設定_秒.ReadOnly = true;
			this.txtシステム設定_秒.Size = new System.Drawing.Size(26, 19);
			this.txtシステム設定_秒.TabIndex = 80;
			// 
			// txtシステム設定_分
			// 
			this.txtシステム設定_分.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_分.Location = new System.Drawing.Point(137, 18);
			this.txtシステム設定_分.Name = "txtシステム設定_分";
			this.txtシステム設定_分.ReadOnly = true;
			this.txtシステム設定_分.Size = new System.Drawing.Size(26, 19);
			this.txtシステム設定_分.TabIndex = 79;
			// 
			// txtシステム設定_曜日
			// 
			this.txtシステム設定_曜日.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_曜日.Location = new System.Drawing.Point(198, 18);
			this.txtシステム設定_曜日.Name = "txtシステム設定_曜日";
			this.txtシステム設定_曜日.ReadOnly = true;
			this.txtシステム設定_曜日.Size = new System.Drawing.Size(76, 19);
			this.txtシステム設定_曜日.TabIndex = 6;
			// 
			// txtシステム設定_時
			// 
			this.txtシステム設定_時.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_時.Location = new System.Drawing.Point(108, 18);
			this.txtシステム設定_時.Name = "txtシステム設定_時";
			this.txtシステム設定_時.ReadOnly = true;
			this.txtシステム設定_時.Size = new System.Drawing.Size(26, 19);
			this.txtシステム設定_時.TabIndex = 5;
			// 
			// txtシステム設定_日
			// 
			this.txtシステム設定_日.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_日.Location = new System.Drawing.Point(82, 18);
			this.txtシステム設定_日.Name = "txtシステム設定_日";
			this.txtシステム設定_日.ReadOnly = true;
			this.txtシステム設定_日.Size = new System.Drawing.Size(21, 19);
			this.txtシステム設定_日.TabIndex = 4;
			// 
			// txtシステム設定_月
			// 
			this.txtシステム設定_月.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_月.Location = new System.Drawing.Point(55, 18);
			this.txtシステム設定_月.Name = "txtシステム設定_月";
			this.txtシステム設定_月.ReadOnly = true;
			this.txtシステム設定_月.Size = new System.Drawing.Size(21, 19);
			this.txtシステム設定_月.TabIndex = 3;
			// 
			// txtシステム設定_年
			// 
			this.txtシステム設定_年.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_年.Location = new System.Drawing.Point(8, 18);
			this.txtシステム設定_年.Name = "txtシステム設定_年";
			this.txtシステム設定_年.ReadOnly = true;
			this.txtシステム設定_年.Size = new System.Drawing.Size(42, 19);
			this.txtシステム設定_年.TabIndex = 2;
			// 
			// label67
			// 
			this.label67.AutoSize = true;
			this.label67.Location = new System.Drawing.Point(69, 101);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(41, 12);
			this.label67.TabIndex = 93;
			this.label67.Text = "時くぎり";
			// 
			// txtログフォルダ
			// 
			this.txtログフォルダ.BackColor = System.Drawing.SystemColors.Window;
			this.txtログフォルダ.Location = new System.Drawing.Point(69, 71);
			this.txtログフォルダ.Name = "txtログフォルダ";
			this.txtログフォルダ.ReadOnly = true;
			this.txtログフォルダ.Size = new System.Drawing.Size(167, 19);
			this.txtログフォルダ.TabIndex = 89;
			this.txtログフォルダ.Text = "C:\\FX\\log";
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(7, 100);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(39, 12);
			this.label66.TabIndex = 92;
			this.label66.Text = "日付は";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(7, 74);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(58, 12);
			this.label21.TabIndex = 90;
			this.label21.Text = "ログフォルダ";
			// 
			// txtシステム設定_日付はn時くぎり
			// 
			this.txtシステム設定_日付はn時くぎり.BackColor = System.Drawing.SystemColors.Window;
			this.txtシステム設定_日付はn時くぎり.Location = new System.Drawing.Point(50, 97);
			this.txtシステム設定_日付はn時くぎり.Name = "txtシステム設定_日付はn時くぎり";
			this.txtシステム設定_日付はn時くぎり.ReadOnly = true;
			this.txtシステム設定_日付はn時くぎり.Size = new System.Drawing.Size(15, 19);
			this.txtシステム設定_日付はn時くぎり.TabIndex = 91;
			this.txtシステム設定_日付はn時くぎり.Text = "6";
			// 
			// timer_日時曜日更新
			// 
			this.timer_日時曜日更新.Interval = 1000;
			this.timer_日時曜日更新.Tick += new System.EventHandler(this.timer_日時曜日更新_1sec_Tick);
			// 
			// timer_Order
			// 
			this.timer_Order.Interval = 600000;
			this.timer_Order.Tick += new System.EventHandler(this.timer_10min_Tick);
			// 
			// txt基準注文単位
			// 
			this.txt基準注文単位.Location = new System.Drawing.Point(461, 20);
			this.txt基準注文単位.Name = "txt基準注文単位";
			this.txt基準注文単位.Size = new System.Drawing.Size(24, 19);
			this.txt基準注文単位.TabIndex = 112;
			this.txt基準注文単位.Text = "1";
			this.txt基準注文単位.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(379, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 12);
			this.label1.TabIndex = 111;
			this.label1.Text = "基準注文単位：";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(1309, 636);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tabControl1);
			this.ForeColor = System.Drawing.SystemColors.InfoText;
			this.Name = "Main";
			this.Text = "Siamese";
			this.Load += new System.EventHandler(this.FMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgv注文)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn損失開始;
        private System.Windows.Forms.DataGridView dgv注文;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConnection;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox txt口座種別;
        private System.Windows.Forms.TextBox txtDB接続先;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn 通貨;
        private System.Windows.Forms.DataGridViewTextBoxColumn 取引状況;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStsLbl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtログフォルダ;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtシステム設定_日付はn時くぎり;
        private System.Windows.Forms.TextBox txtOrder状況;
        private System.Windows.Forms.TextBox txtAuto;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.TextBox txtシステム設定_Trade時間内;
        private System.Windows.Forms.TextBox txtログイン表示;
        private System.Windows.Forms.TextBox txt取引モード表示;
        private System.Windows.Forms.Timer timer_日時曜日更新;
		private System.Windows.Forms.Timer timer_Order;
        private System.Windows.Forms.TextBox txt当日約定金額;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt余剰金の割合;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt維持証拠金;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtロスカット余剰金;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txt出金可能額で調整したロスカット余剰金;
        private System.Windows.Forms.TextBox txt有効証拠金;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txt取引証拠金_現在;
        private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.TextBox txtシステム設定_秒;
		private System.Windows.Forms.TextBox txtシステム設定_分;
		private System.Windows.Forms.TextBox txtシステム設定_曜日;
		private System.Windows.Forms.TextBox txtシステム設定_時;
		private System.Windows.Forms.TextBox txtシステム設定_日;
		private System.Windows.Forms.TextBox txtシステム設定_月;
		private System.Windows.Forms.TextBox txtシステム設定_年;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkRate記録以降の処理をスキップ;
		private System.Windows.Forms.CheckBox chk余剰金確保の自動ポジションCloseはMSG確認する;
		private System.Windows.Forms.TextBox txtn日以上前のポジションは決済;
		private System.Windows.Forms.CheckBox chkn日以上前のポジション決済をスキップ;
		private System.Windows.Forms.CheckBox chk余剰金確保の自動ポジションCloseはしない;
		private System.Windows.Forms.CheckBox chkポジション更新_成行_をスキップ;
		private System.Windows.Forms.TextBox txt基準注文単位;
		private System.Windows.Forms.Label label1;
    }
}

