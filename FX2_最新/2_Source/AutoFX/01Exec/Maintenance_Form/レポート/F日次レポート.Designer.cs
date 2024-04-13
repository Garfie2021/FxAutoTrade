namespace Maintenance_Form
{
    partial class F日次レポート
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
            this.dtp日付 = new System.Windows.Forms.DateTimePicker();
            this.btnレポート表示 = new System.Windows.Forms.Button();
            this.btnレポートファイル保存 = new System.Windows.Forms.Button();
            this.chkSelect想定売買タイミングSwap判定無しを表示する = new System.Windows.Forms.CheckBox();
            this.btnレポート表示_DGV = new System.Windows.Forms.Button();
            this.btnレポート表示_通貨ペア別_DGV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb通貨ペア = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.txtコマンドライン = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt口座 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDB接続先 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnレポートメール送信 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtp日付
            // 
            this.dtp日付.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp日付.Location = new System.Drawing.Point(12, 134);
            this.dtp日付.Name = "dtp日付";
            this.dtp日付.Size = new System.Drawing.Size(144, 22);
            this.dtp日付.TabIndex = 0;
            // 
            // btnレポート表示
            // 
            this.btnレポート表示.Location = new System.Drawing.Point(220, 225);
            this.btnレポート表示.Margin = new System.Windows.Forms.Padding(4);
            this.btnレポート表示.Name = "btnレポート表示";
            this.btnレポート表示.Size = new System.Drawing.Size(200, 36);
            this.btnレポート表示.TabIndex = 16;
            this.btnレポート表示.Text = "レポート表示（Text）";
            this.btnレポート表示.UseVisualStyleBackColor = true;
            this.btnレポート表示.Click += new System.EventHandler(this.btnレポート表示_Click);
            // 
            // btnレポートファイル保存
            // 
            this.btnレポートファイル保存.Location = new System.Drawing.Point(428, 225);
            this.btnレポートファイル保存.Margin = new System.Windows.Forms.Padding(4);
            this.btnレポートファイル保存.Name = "btnレポートファイル保存";
            this.btnレポートファイル保存.Size = new System.Drawing.Size(221, 36);
            this.btnレポートファイル保存.TabIndex = 17;
            this.btnレポートファイル保存.Text = "レポートファイル保存（Text）";
            this.btnレポートファイル保存.UseVisualStyleBackColor = true;
            this.btnレポートファイル保存.Click += new System.EventHandler(this.btnレポートファイル保存_Click);
            // 
            // chkSelect想定売買タイミングSwap判定無しを表示する
            // 
            this.chkSelect想定売買タイミングSwap判定無しを表示する.AutoSize = true;
            this.chkSelect想定売買タイミングSwap判定無しを表示する.ForeColor = System.Drawing.Color.White;
            this.chkSelect想定売買タイミングSwap判定無しを表示する.Location = new System.Drawing.Point(21, 188);
            this.chkSelect想定売買タイミングSwap判定無しを表示する.Name = "chkSelect想定売買タイミングSwap判定無しを表示する";
            this.chkSelect想定売買タイミングSwap判定無しを表示する.Size = new System.Drawing.Size(368, 19);
            this.chkSelect想定売買タイミングSwap判定無しを表示する.TabIndex = 18;
            this.chkSelect想定売買タイミングSwap判定無しを表示する.Text = "【Select想定売買タイミング　Swap判定無し】 を表示する";
            this.chkSelect想定売買タイミングSwap判定無しを表示する.UseVisualStyleBackColor = true;
            // 
            // btnレポート表示_DGV
            // 
            this.btnレポート表示_DGV.Location = new System.Drawing.Point(12, 225);
            this.btnレポート表示_DGV.Margin = new System.Windows.Forms.Padding(4);
            this.btnレポート表示_DGV.Name = "btnレポート表示_DGV";
            this.btnレポート表示_DGV.Size = new System.Drawing.Size(200, 36);
            this.btnレポート表示_DGV.TabIndex = 19;
            this.btnレポート表示_DGV.Text = "レポート表示（DGV）";
            this.btnレポート表示_DGV.UseVisualStyleBackColor = true;
            this.btnレポート表示_DGV.Click += new System.EventHandler(this.btnレポート表示_DGV_Click);
            // 
            // btnレポート表示_通貨ペア別_DGV
            // 
            this.btnレポート表示_通貨ペア別_DGV.ForeColor = System.Drawing.Color.Black;
            this.btnレポート表示_通貨ペア別_DGV.Location = new System.Drawing.Point(12, 409);
            this.btnレポート表示_通貨ペア別_DGV.Margin = new System.Windows.Forms.Padding(4);
            this.btnレポート表示_通貨ペア別_DGV.Name = "btnレポート表示_通貨ペア別_DGV";
            this.btnレポート表示_通貨ペア別_DGV.Size = new System.Drawing.Size(346, 36);
            this.btnレポート表示_通貨ペア別_DGV.TabIndex = 20;
            this.btnレポート表示_通貨ペア別_DGV.Text = "レポート表示（通貨ペア別時系列）";
            this.btnレポート表示_通貨ペア別_DGV.UseVisualStyleBackColor = true;
            this.btnレポート表示_通貨ペア別_DGV.Click += new System.EventHandler(this.btnレポート表示_通貨ペア別_DGV_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(20, 338);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "通貨ペア";
            // 
            // cmb通貨ペア
            // 
            this.cmb通貨ペア.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb通貨ペア.FormattingEnabled = true;
            this.cmb通貨ペア.Location = new System.Drawing.Point(83, 334);
            this.cmb通貨ペア.Margin = new System.Windows.Forms.Padding(4);
            this.cmb通貨ペア.Name = "cmb通貨ペア";
            this.cmb通貨ペア.Size = new System.Drawing.Size(160, 23);
            this.cmb通貨ペア.TabIndex = 22;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(21, 373);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 19);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.Text = "table A";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(100, 373);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(74, 19);
            this.checkBox2.TabIndex = 25;
            this.checkBox2.Text = "table B";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.ForeColor = System.Drawing.Color.White;
            this.checkBox3.Location = new System.Drawing.Point(179, 374);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(74, 19);
            this.checkBox3.TabIndex = 26;
            this.checkBox3.Text = "table C";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.ForeColor = System.Drawing.Color.White;
            this.checkBox4.Location = new System.Drawing.Point(258, 374);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(74, 19);
            this.checkBox4.TabIndex = 27;
            this.checkBox4.Text = "table D";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // txtコマンドライン
            // 
            this.txtコマンドライン.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtコマンドライン.Location = new System.Drawing.Point(104, 69);
            this.txtコマンドライン.Name = "txtコマンドライン";
            this.txtコマンドライン.Size = new System.Drawing.Size(698, 22);
            this.txtコマンドライン.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "コマンドライン：";
            // 
            // txt口座
            // 
            this.txt口座.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt口座.Location = new System.Drawing.Point(104, 39);
            this.txt口座.Name = "txt口座";
            this.txt口座.Size = new System.Drawing.Size(698, 22);
            this.txt口座.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 40;
            this.label1.Text = "口座：";
            // 
            // txtDB接続先
            // 
            this.txtDB接続先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDB接続先.Location = new System.Drawing.Point(104, 9);
            this.txtDB接続先.Name = "txtDB接続先";
            this.txtDB接続先.Size = new System.Drawing.Size(698, 22);
            this.txtDB接続先.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "DB接続先：";
            // 
            // btnレポートメール送信
            // 
            this.btnレポートメール送信.Location = new System.Drawing.Point(13, 267);
            this.btnレポートメール送信.Margin = new System.Windows.Forms.Padding(4);
            this.btnレポートメール送信.Name = "btnレポートメール送信";
            this.btnレポートメール送信.Size = new System.Drawing.Size(200, 36);
            this.btnレポートメール送信.TabIndex = 44;
            this.btnレポートメール送信.Text = "レポート表示（メール送信）";
            this.btnレポートメール送信.UseVisualStyleBackColor = true;
            this.btnレポートメール送信.Click += new System.EventHandler(this.btnレポートメール送信_Click);
            // 
            // F日次レポート
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(823, 485);
            this.Controls.Add(this.btnレポートメール送信);
            this.Controls.Add(this.txtコマンドライン);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt口座);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDB接続先);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb通貨ペア);
            this.Controls.Add(this.btnレポート表示_通貨ペア別_DGV);
            this.Controls.Add(this.btnレポート表示_DGV);
            this.Controls.Add(this.chkSelect想定売買タイミングSwap判定無しを表示する);
            this.Controls.Add(this.btnレポートファイル保存);
            this.Controls.Add(this.btnレポート表示);
            this.Controls.Add(this.dtp日付);
            this.Name = "F日次レポート";
            this.Load += new System.EventHandler(this.F日次レポート_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp日付;
        private System.Windows.Forms.Button btnレポート表示;
        private System.Windows.Forms.Button btnレポートファイル保存;
        private System.Windows.Forms.CheckBox chkSelect想定売買タイミングSwap判定無しを表示する;
        private System.Windows.Forms.Button btnレポート表示_DGV;
        private System.Windows.Forms.Button btnレポート表示_通貨ペア別_DGV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb通貨ペア;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.TextBox txtコマンドライン;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt口座;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDB接続先;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnレポートメール送信;
    }
}