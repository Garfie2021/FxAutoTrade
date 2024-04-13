namespace Maintenance_Form
{
    partial class FOANDAが扱っている通貨ペア一覧
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FOANDAが扱っている通貨ペア一覧));
            this.label1 = new System.Windows.Forms.Label();
            this.txt通貨ペア一覧 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.txt通貨ペア数 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "参照URL";
            // 
            // txt通貨ペア一覧
            // 
            this.txt通貨ペア一覧.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt通貨ペア一覧.Location = new System.Drawing.Point(19, 67);
            this.txt通貨ペア一覧.Multiline = true;
            this.txt通貨ペア一覧.Name = "txt通貨ペア一覧";
            this.txt通貨ペア一覧.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt通貨ペア一覧.Size = new System.Drawing.Size(596, 580);
            this.txt通貨ペア一覧.TabIndex = 1;
            this.txt通貨ペア一覧.Text = resources.GetString("txt通貨ペア一覧.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "通貨ペア一覧 ※2018/02/18更新";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(106, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(272, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://www.oanda.jp/service/fxtrade.php";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(429, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "通貨ペア数：";
            // 
            // txt通貨ペア数
            // 
            this.txt通貨ペア数.Location = new System.Drawing.Point(514, 44);
            this.txt通貨ペア数.Name = "txt通貨ペア数";
            this.txt通貨ペア数.Size = new System.Drawing.Size(100, 22);
            this.txt通貨ペア数.TabIndex = 6;
            // 
            // FOANDAが扱っている通貨ペア一覧
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 659);
            this.Controls.Add(this.txt通貨ペア数);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt通貨ペア一覧);
            this.Controls.Add(this.label1);
            this.Name = "FOANDAが扱っている通貨ペア一覧";
            this.Text = "OANDAが扱っている通貨ペア一覧";
            this.Load += new System.EventHandler(this.OANDAが扱っている通貨ペア一覧_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt通貨ペア一覧;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt通貨ペア数;
    }
}