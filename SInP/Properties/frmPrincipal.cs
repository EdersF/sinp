//1.0.0.1   -   Foi alterado a localização do banco de dados
//1.0.0.2   -   Foi consertado problemas de conexão no arquivo Conexao.cs
//1.0.0.4   -   Foi incluido várias referências necessárias para rodar em algumas máquinas
//1.2.0.0   -   Foi incluido Indicador diário de ruptura de picking

using SInP.Gestao_Estoque;
using SInP.Gestão_de_Estoque;
using System;
using System.Windows.Forms;

namespace SInP
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            this.BackColor = System.Drawing.Color.FromArgb(197, 197, 197);
        }

        private void menuInventarioRotativo_Click(object sender, EventArgs e)
        {
            frmInvRotativo frmInventarioRotativo = new frmInvRotativo();
            frmInventarioRotativo.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmInventarioRotativo.MdiParent = this;
            frmInventarioRotativo.Show();
        }

        private void rupturaDePickingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRupturaPK frmRuptura = new frmRupturaPK();
            frmRuptura.MdiParent = this;
            frmRuptura.Show();
        }

        private void mensalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIndicadoresMensal frmIndicadoresMensal = new frmIndicadoresMensal();
            frmIndicadoresMensal.MdiParent = this;
            frmIndicadoresMensal.Show();
        }

        private void diárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIndicadorDiario frmIndicadorDiario = new frmIndicadorDiario();
            frmIndicadorDiario.MdiParent = this;
            frmIndicadorDiario.Show();
        }

        private void inventáriosPOSTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarInventario frmImportarInventario = new frmImportarInventario(this);
            frmImportarInventario.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmImportarInventario.MdiParent = this;
            frmImportarInventario.Show();
        }
        private void estoqueFísicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarEstoqueFisico frmImportarEstoqueFisico = new frmImportarEstoqueFisico(this);
            frmImportarEstoqueFisico.MdiParent = this;
            frmImportarEstoqueFisico.Show();
        }

        private void posiçãoNoDepósitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarPosicoes frmPosicoesEstoque = new frmImportarPosicoes(this);
            frmPosicoesEstoque.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frmPosicoesEstoque.MdiParent = this;
            frmPosicoesEstoque.Show();
        }

        private void painelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioPainel frmPainel = new frmInventarioPainel();
            frmPainel.MdiParent = this;
            frmPainel.Show();
        }

        private void importarInventárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportarInventarioGeral frmImportarInventarioGeral = new frmImportarInventarioGeral(this);
            frmImportarInventarioGeral.MdiParent = this;
            frmImportarInventarioGeral.Show();
        }

        private void faturamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFaturamento frmFaturamento = new frmFaturamento();
            frmFaturamento.MdiParent = this;
            frmFaturamento.Show();
        }

        private void avariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLancAvaria frmAvaria = new frmLancAvaria();
            frmAvaria.MdiParent = this;
            frmAvaria.Show();
        }
    }
}
