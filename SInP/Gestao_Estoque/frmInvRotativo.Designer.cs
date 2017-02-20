namespace SInP
{
    partial class frmInvRotativo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPos = new System.Windows.Forms.DataGridView();
            this.colPos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQtdCont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimaCont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbPesquisa = new System.Windows.Forms.ComboBox();
            this.gbPainel = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUltimoInvent = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRua = new System.Windows.Forms.ComboBox();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.bgwPainel = new System.ComponentModel.BackgroundWorker();
            this.bgwGrafEvolucaoRotativo = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).BeginInit();
            this.gbPainel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPos
            // 
            this.dgvPos.AllowUserToAddRows = false;
            this.dgvPos.AllowUserToDeleteRows = false;
            this.dgvPos.AllowUserToResizeColumns = false;
            this.dgvPos.AllowUserToResizeRows = false;
            this.dgvPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPos.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPos,
            this.colQtdCont,
            this.colUltimaCont});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPos.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvPos.Location = new System.Drawing.Point(6, 151);
            this.dgvPos.Name = "dgvPos";
            this.dgvPos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPos.RowHeadersVisible = false;
            this.dgvPos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPos.Size = new System.Drawing.Size(304, 582);
            this.dgvPos.TabIndex = 5;
            // 
            // colPos
            // 
            this.colPos.HeaderText = "Posição";
            this.colPos.Name = "colPos";
            this.colPos.ReadOnly = true;
            // 
            // colQtdCont
            // 
            this.colQtdCont.HeaderText = "Qtd. Contagem";
            this.colQtdCont.Name = "colQtdCont";
            this.colQtdCont.ReadOnly = true;
            // 
            // colUltimaCont
            // 
            this.colUltimaCont.HeaderText = "Última Contagem";
            this.colUltimaCont.Name = "colUltimaCont";
            this.colUltimaCont.ReadOnly = true;
            // 
            // cmbPesquisa
            // 
            this.cmbPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPesquisa.FormattingEnabled = true;
            this.cmbPesquisa.Items.AddRange(new object[] {
            "Todas as Posições",
            "Posições NÃO contadas",
            "Posições Contadas"});
            this.cmbPesquisa.Location = new System.Drawing.Point(9, 97);
            this.cmbPesquisa.Name = "cmbPesquisa";
            this.cmbPesquisa.Size = new System.Drawing.Size(203, 21);
            this.cmbPesquisa.TabIndex = 6;
            // 
            // gbPainel
            // 
            this.gbPainel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPainel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gbPainel.Controls.Add(this.label6);
            this.gbPainel.Controls.Add(this.lblUltimoInvent);
            this.gbPainel.Controls.Add(this.btnAtualizar);
            this.gbPainel.Controls.Add(this.label4);
            this.gbPainel.Controls.Add(this.dgvPos);
            this.gbPainel.Controls.Add(this.label2);
            this.gbPainel.Controls.Add(this.label3);
            this.gbPainel.Controls.Add(this.cmbNivel);
            this.gbPainel.Controls.Add(this.label1);
            this.gbPainel.Controls.Add(this.cmbRua);
            this.gbPainel.Controls.Add(this.dtpAte);
            this.gbPainel.Controls.Add(this.dtpDe);
            this.gbPainel.Controls.Add(this.cmbPesquisa);
            this.gbPainel.Location = new System.Drawing.Point(12, 12);
            this.gbPainel.Name = "gbPainel";
            this.gbPainel.Size = new System.Drawing.Size(317, 739);
            this.gbPainel.TabIndex = 7;
            this.gbPainel.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(165, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Último Inventário Salvo:";
            // 
            // lblUltimoInvent
            // 
            this.lblUltimoInvent.AutoSize = true;
            this.lblUltimoInvent.ForeColor = System.Drawing.Color.Yellow;
            this.lblUltimoInvent.Location = new System.Drawing.Point(165, 38);
            this.lblUltimoInvent.Name = "lblUltimoInvent";
            this.lblUltimoInvent.Size = new System.Drawing.Size(35, 13);
            this.lblUltimoInvent.TabIndex = 12;
            this.lblUltimoInvent.Text = "label5";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(235, 97);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 48);
            this.btnAtualizar.TabIndex = 11;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nível";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "até";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rua";
            // 
            // cmbNivel
            // 
            this.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Location = new System.Drawing.Point(150, 124);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(62, 21);
            this.cmbNivel.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Período";
            // 
            // cmbRua
            // 
            this.cmbRua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRua.FormattingEnabled = true;
            this.cmbRua.Location = new System.Drawing.Point(43, 124);
            this.cmbRua.Name = "cmbRua";
            this.cmbRua.Size = new System.Drawing.Size(62, 21);
            this.cmbRua.TabIndex = 8;
            // 
            // dtpAte
            // 
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(9, 71);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.Size = new System.Drawing.Size(96, 20);
            this.dtpAte.TabIndex = 1;
            // 
            // dtpDe
            // 
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.Location = new System.Drawing.Point(9, 32);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.Size = new System.Drawing.Size(96, 20);
            this.dtpDe.TabIndex = 0;
            // 
            // frmInvRotativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 742);
            this.Controls.Add(this.gbPainel);
            this.Name = "frmInvRotativo";
            this.ShowIcon = false;
            this.Text = "Inventário Rotativo";
            this.Load += new System.EventHandler(this.frmInvRotativo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).EndInit();
            this.gbPainel.ResumeLayout(false);
            this.gbPainel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQtdCont;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimaCont;
        private System.Windows.Forms.ComboBox cmbPesquisa;
        private System.Windows.Forms.GroupBox gbPainel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.ComboBox cmbRua;
        private System.Windows.Forms.ComboBox cmbNivel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUltimoInvent;
        private System.ComponentModel.BackgroundWorker bgwPainel;
        private System.ComponentModel.BackgroundWorker bgwGrafEvolucaoRotativo;
    }
}