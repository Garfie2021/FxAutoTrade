namespace Maintenance_Form
{
    partial class F結果
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
            this.txt結果 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt結果
            // 
            this.txt結果.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt結果.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt結果.ForeColor = System.Drawing.Color.White;
            this.txt結果.Location = new System.Drawing.Point(12, 12);
            this.txt結果.Multiline = true;
            this.txt結果.Name = "txt結果";
            this.txt結果.Size = new System.Drawing.Size(761, 465);
            this.txt結果.TabIndex = 0;
            // 
            // F結果
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(785, 489);
            this.Controls.Add(this.txt結果);
            this.Name = "F結果";
            this.Text = "F結果";
            this.Load += new System.EventHandler(this.F結果_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt結果;
    }
}