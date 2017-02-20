namespace SInP
{
    partial class frmImportarPosicoes
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
            this.dgvPos = new System.Windows.Forms.DataGridView();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.bgwImportaExcel = new System.ComponentModel.BackgroundWorker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).BeginInit();
            this.SuspendLayout();
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
            this.dgvPos.Location = new System.Drawing.Point(13, 42);
            this.dgvPos.Name = "dgvPos";
            this.dgvPos.Size = new System.Drawing.Size(1051, 496);
            this.dgvPos.TabIndex = 4;
            // 
            // ofd1
            // 
            this.ofd1.ReadOnlyChecked = true;
            this.ofd1.RestoreDirectory = true;
            this.ofd1.ShowReadOnly = true;
            // 
            // bgwImportaExcel
            // 
            this.bgwImportaExcel.WorkerReportsProgress = true;
            this.bgwImportaExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwImportaExcel_DoWork);
            this.bgwImportaExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwImportaExcel_RunWorkerCompleted);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackgroundImage = global::SInP.Properties.Resources._1460869027_vector_66_12;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSalvar.Location = new System.Drawing.Point(112, 3);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(94, 33);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = global::SInP.Properties.Resources._1460868521_excel;
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImportar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnImportar.Location = new System.Drawing.Point(12, 3);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(94, 33);
            this.btnImportar.TabIndex = 3;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // frmImportarPosicoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 550);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dgvPos);
            this.Controls.Add(this.btnImportar);
            this.Name = "frmImportarPosicoes";
            this.ShowIcon = false;
            this.Text = "Importar Posições";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImportarPosicoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.DataGridView dgvPos;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.Button btnSalvar;
        private System.ComponentModel.BackgroundWorker bgwImportaExcel;
    }
}