namespace Maintenance_Form
{
    partial class F注文可能通貨ペア
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
            this.btn通貨ペア抽出 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtコマンドライン = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt口座 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDB接続先 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btn通貨ペア別の最新売買スワップ = new System.Windows.Forms.Button();
            this.btnOANDAが扱っている通貨ペア一覧 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn通貨ペア抽出);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(13, 138);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(429, 170);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. 注文可能条件を満たしている通貨ペア抽出";
            // 
            // btn通貨ペア抽出
            // 
            this.btn通貨ペア抽出.ForeColor = System.Drawing.Color.Black;
            this.btn通貨ペア抽出.Location = new System.Drawing.Point(15, 106);
            this.btn通貨ペア抽出.Margin = new System.Windows.Forms.Padding(4);
            this.btn通貨ペア抽出.Name = "btn通貨ペア抽出";
            this.btn通貨ペア抽出.Size = new System.Drawing.Size(265, 36);
            this.btn通貨ペア抽出.TabIndex = 16;
            this.btn通貨ペア抽出.Text = "通貨ペア抽出";
            this.btn通貨ペア抽出.UseVisualStyleBackColor = true;
            this.btn通貨ペア抽出.Click += new System.EventHandler(this.btn通貨ペア抽出_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "【注文可能条件】\r\nSwapが有る\r\nMin15が2ヵ月有る\r\nMonth1が14ヵ月有る\r\n";
            // 
            // txtコマンドライン
            // 
            this.txtコマンドライン.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtコマンドライン.Location = new System.Drawing.Point(109, 71);
            this.txtコマンドライン.Name = "txtコマンドライン";
            this.txtコマンドライン.Size = new System.Drawing.Size(685, 22);
            this.txtコマンドライン.TabIndex = 55;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(13, 72);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 15);
            this.label22.TabIndex = 54;
            this.label22.Text = "コマンドライン：";
            // 
            // txt口座
            // 
            this.txt口座.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt口座.Location = new System.Drawing.Point(109, 41);
            this.txt口座.Name = "txt口座";
            this.txt口座.Size = new System.Drawing.Size(685, 22);
            this.txt口座.TabIndex = 53;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(13, 42);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 15);
            this.label23.TabIndex = 52;
            this.label23.Text = "口座：";
            // 
            // txtDB接続先
            // 
            this.txtDB接続先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDB接続先.Location = new System.Drawing.Point(109, 11);
            this.txtDB接続先.Name = "txtDB接続先";
            this.txtDB接続先.Size = new System.Drawing.Size(685, 22);
            this.txtDB接続先.TabIndex = 51;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(13, 12);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 15);
            this.label24.TabIndex = 50;
            this.label24.Text = "DB接続先：";
            // 
            // btn通貨ペア別の最新売買スワップ
            // 
            this.btn通貨ペア別の最新売買スワップ.ForeColor = System.Drawing.Color.Black;
            this.btn通貨ペア別の最新売買スワップ.Location = new System.Drawing.Point(450, 159);
            this.btn通貨ペア別の最新売買スワップ.Margin = new System.Windows.Forms.Padding(4);
            this.btn通貨ペア別の最新売買スワップ.Name = "btn通貨ペア別の最新売買スワップ";
            this.btn通貨ペア別の最新売買スワップ.Size = new System.Drawing.Size(265, 36);
            this.btn通貨ペア別の最新売買スワップ.TabIndex = 16;
            this.btn通貨ペア別の最新売買スワップ.Text = "通貨ペア別の最新売買スワップ";
            this.btn通貨ペア別の最新売買スワップ.UseVisualStyleBackColor = true;
            this.btn通貨ペア別の最新売買スワップ.Click += new System.EventHandler(this.btn通貨ペア別の最新売買スワップ_Click);
            // 
            // btnOANDAが扱っている通貨ペア一覧
            // 
            this.btnOANDAが扱っている通貨ペア一覧.ForeColor = System.Drawing.Color.Black;
            this.btnOANDAが扱っている通貨ペア一覧.Location = new System.Drawing.Point(726, 158);
            this.btnOANDAが扱っている通貨ペア一覧.Margin = new System.Windows.Forms.Padding(4);
            this.btnOANDAが扱っている通貨ペア一覧.Name = "btnOANDAが扱っている通貨ペア一覧";
            this.btnOANDAが扱っている通貨ペア一覧.Size = new System.Drawing.Size(265, 36);
            this.btnOANDAが扱っている通貨ペア一覧.TabIndex = 56;
            this.btnOANDAが扱っている通貨ペア一覧.Text = "OANDAが扱っている通貨ペア一覧";
            this.btnOANDAが扱っている通貨ペア一覧.UseVisualStyleBackColor = true;
            this.btnOANDAが扱っている通貨ペア一覧.Click += new System.EventHandler(this.btnOANDAが扱っている通貨ペア一覧_Click);
            // 
            // F注文可能通貨ペア
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1345, 348);
            this.Controls.Add(this.btnOANDAが扱っている通貨ペア一覧);
            this.Controls.Add(this.btn通貨ペア別の最新売買スワップ);
            this.Controls.Add(this.txtコマンドライン);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txt口座);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtDB接続先);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.groupBox1);
            this.Name = "F注文可能通貨ペア";
            this.Text = "F注文可能通貨ペア";
            this.Load += new System.EventHandler(this.F注文可能通貨ペア_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn通貨ペア抽出;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtコマンドライン;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt口座;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtDB接続先;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btn通貨ペア別の最新売買スワップ;
        private System.Windows.Forms.Button btnOANDAが扱っている通貨ペア一覧;
    }
}