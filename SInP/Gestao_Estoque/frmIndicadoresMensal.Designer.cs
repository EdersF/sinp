namespace SInP
{
    partial class frmIndicadoresMensal
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
            this.components = new System.ComponentModel.Container();
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
            this.pnGrafico = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grafRupturaPK = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmsRuptura = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.targetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TipotoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colunasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pizzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.racionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.grafAcuracidadeMensal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grafEanPosicaoMensal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpDe2 = new System.Windows.Forms.DateTimePicker();
            this.dtpAte2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAtulizar2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grafRotativoPercent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDe1 = new System.Windows.Forms.DateTimePicker();
            this.btnAtualizar1 = new System.Windows.Forms.Button();
            this.lblPosPendentes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUltimoInvent = new System.Windows.Forms.Label();
            this.dtpAte1 = new System.Windows.Forms.DateTimePicker();
            this.lblPosContadas = new System.Windows.Forms.Label();
            this.bgwGrafEvolucaoRotativo = new System.ComponentModel.BackgroundWorker();
            this.bgwAcuracidadeMensal = new System.ComponentModel.BackgroundWorker();
            this.bgwEanPosicaoMensal = new System.ComponentModel.BackgroundWorker();
            this.bgwRupturaPK = new System.ComponentModel.BackgroundWorker();
            this.pnGrafico.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafRupturaPK)).BeginInit();
            this.cmsRuptura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafAcuracidadeMensal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafEanPosicaoMensal)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafRotativoPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnGrafico
            // 
            this.pnGrafico.AutoScroll = true;
            this.pnGrafico.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnGrafico.Controls.Add(this.panel2);
            this.pnGrafico.Controls.Add(this.panel1);
            this.pnGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrafico.Location = new System.Drawing.Point(0, 0);
            this.pnGrafico.Name = "pnGrafico";
            this.pnGrafico.Size = new System.Drawing.Size(1114, 742);
            this.pnGrafico.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Controls.Add(this.grafRupturaPK);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.grafAcuracidadeMensal);
            this.panel2.Controls.Add(this.grafEanPosicaoMensal);
            this.panel2.Controls.Add(this.dtpDe2);
            this.panel2.Controls.Add(this.dtpAte2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnAtulizar2);
            this.panel2.Location = new System.Drawing.Point(3, 434);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1057, 826);
            this.panel2.TabIndex = 28;
            // 
            // grafRupturaPK
            // 
            this.grafRupturaPK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafRupturaPK.BorderlineColor = System.Drawing.Color.DimGray;
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
            this.grafRupturaPK.ChartAreas.Add(chartArea1);
            this.grafRupturaPK.ContextMenuStrip = this.cmsRuptura;
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
            this.grafRupturaPK.Legends.Add(legend1);
            this.grafRupturaPK.Location = new System.Drawing.Point(3, 67);
            this.grafRupturaPK.Name = "grafRupturaPK";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.grafRupturaPK.Series.Add(series1);
            this.grafRupturaPK.Size = new System.Drawing.Size(1051, 213);
            this.grafRupturaPK.TabIndex = 13;
            this.grafRupturaPK.Tag = "";
            this.grafRupturaPK.Text = "chart2";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Position.Auto = false;
            title1.Position.Height = 10F;
            title1.Position.Width = 94F;
            title1.Position.X = 3F;
            title1.Text = "Ruptura de Picking";
            this.grafRupturaPK.Titles.Add(title1);
            // 
            // cmsRuptura
            // 
            this.cmsRuptura.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.targetToolStripMenuItem,
            this.TipotoolStripMenuItem1,
            this.toolStripSeparator1,
            this.racionalToolStripMenuItem});
            this.cmsRuptura.Name = "cmsAcuracidadeMensal";
            this.cmsRuptura.ShowImageMargin = false;
            this.cmsRuptura.Size = new System.Drawing.Size(132, 76);
            // 
            // targetToolStripMenuItem
            // 
            this.targetToolStripMenuItem.Enabled = false;
            this.targetToolStripMenuItem.Name = "targetToolStripMenuItem";
            this.targetToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.targetToolStripMenuItem.Text = "Target";
            // 
            // TipotoolStripMenuItem1
            // 
            this.TipotoolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colunasToolStripMenuItem,
            this.linhaToolStripMenuItem,
            this.pizzaToolStripMenuItem,
            this.barraToolStripMenuItem});
            this.TipotoolStripMenuItem1.Name = "TipotoolStripMenuItem1";
            this.TipotoolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.TipotoolStripMenuItem1.Text = "Tipo do Gráfico";
            // 
            // colunasToolStripMenuItem
            // 
            this.colunasToolStripMenuItem.Name = "colunasToolStripMenuItem";
            this.colunasToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.colunasToolStripMenuItem.Text = "Colunas";
            // 
            // linhaToolStripMenuItem
            // 
            this.linhaToolStripMenuItem.Name = "linhaToolStripMenuItem";
            this.linhaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.linhaToolStripMenuItem.Text = "Linha";
            // 
            // pizzaToolStripMenuItem
            // 
            this.pizzaToolStripMenuItem.Name = "pizzaToolStripMenuItem";
            this.pizzaToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pizzaToolStripMenuItem.Text = "Pizza";
            // 
            // barraToolStripMenuItem
            // 
            this.barraToolStripMenuItem.Name = "barraToolStripMenuItem";
            this.barraToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.barraToolStripMenuItem.Text = "Barra";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
            // 
            // racionalToolStripMenuItem
            // 
            this.racionalToolStripMenuItem.Name = "racionalToolStripMenuItem";
            this.racionalToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.racionalToolStripMenuItem.Text = "Racional";
            this.racionalToolStripMenuItem.Click += new System.EventHandler(this.racionalToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "De:";
            // 
            // grafAcuracidadeMensal
            // 
            this.grafAcuracidadeMensal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafAcuracidadeMensal.BorderlineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.Maximum = 100D;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 80F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 20F;
            this.grafAcuracidadeMensal.ChartAreas.Add(chartArea2);
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Enabled = false;
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.MaximumAutoSize = 80F;
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 8F;
            legend2.Position.Width = 60F;
            legend2.Position.X = 20F;
            legend2.Position.Y = 91F;
            this.grafAcuracidadeMensal.Legends.Add(legend2);
            this.grafAcuracidadeMensal.Location = new System.Drawing.Point(0, 291);
            this.grafAcuracidadeMensal.Name = "grafAcuracidadeMensal";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.grafAcuracidadeMensal.Series.Add(series2);
            this.grafAcuracidadeMensal.Size = new System.Drawing.Size(1054, 213);
            this.grafAcuracidadeMensal.TabIndex = 13;
            this.grafAcuracidadeMensal.Tag = "Racional: Valor total do estoque / total de divergências";
            this.grafAcuracidadeMensal.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            title2.Name = "Title1";
            title2.Position.Auto = false;
            title2.Position.Height = 10F;
            title2.Position.Width = 94F;
            title2.Position.X = 3F;
            title2.Text = "Acuracidade de Estoque MENSAL";
            this.grafAcuracidadeMensal.Titles.Add(title2);
            this.grafAcuracidadeMensal.Visible = false;
            // 
            // grafEanPosicaoMensal
            // 
            this.grafEanPosicaoMensal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grafEanPosicaoMensal.BorderlineColor = System.Drawing.Color.DimGray;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisY.Maximum = 100D;
            chartArea3.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea3.Name = "ChartArea1";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 90F;
            chartArea3.Position.Width = 100F;
            chartArea3.Position.Y = 10F;
            this.grafEanPosicaoMensal.ChartAreas.Add(chartArea3);
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
            this.grafEanPosicaoMensal.Legends.Add(legend3);
            this.grafEanPosicaoMensal.Location = new System.Drawing.Point(0, 530);
            this.grafEanPosicaoMensal.Name = "grafEanPosicaoMensal";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.grafEanPosicaoMensal.Series.Add(series3);
            this.grafEanPosicaoMensal.Size = new System.Drawing.Size(1054, 213);
            this.grafEanPosicaoMensal.TabIndex = 11;
            this.grafEanPosicaoMensal.Text = "chart1";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            title3.Name = "Title1";
            title3.Position.Auto = false;
            title3.Position.Height = 5.236815F;
            title3.Position.Width = 94F;
            title3.Position.X = 3F;
            title3.Text = "Ean Posição Mensal";
            this.grafEanPosicaoMensal.Titles.Add(title3);
            this.grafEanPosicaoMensal.Visible = false;
            // 
            // dtpDe2
            // 
            this.dtpDe2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe2.Location = new System.Drawing.Point(9, 27);
            this.dtpDe2.Name = "dtpDe2";
            this.dtpDe2.Size = new System.Drawing.Size(96, 20);
            this.dtpDe2.TabIndex = 1;
            // 
            // dtpAte2
            // 
            this.dtpAte2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte2.Location = new System.Drawing.Point(111, 27);
            this.dtpAte2.Name = "dtpAte2";
            this.dtpAte2.Size = new System.Drawing.Size(96, 20);
            this.dtpAte2.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(108, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Até:";
            // 
            // btnAtulizar2
            // 
            this.btnAtulizar2.Location = new System.Drawing.Point(222, 24);
            this.btnAtulizar2.Name = "btnAtulizar2";
            this.btnAtulizar2.Size = new System.Drawing.Size(75, 23);
            this.btnAtulizar2.TabIndex = 26;
            this.btnAtulizar2.Text = "Atualizar";
            this.btnAtulizar2.UseVisualStyleBackColor = true;
            this.btnAtulizar2.Click += new System.EventHandler(this.btnAtulizar2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.grafRotativoPercent);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpDe1);
            this.panel1.Controls.Add(this.btnAtualizar1);
            this.panel1.Controls.Add(this.lblPosPendentes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblUltimoInvent);
            this.panel1.Controls.Add(this.dtpAte1);
            this.panel1.Controls.Add(this.lblPosContadas);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 425);
            this.panel1.TabIndex = 27;
            // 
            // grafRotativoPercent
            // 
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea4.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea4.Name = "ChartArea1";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 81F;
            chartArea4.Position.Width = 100F;
            chartArea4.Position.Y = 19F;
            this.grafRotativoPercent.ChartAreas.Add(chartArea4);
            legend4.DockedToChartArea = "ChartArea1";
            legend4.IsTextAutoFit = false;
            legend4.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend4.MaximumAutoSize = 80F;
            legend4.Name = "Legend1";
            this.grafRotativoPercent.Legends.Add(legend4);
            this.grafRotativoPercent.Location = new System.Drawing.Point(9, 59);
            this.grafRotativoPercent.Name = "grafRotativoPercent";
            this.grafRotativoPercent.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series4.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Contado";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.grafRotativoPercent.Series.Add(series4);
            this.grafRotativoPercent.Size = new System.Drawing.Size(406, 306);
            this.grafRotativoPercent.TabIndex = 9;
            this.grafRotativoPercent.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "De:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(490, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Posições Pendentes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(490, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Posições Contadas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(490, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Último Inventário Salvo:";
            // 
            // dtpDe1
            // 
            this.dtpDe1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe1.Location = new System.Drawing.Point(9, 33);
            this.dtpDe1.Name = "dtpDe1";
            this.dtpDe1.Size = new System.Drawing.Size(96, 20);
            this.dtpDe1.TabIndex = 1;
            // 
            // btnAtualizar1
            // 
            this.btnAtualizar1.Enabled = false;
            this.btnAtualizar1.Location = new System.Drawing.Point(222, 30);
            this.btnAtualizar1.Name = "btnAtualizar1";
            this.btnAtualizar1.Size = new System.Drawing.Size(98, 23);
            this.btnAtualizar1.TabIndex = 26;
            this.btnAtualizar1.Text = "Atualizando...";
            this.btnAtualizar1.UseVisualStyleBackColor = true;
            this.btnAtualizar1.Click += new System.EventHandler(this.btnAtualizar1_Click);
            // 
            // lblPosPendentes
            // 
            this.lblPosPendentes.AutoSize = true;
            this.lblPosPendentes.ForeColor = System.Drawing.Color.Black;
            this.lblPosPendentes.Location = new System.Drawing.Point(615, 106);
            this.lblPosPendentes.Name = "lblPosPendentes";
            this.lblPosPendentes.Size = new System.Drawing.Size(31, 13);
            this.lblPosPendentes.TabIndex = 17;
            this.lblPosPendentes.Text = "--------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(108, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Até:";
            // 
            // lblUltimoInvent
            // 
            this.lblUltimoInvent.AutoSize = true;
            this.lblUltimoInvent.ForeColor = System.Drawing.Color.Black;
            this.lblUltimoInvent.Location = new System.Drawing.Point(615, 152);
            this.lblUltimoInvent.Name = "lblUltimoInvent";
            this.lblUltimoInvent.Size = new System.Drawing.Size(31, 13);
            this.lblUltimoInvent.TabIndex = 17;
            this.lblUltimoInvent.Text = "--------";
            // 
            // dtpAte1
            // 
            this.dtpAte1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte1.Location = new System.Drawing.Point(111, 33);
            this.dtpAte1.Name = "dtpAte1";
            this.dtpAte1.Size = new System.Drawing.Size(96, 20);
            this.dtpAte1.TabIndex = 21;
            // 
            // lblPosContadas
            // 
            this.lblPosContadas.AutoSize = true;
            this.lblPosContadas.ForeColor = System.Drawing.Color.Black;
            this.lblPosContadas.Location = new System.Drawing.Point(615, 129);
            this.lblPosContadas.Name = "lblPosContadas";
            this.lblPosContadas.Size = new System.Drawing.Size(31, 13);
            this.lblPosContadas.TabIndex = 17;
            this.lblPosContadas.Text = "--------";
            // 
            // bgwGrafEvolucaoRotativo
            // 
            this.bgwGrafEvolucaoRotativo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwGrafEvolucaoRotativo_DoWork_1);
            this.bgwGrafEvolucaoRotativo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwGrafEvolucaoRotativo_RunWorkerCompleted);
            // 
            // bgwAcuracidadeMensal
            // 
            this.bgwAcuracidadeMensal.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwAcuracidadeMensal_DoWork);
            // 
            // bgwEanPosicaoMensal
            // 
            this.bgwEanPosicaoMensal.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwEanPosicaoMensal_DoWork);
            // 
            // bgwRupturaPK
            // 
            this.bgwRupturaPK.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRupturaPK_DoWork);
            this.bgwRupturaPK.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRupturaPK_RunWorkerCompleted);
            // 
            // frmIndicadoresMensal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 742);
            this.Controls.Add(this.pnGrafico);
            this.Name = "frmIndicadoresMensal";
            this.Text = "Indicadores Mensal";
            this.Load += new System.EventHandler(this.frmIndicadores_Load);
            this.pnGrafico.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafRupturaPK)).EndInit();
            this.cmsRuptura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grafAcuracidadeMensal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafEanPosicaoMensal)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grafRotativoPercent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafAcuracidadeMensal;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafEanPosicaoMensal;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafRotativoPercent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUltimoInvent;
        private System.ComponentModel.BackgroundWorker bgwGrafEvolucaoRotativo;
        private System.Windows.Forms.DateTimePicker dtpDe1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAte1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPosContadas;
        private System.Windows.Forms.Label lblPosPendentes;
        private System.ComponentModel.BackgroundWorker bgwAcuracidadeMensal;
        private System.ComponentModel.BackgroundWorker bgwEanPosicaoMensal;
        private System.Windows.Forms.Button btnAtualizar1;
        private System.Windows.Forms.ContextMenuStrip cmsRuptura;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafRupturaPK;
        private System.ComponentModel.BackgroundWorker bgwRupturaPK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDe2;
        private System.Windows.Forms.DateTimePicker dtpAte2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAtulizar2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem targetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem racionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TipotoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem colunasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linhaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pizzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}