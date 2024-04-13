namespace Maintenance_Form.F手動データ登録
{
    partial class F全通貨ペアで注文
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt1通貨ペアの注文数 = new System.Windows.Forms.TextBox();
            this.btn注文実行 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt接続先 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOandaAccountId買いポジション用口座A = new System.Windows.Forms.TextBox();
            this.txtAccessToken = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOandaAccountId売りポジション用口座A = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOandaAccountId買いポジション用口座B = new System.Windows.Forms.TextBox();
            this.txtOandaAccountId売りポジション用口座B = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "1通貨ペアの注文数：";
            // 
            // txt1通貨ペアの注文数
            // 
            this.txt1通貨ペアの注文数.Location = new System.Drawing.Point(165, 56);
            this.txt1通貨ペアの注文数.Name = "txt1通貨ペアの注文数";
            this.txt1通貨ペアの注文数.Size = new System.Drawing.Size(100, 22);
            this.txt1通貨ペアの注文数.TabIndex = 1;
            this.txt1通貨ペアの注文数.Text = "1000";
            this.txt1通貨ペアの注文数.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn注文実行
            // 
            this.btn注文実行.ForeColor = System.Drawing.Color.Black;
            this.btn注文実行.Location = new System.Drawing.Point(56, 97);
            this.btn注文実行.Name = "btn注文実行";
            this.btn注文実行.Size = new System.Drawing.Size(209, 38);
            this.btn注文実行.TabIndex = 2;
            this.btn注文実行.Text = "注文実行";
            this.btn注文実行.UseVisualStyleBackColor = true;
            this.btn注文実行.Click += new System.EventHandler(this.btn注文実行_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "定時スワップ収集用ポジションを注文する。";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn注文実行);
            this.groupBox1.Controls.Add(this.txt1通貨ペアの注文数);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 159);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txt接続先
            // 
            this.txt接続先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt接続先.Location = new System.Drawing.Point(76, 10);
            this.txt接続先.Multiline = true;
            this.txt接続先.Name = "txt接続先";
            this.txt接続先.Size = new System.Drawing.Size(610, 105);
            this.txt接続先.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(10, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "接続先：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "OandaAccountId 買いポジション用口座：";
            // 
            // txtOandaAccountId買いポジション用口座A
            // 
            this.txtOandaAccountId買いポジション用口座A.Location = new System.Drawing.Point(271, 160);
            this.txtOandaAccountId買いポジション用口座A.Name = "txtOandaAccountId買いポジション用口座A";
            this.txtOandaAccountId買いポジション用口座A.Size = new System.Drawing.Size(100, 22);
            this.txtOandaAccountId買いポジション用口座A.TabIndex = 9;
            this.txtOandaAccountId買いポジション用口座A.Text = "111";
            // 
            // txtAccessToken
            // 
            this.txtAccessToken.Location = new System.Drawing.Point(125, 281);
            this.txtAccessToken.Name = "txtAccessToken";
            this.txtAccessToken.Size = new System.Drawing.Size(525, 22);
            this.txtAccessToken.TabIndex = 11;
            this.txtAccessToken.Text = "111";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Access Token：";
            // 
            // txtOandaAccountId売りポジション用口座A
            // 
            this.txtOandaAccountId売りポジション用口座A.Location = new System.Drawing.Point(271, 214);
            this.txtOandaAccountId売りポジション用口座A.Name = "txtOandaAccountId売りポジション用口座A";
            this.txtOandaAccountId売りポジション用口座A.Size = new System.Drawing.Size(100, 22);
            this.txtOandaAccountId売りポジション用口座A.TabIndex = 13;
            this.txtOandaAccountId売りポジション用口座A.Text = "111";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "OandaAccountId 売りポジション用口座：";
            // 
            // txtOandaAccountId買いポジション用口座B
            // 
            this.txtOandaAccountId買いポジション用口座B.Location = new System.Drawing.Point(271, 187);
            this.txtOandaAccountId買いポジション用口座B.Name = "txtOandaAccountId買いポジション用口座B";
            this.txtOandaAccountId買いポジション用口座B.Size = new System.Drawing.Size(100, 22);
            this.txtOandaAccountId買いポジション用口座B.TabIndex = 14;
            this.txtOandaAccountId買いポジション用口座B.Text = "111";
            // 
            // txtOandaAccountId売りポジション用口座B
            // 
            this.txtOandaAccountId売りポジション用口座B.Location = new System.Drawing.Point(271, 241);
            this.txtOandaAccountId売りポジション用口座B.Name = "txtOandaAccountId売りポジション用口座B";
            this.txtOandaAccountId売りポジション用口座B.Size = new System.Drawing.Size(100, 22);
            this.txtOandaAccountId売りポジション用口座B.TabIndex = 15;
            this.txtOandaAccountId売りポジション用口座B.Text = "111";
            // 
            // F全通貨ペアで注文
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(711, 600);
            this.Controls.Add(this.txtOandaAccountId売りポジション用口座B);
            this.Controls.Add(this.txtOandaAccountId買いポジション用口座B);
            this.Controls.Add(this.txtOandaAccountId売りポジション用口座A);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAccessToken);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOandaAccountId買いポジション用口座A);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt接続先);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "F全通貨ペアで注文";
            this.Text = "全通貨ペアで注文";
            this.Load += new System.EventHandler(this.F全通貨ペアで注文_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt1通貨ペアの注文数;
        private System.Windows.Forms.Button btn注文実行;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt接続先;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOandaAccountId買いポジション用口座A;
        private System.Windows.Forms.TextBox txtAccessToken;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOandaAccountId売りポジション用口座A;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOandaAccountId買いポジション用口座B;
        private System.Windows.Forms.TextBox txtOandaAccountId売りポジション用口座B;
    }
}