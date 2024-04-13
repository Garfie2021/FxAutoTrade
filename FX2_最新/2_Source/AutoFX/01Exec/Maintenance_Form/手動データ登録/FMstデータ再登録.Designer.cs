namespace Maintenance_Form
{
	partial class FMstデータ再登録
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
            this.btn通貨ペア再登録 = new System.Windows.Forms.Button();
            this.btn通貨ペア一覧表示 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn通貨ペア再登録
            // 
            this.btn通貨ペア再登録.Location = new System.Drawing.Point(22, 145);
            this.btn通貨ペア再登録.Margin = new System.Windows.Forms.Padding(4);
            this.btn通貨ペア再登録.Name = "btn通貨ペア再登録";
            this.btn通貨ペア再登録.Size = new System.Drawing.Size(169, 36);
            this.btn通貨ペア再登録.TabIndex = 15;
            this.btn通貨ペア再登録.Text = "通貨ペア再登録";
            this.btn通貨ペア再登録.UseVisualStyleBackColor = true;
            this.btn通貨ペア再登録.Click += new System.EventHandler(this.btn通貨ペア再登録_Click);
            // 
            // btn通貨ペア一覧表示
            // 
            this.btn通貨ペア一覧表示.Location = new System.Drawing.Point(22, 81);
            this.btn通貨ペア一覧表示.Margin = new System.Windows.Forms.Padding(4);
            this.btn通貨ペア一覧表示.Name = "btn通貨ペア一覧表示";
            this.btn通貨ペア一覧表示.Size = new System.Drawing.Size(169, 36);
            this.btn通貨ペア一覧表示.TabIndex = 21;
            this.btn通貨ペア一覧表示.Text = "通貨ペア一覧表示";
            this.btn通貨ペア一覧表示.UseVisualStyleBackColor = true;
            this.btn通貨ペア一覧表示.Click += new System.EventHandler(this.btn通貨ペア一覧表示_Click);
            // 
            // FMstデータ再登録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1499, 275);
            this.Controls.Add(this.btn通貨ペア一覧表示);
            this.Controls.Add(this.btn通貨ペア再登録);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FMstデータ再登録";
            this.Text = "FMstデータ再登録";
            this.Load += new System.EventHandler(this.FMstデータ再登録_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Button btn通貨ペア再登録;
        private System.Windows.Forms.Button btn通貨ペア一覧表示;
    }
}