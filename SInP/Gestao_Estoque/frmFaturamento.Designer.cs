namespace SInP.Gestão_de_Estoque
{
    partial class frmFaturamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.btnLancar = new System.Windows.Forms.Button();
            this.txtLinhas = new System.Windows.Forms.TextBox();
            this.dgvFaturamento = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturamento)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpData
            // 
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(13, 39);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(98, 20);
            this.dtpData.TabIndex = 1;
            // 
            // btnLancar
            // 
            this.btnLancar.Location = new System.Drawing.Point(329, 36);
            this.btnLancar.Name = "btnLancar";
            this.btnLancar.Size = new System.Drawing.Size(75, 23);
            this.btnLancar.TabIndex = 4;
            this.btnLancar.Text = "Lançar";
            this.btnLancar.UseVisualStyleBackColor = true;
            this.btnLancar.Click += new System.EventHandler(this.btnLancar_Click);
            // 
            // txtLinhas
            // 
            this.txtLinhas.Location = new System.Drawing.Point(117, 39);
            this.txtLinhas.Name = "txtLinhas";
            this.txtLinhas.Size = new System.Drawing.Size(100, 20);
            this.txtLinhas.TabIndex = 2;
            this.txtLinhas.Text = "0";
            this.txtLinhas.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            // 
            // dgvFaturamento
            // 
            this.dgvFaturamento.AllowUserToAddRows = false;
            this.dgvFaturamento.AllowUserToResizeColumns = false;
            this.dgvFaturamento.AllowUserToResizeRows = false;
            this.dgvFaturamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFaturamento.BackgroundColor = System.Drawing.Color.White;
            this.dgvFaturamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaturamento.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colData,
            this.colTotalDespesa,
            this.colTotalRS});
            this.dgvFaturamento.Location = new System.Drawing.Point(13, 65);
            this.dgvFaturamento.Name = "dgvFaturamento";
            this.dgvFaturamento.RowHeadersVisible = false;
            this.dgvFaturamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaturamento.Size = new System.Drawing.Size(546, 506);
            this.dgvFaturamento.TabIndex = 16;
            this.dgvFaturamento.TabStop = false;
            this.dgvFaturamento.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFaturamento_CellEndEdit);
            this.dgvFaturamento.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDespesas_UserDeletingRow);
            // 
            // colId
            // 
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Visible = false;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            // 
            // colTotalDespesa
            // 
            this.colTotalDespesa.HeaderText = "Total Linhas";
            this.colTotalDespesa.Name = "colTotalDespesa";
            this.colTotalDespesa.Width = 120;
            // 
            // colTotalRS
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colTotalRS.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTotalRS.HeaderText = "Total R$";
            this.colTotalRS.Name = "colTotalRS";
            this.colTotalRS.Width = 120;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(394, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(165, 25);
            this.label16.TabIndex = 17;
            this.label16.Text = "FATURAMENTO";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(223, 39);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 20);
            this.txtValor.TabIndex = 3;
            this.txtValor.Text = "R$ 0,00";
            this.txtValor.TextChanged += new System.EventHandler(this.txtValor_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Total Linhas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Total R$";
            // 
            // frmFaturamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 583);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvFaturamento);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.txtLinhas);
            this.Controls.Add(this.btnLancar);
            this.Controls.Add(this.dtpData);
            this.Name = "frmFaturamento";
            this.Text = "Despesas";
            this.Load += new System.EventHandler(this.frmDespesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.Button btnLancar;
        private System.Windows.Forms.TextBox txtLinhas;
        private System.Windows.Forms.DataGridView dgvFaturamento;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalRS;
    }
}