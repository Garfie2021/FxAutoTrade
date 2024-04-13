namespace Maintenance_Form
{
    partial class Utxt環境情報
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtDB接続先 = new System.Windows.Forms.TextBox();
            this.txt口座 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtコマンドライン = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "DB接続先：";
            // 
            // txtDB接続先
            // 
            this.txtDB接続先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDB接続先.Location = new System.Drawing.Point(103, 3);
            this.txtDB接続先.Name = "txtDB接続先";
            this.txtDB接続先.Size = new System.Drawing.Size(485, 22);
            this.txtDB接続先.TabIndex = 1;
            // 
            // txt口座
            // 
            this.txt口座.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt口座.Location = new System.Drawing.Point(103, 33);
            this.txt口座.Name = "txt口座";
            this.txt口座.Size = new System.Drawing.Size(485, 22);
            this.txt口座.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "口座：";
            // 
            // txtコマンドライン
            // 
            this.txtコマンドライン.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtコマンドライン.Location = new System.Drawing.Point(103, 63);
            this.txtコマンドライン.Name = "txtコマンドライン";
            this.txtコマンドライン.Size = new System.Drawing.Size(485, 22);
            this.txtコマンドライン.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "コマンドライン：";
            // 
            // Utxt環境情報
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.txtコマンドライン);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt口座);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDB接続先);
            this.Controls.Add(this.label1);
            this.Name = "Utxt環境情報";
            this.Size = new System.Drawing.Size(591, 94);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDB接続先;
        private System.Windows.Forms.TextBox txt口座;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtコマンドライン;
        private System.Windows.Forms.Label label3;
    }
}
