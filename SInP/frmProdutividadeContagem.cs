using System;
using System.Collections;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SInP
{
    public partial class frmProdutividadeContagem : Form
    {
        LiteBD liteBd = new LiteBD();
        SQLiteDataReader retornoBD;

        public frmProdutividadeContagem()
        {
            InitializeComponent();
        }

        private void frmProdutividadeContagem_Load(object sender, EventArgs e)
        {
            string SQL = "SELECT DISTINCT data_contagem " +
                        "FROM Inventarios " +
                        "WHERE data_contagem AND contador <> 0 " +
                        "ORDER BY data_contagem";
            liteBd.AbrirConexao();
            try
            {
                retornoBD = liteBd.ConsultaReader(SQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            while (retornoBD.Read())
            {// Preenche o Combobox com os anos
                cmbDataDe.Items.Add(retornoBD[0]);
                cmbDataAte.Items.Add(retornoBD[0]);
            }
            liteBd.FecharConexao();
            cmbDataAte.SelectedIndex = 0;
            cmbDataDe.SelectedIndex = 0;
            cmbHoraAte.SelectedIndex = 0;
            cmbHoraDe.SelectedIndex = 0;

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregaDgv1();
        }

        private void CarregaDgv1()
        {
            DateTime dtInicio = DateTime.Parse("24/03/2012 22:00:00");
            DateTime dtFinal = DateTime.Parse("25/03/2012 04:00:00");
            string SQL, dataDe, dataAte, status;
            int post = 0, coun = 0, reco = 0, dele = 0;
            int x = 0, y = 0,   //
                tot_pos_cont = 0;   //Total de posições contadas
            double media = 0;
            string contador2 = "";
            ArrayList tempo_contagem = new ArrayList();
            TimeSpan tempo_contagem2;
            ArrayList contador = new ArrayList();

            dgv1.Rows.Clear();

            dataDe = cmbDataDe.Text.Substring(6, 4) + "-" + cmbDataDe.Text.Substring(3, 2) + "-" + cmbDataDe.Text.Substring(0, 2);
            dataAte = cmbDataAte.Text.Substring(6, 4) + "-" + cmbDataAte.Text.Substring(3, 2) + "-" + cmbDataAte.Text.Substring(0, 2);

            SQL = "SELECT contador, data_contagem || ' ' || tempo_contagem, status_inv " +
                    "FROM Inventarios " +
                    "WHERE contador <> 0 AND Datetime(data_contagem || ' ' || tempo_contagem) BETWEEN Datetime('" + dataDe + " " + cmbHoraDe.Text + "' ) AND Datetime('" + dataAte + " " + cmbHoraAte.Text + "') " +
                    "GROUP BY contador, tempo_contagem " +
                    "ORDER BY contador, data_contagem, tempo_contagem, status_inv ";
            liteBd.AbrirConexao();

            retornoBD = liteBd.ConsultaReader(SQL);
            while (retornoBD.Read())
            {
                contador.Add(retornoBD[0]);
                tempo_contagem.Add(retornoBD[1]);
                status = retornoBD[2].ToString();
                switch (status)
                {
                    case "POST":
                        post += 1;
                        break;
                    case "COUN":
                        coun += 1;
                        break;
                    case "RECO":
                        reco += 1;
                        break;
                    case "DELE":
                        dele += 1;
                        break;
                }
                if (contador.Count > 1)
                {
                    if (contador[x - 1].ToString() == contador[x].ToString())
                    {
                        tot_pos_cont += 1;
                        if (Incluir_na_Media(DateTime.Parse(tempo_contagem[x-1].ToString()) ,DateTime.Parse(tempo_contagem[x].ToString())))
                        {
                            y += 1;
                            tempo_contagem2 = DateTime.Parse(tempo_contagem[x].ToString()) - DateTime.Parse(tempo_contagem[x - 1].ToString());
                            media += (tempo_contagem2.Hours * 60) + (tempo_contagem2.Minutes);
                            contador2 = retornoBD[0].ToString();
                        }
                    }
                    else if (y != 0) //Se y for = a zero é porque o código não passou no if, ou seja o contador contou apenas uma posição
                    {//Se y for diferente de 0 é pq o contador contou pelo menos 2 posições, então calcula-se a média abaixo
                        media = media / y;
                        dgv1.Rows.Add(contador2, Math.Floor(media / 60).ToString("00") + ":" + Math.Floor(media % 60).ToString("00") + ":" + Math.Round((media % 1) * 60, 0).ToString("00"),
                            tot_pos_cont + 1,                      //Total de posições contadas
                            coun, post, reco, dele);    //Total de cada status
                        media = 0;
                        y = 0;
                        tot_pos_cont = 0;
                        coun = 0;
                        reco = 0;
                        post = 0;
                        dele = 0;
                    }
                }
                x += 1;
            }
            if (y != 0) //Se y for = a zero é porque o código não passou no if, ou seja o contador contou apenas uma posição
            {//Se y for diferente de 0 é pq o contador contou pelo menos 2 posições, então calcula-se a média abaixo
                media = media / y;
                dgv1.Rows.Add(contador2, Math.Floor(media / 60).ToString("00") + ":" + Math.Floor(media % 60).ToString("00") + ":" + Math.Round((media % 1) * 60, 0).ToString("00"),
                    tot_pos_cont + 1,                      //Total de posições contadas
                    coun, post, reco, dele);    //Total de cada status
                media = 0;
                y = 0;
                tot_pos_cont = 0;
                coun = 0;
                reco = 0;
                post = 0;
                dele = 0;
            }
            liteBd.FecharConexao();
        }


        private bool Incluir_na_Media(DateTime hora_1, DateTime hora_2)
        {
            string SQL;
            DateTime horaInicio, horaFim;
            bool retorno = false;
            SQLiteDataReader retornoBD2;

            SQL = "SELECT data, hora_inicio, hora_fim " +
            "FROM Paradas ";

            retornoBD2 = liteBd.ConsultaReader(SQL);

            while (retornoBD2.Read())
            {
                horaInicio = Convert.ToDateTime(retornoBD2[0].ToString().Substring(0, 10) + " " + retornoBD2[1]);
                horaFim = Convert.ToDateTime(retornoBD2[0].ToString().Substring(0, 10) + " " + retornoBD2[2]);
                if (
                    (hora_1 <= horaInicio && hora_2 >= horaFim) ||
                    hora_1 <= horaInicio && (hora_2 >= horaInicio && hora_2 <= horaFim) ||
                    hora_2 >= horaFim && (hora_1 >= horaInicio && hora_1 <= horaFim) ||
                    (hora_1 >= horaInicio && hora_2 <= horaFim)
                    )
                {
                    retorno = false;
                    return retorno;
                }
                else
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string contador, SQL;
            string dataDe, dataAte;
            SQLiteDataReader retornoBD3;

            dataDe = cmbDataDe.Text.Substring(6, 4) + "-" + cmbDataDe.Text.Substring(3, 2) + "-" + cmbDataDe.Text.Substring(0, 2);
            dataAte = cmbDataAte.Text.Substring(6, 4) + "-" + cmbDataAte.Text.Substring(3, 2) + "-" + cmbDataAte.Text.Substring(0, 2);

            liteBd.AbrirConexao();

            contador = dgv1.CurrentRow.Cells[0].Value.ToString();
            SQL = "SELECT contador, data_contagem || ' ' || tempo_contagem, status_inv " +
                    "FROM Inventarios " +
                    "WHERE contador = " + contador + " AND Datetime(data_contagem || ' ' || tempo_contagem) BETWEEN Datetime('" + dataDe + " " + cmbHoraDe.Text + "' ) AND Datetime('" + dataAte + " " + cmbHoraAte.Text + "') " +
                    "GROUP BY contador, tempo_contagem " +
                    "ORDER BY contador, data_contagem, tempo_contagem, status_inv ; ";
            dgv2.Rows.Clear();
            retornoBD3 = liteBd.ConsultaReader(SQL);
            while (retornoBD3.Read())
            {
                dgv2.Rows.Add(retornoBD3[0], retornoBD3[1], retornoBD3[2]);
            }
            liteBd.FecharConexao();
        }

    }
}
