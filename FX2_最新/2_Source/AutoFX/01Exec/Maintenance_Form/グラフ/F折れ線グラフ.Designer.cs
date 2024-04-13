namespace Maintenance_Form.Fグラフ
{
    partial class F折れ線グラフ
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart折れ線グラフ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart折れ線グラフ)).BeginInit();
            this.SuspendLayout();
            // 
            // chart折れ線グラフ
            // 
            this.chart折れ線グラフ.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart折れ線グラフ.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart折れ線グラフ.Legends.Add(legend1);
            this.chart折れ線グラフ.Location = new System.Drawing.Point(1, 0);
            this.chart折れ線グラフ.Name = "chart折れ線グラフ";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart折れ線グラフ.Series.Add(series1);
            this.chart折れ線グラフ.Size = new System.Drawing.Size(563, 383);
            this.chart折れ線グラフ.TabIndex = 0;
            this.chart折れ線グラフ.Text = "chart1";
            // 
            // F折れ線グラフ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(559, 379);
            this.Controls.Add(this.chart折れ線グラフ);
            this.Name = "F折れ線グラフ";
            this.Text = "F折れ線グラフ";
            this.Load += new System.EventHandler(this.F折れ線グラフ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart折れ線グラフ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart折れ線グラフ;
    }
}