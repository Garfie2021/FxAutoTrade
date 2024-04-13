namespace Test
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
			this.btn通貨ペア取得 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn通貨ペア取得
			// 
			this.btn通貨ペア取得.Location = new System.Drawing.Point(12, 12);
			this.btn通貨ペア取得.Name = "btn通貨ペア取得";
			this.btn通貨ペア取得.Size = new System.Drawing.Size(165, 43);
			this.btn通貨ペア取得.TabIndex = 0;
			this.btn通貨ペア取得.Text = "通貨ペア取得";
			this.btn通貨ペア取得.UseVisualStyleBackColor = true;
			this.btn通貨ペア取得.Click += new System.EventHandler(this.btn通貨ペア取得_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.btn通貨ペア取得);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn通貨ペア取得;
	}
}

