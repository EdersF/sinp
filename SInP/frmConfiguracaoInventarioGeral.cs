using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SInP
{
    public partial class frmConfiguracaoInventarioGeral : Form
    {
        LiteBD liteBd = new LiteBD();
        SQLiteDataReader retornoBD;

        public frmConfiguracaoInventarioGeral()
        {
            InitializeComponent();
        }

        private void frmConfiguracaoInventarioGeral_Load(object sender, EventArgs e)
        {
            CarregaDgvParada1();
            CarregaDgvParada2();
            liteBd.AbrirConexao();
            txtInicioInvent.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'Inicio'");
            txtPosicoesHora.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'posicoes_hora'");
            txtSegContagem.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'percent_seg_cont'");
            txtTerContagem.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'percent_ter_cont'");
            txtContadores.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'contadores_turno'");
            txtTermino.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'termino'");
            txtMediaContadores.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'media_contadores'");

            liteBd.FecharConexao();
        }

        private void CarregaDgvParada1()
        {
            string SQL = "SELECT * FROM Paradas WHERE tipo = 'PLANEJADO'";

            liteBd.AbrirConexao();
            retornoBD = liteBd.ConsultaReader(SQL);
            dgvParada1.Rows.Clear();
            while (retornoBD.Read())
            {
                dgvParada1.Rows.Add(retornoBD[0], Convert.ToDateTime(retornoBD[1]), retornoBD[2], retornoBD[3], retornoBD[4]);
            }

            liteBd.FecharConexao();
        }

        private void CarregaDgvParada2()
        {
            string SQL = "SELECT * FROM Paradas WHERE tipo = 'REAL'";

            liteBd.AbrirConexao();
            retornoBD = liteBd.ConsultaReader(SQL);
            dgvParada2.Rows.Clear();
            while (retornoBD.Read())
            {
                dgvParada2.Rows.Add(retornoBD[0], Convert.ToDateTime(retornoBD[1]), retornoBD[2], retornoBD[3], retornoBD[4]);
            }

            liteBd.FecharConexao();
        }

        private void dgvParada1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CarregaDgvParada1();
        }
        private void dgvParada2_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CarregaDgvParada2();
        }

        private void dgvParada1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            liteBd.AbrirConexao();

            liteBd.InsertDeleteUpdate("DELETE FROM Paradas WHERE Cod = " + dgvParada1.CurrentRow.Cells[0].Value);

            liteBd.FecharConexao();

        }
        private void dgvParada2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            liteBd.AbrirConexao();

            liteBd.InsertDeleteUpdate("DELETE FROM Paradas WHERE Cod = " + dgvParada2.CurrentRow.Cells[0].Value);

            liteBd.FecharConexao();

        }

        private void btnInserir1_Click(object sender, EventArgs e)
        {
            LiteBD liteBd2 = new LiteBD();

            string data = dtpData.Text.Substring(6, 4) + "-" + dtpData.Text.Substring(3, 2) + "-" + dtpData.Text.Substring(0, 2);

            liteBd2.AbrirConexao();
            liteBd2.InsertDeleteUpdate("INSERT INTO Paradas (data, hora_inicio, hora_fim, descricao, tipo) " +
                "values('" + data + "', '" + txtHoraInicio.Text + "', '" + txtHoraFim.Text + "', '" + txtMotivo.Text + "', 'PLANEJADO')");
            liteBd2.FecharConexao();
            CarregaDgvParada1();
        }

        private void btnInserir2_Click_1(object sender, EventArgs e)
        {
            LiteBD liteBd2 = new LiteBD();

            string data = dtpData2.Text.Substring(6, 4) + "-" + dtpData2.Text.Substring(3, 2) + "-" + dtpData2.Text.Substring(0, 2);

            liteBd2.AbrirConexao();
            liteBd2.InsertDeleteUpdate("INSERT INTO Paradas (data, hora_inicio, hora_fim, descricao, tipo) " +
                "values('" + data + "', '" + txtHoraInicio2.Text + "', '" + txtHoraFim2.Text + "', '" + txtMotivo2.Text + "', 'REAL')");
            liteBd2.FecharConexao();
            CarregaDgvParada2();
        }

        private void btnInicioInvent_Click(object sender, EventArgs e)
        {
            string SQL ="UPDATE Config SET valor = '"+txtInicioInvent.Text+"' WHERE nome = 'Inicio'";
            try
            {
                liteBd.AbrirConexao();
                liteBd.InsertDeleteUpdate(SQL);
                liteBd.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco \n erro:" + ex.Message);
            }

        }

        private void btnPosicoesHora_Click(object sender, EventArgs e)
        {
            string SQL = "UPDATE Config SET valor = '" + txtPosicoesHora.Text + "' WHERE nome = 'posicoes_hora'";
            try
            {
                liteBd.AbrirConexao();
                liteBd.InsertDeleteUpdate(SQL);
                liteBd.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco \n erro:" + ex.Message);
            }

        }

        private void btnSegContagem_Click(object sender, EventArgs e)
        {
            string SQL = "UPDATE Config SET valor = '" + txtSegContagem.Text + "' WHERE nome = 'percent_seg_cont'";
            try
            {
                liteBd.AbrirConexao();
                liteBd.InsertDeleteUpdate(SQL);
                liteBd.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco \n erro:" + ex.Message);
            }

        }

        private void btnTerContagem_Click(object sender, EventArgs e)
        {
            string SQL = "UPDATE Config SET valor = '" + txtTerContagem.Text + "' WHERE nome = 'percent_ter_cont'";
            try
            {
                liteBd.AbrirConexao();
                liteBd.InsertDeleteUpdate(SQL);
                liteBd.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco \n erro:" + ex.Message);
            }

        }

        private void btnContadores_Click(object sender, EventArgs e)
        {
            string SQL = "UPDATE Config SET valor = '" + txtContadores.Text + "' WHERE nome = 'contadores_turno'";
            try
            {
                liteBd.AbrirConexao();
                liteBd.InsertDeleteUpdate(SQL);
                liteBd.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco \n erro:" + ex.Message);
            }

        }

        private void btnTermino_Click(object sender, EventArgs e)
        {
            string SQL = "UPDATE Config SET valor = '" + txtTermino.Text + "' WHERE nome = 'termino'";
            try
            {
                liteBd.AbrirConexao();
                liteBd.InsertDeleteUpdate(SQL);
                liteBd.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco \n erro:" + ex.Message);
            }
        }

        private void btnMediaContadores_Click(object sender, EventArgs e)
        {
            string SQL = "UPDATE Config SET valor = '" + txtMediaContadores.Text + "' WHERE nome = 'media_contadores'";
            try
            {
                liteBd.AbrirConexao();
                liteBd.InsertDeleteUpdate(SQL);
                liteBd.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de conexão com o banco \n erro:" + ex.Message);
            }

        }
    }
}
