namespace SInP
{
    partial class frmInventarioPainel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioPainel));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnConfig = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPlanProdutividade = new System.Windows.Forms.Label();
            this.lblPlanContadores = new System.Windows.Forms.Label();
            this.lblPlanSegunda = new System.Windows.Forms.Label();
            this.lblPlanTerceira = new System.Windows.Forms.Label();
            this.lblPlanTermino = new System.Windows.Forms.Label();
            this.lblRealProdutividade = new System.Windows.Forms.Label();
            this.lblRealContadores = new System.Windows.Forms.Label();
            this.lblRealSegunda = new System.Windows.Forms.Label();
            this.lblRealTerceira = new System.Windows.Forms.Label();
            this.lblRealTermino = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.grafContagens = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafContagens)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(13, 13);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(89, 23);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "Configurações";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(425, 247);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblPlanProdutividade
            // 
            this.lblPlanProdutividade.AutoSize = true;
            this.lblPlanProdutividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanProdutividade.Location = new System.Drawing.Point(190, 85);
            this.lblPlanProdutividade.Name = "lblPlanProdutividade";
            this.lblPlanProdutividade.Size = new System.Drawing.Size(50, 20);
            this.lblPlanProdutividade.TabIndex = 2;
            this.lblPlanProdutividade.Text = "100%";
            // 
            // lblPlanContadores
            // 
            this.lblPlanContadores.AutoSize = true;
            this.lblPlanContadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanContadores.Location = new System.Drawing.Point(190, 124);
            this.lblPlanContadores.Name = "lblPlanContadores";
            this.lblPlanContadores.Size = new System.Drawing.Size(51, 20);
            this.lblPlanContadores.TabIndex = 2;
            this.lblPlanContadores.Text = "label1";
            // 
            // lblPlanSegunda
            // 
            this.lblPlanSegunda.AutoSize = true;
            this.lblPlanSegunda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanSegunda.Location = new System.Drawing.Point(190, 166);
            this.lblPlanSegunda.Name = "lblPlanSegunda";
            this.lblPlanSegunda.Size = new System.Drawing.Size(51, 20);
            this.lblPlanSegunda.TabIndex = 2;
            this.lblPlanSegunda.Text = "label1";
            // 
            // lblPlanTerceira
            // 
            this.lblPlanTerceira.AutoSize = true;
            this.lblPlanTerceira.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanTerceira.Location = new System.Drawing.Point(190, 207);
            this.lblPlanTerceira.Name = "lblPlanTerceira";
            this.lblPlanTerceira.Size = new System.Drawing.Size(51, 20);
            this.lblPlanTerceira.TabIndex = 2;
            this.lblPlanTerceira.Text = "label1";
            // 
            // lblPlanTermino
            // 
            this.lblPlanTermino.AutoSize = true;
            this.lblPlanTermino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanTermino.Location = new System.Drawing.Point(163, 249);
            this.lblPlanTermino.Name = "lblPlanTermino";
            this.lblPlanTermino.Size = new System.Drawing.Size(45, 16);
            this.lblPlanTermino.TabIndex = 2;
            this.lblPlanTermino.Text = "label1";
            // 
            // lblRealProdutividade
            // 
            this.lblRealProdutividade.AutoSize = true;
            this.lblRealProdutividade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealProdutividade.Location = new System.Drawing.Point(324, 85);
            this.lblRealProdutividade.Name = "lblRealProdutividade";
            this.lblRealProdutividade.Size = new System.Drawing.Size(51, 20);
            this.lblRealProdutividade.TabIndex = 2;
            this.lblRealProdutividade.Text = "label1";
            // 
            // lblRealContadores
            // 
            this.lblRealContadores.AutoSize = true;
            this.lblRealContadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealContadores.Location = new System.Drawing.Point(324, 124);
            this.lblRealContadores.Name = "lblRealContadores";
            this.lblRealContadores.Size = new System.Drawing.Size(51, 20);
            this.lblRealContadores.TabIndex = 2;
            this.lblRealContadores.Text = "label1";
            // 
            // lblRealSegunda
            // 
            this.lblRealSegunda.AutoSize = true;
            this.lblRealSegunda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealSegunda.Location = new System.Drawing.Point(324, 166);
            this.lblRealSegunda.Name = "lblRealSegunda";
            this.lblRealSegunda.Size = new System.Drawing.Size(51, 20);
            this.lblRealSegunda.TabIndex = 2;
            this.lblRealSegunda.Text = "label1";
            // 
            // lblRealTerceira
            // 
            this.lblRealTerceira.AutoSize = true;
            this.lblRealTerceira.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealTerceira.Location = new System.Drawing.Point(324, 207);
            this.lblRealTerceira.Name = "lblRealTerceira";
            this.lblRealTerceira.Size = new System.Drawing.Size(51, 20);
            this.lblRealTerceira.TabIndex = 2;
            this.lblRealTerceira.Text = "label1";
            // 
            // lblRealTermino
            // 
            this.lblRealTermino.AutoSize = true;
            this.lblRealTermino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealTermino.Location = new System.Drawing.Point(324, 249);
            this.lblRealTermino.Name = "lblRealTermino";
            this.lblRealTermino.Size = new System.Drawing.Size(51, 20);
            this.lblRealTermino.TabIndex = 2;
            this.lblRealTermino.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Atualizar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(444, 92);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "detalhes";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // grafContagens
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 81F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 19F;
            this.grafContagens.ChartAreas.Add(chartArea1);
            legend1.DockedToChartArea = "ChartArea1";
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.MaximumAutoSize = 80F;
            legend1.Name = "Legend1";
            this.grafContagens.Legends.Add(legend1);
            this.grafContagens.Location = new System.Drawing.Point(510, 42);
            this.grafContagens.Name = "grafContagens";
            this.grafContagens.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Contado";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.grafContagens.Series.Add(series1);
            this.grafContagens.Size = new System.Drawing.Size(494, 305);
            this.grafContagens.TabIndex = 10;
            this.grafContagens.Text = "chart1";
            // 
            // frmInventarioPainel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1191, 690);
            this.Controls.Add(this.grafContagens);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblRealTermino);
            this.Controls.Add(this.lblPlanTermino);
            this.Controls.Add(this.lblRealTerceira);
            this.Controls.Add(this.lblPlanTerceira);
            this.Controls.Add(this.lblRealSegunda);
            this.Controls.Add(this.lblPlanSegunda);
            this.Controls.Add(this.lblRealContadores);
            this.Controls.Add(this.lblPlanContadores);
            this.Controls.Add(this.lblRealProdutividade);
            this.Controls.Add(this.lblPlanProdutividade);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnConfig);
            this.Name = "frmInventarioPainel";
            this.Text = "Painel";
            this.Load += new System.EventHandler(this.frmInventarioPainel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafContagens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPlanProdutividade;
        private System.Windows.Forms.Label lblPlanContadores;
        private System.Windows.Forms.Label lblPlanSegunda;
        private System.Windows.Forms.Label lblPlanTerceira;
        private System.Windows.Forms.Label lblPlanTermino;
        private System.Windows.Forms.Label lblRealProdutividade;
        private System.Windows.Forms.Label lblRealContadores;
        private System.Windows.Forms.Label lblRealSegunda;
        private System.Windows.Forms.Label lblRealTerceira;
        private System.Windows.Forms.Label lblRealTermino;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafContagens;
    }
}