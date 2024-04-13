namespace AutoFX_Form
{
    partial class Form2
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
			this.btn通貨ペア取得 = new System.Windows.Forms.Button();
			this.btnアカウント情報取得 = new System.Windows.Forms.Button();
			this.btnRate取得 = new System.Windows.Forms.Button();
			this.btnOrders = new System.Windows.Forms.Button();
			this.btnTrades = new System.Windows.Forms.Button();
			this.btnPositions = new System.Windows.Forms.Button();
			this.btnTransactions = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn通貨ペア取得
			// 
			this.btn通貨ペア取得.Location = new System.Drawing.Point(12, 12);
			this.btn通貨ペア取得.Name = "btn通貨ペア取得";
			this.btn通貨ペア取得.Size = new System.Drawing.Size(173, 23);
			this.btn通貨ペア取得.TabIndex = 1;
			this.btn通貨ペア取得.Text = "通貨ペア取得";
			this.btn通貨ペア取得.UseVisualStyleBackColor = true;
			this.btn通貨ペア取得.Click += new System.EventHandler(this.btn通貨ペア取得_Click);
			// 
			// btnアカウント情報取得
			// 
			this.btnアカウント情報取得.Location = new System.Drawing.Point(12, 89);
			this.btnアカウント情報取得.Name = "btnアカウント情報取得";
			this.btnアカウント情報取得.Size = new System.Drawing.Size(173, 23);
			this.btnアカウント情報取得.TabIndex = 2;
			this.btnアカウント情報取得.Text = "Accounts取得";
			this.btnアカウント情報取得.UseVisualStyleBackColor = true;
			this.btnアカウント情報取得.Click += new System.EventHandler(this.btnアカウント情報取得_Click);
			// 
			// btnRate取得
			// 
			this.btnRate取得.Location = new System.Drawing.Point(12, 51);
			this.btnRate取得.Name = "btnRate取得";
			this.btnRate取得.Size = new System.Drawing.Size(173, 23);
			this.btnRate取得.TabIndex = 3;
			this.btnRate取得.Text = "Rate取得";
			this.btnRate取得.UseVisualStyleBackColor = true;
			this.btnRate取得.Click += new System.EventHandler(this.btnRate取得_Click);
			// 
			// btnOrders
			// 
			this.btnOrders.Location = new System.Drawing.Point(12, 125);
			this.btnOrders.Name = "btnOrders";
			this.btnOrders.Size = new System.Drawing.Size(173, 23);
			this.btnOrders.TabIndex = 4;
			this.btnOrders.Text = "Orders取得";
			this.btnOrders.UseVisualStyleBackColor = true;
			this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
			// 
			// btnTrades
			// 
			this.btnTrades.Location = new System.Drawing.Point(12, 160);
			this.btnTrades.Name = "btnTrades";
			this.btnTrades.Size = new System.Drawing.Size(173, 23);
			this.btnTrades.TabIndex = 5;
			this.btnTrades.Text = "Trades取得";
			this.btnTrades.UseVisualStyleBackColor = true;
			this.btnTrades.Click += new System.EventHandler(this.btnTrades_Click);
			// 
			// btnPositions
			// 
			this.btnPositions.Location = new System.Drawing.Point(12, 198);
			this.btnPositions.Name = "btnPositions";
			this.btnPositions.Size = new System.Drawing.Size(173, 23);
			this.btnPositions.TabIndex = 6;
			this.btnPositions.Text = "Positions取得";
			this.btnPositions.UseVisualStyleBackColor = true;
			this.btnPositions.Click += new System.EventHandler(this.btnPositions_Click);
			// 
			// btnTransactions
			// 
			this.btnTransactions.Location = new System.Drawing.Point(12, 230);
			this.btnTransactions.Name = "btnTransactions";
			this.btnTransactions.Size = new System.Drawing.Size(173, 23);
			this.btnTransactions.TabIndex = 7;
			this.btnTransactions.Text = "Transactions取得";
			this.btnTransactions.UseVisualStyleBackColor = true;
			this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(206, 464);
			this.Controls.Add(this.btnTransactions);
			this.Controls.Add(this.btnPositions);
			this.Controls.Add(this.btnTrades);
			this.Controls.Add(this.btnOrders);
			this.Controls.Add(this.btnRate取得);
			this.Controls.Add(this.btnアカウント情報取得);
			this.Controls.Add(this.btn通貨ペア取得);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button btn通貨ペア取得;
        private System.Windows.Forms.Button btnアカウント情報取得;
		private System.Windows.Forms.Button btnRate取得;
		private System.Windows.Forms.Button btnOrders;
		private System.Windows.Forms.Button btnTrades;
		private System.Windows.Forms.Button btnPositions;
		private System.Windows.Forms.Button btnTransactions;
    }
}