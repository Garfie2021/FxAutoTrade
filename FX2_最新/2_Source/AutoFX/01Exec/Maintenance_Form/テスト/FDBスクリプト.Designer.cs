namespace Maintenance_Form
{
    partial class FDBスクリプト
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDBスクリプト));
            this.btnスキーマ比較開始 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDB元 = new System.Windows.Forms.TextBox();
            this.txtSVNとの比較用に加工したDBスクリプトの保存先 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDBとの比較用に加工したSVNスクリプトの保存先 = new System.Windows.Forms.TextBox();
            this.btn加工開始_SVN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSVN元 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn加工開始_DB = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTextData加工済みファイルの保存先_DB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnストアド比較開始 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnスキーマ比較開始
            // 
            this.btnスキーマ比較開始.Location = new System.Drawing.Point(11, 57);
            this.btnスキーマ比較開始.Name = "btnスキーマ比較開始";
            this.btnスキーマ比較開始.Size = new System.Drawing.Size(169, 36);
            this.btnスキーマ比較開始.TabIndex = 0;
            this.btnスキーマ比較開始.Text = "スキーマ比較開始";
            this.btnスキーマ比較開始.UseVisualStyleBackColor = true;
            this.btnスキーマ比較開始.Click += new System.EventHandler(this.btnスキーマ比較開始_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "DBから出力したスクリプトの保存先フォルダ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "SVNとの比較用に加工したDBスクリプトの保存先";
            // 
            // txtDB元
            // 
            this.txtDB元.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDB元.Location = new System.Drawing.Point(311, 21);
            this.txtDB元.Name = "txtDB元";
            this.txtDB元.Size = new System.Drawing.Size(483, 22);
            this.txtDB元.TabIndex = 4;
            this.txtDB元.Text = "C:\\Users\\1111\\Documents\\DBスクリプト比較\\DB\\plane";
            // 
            // txtSVNとの比較用に加工したDBスクリプトの保存先
            // 
            this.txtSVNとの比較用に加工したDBスクリプトの保存先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSVNとの比較用に加工したDBスクリプトの保存先.Location = new System.Drawing.Point(311, 59);
            this.txtSVNとの比較用に加工したDBスクリプトの保存先.Name = "txtSVNとの比較用に加工したDBスクリプトの保存先";
            this.txtSVNとの比較用に加工したDBスクリプトの保存先.Size = new System.Drawing.Size(483, 22);
            this.txtSVNとの比較用に加工したDBスクリプトの保存先.TabIndex = 5;
            this.txtSVNとの比較用に加工したDBスクリプトの保存先.Text = "C:\\Users\\1111\\Documents\\DBスクリプト比較\\DB\\フォルダ構成加工済み";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDB元);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(846, 63);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. DBスクリプトを出力";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtDBとの比較用に加工したSVNスクリプトの保存先);
            this.groupBox2.Controls.Add(this.btn加工開始_SVN);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtSVN元);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 442);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(846, 163);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "4. SVNのDBスクリプトを比較用に加工";
            // 
            // txtDBとの比較用に加工したSVNスクリプトの保存先
            // 
            this.txtDBとの比較用に加工したSVNスクリプトの保存先.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBとの比較用に加工したSVNスクリプトの保存先.Location = new System.Drawing.Point(311, 51);
            this.txtDBとの比較用に加工したSVNスクリプトの保存先.Name = "txtDBとの比較用に加工したSVNスクリプトの保存先";
            this.txtDBとの比較用に加工したSVNスクリプトの保存先.Size = new System.Drawing.Size(483, 22);
            this.txtDBとの比較用に加工したSVNスクリプトの保存先.TabIndex = 12;
            this.txtDBとの比較用に加工したSVNスクリプトの保存先.Text = "C:\\Users\\1111\\Documents\\DBスクリプト比較\\SVN\\TextData加工済み";
            // 
            // btn加工開始_SVN
            // 
            this.btn加工開始_SVN.Location = new System.Drawing.Point(11, 109);
            this.btn加工開始_SVN.Name = "btn加工開始_SVN";
            this.btn加工開始_SVN.Size = new System.Drawing.Size(169, 36);
            this.btn加工開始_SVN.TabIndex = 10;
            this.btn加工開始_SVN.Text = "加工開始（SVN）";
            this.btn加工開始_SVN.UseVisualStyleBackColor = true;
            this.btn加工開始_SVN.Click += new System.EventHandler(this.btn加工開始_SVN_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "SVNのDB比較用に加工したスクリプトの保存先";
            // 
            // txtSVN元
            // 
            this.txtSVN元.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSVN元.Location = new System.Drawing.Point(311, 21);
            this.txtSVN元.Name = "txtSVN元";
            this.txtSVN元.Size = new System.Drawing.Size(483, 22);
            this.txtSVN元.TabIndex = 4;
            this.txtSVN元.Text = "D:\\work\\3_FX\\2_FX2\\trunk2\\3_SourceDB\\RealA\\1_DDL\\2_SP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "SVNのDBスクリプトの保存先フォルダ";
            // 
            // btn加工開始_DB
            // 
            this.btn加工開始_DB.Location = new System.Drawing.Point(6, 86);
            this.btn加工開始_DB.Name = "btn加工開始_DB";
            this.btn加工開始_DB.Size = new System.Drawing.Size(169, 36);
            this.btn加工開始_DB.TabIndex = 8;
            this.btn加工開始_DB.Text = "加工開始（DB）";
            this.btn加工開始_DB.UseVisualStyleBackColor = true;
            this.btn加工開始_DB.Click += new System.EventHandler(this.btn加工開始_DB_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtTextData加工済みファイルの保存先_DB);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btn加工開始_DB);
            this.groupBox3.Controls.Add(this.txtSVNとの比較用に加工したDBスクリプトの保存先);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 287);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(846, 138);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. DBから出力したスクリプトを比較用に加工";
            // 
            // txtTextData加工済みファイルの保存先_DB
            // 
            this.txtTextData加工済みファイルの保存先_DB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextData加工済みファイルの保存先_DB.Location = new System.Drawing.Point(311, 24);
            this.txtTextData加工済みファイルの保存先_DB.Name = "txtTextData加工済みファイルの保存先_DB";
            this.txtTextData加工済みファイルの保存先_DB.Size = new System.Drawing.Size(483, 22);
            this.txtTextData加工済みファイルの保存先_DB.TabIndex = 10;
            this.txtTextData加工済みファイルの保存先_DB.Text = "C:\\Users\\1111\\Documents\\DBスクリプト比較\\DB\\TextData加工済み";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "TextData加工済みファイルの保存先";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnストアド比較開始);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnスキーマ比較開始);
            this.groupBox4.Location = new System.Drawing.Point(12, 611);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(846, 100);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "5. 比較";
            // 
            // btnストアド比較開始
            // 
            this.btnストアド比較開始.Location = new System.Drawing.Point(194, 57);
            this.btnストアド比較開始.Name = "btnストアド比較開始";
            this.btnストアド比較開始.Size = new System.Drawing.Size(169, 36);
            this.btnストアド比較開始.TabIndex = 12;
            this.btnストアド比較開始.Text = "ストアド比較開始";
            this.btnストアド比較開始.UseVisualStyleBackColor = true;
            this.btnストアド比較開始.Click += new System.EventHandler(this.btnストアド比較開始_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "加工済みスクリプトファイルを比較";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(846, 196);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "1. 事前に作業用フォルダを作成";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(11, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(783, 155);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // FDBスクリプト
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 742);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FDBスクリプト";
            this.Text = "DBスクリプト";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnスキーマ比較開始;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDB元;
        private System.Windows.Forms.TextBox txtSVNとの比較用に加工したDBスクリプトの保存先;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSVN元;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn加工開始_DB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn加工開始_SVN;
        private System.Windows.Forms.TextBox txtTextData加工済みファイルの保存先_DB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDBとの比較用に加工したSVNスクリプトの保存先;
        private System.Windows.Forms.Button btnストアド比較開始;
    }
}