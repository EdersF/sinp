namespace SInP
{
    partial class frmIndicadorDiario
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
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grafRupturaPKdiaria = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnAtualizar2 = new System.Windows.Forms.Button();
            this.dtpDataDe2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDataAte2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grafRotativoDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grafAcuracidadeDiario = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grafEanPosicaoDiario = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bgwPosicoesContadas = new System.ComponentModel.BackgroundWorker();
            this.bgwEanPosicaoDiario = new System.ComponentModel.BackgroundWorker();
            this.bgwAcuracidadeDiaria = new System.ComponentModel.BackgroundWorker();
            this.bgwRupturaPKdiaria = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafRupturaPKdiaria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafRotativoDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafAcuracidadeDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafEanPosicaoDiario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.grafRupturaPKdiaria);
            this.panel1.Controls.Add(this.btnAtualizar2);
            this.panel1.Controls.Add(this.dtpDataDe2);
            this.panel1.Controls.Add(this.dtpDataAte2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.grafRotativoDia);
            this.panel1.Controls.Add(this.grafAcuracidadeDiario);
            this.panel1.Controls.Add(this.grafEanPosicaoDiario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 513);
            this.panel1.TabIndex = 0;
            // 
            // grafRupturaPKdiaria
            // 
            this.grafRupturaPKdiaria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafRupturaPKdiaria.BorderlineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 70F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 20F;
            this.grafRupturaPKdiaria.ChartAreas.Add(chartArea1);
            legend1.DockedToChartArea = "ChartArea1";
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.MaximumAutoSize = 80F;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 8F;
            legend1.Position.Width = 60F;
            legend1.Position.X = 20F;
            legend1.Position.Y = 91F;
            this.grafRupturaPKdiaria.Legends.Add(legend1);
            this.grafRupturaPKdiaria.Location = new System.Drawing.Point(3, 77);
            this.grafRupturaPKdiaria.Name = "grafRupturaPKdiaria";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.grafRupturaPKdiaria.Series.Add(series1);
            this.grafRupturaPKdiaria.Size = new System.Drawing.Size(1003, 213);
            this.grafRupturaPKdiaria.TabIndex = 34;
            this.grafRupturaPKdiaria.Tag = "";
            this.grafRupturaPKdiaria.Text = "chart2";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Position.Auto = false;
            title1.Position.Height = 10F;
            title1.Position.Width = 94F;
            title1.Position.X = 3F;
            title1.Text = "Ruptura de Picking";
            this.grafRupturaPKdiaria.Titles.Add(title1);
            // 
            // btnAtualizar2
            // 
            this.btnAtualizar2.Location = new System.Drawing.Point(219, 25);
            this.btnAtualizar2.Name = "btnAtualizar2";
            this.btnAtualizar2.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar2.TabIndex = 33;
            this.btnAtualizar2.Text = "Atualizar";
            this.btnAtualizar2.UseVisualStyleBackColor = true;
            this.btnAtualizar2.Click += new System.EventHandler(this.btnAtualizar2_Click);
            // 
            // dtpDataDe2
            // 
            this.dtpDataDe2.Checked = false;
            this.dtpDataDe2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDe2.Location = new System.Drawing.Point(15, 25);
            this.dtpDataDe2.Name = "dtpDataDe2";
            this.dtpDataDe2.Size = new System.Drawing.Size(96, 20);
            this.dtpDataDe2.TabIndex = 29;
            // 
            // dtpDataAte2
            // 
            this.dtpDataAte2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataAte2.Location = new System.Drawing.Point(117, 25);
            this.dtpDataAte2.Name = "dtpDataAte2";
            this.dtpDataAte2.Size = new System.Drawing.Size(96, 20);
            this.dtpDataAte2.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "até";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Período";
            // 
            // grafRotativoDia
            // 
            this.grafRotativoDia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 82F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 10F;
            this.grafRotativoDia.ChartAreas.Add(chartArea2);
            legend2.DockedToChartArea = "ChartArea1";
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.MaximumAutoSize = 80F;
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 8F;
            legend2.Position.Width = 60F;
            legend2.Position.X = 20F;
            legend2.Position.Y = 91F;
            this.grafRotativoDia.Legends.Add(legend2);
            this.grafRotativoDia.Location = new System.Drawing.Point(12, 888);
            this.grafRotativoDia.Name = "grafRotativoDia";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.grafRotativoDia.Series.Add(series2);
            this.grafRotativoDia.Size = new System.Drawing.Size(985, 292);
            this.grafRotativoDia.TabIndex = 14;
            this.grafRotativoDia.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Posições CONTADAS DIARIO";
            this.grafRotativoDia.Titles.Add(title2);
            this.grafRotativoDia.Visible = false;
            // 
            // grafAcuracidadeDiario
            // 
            this.grafAcuracidadeDiario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisY.Maximum = 100D;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea3.Name = "ChartArea1";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 80F;
            chartArea3.Position.Width = 100F;
            chartArea3.Position.Y = 20F;
            this.grafAcuracidadeDiario.ChartAreas.Add(chartArea3);
            legend3.DockedToChartArea = "ChartArea1";
            legend3.Enabled = false;
            legend3.IsTextAutoFit = false;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend3.MaximumAutoSize = 80F;
            legend3.Name = "Legend1";
            legend3.Position.Auto = false;
            legend3.Position.Height = 8F;
            legend3.Position.Width = 60F;
            legend3.Position.X = 20F;
            legend3.Position.Y = 91F;
            this.grafAcuracidadeDiario.Legends.Add(legend3);
            this.grafAcuracidadeDiario.Location = new System.Drawing.Point(12, 662);
            this.grafAcuracidadeDiario.Name = "grafAcuracidadeDiario";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.grafAcuracidadeDiario.Series.Add(series3);
            this.grafAcuracidadeDiario.Size = new System.Drawing.Size(985, 220);
            this.grafAcuracidadeDiario.TabIndex = 13;
            this.grafAcuracidadeDiario.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            title3.Name = "Title1";
            title3.Position.Auto = false;
            title3.Position.Height = 20F;
            title3.Position.Width = 94F;
            title3.Position.X = 3F;
            title3.Text = "Acuracidade de estoque DIÁRIA";
            this.grafAcuracidadeDiario.Titles.Add(title3);
            this.grafAcuracidadeDiario.Visible = false;
            // 
            // grafEanPosicaoDiario
            // 
            this.grafEanPosicaoDiario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisY.IsStartedFromZero = false;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea4.AxisY.Maximum = 100D;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea4.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea4.Name = "ChartArea1";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 80F;
            chartArea4.Position.Width = 100F;
            chartArea4.Position.Y = 20F;
            this.grafEanPosicaoDiario.ChartAreas.Add(chartArea4);
            legend4.DockedToChartArea = "ChartArea1";
            legend4.Enabled = false;
            legend4.IsTextAutoFit = false;
            legend4.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend4.MaximumAutoSize = 80F;
            legend4.Name = "Legend1";
            legend4.Position.Auto = false;
            legend4.Position.Height = 8F;
            legend4.Position.Width = 60F;
            legend4.Position.X = 20F;
            legend4.Position.Y = 91F;
            this.grafEanPosicaoDiario.Legends.Add(legend4);
            this.grafEanPosicaoDiario.Location = new System.Drawing.Point(21, 435);
            this.grafEanPosicaoDiario.Name = "grafEanPosicaoDiario";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.grafEanPosicaoDiario.Series.Add(series4);
            this.grafEanPosicaoDiario.Size = new System.Drawing.Size(985, 221);
            this.grafEanPosicaoDiario.TabIndex = 11;
            this.grafEanPosicaoDiario.Text = "chart1";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title4.Name = "Title1";
            title4.Position.Auto = false;
            title4.Position.Height = 5.236815F;
            title4.Position.Width = 94F;
            title4.Position.X = 3F;
            title4.Text = "Ean Posição DIARIO";
            this.grafEanPosicaoDiario.Titles.Add(title4);
            this.grafEanPosicaoDiario.Visible = false;
            // 
            // bgwRupturaPKdiaria
            // 
            this.bgwRupturaPKdiaria.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRupturaPKdiaria_DoWork);
            this.bgwRupturaPKdiaria.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRupturaPKdiaria_RunWorkerCompleted);
            // 
            // frmIndicadorDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 513);
            this.Controls.Add(this.panel1);
            this.Name = "frmIndicadorDiario";
            this.Text = "Indicador Diário";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmIndicadorDiario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafRupturaPKdiaria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafRotativoDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafAcuracidadeDiario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafEanPosicaoDiario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafEanPosicaoDiario;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafAcuracidadeDiario;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafRotativoDia;
        private System.Windows.Forms.Button btnAtualizar2;
        private System.Windows.Forms.DateTimePicker dtpDataDe2;
        private System.Windows.Forms.DateTimePicker dtpDataAte2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker bgwPosicoesContadas;
        private System.ComponentModel.BackgroundWorker bgwEanPosicaoDiario;
        private System.ComponentModel.BackgroundWorker bgwAcuracidadeDiaria;
        private System.ComponentModel.BackgroundWorker bgwRupturaPKdiaria;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafRupturaPKdiaria;
    }
}