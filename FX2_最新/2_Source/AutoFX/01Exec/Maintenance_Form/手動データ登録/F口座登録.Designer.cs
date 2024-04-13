namespace Maintenance_Form
{
    partial class F口座登録
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
            this.txtOandaAccountId = new System.Windows.Forms.TextBox();
            this.btn登録 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOandaAccessToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFX会社 = new System.Windows.Forms.ComboBox();
            this.cmbFxServerContry = new System.Windows.Forms.ComboBox();
            this.cmb個人法人 = new System.Windows.Forms.ComboBox();
            this.cmbDemoReal = new System.Windows.Forms.ComboBox();
            this.txt取引証拠金上限 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb毎朝の自動注文開始を行う = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOandaAccountId
            // 
            this.txtOandaAccountId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOandaAccountId.Location = new System.Drawing.Point(216, 18);
            this.txtOandaAccountId.Margin = new System.Windows.Forms.Padding(4);
            this.txtOandaAccountId.Name = "txtOandaAccountId";
            this.txtOandaAccountId.Size = new System.Drawing.Size(240, 22);
            this.txtOandaAccountId.TabIndex = 1;
            // 
            // btn登録
            // 
            this.btn登録.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn登録.ForeColor = System.Drawing.Color.Black;
            this.btn登録.Location = new System.Drawing.Point(590, 286);
            this.btn登録.Margin = new System.Windows.Forms.Padding(4);
            this.btn登録.Name = "btn登録";
            this.btn登録.Size = new System.Drawing.Size(168, 39);
            this.btn登録.TabIndex = 3;
            this.btn登録.Text = "登録";
            this.btn登録.UseVisualStyleBackColor = true;
            this.btn登録.Click += new System.EventHandler(this.btn登録_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "OandaAccountId（必須）";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "OandaAccessToken（必須）";
            // 
            // txtOandaAccessToken
            // 
            this.txtOandaAccessToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOandaAccessToken.Location = new System.Drawing.Point(216, 48);
            this.txtOandaAccessToken.Margin = new System.Windows.Forms.Padding(4);
            this.txtOandaAccessToken.Name = "txtOandaAccessToken";
            this.txtOandaAccessToken.Size = new System.Drawing.Size(542, 22);
            this.txtOandaAccessToken.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "FX会社（必須）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "FxServerContry（必須）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(26, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "個人法人（必須）";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(26, 170);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "DemoReal（必須）";
            // 
            // cmbFX会社
            // 
            this.cmbFX会社.FormattingEnabled = true;
            this.cmbFX会社.Items.AddRange(new object[] {
            "OANDA"});
            this.cmbFX会社.Location = new System.Drawing.Point(216, 80);
            this.cmbFX会社.Name = "cmbFX会社";
            this.cmbFX会社.Size = new System.Drawing.Size(240, 23);
            this.cmbFX会社.TabIndex = 18;
            // 
            // cmbFxServerContry
            // 
            this.cmbFxServerContry.FormattingEnabled = true;
            this.cmbFxServerContry.Location = new System.Drawing.Point(216, 107);
            this.cmbFxServerContry.Name = "cmbFxServerContry";
            this.cmbFxServerContry.Size = new System.Drawing.Size(240, 23);
            this.cmbFxServerContry.TabIndex = 19;
            // 
            // cmb個人法人
            // 
            this.cmb個人法人.FormattingEnabled = true;
            this.cmb個人法人.Location = new System.Drawing.Point(216, 137);
            this.cmb個人法人.Name = "cmb個人法人";
            this.cmb個人法人.Size = new System.Drawing.Size(240, 23);
            this.cmb個人法人.TabIndex = 20;
            // 
            // cmbDemoReal
            // 
            this.cmbDemoReal.FormattingEnabled = true;
            this.cmbDemoReal.Location = new System.Drawing.Point(216, 167);
            this.cmbDemoReal.Name = "cmbDemoReal";
            this.cmbDemoReal.Size = new System.Drawing.Size(240, 23);
            this.cmbDemoReal.TabIndex = 21;
            // 
            // txt取引証拠金上限
            // 
            this.txt取引証拠金上限.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt取引証拠金上限.Location = new System.Drawing.Point(216, 198);
            this.txt取引証拠金上限.Margin = new System.Windows.Forms.Padding(4);
            this.txt取引証拠金上限.Name = "txt取引証拠金上限";
            this.txt取引証拠金上限.Size = new System.Drawing.Size(240, 22);
            this.txt取引証拠金上限.TabIndex = 22;
            this.txt取引証拠金上限.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(26, 200);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "取引証拠金上限";
            // 
            // cmb毎朝の自動注文開始を行う
            // 
            this.cmb毎朝の自動注文開始を行う.FormattingEnabled = true;
            this.cmb毎朝の自動注文開始を行う.Location = new System.Drawing.Point(216, 227);
            this.cmb毎朝の自動注文開始を行う.Name = "cmb毎朝の自動注文開始を行う";
            this.cmb毎朝の自動注文開始を行う.Size = new System.Drawing.Size(240, 23);
            this.cmb毎朝の自動注文開始を行う.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(26, 230);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(220, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "毎朝の自動注文開始を行う（必須）";
            // 
            // F口座登録
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(771, 344);
            this.Controls.Add(this.cmb毎朝の自動注文開始を行う);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt取引証拠金上限);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDemoReal);
            this.Controls.Add(this.cmb個人法人);
            this.Controls.Add(this.cmbFxServerContry);
            this.Controls.Add(this.cmbFX会社);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOandaAccountId);
            this.Controls.Add(this.btn登録);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOandaAccessToken);
            this.Controls.Add(this.label2);
            this.Name = "F口座登録";
            this.Text = "F口座登録";
            this.Load += new System.EventHandler(this.F口座登録_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtOandaAccountId;
        private System.Windows.Forms.Button btn登録;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOandaAccessToken;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFX会社;
        private System.Windows.Forms.ComboBox cmbFxServerContry;
        private System.Windows.Forms.ComboBox cmb個人法人;
        private System.Windows.Forms.ComboBox cmbDemoReal;
        private System.Windows.Forms.TextBox txt取引証拠金上限;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb毎朝の自動注文開始を行う;
        private System.Windows.Forms.Label label8;
    }
}