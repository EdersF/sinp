namespace SInP
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestãoDeEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInventarioRotativo = new System.Windows.Forms.ToolStripMenuItem();
            this.itensBESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.análiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importarInventáriosSAPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rupturaDePickingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rupturaDePickingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ocupaçãoDoEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPosicaoEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.importarEstoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventáriosPOSTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estoqueFísicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posiçãoNoDepósitoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faturamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.indicadoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mensalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recebimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preparaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expediçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cGPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intentárioGeralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.painelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarInventárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.avariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestãoDeEstoqueToolStripMenuItem,
            this.recebimentoToolStripMenuItem,
            this.preparaçãoToolStripMenuItem,
            this.expediçãoToolStripMenuItem,
            this.cGPToolStripMenuItem,
            this.intentárioGeralToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestãoDeEstoqueToolStripMenuItem
            // 
            this.gestãoDeEstoqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventáriosToolStripMenuItem,
            this.avariaToolStripMenuItem,
            this.rupturaDePickingToolStripMenuItem,
            this.ocupaçãoDoEstoqueToolStripMenuItem,
            this.importarToolStripMenuItem,
            this.faturamentoToolStripMenuItem,
            this.toolStripSeparator1,
            this.indicadoresToolStripMenuItem1});
            this.gestãoDeEstoqueToolStripMenuItem.Name = "gestãoDeEstoqueToolStripMenuItem";
            this.gestãoDeEstoqueToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.gestãoDeEstoqueToolStripMenuItem.Text = "Gestão de Estoque";
            // 
            // inventáriosToolStripMenuItem
            // 
            this.inventáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInventarioRotativo,
            this.itensBESTToolStripMenuItem,
            this.análiseToolStripMenuItem,
            this.toolStripSeparator2,
            this.importarInventáriosSAPToolStripMenuItem});
            this.inventáriosToolStripMenuItem.Name = "inventáriosToolStripMenuItem";
            this.inventáriosToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.inventáriosToolStripMenuItem.Text = "Inventários";
            // 
            // menuInventarioRotativo
            // 
            this.menuInventarioRotativo.Name = "menuInventarioRotativo";
            this.menuInventarioRotativo.Size = new System.Drawing.Size(205, 22);
            this.menuInventarioRotativo.Text = "Rotativo";
            this.menuInventarioRotativo.Click += new System.EventHandler(this.menuInventarioRotativo_Click);
            // 
            // itensBESTToolStripMenuItem
            // 
            this.itensBESTToolStripMenuItem.Enabled = false;
            this.itensBESTToolStripMenuItem.Name = "itensBESTToolStripMenuItem";
            this.itensBESTToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.itensBESTToolStripMenuItem.Text = "Itens BEST";
            // 
            // análiseToolStripMenuItem
            // 
            this.análiseToolStripMenuItem.Enabled = false;
            this.análiseToolStripMenuItem.Name = "análiseToolStripMenuItem";
            this.análiseToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.análiseToolStripMenuItem.Text = "Análise";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(202, 6);
            // 
            // importarInventáriosSAPToolStripMenuItem
            // 
            this.importarInventáriosSAPToolStripMenuItem.Name = "importarInventáriosSAPToolStripMenuItem";
            this.importarInventáriosSAPToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.importarInventáriosSAPToolStripMenuItem.Text = "Importar Inventários SAP";
            // 
            // rupturaDePickingToolStripMenuItem
            // 
            this.rupturaDePickingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rupturaDePickingToolStripMenuItem1});
            this.rupturaDePickingToolStripMenuItem.Name = "rupturaDePickingToolStripMenuItem";
            this.rupturaDePickingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.rupturaDePickingToolStripMenuItem.Text = "Ruptura";
            // 
            // rupturaDePickingToolStripMenuItem1
            // 
            this.rupturaDePickingToolStripMenuItem1.Name = "rupturaDePickingToolStripMenuItem1";
            this.rupturaDePickingToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.rupturaDePickingToolStripMenuItem1.Text = "Ruptura de Picking";
            this.rupturaDePickingToolStripMenuItem1.Click += new System.EventHandler(this.rupturaDePickingToolStripMenuItem1_Click);
            // 
            // ocupaçãoDoEstoqueToolStripMenuItem
            // 
            this.ocupaçãoDoEstoqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPosicaoEstoque,
            this.importarEstoqueToolStripMenuItem});
            this.ocupaçãoDoEstoqueToolStripMenuItem.Name = "ocupaçãoDoEstoqueToolStripMenuItem";
            this.ocupaçãoDoEstoqueToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ocupaçãoDoEstoqueToolStripMenuItem.Text = "Ocupação do Estoque";
            // 
            // MenuPosicaoEstoque
            // 
            this.MenuPosicaoEstoque.Name = "MenuPosicaoEstoque";
            this.MenuPosicaoEstoque.Size = new System.Drawing.Size(251, 22);
            this.MenuPosicaoEstoque.Text = "Importar Posições SAP";
            // 
            // importarEstoqueToolStripMenuItem
            // 
            this.importarEstoqueToolStripMenuItem.Name = "importarEstoqueToolStripMenuItem";
            this.importarEstoqueToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.importarEstoqueToolStripMenuItem.Text = "Importar Estoque (Estoque Físico)";
            // 
            // importarToolStripMenuItem
            // 
            this.importarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventáriosPOSTToolStripMenuItem,
            this.estoqueFísicoToolStripMenuItem,
            this.posiçãoNoDepósitoToolStripMenuItem});
            this.importarToolStripMenuItem.Name = "importarToolStripMenuItem";
            this.importarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importarToolStripMenuItem.Text = "Importar";
            // 
            // inventáriosPOSTToolStripMenuItem
            // 
            this.inventáriosPOSTToolStripMenuItem.Name = "inventáriosPOSTToolStripMenuItem";
            this.inventáriosPOSTToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.inventáriosPOSTToolStripMenuItem.Text = "Inventários (POST)";
            this.inventáriosPOSTToolStripMenuItem.Click += new System.EventHandler(this.inventáriosPOSTToolStripMenuItem_Click);
            // 
            // estoqueFísicoToolStripMenuItem
            // 
            this.estoqueFísicoToolStripMenuItem.Name = "estoqueFísicoToolStripMenuItem";
            this.estoqueFísicoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.estoqueFísicoToolStripMenuItem.Text = "Estoque Físico";
            this.estoqueFísicoToolStripMenuItem.Click += new System.EventHandler(this.estoqueFísicoToolStripMenuItem_Click);
            // 
            // posiçãoNoDepósitoToolStripMenuItem
            // 
            this.posiçãoNoDepósitoToolStripMenuItem.Name = "posiçãoNoDepósitoToolStripMenuItem";
            this.posiçãoNoDepósitoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.posiçãoNoDepósitoToolStripMenuItem.Text = "Posição no Depósito";
            this.posiçãoNoDepósitoToolStripMenuItem.Click += new System.EventHandler(this.posiçãoNoDepósitoToolStripMenuItem_Click);
            // 
            // faturamentoToolStripMenuItem
            // 
            this.faturamentoToolStripMenuItem.Name = "faturamentoToolStripMenuItem";
            this.faturamentoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.faturamentoToolStripMenuItem.Text = "Faturamento";
            this.faturamentoToolStripMenuItem.Click += new System.EventHandler(this.faturamentoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // indicadoresToolStripMenuItem1
            // 
            this.indicadoresToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mensalToolStripMenuItem,
            this.diárioToolStripMenuItem});
            this.indicadoresToolStripMenuItem1.Name = "indicadoresToolStripMenuItem1";
            this.indicadoresToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.indicadoresToolStripMenuItem1.Text = "Indicadores";
            // 
            // mensalToolStripMenuItem
            // 
            this.mensalToolStripMenuItem.Name = "mensalToolStripMenuItem";
            this.mensalToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.mensalToolStripMenuItem.Text = "Mensal";
            this.mensalToolStripMenuItem.Click += new System.EventHandler(this.mensalToolStripMenuItem_Click);
            // 
            // diárioToolStripMenuItem
            // 
            this.diárioToolStripMenuItem.Name = "diárioToolStripMenuItem";
            this.diárioToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.diárioToolStripMenuItem.Text = "Diário";
            this.diárioToolStripMenuItem.Click += new System.EventHandler(this.diárioToolStripMenuItem_Click);
            // 
            // recebimentoToolStripMenuItem
            // 
            this.recebimentoToolStripMenuItem.Enabled = false;
            this.recebimentoToolStripMenuItem.Name = "recebimentoToolStripMenuItem";
            this.recebimentoToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.recebimentoToolStripMenuItem.Text = "Recebimento";
            // 
            // preparaçãoToolStripMenuItem
            // 
            this.preparaçãoToolStripMenuItem.Enabled = false;
            this.preparaçãoToolStripMenuItem.Name = "preparaçãoToolStripMenuItem";
            this.preparaçãoToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.preparaçãoToolStripMenuItem.Text = "Preparação";
            // 
            // expediçãoToolStripMenuItem
            // 
            this.expediçãoToolStripMenuItem.Enabled = false;
            this.expediçãoToolStripMenuItem.Name = "expediçãoToolStripMenuItem";
            this.expediçãoToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.expediçãoToolStripMenuItem.Text = "Expedição";
            // 
            // cGPToolStripMenuItem
            // 
            this.cGPToolStripMenuItem.Enabled = false;
            this.cGPToolStripMenuItem.Name = "cGPToolStripMenuItem";
            this.cGPToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.cGPToolStripMenuItem.Text = "CGP";
            // 
            // intentárioGeralToolStripMenuItem
            // 
            this.intentárioGeralToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.painelToolStripMenuItem,
            this.importarInventárioToolStripMenuItem});
            this.intentárioGeralToolStripMenuItem.Enabled = false;
            this.intentárioGeralToolStripMenuItem.Name = "intentárioGeralToolStripMenuItem";
            this.intentárioGeralToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.intentárioGeralToolStripMenuItem.Text = "Intentário Geral";
            // 
            // painelToolStripMenuItem
            // 
            this.painelToolStripMenuItem.Name = "painelToolStripMenuItem";
            this.painelToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.painelToolStripMenuItem.Text = "Painel";
            this.painelToolStripMenuItem.Click += new System.EventHandler(this.painelToolStripMenuItem_Click);
            // 
            // importarInventárioToolStripMenuItem
            // 
            this.importarInventárioToolStripMenuItem.Name = "importarInventárioToolStripMenuItem";
            this.importarInventárioToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.importarInventárioToolStripMenuItem.Text = "Importar Inventário";
            this.importarInventárioToolStripMenuItem.Click += new System.EventHandler(this.importarInventárioToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(867, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // avariaToolStripMenuItem
            // 
            this.avariaToolStripMenuItem.Name = "avariaToolStripMenuItem";
            this.avariaToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.avariaToolStripMenuItem.Text = "Avaria";
            this.avariaToolStripMenuItem.Click += new System.EventHandler(this.avariaToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.BackgroundImage = global::SInP.Properties.Resources.indicadores_desempenho;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(867, 537);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "SInP -Sistema Indicador de Performance";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestãoDeEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuInventarioRotativo;
        public System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem itensBESTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem análiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem importarInventáriosSAPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ocupaçãoDoEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuPosicaoEstoque;
        private System.Windows.Forms.ToolStripMenuItem indicadoresToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importarEstoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recebimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preparaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expediçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cGPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rupturaDePickingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rupturaDePickingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mensalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventáriosPOSTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estoqueFísicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posiçãoNoDepósitoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intentárioGeralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem painelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarInventárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faturamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avariaToolStripMenuItem;
    }
}