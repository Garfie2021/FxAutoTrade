namespace Maintenance_Form
{
    partial class Fシュミレーション
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
            this.btnOrder_Ver7_WMA反転_BS = new System.Windows.Forms.Button();
            this.txtコマンドライン = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt口座 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDB接続先 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtログ = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkWMA月判定有り = new System.Windows.Forms.CheckBox();
            this.chkWMA週判定有り = new System.Windows.Forms.CheckBox();
            this.chkWMA日判定有り = new System.Windows.Forms.CheckBox();
            this.chkBS判定有り = new System.Windows.Forms.CheckBox();
            this.rdo買い = new System.Windows.Forms.RadioButton();
            this.rdo売り = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn週次に対して日次が反転した際に注文 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOrder_Ver7_WMA反転_BS
            // 
            this.btnOrder_Ver7_WMA反転_BS.ForeColor = System.Drawing.Color.Black;
            this.btnOrder_Ver7_WMA反転_BS.Location = new System.Drawing.Point(18, 113);
            this.btnOrder_Ver7_WMA反転_BS.Margin = new System.Windows.Forms.Padding(4);
            this.btnOrder_Ver7_WMA反転_BS.Name = "btnOrder_Ver7_WMA反転_BS";
            this.btnOrder_Ver7_WMA反転_BS.Size = new System.Drawing.Size(318, 36);
            this.btnOrder_Ver7_WMA反転_BS.TabIndex = 19;
            this.btnOrder_Ver7_WMA反転_BS.Text = "Hour1のみでWMAが反転した際に注文";
            this.btnOrder_Ver7_WMA反転_BS.UseVisualStyleBackColor = true;
            this.btnOrder_Ver7_WMA反転_BS.Click += new System.EventHandler(this.btnOrder_Ver7_WMA反転_BS_Click);
            // 
            // txtコマンドライン
            // 
            this.txtコマンドライン.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtコマンドライン.Location = new System.Drawing.Point(111, 72);
            this.txtコマンドライン.Name = "txtコマンドライン";
            this.txtコマンドライン.Size = new System.Drawing.Size(656, 22);
            this.txtコマンドライン.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 54;
            this.label3.Text = "コマンドライン：";
            // 
            // txt口座
            // 
            this.txt口座.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt口座.Location = new System.Drawing.Point(111, 42);
            this.txt口座.Name = "txt口座";
            this.txt口座.Size = new System.Drawing.Size(656, 22);
            this.txt口座.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "口座：";
            // 
            // txtDB接続先
            // 
            this.txtDB接続先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDB接続先.Location = new System.Drawing.Point(111, 12);
            this.txtDB接続先.Name = "txtDB接続先";
            this.txtDB接続先.Size = new System.Drawing.Size(656, 22);
            this.txtDB接続先.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 50;
            this.label4.Text = "DB接続先：";
            // 
            // txtログ
            // 
            this.txtログ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtログ.Location = new System.Drawing.Point(6, 21);
            this.txtログ.Multiline = true;
            this.txtログ.Name = "txtログ";
            this.txtログ.Size = new System.Drawing.Size(1009, 413);
            this.txtログ.TabIndex = 56;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtログ);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(18, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1021, 440);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "結果";
            // 
            // chkWMA月判定有り
            // 
            this.chkWMA月判定有り.AutoSize = true;
            this.chkWMA月判定有り.ForeColor = System.Drawing.Color.White;
            this.chkWMA月判定有り.Location = new System.Drawing.Point(344, 122);
            this.chkWMA月判定有り.Name = "chkWMA月判定有り";
            this.chkWMA月判定有り.Size = new System.Drawing.Size(129, 19);
            this.chkWMA月判定有り.TabIndex = 58;
            this.chkWMA月判定有り.Text = "WMA月判定有り";
            this.chkWMA月判定有り.UseVisualStyleBackColor = true;
            // 
            // chkWMA週判定有り
            // 
            this.chkWMA週判定有り.AutoSize = true;
            this.chkWMA週判定有り.ForeColor = System.Drawing.Color.White;
            this.chkWMA週判定有り.Location = new System.Drawing.Point(488, 123);
            this.chkWMA週判定有り.Name = "chkWMA週判定有り";
            this.chkWMA週判定有り.Size = new System.Drawing.Size(129, 19);
            this.chkWMA週判定有り.TabIndex = 59;
            this.chkWMA週判定有り.Text = "WMA週判定有り";
            this.chkWMA週判定有り.UseVisualStyleBackColor = true;
            // 
            // chkWMA日判定有り
            // 
            this.chkWMA日判定有り.AutoSize = true;
            this.chkWMA日判定有り.ForeColor = System.Drawing.Color.White;
            this.chkWMA日判定有り.Location = new System.Drawing.Point(631, 122);
            this.chkWMA日判定有り.Name = "chkWMA日判定有り";
            this.chkWMA日判定有り.Size = new System.Drawing.Size(129, 19);
            this.chkWMA日判定有り.TabIndex = 60;
            this.chkWMA日判定有り.Text = "WMA日判定有り";
            this.chkWMA日判定有り.UseVisualStyleBackColor = true;
            // 
            // chkBS判定有り
            // 
            this.chkBS判定有り.AutoSize = true;
            this.chkBS判定有り.ForeColor = System.Drawing.Color.White;
            this.chkBS判定有り.Location = new System.Drawing.Point(775, 122);
            this.chkBS判定有り.Name = "chkBS判定有り";
            this.chkBS判定有り.Size = new System.Drawing.Size(102, 19);
            this.chkBS判定有り.TabIndex = 61;
            this.chkBS判定有り.Text = "BS判定有り";
            this.chkBS判定有り.UseVisualStyleBackColor = true;
            // 
            // rdo買い
            // 
            this.rdo買い.AutoSize = true;
            this.rdo買い.Checked = true;
            this.rdo買い.ForeColor = System.Drawing.Color.White;
            this.rdo買い.Location = new System.Drawing.Point(15, 15);
            this.rdo買い.Name = "rdo買い";
            this.rdo買い.Size = new System.Drawing.Size(55, 19);
            this.rdo買い.TabIndex = 62;
            this.rdo買い.TabStop = true;
            this.rdo買い.Text = "買い";
            this.rdo買い.UseVisualStyleBackColor = true;
            // 
            // rdo売り
            // 
            this.rdo売り.AutoSize = true;
            this.rdo売り.ForeColor = System.Drawing.Color.White;
            this.rdo売り.Location = new System.Drawing.Point(76, 15);
            this.rdo売り.Name = "rdo売り";
            this.rdo売り.Size = new System.Drawing.Size(52, 19);
            this.rdo売り.TabIndex = 63;
            this.rdo売り.TabStop = true;
            this.rdo売り.Text = "売り";
            this.rdo売り.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdo買い);
            this.groupBox2.Controls.Add(this.rdo売り);
            this.groupBox2.Location = new System.Drawing.Point(883, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 53);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            // 
            // btn週次に対して日次が反転した際に注文
            // 
            this.btn週次に対して日次が反転した際に注文.ForeColor = System.Drawing.Color.Black;
            this.btn週次に対して日次が反転した際に注文.Location = new System.Drawing.Point(18, 157);
            this.btn週次に対して日次が反転した際に注文.Margin = new System.Windows.Forms.Padding(4);
            this.btn週次に対して日次が反転した際に注文.Name = "btn週次に対して日次が反転した際に注文";
            this.btn週次に対して日次が反転した際に注文.Size = new System.Drawing.Size(318, 36);
            this.btn週次に対して日次が反転した際に注文.TabIndex = 65;
            this.btn週次に対して日次が反転した際に注文.Text = "週次に対して日次が反転した際に注文";
            this.btn週次に対して日次が反転した際に注文.UseVisualStyleBackColor = true;
            this.btn週次に対して日次が反転した際に注文.Click += new System.EventHandler(this.btn週次に対して日次が反転した際に注文_Click);
            // 
            // Fシュミレーション
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1051, 687);
            this.Controls.Add(this.btn週次に対して日次が反転した際に注文);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkBS判定有り);
            this.Controls.Add(this.chkWMA日判定有り);
            this.Controls.Add(this.chkWMA週判定有り);
            this.Controls.Add(this.chkWMA月判定有り);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtコマンドライン);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt口座);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDB接続先);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOrder_Ver7_WMA反転_BS);
            this.Name = "Fシュミレーション";
            this.Text = "Fシュミレーション";
            this.Load += new System.EventHandler(this.Fシュミレーション_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOrder_Ver7_WMA反転_BS;
        private System.Windows.Forms.TextBox txtコマンドライン;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt口座;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDB接続先;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtログ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkWMA月判定有り;
        private System.Windows.Forms.CheckBox chkWMA週判定有り;
        private System.Windows.Forms.CheckBox chkWMA日判定有り;
        private System.Windows.Forms.CheckBox chkBS判定有り;
        private System.Windows.Forms.RadioButton rdo買い;
        private System.Windows.Forms.RadioButton rdo売り;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn週次に対して日次が反転した際に注文;
    }
}