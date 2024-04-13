namespace Maintenance_Form.F手動データ登録
{
    partial class F環境設定
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv環境設定一覧 = new System.Windows.Forms.DataGridView();
            this.btn更新 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv環境設定一覧)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgv環境設定一覧);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 483);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "環境設定一覧";
            // 
            // dgv環境設定一覧
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            this.dgv環境設定一覧.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv環境設定一覧.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv環境設定一覧.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv環境設定一覧.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv環境設定一覧.Location = new System.Drawing.Point(9, 21);
            this.dgv環境設定一覧.Name = "dgv環境設定一覧";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            this.dgv環境設定一覧.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv環境設定一覧.RowTemplate.Height = 24;
            this.dgv環境設定一覧.Size = new System.Drawing.Size(657, 447);
            this.dgv環境設定一覧.TabIndex = 5;
            // 
            // btn更新
            // 
            this.btn更新.ForeColor = System.Drawing.Color.Black;
            this.btn更新.Location = new System.Drawing.Point(539, 502);
            this.btn更新.Margin = new System.Windows.Forms.Padding(4);
            this.btn更新.Name = "btn更新";
            this.btn更新.Size = new System.Drawing.Size(144, 27);
            this.btn更新.TabIndex = 28;
            this.btn更新.Text = "更新";
            this.btn更新.UseVisualStyleBackColor = true;
            this.btn更新.Click += new System.EventHandler(this.btn更新_Click);
            // 
            // F環境設定
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(696, 541);
            this.Controls.Add(this.btn更新);
            this.Controls.Add(this.groupBox2);
            this.Name = "F環境設定";
            this.Text = "F環境設定";
            this.Load += new System.EventHandler(this.F環境設定_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv環境設定一覧)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv環境設定一覧;
        private System.Windows.Forms.Button btn更新;
    }
}