namespace SInP.Gestao_Estoque
{
    partial class frmImportarInventarioGeral
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
            this.txtUltimoInventario = new System.Windows.Forms.TextBox();
            this.lblUltimoInventario = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.dgvPos = new System.Windows.Forms.DataGridView();
            this.btnImportar = new System.Windows.Forms.Button();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUltimoInventario
            // 
            this.txtUltimoInventario.Location = new System.Drawing.Point(430, 25);
            this.txtUltimoInventario.Name = "txtUltimoInventario";
            this.txtUltimoInventario.ReadOnly = true;
            this.txtUltimoInventario.Size = new System.Drawing.Size(133, 20);
            this.txtUltimoInventario.TabIndex = 13;
            // 
            // lblUltimoInventario
            // 
            this.lblUltimoInventario.AutoSize = true;
            this.lblUltimoInventario.Location = new System.Drawing.Point(308, 28);
            this.lblUltimoInventario.Name = "lblUltimoInventario";
            this.lblUltimoInventario.Size = new System.Drawing.Size(116, 13);
            this.lblUltimoInventario.TabIndex = 12;
            this.lblUltimoInventario.Text = "Último inventário salvo:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackgroundImage = global::SInP.Properties.Resources._1460869027_vector_66_12;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSalvar.Location = new System.Drawing.Point(112, 12);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(94, 33);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // dgvPos
            // 
            this.dgvPos.AllowUserToAddRows = false;
            this.dgvPos.AllowUserToResizeRows = false;
            this.dgvPos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPos.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvPos.Location = new System.Drawing.Point(13, 51);
            this.dgvPos.Name = "dgvPos";
            this.dgvPos.Size = new System.Drawing.Size(932, 525);
            this.dgvPos.TabIndex = 10;
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = global::SInP.Properties.Resources._1460868521_excel;
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnImportar.Location = new System.Drawing.Point(12, 12);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(94, 33);
            this.btnImportar.TabIndex = 9;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // ofd1
            // 
            this.ofd1.FileName = "openFileDialog1";
            // 
            // frmImportarInventarioGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 588);
            this.Controls.Add(this.txtUltimoInventario);
            this.Controls.Add(this.lblUltimoInventario);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dgvPos);
            this.Controls.Add(this.btnImportar);
            this.Name = "frmImportarInventarioGeral";
            this.Text = "Importar Inventário Geral";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUltimoInventario;
        private System.Windows.Forms.Label lblUltimoInventario;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView dgvPos;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.OpenFileDialog ofd1;
    }
}