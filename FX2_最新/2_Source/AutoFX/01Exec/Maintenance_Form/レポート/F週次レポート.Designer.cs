namespace Maintenance_Form
{
    partial class F週次レポート
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
            this.btnレポートファイル保存 = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnレポート表示 = new System.Windows.Forms.Button();
            this.cmb年 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb週 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnレポートファイル保存
            // 
            this.btnレポートファイル保存.Location = new System.Drawing.Point(642, 8);
            this.btnレポートファイル保存.Margin = new System.Windows.Forms.Padding(4);
            this.btnレポートファイル保存.Name = "btnレポートファイル保存";
            this.btnレポートファイル保存.Size = new System.Drawing.Size(169, 36);
            this.btnレポートファイル保存.TabIndex = 21;
            this.btnレポートファイル保存.Text = "レポートファイル保存";
            this.btnレポートファイル保存.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtResult.ForeColor = System.Drawing.Color.White;
            this.txtResult.Location = new System.Drawing.Point(12, 53);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(1010, 636);
            this.txtResult.TabIndex = 18;
            // 
            // btnレポート表示
            // 
            this.btnレポート表示.Location = new System.Drawing.Point(454, 8);
            this.btnレポート表示.Margin = new System.Windows.Forms.Padding(4);
            this.btnレポート表示.Name = "btnレポート表示";
            this.btnレポート表示.Size = new System.Drawing.Size(169, 36);
            this.btnレポート表示.TabIndex = 20;
            this.btnレポート表示.Text = "レポート表示";
            this.btnレポート表示.UseVisualStyleBackColor = true;
            this.btnレポート表示.Click += new System.EventHandler(this.btnレポート表示_Click);
            // 
            // cmb年
            // 
            this.cmb年.FormattingEnabled = true;
            this.cmb年.Location = new System.Drawing.Point(47, 16);
            this.cmb年.Name = "cmb年";
            this.cmb年.Size = new System.Drawing.Size(121, 23);
            this.cmb年.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "年";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(188, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "週";
            // 
            // cmb週
            // 
            this.cmb週.FormattingEnabled = true;
            this.cmb週.Location = new System.Drawing.Point(220, 14);
            this.cmb週.Name = "cmb週";
            this.cmb週.Size = new System.Drawing.Size(121, 23);
            this.cmb週.TabIndex = 24;
            // 
            // F週次レポート
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1034, 698);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb週);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb年);
            this.Controls.Add(this.btnレポートファイル保存);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnレポート表示);
            this.Name = "F週次レポート";
            this.Text = "F週次レポート";
            this.Load += new System.EventHandler(this.F週次レポート_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnレポートファイル保存;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnレポート表示;
        private System.Windows.Forms.ComboBox cmb年;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb週;
    }
}