namespace SwapCollect
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
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.chk自動開始 = new System.Windows.Forms.CheckBox();
            this.btn手動実行 = new System.Windows.Forms.Button();
            this.label70 = new System.Windows.Forms.Label();
            this.txtステータス = new System.Windows.Forms.TextBox();
            this.txtOandaAccountId売りポジション用口座A = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOandaAccountId買いポジション用口座A = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDB接続先 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt売りポジション用口座ANo = new System.Windows.Forms.TextBox();
            this.txt買いポジション用口座ANo = new System.Windows.Forms.TextBox();
            this.txt買いポジション用口座BNo = new System.Windows.Forms.TextBox();
            this.txtOandaAccountId買いポジション用口座B = new System.Windows.Forms.TextBox();
            this.txt売りポジション用口座BNo = new System.Windows.Forms.TextBox();
            this.txtOandaAccountId売りポジション用口座B = new System.Windows.Forms.TextBox();
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo = new System.Windows.Forms.Button();
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal = new System.Windows.Forms.Button();
            this.btnTimer手動実行 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn日次レポート送信 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtデータフォルダ = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chk自動開始
            // 
            this.chk自動開始.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk自動開始.AutoSize = true;
            this.chk自動開始.ForeColor = System.Drawing.Color.White;
            this.chk自動開始.Location = new System.Drawing.Point(653, 42);
            this.chk自動開始.Margin = new System.Windows.Forms.Padding(4);
            this.chk自動開始.Name = "chk自動開始";
            this.chk自動開始.Size = new System.Drawing.Size(89, 19);
            this.chk自動開始.TabIndex = 133;
            this.chk自動開始.Text = "自動開始";
            this.chk自動開始.UseVisualStyleBackColor = true;
            this.chk自動開始.CheckedChanged += new System.EventHandler(this.chk自動開始_CheckedChanged);
            // 
            // btn手動実行
            // 
            this.btn手動実行.BackColor = System.Drawing.SystemColors.Control;
            this.btn手動実行.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn手動実行.Location = new System.Drawing.Point(13, 232);
            this.btn手動実行.Margin = new System.Windows.Forms.Padding(4);
            this.btn手動実行.Name = "btn手動実行";
            this.btn手動実行.Size = new System.Drawing.Size(366, 29);
            this.btn手動実行.TabIndex = 153;
            this.btn手動実行.Text = "収集手動実行";
            this.btn手動実行.UseVisualStyleBackColor = false;
            this.btn手動実行.Click += new System.EventHandler(this.btn手動実行_Click);
            // 
            // label70
            // 
            this.label70.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label70.AutoSize = true;
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(570, 15);
            this.label70.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(62, 15);
            this.label70.TabIndex = 154;
            this.label70.Text = "ステータス";
            // 
            // txtステータス
            // 
            this.txtステータス.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtステータス.Location = new System.Drawing.Point(637, 11);
            this.txtステータス.Margin = new System.Windows.Forms.Padding(4);
            this.txtステータス.Name = "txtステータス";
            this.txtステータス.Size = new System.Drawing.Size(105, 22);
            this.txtステータス.TabIndex = 155;
            this.txtステータス.Text = "停止中";
            // 
            // txtOandaAccountId売りポジション用口座A
            // 
            this.txtOandaAccountId売りポジション用口座A.Location = new System.Drawing.Point(305, 72);
            this.txtOandaAccountId売りポジション用口座A.Name = "txtOandaAccountId売りポジション用口座A";
            this.txtOandaAccountId売りポジション用口座A.Size = new System.Drawing.Size(89, 22);
            this.txtOandaAccountId売りポジション用口座A.TabIndex = 161;
            this.txtOandaAccountId売りポジション用口座A.Text = "111";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 15);
            this.label6.TabIndex = 160;
            this.label6.Text = "OandaAccountId 売りポジション用口座：";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(127, 141);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(588, 22);
            this.txtAccessToken.TabIndex = 159;
            this.txtAccessToken.Text = "111 ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 158;
            this.label4.Text = "Access Token：";
            // 
            // txtOandaAccountId買いポジション用口座A
            // 
            this.txtOandaAccountId買いポジション用口座A.Location = new System.Drawing.Point(305, 15);
            this.txtOandaAccountId買いポジション用口座A.Name = "txtOandaAccountId買いポジション用口座A";
            this.txtOandaAccountId買いポジション用口座A.Size = new System.Drawing.Size(89, 22);
            this.txtOandaAccountId買いポジション用口座A.TabIndex = 157;
            this.txtOandaAccountId買いポジション用口座A.Text = "111";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 15);
            this.label3.TabIndex = 156;
            this.label3.Text = "OandaAccountId 買いポジション用口座：";
            // 
            // txtDB接続先
            // 
            this.txtDB接続先.Location = new System.Drawing.Point(127, 169);
            this.txtDB接続先.Name = "txtDB接続先";
            this.txtDB接続先.Size = new System.Drawing.Size(588, 22);
            this.txtDB接続先.TabIndex = 163;
            this.txtDB接続先.Text = "Data Source=1111.5;Initial Catalog=FX_DemoA;User ID=sa;Password=1111";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 162;
            this.label1.Text = "DB接続先：";
            // 
            // txt売りポジション用口座ANo
            // 
            this.txt売りポジション用口座ANo.Location = new System.Drawing.Point(269, 72);
            this.txt売りポジション用口座ANo.Name = "txt売りポジション用口座ANo";
            this.txt売りポジション用口座ANo.Size = new System.Drawing.Size(30, 22);
            this.txt売りポジション用口座ANo.TabIndex = 165;
            this.txt売りポジション用口座ANo.Text = "3";
            // 
            // txt買いポジション用口座ANo
            // 
            this.txt買いポジション用口座ANo.Location = new System.Drawing.Point(269, 15);
            this.txt買いポジション用口座ANo.Name = "txt買いポジション用口座ANo";
            this.txt買いポジション用口座ANo.Size = new System.Drawing.Size(30, 22);
            this.txt買いポジション用口座ANo.TabIndex = 164;
            this.txt買いポジション用口座ANo.Text = "1";
            // 
            // txt買いポジション用口座BNo
            // 
            this.txt買いポジション用口座BNo.Location = new System.Drawing.Point(269, 43);
            this.txt買いポジション用口座BNo.Name = "txt買いポジション用口座BNo";
            this.txt買いポジション用口座BNo.Size = new System.Drawing.Size(30, 22);
            this.txt買いポジション用口座BNo.TabIndex = 167;
            this.txt買いポジション用口座BNo.Text = "2";
            // 
            // txtOandaAccountId買いポジション用口座B
            // 
            this.txtOandaAccountId買いポジション用口座B.Location = new System.Drawing.Point(305, 43);
            this.txtOandaAccountId買いポジション用口座B.Name = "txtOandaAccountId買いポジション用口座B";
            this.txtOandaAccountId買いポジション用口座B.Size = new System.Drawing.Size(89, 22);
            this.txtOandaAccountId買いポジション用口座B.TabIndex = 166;
            this.txtOandaAccountId買いポジション用口座B.Text = "111";
            // 
            // txt売りポジション用口座BNo
            // 
            this.txt売りポジション用口座BNo.Location = new System.Drawing.Point(269, 100);
            this.txt売りポジション用口座BNo.Name = "txt売りポジション用口座BNo";
            this.txt売りポジション用口座BNo.Size = new System.Drawing.Size(30, 22);
            this.txt売りポジション用口座BNo.TabIndex = 169;
            this.txt売りポジション用口座BNo.Text = "4";
            // 
            // txtOandaAccountId売りポジション用口座B
            // 
            this.txtOandaAccountId売りポジション用口座B.Location = new System.Drawing.Point(305, 100);
            this.txtOandaAccountId売りポジション用口座B.Name = "txtOandaAccountId売りポジション用口座B";
            this.txtOandaAccountId売りポジション用口座B.Size = new System.Drawing.Size(89, 22);
            this.txtOandaAccountId売りポジション用口座B.TabIndex = 168;
            this.txtOandaAccountId売りポジション用口座B.Text = "111";
            // 
            // btn手動実行_spInsertSwap手動登録_Day1_toDemo
            // 
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.BackColor = System.Drawing.SystemColors.Control;
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.Location = new System.Drawing.Point(13, 269);
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.Margin = new System.Windows.Forms.Padding(4);
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.Name = "btn手動実行_spInsertSwap手動登録_Day1_toDemo";
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.Size = new System.Drawing.Size(366, 29);
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.TabIndex = 170;
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.Text = "手動実行_spInsertSwap手動登録_Day1_toDemo";
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.UseVisualStyleBackColor = false;
            this.btn手動実行_spInsertSwap手動登録_Day1_toDemo.Click += new System.EventHandler(this.btn手動実行_spInsertSwap手動登録_Day1_toDemo_Click);
            // 
            // btn手動実行_spInsertSwap手動登録_Day1_toReal
            // 
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.BackColor = System.Drawing.SystemColors.Control;
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.Location = new System.Drawing.Point(13, 306);
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.Margin = new System.Windows.Forms.Padding(4);
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.Name = "btn手動実行_spInsertSwap手動登録_Day1_toReal";
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.Size = new System.Drawing.Size(366, 29);
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.TabIndex = 171;
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.Text = "手動実行_spInsertSwap手動登録_Day1_toReal";
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.UseVisualStyleBackColor = false;
            this.btn手動実行_spInsertSwap手動登録_Day1_toReal.Click += new System.EventHandler(this.btn手動実行_spInsertSwap手動登録_Day1_toReal_Click);
            // 
            // btnTimer手動実行
            // 
            this.btnTimer手動実行.BackColor = System.Drawing.SystemColors.Control;
            this.btnTimer手動実行.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnTimer手動実行.Location = new System.Drawing.Point(13, 343);
            this.btnTimer手動実行.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimer手動実行.Name = "btnTimer手動実行";
            this.btnTimer手動実行.Size = new System.Drawing.Size(366, 29);
            this.btnTimer手動実行.TabIndex = 172;
            this.btnTimer手動実行.Text = "Timer手動実行";
            this.btnTimer手動実行.UseVisualStyleBackColor = false;
            this.btnTimer手動実行.Click += new System.EventHandler(this.btnTimer手動実行_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtデータフォルダ);
            this.groupBox1.Controls.Add(this.btn日次レポート送信);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 113);
            this.groupBox1.TabIndex = 179;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "レポートメール";
            // 
            // btn日次レポート送信
            // 
            this.btn日次レポート送信.ForeColor = System.Drawing.Color.Black;
            this.btn日次レポート送信.Location = new System.Drawing.Point(12, 54);
            this.btn日次レポート送信.Margin = new System.Windows.Forms.Padding(4);
            this.btn日次レポート送信.Name = "btn日次レポート送信";
            this.btn日次レポート送信.Size = new System.Drawing.Size(169, 36);
            this.btn日次レポート送信.TabIndex = 18;
            this.btn日次レポート送信.Text = "日次レポート送信";
            this.btn日次レポート送信.UseVisualStyleBackColor = true;
            this.btn日次レポート送信.Click += new System.EventHandler(this.btn日次レポート送信_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 180;
            this.label2.Text = "データフォルダ：";
            // 
            // txtデータフォルダ
            // 
            this.txtデータフォルダ.Location = new System.Drawing.Point(107, 30);
            this.txtデータフォルダ.Name = "txtデータフォルダ";
            this.txtデータフォルダ.Size = new System.Drawing.Size(278, 22);
            this.txtデータフォルダ.TabIndex = 181;
            this.txtデータフォルダ.Text = "C:\\MSSQL";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(755, 514);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimer手動実行);
            this.Controls.Add(this.btn手動実行_spInsertSwap手動登録_Day1_toReal);
            this.Controls.Add(this.btn手動実行_spInsertSwap手動登録_Day1_toDemo);
            this.Controls.Add(this.txt売りポジション用口座BNo);
            this.Controls.Add(this.txtOandaAccountId売りポジション用口座B);
            this.Controls.Add(this.txt買いポジション用口座BNo);
            this.Controls.Add(this.txtOandaAccountId買いポジション用口座B);
            this.Controls.Add(this.txt売りポジション用口座ANo);
            this.Controls.Add(this.txt買いポジション用口座ANo);
            this.Controls.Add(this.txtDB接続先);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOandaAccountId売りポジション用口座A);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOandaAccountId買いポジション用口座A);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label70);
            this.Controls.Add(this.txtステータス);
            this.Controls.Add(this.btn手動実行);
            this.Controls.Add(this.chk自動開始);
            this.Name = "Form1";
            this.Text = "Swap収集";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk自動開始;
        private System.Windows.Forms.Button btn手動実行;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.TextBox txtステータス;
        private System.Windows.Forms.TextBox txtOandaAccountId売りポジション用口座A;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOandaAccountId買いポジション用口座A;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDB接続先;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt売りポジション用口座ANo;
        private System.Windows.Forms.TextBox txt買いポジション用口座ANo;
        private System.Windows.Forms.TextBox txt買いポジション用口座BNo;
        private System.Windows.Forms.TextBox txtOandaAccountId買いポジション用口座B;
        private System.Windows.Forms.TextBox txt売りポジション用口座BNo;
        private System.Windows.Forms.TextBox txtOandaAccountId売りポジション用口座B;
        private System.Windows.Forms.Button btn手動実行_spInsertSwap手動登録_Day1_toDemo;
        private System.Windows.Forms.Button btn手動実行_spInsertSwap手動登録_Day1_toReal;
        private System.Windows.Forms.Button btnTimer手動実行;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn日次レポート送信;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtデータフォルダ;
    }
}

