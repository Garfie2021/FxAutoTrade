namespace HealthCheck
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
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.btnヘルスチェック実行 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbコマンドライン = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb口座 = new System.Windows.Forms.ComboBox();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.cmbサーバ = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnヘルスチェック実行
            // 
            this.btnヘルスチェック実行.Location = new System.Drawing.Point(51, 377);
            this.btnヘルスチェック実行.Name = "btnヘルスチェック実行";
            this.btnヘルスチェック実行.Size = new System.Drawing.Size(193, 48);
            this.btnヘルスチェック実行.TabIndex = 0;
            this.btnヘルスチェック実行.Text = "ヘルスチェック実行";
            this.btnヘルスチェック実行.UseVisualStyleBackColor = true;
            this.btnヘルスチェック実行.Click += new System.EventHandler(this.btnヘルスチェック実行_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 45;
            this.label4.Text = "コマンドライン：";
            // 
            // cmbコマンドライン
            // 
            this.cmbコマンドライン.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbコマンドライン.FormattingEnabled = true;
            this.cmbコマンドライン.Location = new System.Drawing.Point(113, 13);
            this.cmbコマンドライン.Margin = new System.Windows.Forms.Padding(4);
            this.cmbコマンドライン.Name = "cmbコマンドライン";
            this.cmbコマンドライン.Size = new System.Drawing.Size(349, 23);
            this.cmbコマンドライン.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(485, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 43;
            this.label2.Text = "口座：";
            // 
            // cmb口座
            // 
            this.cmb口座.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb口座.FormattingEnabled = true;
            this.cmb口座.Location = new System.Drawing.Point(534, 49);
            this.cmb口座.Margin = new System.Windows.Forms.Padding(4);
            this.cmb口座.Name = "cmb口座";
            this.cmb口座.Size = new System.Drawing.Size(180, 23);
            this.cmb口座.TabIndex = 42;
            // 
            // cmbDB
            // 
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Location = new System.Drawing.Point(286, 49);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(176, 23);
            this.cmbDB.TabIndex = 41;
            // 
            // cmbサーバ
            // 
            this.cmbサーバ.FormattingEnabled = true;
            this.cmbサーバ.Location = new System.Drawing.Point(72, 51);
            this.cmbサーバ.Name = "cmbサーバ";
            this.cmbサーバ.Size = new System.Drawing.Size(160, 23);
            this.cmbサーバ.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 39;
            this.label3.Text = "サーバ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(253, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "DB";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(96, 107);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(253, 22);
            this.txtStartDate.TabIndex = 46;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(96, 135);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(253, 22);
            this.txtEndDate.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(22, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 48;
            this.label5.Text = "StartDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(22, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 49;
            this.label6.Text = "EndDate";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(993, 476);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbコマンドライン);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb口座);
            this.Controls.Add(this.cmbDB);
            this.Controls.Add(this.cmbサーバ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnヘルスチェック実行);
            this.Name = "Form1";
            this.Text = "ヘルスチェック";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnヘルスチェック実行;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbコマンドライン;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb口座;
        private System.Windows.Forms.ComboBox cmbDB;
        private System.Windows.Forms.ComboBox cmbサーバ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

