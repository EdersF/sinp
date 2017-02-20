namespace SInP.Gestao_Estoque
{
    partial class frmImportarEstoqueFisico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvImportarEstoque = new System.Windows.Forms.DataGridView();
            this.cmbAno = new System.Windows.Forms.ComboBox();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.colMes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItensEstoque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportarEstoque)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvImportarEstoque
            // 
            this.dgvImportarEstoque.AllowUserToAddRows = false;
            this.dgvImportarEstoque.AllowUserToDeleteRows = false;
            this.dgvImportarEstoque.AllowUserToResizeColumns = false;
            this.dgvImportarEstoque.AllowUserToResizeRows = false;
            this.dgvImportarEstoque.BackgroundColor = System.Drawing.Color.White;
            this.dgvImportarEstoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvImportarEstoque.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMes,
            this.colValorEstoque,
            this.colItensEstoque,
            this.colData,
            this.colImportar});
            this.dgvImportarEstoque.Location = new System.Drawing.Point(12, 99);
            this.dgvImportarEstoque.Name = "dgvImportarEstoque";
            this.dgvImportarEstoque.ReadOnly = true;
            this.dgvImportarEstoque.Size = new System.Drawing.Size(637, 353);
            this.dgvImportarEstoque.TabIndex = 0;
            this.dgvImportarEstoque.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvImportarEstoque_CellContentClick);
            // 
            // cmbAno
            // 
            this.cmbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.Location = new System.Drawing.Point(13, 72);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(121, 21);
            this.cmbAno.TabIndex = 1;
            this.cmbAno.SelectedIndexChanged += new System.EventHandler(this.cmbAno_SelectedIndexChanged);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // colMes
            // 
            this.colMes.HeaderText = "Mês";
            this.colMes.Name = "colMes";
            this.colMes.ReadOnly = true;
            // 
            // colValorEstoque
            // 
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = "0";
            this.colValorEstoque.DefaultCellStyle = dataGridViewCellStyle1;
            this.colValorEstoque.HeaderText = "Valor de Estoque";
            this.colValorEstoque.Name = "colValorEstoque";
            this.colValorEstoque.ReadOnly = true;
            this.colValorEstoque.Width = 150;
            // 
            // colItensEstoque
            // 
            this.colItensEstoque.HeaderText = "Total Itens em Estoque";
            this.colItensEstoque.Name = "colItensEstoque";
            this.colItensEstoque.ReadOnly = true;
            // 
            // colData
            // 
            this.colData.HeaderText = "Data da Atualização";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 120;
            // 
            // colImportar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomRight;
            this.colImportar.DefaultCellStyle = dataGridViewCellStyle2;
            this.colImportar.HeaderText = "Importar";
            this.colImportar.Name = "colImportar";
            this.colImportar.ReadOnly = true;
            this.colImportar.Text = "";
            this.colImportar.UseColumnTextForButtonValue = true;
            this.colImportar.Width = 70;
            // 
            // frmImportarEstoqueFisico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 464);
            this.Controls.Add(this.cmbAno);
            this.Controls.Add(this.dgvImportarEstoque);
            this.Name = "frmImportarEstoqueFisico";
            this.Text = "Importar Estoque Físico";
            this.Load += new System.EventHandler(this.frmImportarEstoqueFisico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportarEstoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvImportarEstoque;
        private System.Windows.Forms.ComboBox cmbAno;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItensEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewButtonColumn colImportar;
    }
}