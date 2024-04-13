namespace Maintenance_Form.Fデータ加工
{
    partial class F日毎に横並び
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
            this.btn表示 = new System.Windows.Forms.Button();
            this.txtコマンドライン = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt口座 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDB接続先 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn表示
            // 
            this.btn表示.Location = new System.Drawing.Point(16, 131);
            this.btn表示.Margin = new System.Windows.Forms.Padding(4);
            this.btn表示.Name = "btn表示";
            this.btn表示.Size = new System.Drawing.Size(200, 36);
            this.btn表示.TabIndex = 17;
            this.btn表示.Text = "表示（Text）";
            this.btn表示.UseVisualStyleBackColor = true;
            this.btn表示.Click += new System.EventHandler(this.btn表示_Click);
            // 
            // txtコマンドライン
            // 
            this.txtコマンドライン.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtコマンドライン.Location = new System.Drawing.Point(109, 72);
            this.txtコマンドライン.Name = "txtコマンドライン";
            this.txtコマンドライン.Size = new System.Drawing.Size(778, 22);
            this.txtコマンドライン.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 48;
            this.label3.Text = "コマンドライン：";
            // 
            // txt口座
            // 
            this.txt口座.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt口座.Location = new System.Drawing.Point(109, 42);
            this.txt口座.Name = "txt口座";
            this.txt口座.Size = new System.Drawing.Size(778, 22);
            this.txt口座.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 46;
            this.label1.Text = "口座：";
            // 
            // txtDB接続先
            // 
            this.txtDB接続先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDB接続先.Location = new System.Drawing.Point(109, 12);
            this.txtDB接続先.Name = "txtDB接続先";
            this.txtDB接続先.Size = new System.Drawing.Size(778, 22);
            this.txtDB接続先.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 44;
            this.label4.Text = "DB接続先：";
            // 
            // F日毎に横並び
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(978, 227);
            this.Controls.Add(this.txtコマンドライン);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt口座);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDB接続先);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn表示);
            this.Name = "F日毎に横並び";
            this.Text = "F日毎に横並び";
            this.Load += new System.EventHandler(this.F日毎に横並び_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn表示;
        private System.Windows.Forms.TextBox txtコマンドライン;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt口座;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDB接続先;
        private System.Windows.Forms.Label label4;
    }
}