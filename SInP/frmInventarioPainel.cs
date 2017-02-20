using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;


namespace SInP
{
    public partial class frmInventarioPainel : Form
    {
        LiteBD liteBd = new LiteBD();
        public int posicoesContadas = 0;                    // Posições contadas no período
        public int priContActi;                            // Primeira contagem ativa

        public double minutosTotais,                        // Total de minutos do início do inventário até o última contagem
            qtdSegCont,
            qtdTerCont;
        public string dataInicioInvent, dataUltimoInvent;   

        public frmInventarioPainel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConfiguracaoInventarioGeral configuracoes = new frmConfiguracaoInventarioGeral();
            configuracoes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarregaPainel();
            Produtividade();
            CarregaEvolucaoGeral();

        }

        private void frmInventarioPainel_Load(object sender, EventArgs e)
        {
            CarregaPainel();
            CarregaEvolucaoGeral();
        }

        public void CarregaPainel()
        {
            liteBd.AbrirConexao();
            lblPlanContadores.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'contadores_turno'");
            lblPlanSegunda.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'percent_seg_cont'")+"%"; 
            lblPlanTerceira.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'percent_ter_cont'")+"%";
            lblPlanTermino.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'termino'");
            lblRealContadores.Text = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'media_contadores'");
            liteBd.FecharConexao();

            if (Convert.ToDouble(lblRealContadores.Text) < Convert.ToDouble(lblPlanContadores.Text))
            {
                lblRealContadores.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblRealContadores.ForeColor = System.Drawing.Color.Green;
            }

            Produtividade();
            SegundaContagemPercent();
            TerceiraContagemPercent();
            TerminoInventario();
        }

        private void Produtividade()
        {
            int minutosParadosPlan,                         // Minutos totais parados Planejados
                minutosParadosReal,                         // Minutos totais parados Real
                contadoresTurno,                            // Total de contadores por turno
                minutosTrabalhados = 0;                     // Minutos Totais - minutos parados

            double meta,                                    // armazena quantas posições deveriam ser contadas até o instante (média móvel)
                posicoesHora;                               // Posições por hora homem
            liteBd.AbrirConexao();

            dataInicioInvent = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'Inicio'");
            dataUltimoInvent = liteBd.ConsultaScalar("SELECT DISTINCT data_contagem || ' ' || tempo_contagem FROM Inventarios WHERE contador > 0 ORDER BY data_contagem DESC, tempo_contagem DESC LIMIT 1");
            minutosParadosPlan = Convert.ToInt32(liteBd.ConsultaScalar("SELECT IFNULL(sum((strftime('%s', hora_fim) - strftime('%s', hora_inicio)) / 60), 0) " +
                            "FROM PARADAS " +
                            "WHERE strftime('%s', DATA || ' ' || hora_inicio) BETWEEN strftime('%s', '"+ dataInicioInvent +"') AND strftime('%s', '"+ dataUltimoInvent +"') AND tipo = 'PLANEJADO'"));
            //minutosParadosReal = Convert.ToInt32(liteBd.ConsultaScalar("SELECT IFNULL(sum((strftime('%s', hora_fim) - strftime('%s', hora_inicio)) / 60), 0) " +
            //                "FROM PARADAS " +
            //                "WHERE strftime('%s', DATA || ' ' || hora_inicio) BETWEEN strftime('%s', '" + dataInicioInvent + "') AND strftime('%s', '" + dataUltimoInvent + "') AND tipo = 'REAL'"));
            minutosTotais = Convert.ToDateTime(dataUltimoInvent.Substring(8, 2) + "/" + dataUltimoInvent.Substring(5, 2) + "/" + dataUltimoInvent.Substring(0, 4) + " " + dataUltimoInvent.Substring(11, 5))    //convertendo para data a string vinda do SQLITE
                .Subtract(
                Convert.ToDateTime(dataInicioInvent.Substring(8, 2) + "/" + dataInicioInvent.Substring(5, 2) + "/" + dataInicioInvent.Substring(0, 4) + " " + dataInicioInvent.Substring(11, 5)))
                .TotalHours * 60;
            minutosTrabalhados =  Convert.ToInt32(minutosTotais) - minutosParadosPlan;
            posicoesHora = Convert.ToInt32(liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'posicoes_hora'"));
            contadoresTurno = Convert.ToInt32(liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'contadores_turno'"));
            meta = Convert.ToDouble(minutosTrabalhados) * (posicoesHora / 60) * contadoresTurno;

            posicoesContadas = Convert.ToInt32(liteBd.ConsultaScalar("SELECT count(posicao) " +
                                                    "FROM " +
                                                    "(SELECT posicao " +
                                                    "FROM Inventarios " +
                                                    "WHERE status_inv in ('POST', 'RECO', 'COUN') AND(data_contagem || ' ' || tempo_contagem BETWEEN '"+ dataInicioInvent + "' AND '"+ dataUltimoInvent + "') " +
                                                    "GROUP BY ordem, posicao)"));

            lblRealProdutividade.Text = Convert.ToString(Math.Round((posicoesContadas / meta) * 100, 2)) + "%";// + posicoesContadas / ((minutosTotais - minutosParadosReal)/60);

            if((posicoesContadas / meta) * 100 < 100)
            {
                lblRealProdutividade.ForeColor = System.Drawing.Color.Red;
            }else
            {
                lblRealProdutividade.ForeColor = System.Drawing.Color.Green;
            }
            //liteBd.InsertDeleteUpdate(SQL);
            liteBd.FecharConexao();
            //MessageBox.Show((meta).ToString() + "\n" +
            //    "Minutos trabalhados: "+minutosTrabalhados + "\n" +
            //    "posições por hora: "+ posicoesHora);

        }

        private void SegundaContagemPercent()
        {
            double totalPosCont;
            string SQL1, SQL2;

            SQL1 = "SELECT COUNT(CONTAR) " +
                    "FROM("+
                        "SELECT posicao, COUNT(posicao) CONTAR "+
                        "FROM( "+
                            "SELECT posicao "+
                            "FROM Inventarios "+
                            "WHERE status_inv not in ('DELE') "+
                            "GROUP BY ordem, posicao "+
                            ") "+
                        "GROUP BY posicao "+
                        ") "+
                    "WHERE CONTAR = 2";

            SQL2 = "SELECT COUNT(posicao) " +
                    "FROM("+
                        "SELECT DISTINCT posicao " +
                        "FROM Inventarios " +
                        "WHERE status_inv not in ('DELE', 'ACTI', 'INAC'))";

            liteBd.AbrirConexao();
            qtdSegCont = Convert.ToDouble(liteBd.ConsultaScalar(SQL1));                                     // quantidade de posições em segunda contagem
            totalPosCont = Convert.ToDouble(liteBd.ConsultaScalar(SQL2));
            lblRealSegunda.Text =  Math.Round((qtdSegCont / totalPosCont) * 100, 2).ToString() + "%";
            liteBd.FecharConexao();

            if (Convert.ToDouble(lblRealSegunda.Text.Replace("%", "")) > Convert.ToDouble(lblPlanSegunda.Text.Replace("%", "")))
            {
                lblRealSegunda.ForeColor = System.Drawing.Color.Red;
            }else
            {
                lblRealSegunda.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void TerceiraContagemPercent()
        {
            double totalPosCont;
            string SQL1, SQL2;

            SQL1 = "SELECT COUNT(CONTAR) " +
                    "FROM(" +
                        "SELECT posicao, COUNT(posicao) CONTAR " +
                        "FROM( " +
                            "SELECT posicao " +
                            "FROM Inventarios " +
                            "WHERE status_inv not in ('DELE') " +
                            "GROUP BY ordem, posicao " +
                            ") " +
                        "GROUP BY posicao " +
                        ") " +
                    "WHERE CONTAR > 2";

            SQL2 = "SELECT COUNT(posicao) " +
                    "FROM(" +
                        "SELECT DISTINCT posicao " +
                        "FROM Inventarios " +
                        "WHERE status_inv not in ('DELE', 'ACTI'))";

            liteBd.AbrirConexao();
            qtdTerCont = Convert.ToDouble(liteBd.ConsultaScalar(SQL1));                                     // quantidade de posições em segunda contagem
            totalPosCont = Convert.ToDouble(liteBd.ConsultaScalar(SQL2));
            lblRealTerceira.Text = Math.Round((qtdTerCont / totalPosCont) * 100, 2).ToString() + "%";
            liteBd.FecharConexao();

            if (Convert.ToDouble(lblRealTerceira.Text.Replace("%", "")) > Convert.ToDouble(lblPlanTerceira.Text.Replace("%", "")))
            {
                lblRealTerceira.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblRealTerceira.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void TerminoInventario()
        {
            string SQL, dataFimInventPlanejado;         // Data planejada pra terminar o inventário
            int posPendenteContagem,                    // Total de posições pendentes a contar
                minutosParadosReal,                     // Total de minutos parados Real
                minutosParadosRestantesPlanejados;      // Minutos parados restantes planejados
            double segContPercent, terContPercent,      // Percentual de segunda e terceira contagem 
                minutosParaTerminarInvent,              // Minutos estimados para terminar o inventário
                minutosPorPosicao,                      // quantos minutos está levando para se contar um posição em média
                estimativaPosContar;                    // Estimativa de posições a contar
            DateTime ultimoInvent = Convert.ToDateTime(dataUltimoInvent.Substring(8, 2) + "/" + dataUltimoInvent.Substring(5, 2) + "/" + dataUltimoInvent.Substring(0, 4) + " " + dataUltimoInvent.Substring(11, 5));


            liteBd.AbrirConexao();
            posPendenteContagem = Convert.ToInt32(liteBd.ConsultaScalar("SELECT COUNT(status_inv) " +
                                                    "FROM Inventarios " +
                                                    "WHERE status_inv IN ('ACTI', 'INAC')"));
            SQL = "SELECT COUNT(posicao) " +
                "FROM(" +
                    "SELECT tab1.posicao, tab1.status_inv, tab2.contar " +
                    "FROM " +
                        "(SELECT posicao, status_inv " +
                        "FROM Inventarios " +
                        "GROUP BY ordem, posicao, status_inv) AS tab1 " +
                    "LEFT JOIN " +
                        "(SELECT posicao, count(posicao)contar " +
                        "FROM( " +
                        "SELECT posicao, status_inv " +
                        "FROM Inventarios " +
                        "WHERE status_inv not in ('DELE') " +
                        "GROUP BY ordem, posicao, status_inv) " +
                        "GROUP BY posicao) AS tab2 " +
                        "ON tab1.posicao = tab2.posicao " +
                    "ORDER BY tab1.posicao) " +
            "WHERE status_inv in ('ACTI', 'INAC') and contar = 1 ";
            priContActi = Convert.ToInt32(liteBd.ConsultaScalar(SQL));

            minutosParadosReal = Convert.ToInt32(liteBd.ConsultaScalar("SELECT IFNULL(sum((strftime('%s', hora_fim) - strftime('%s', hora_inicio)) / 60), 0) " +
                "FROM PARADAS " +
                "WHERE strftime('%s', DATA || ' ' || hora_inicio) BETWEEN strftime('%s', '" + dataInicioInvent + "') AND strftime('%s', '" + dataUltimoInvent + "') AND tipo = 'REAL'"));

            dataFimInventPlanejado = liteBd.ConsultaScalar("SELECT valor FROM Config WHERE nome = 'termino'");

            //minutosParadosRestantesPlanejados = Convert.ToInt32(liteBd.ConsultaScalar("SELECT IFNULL(sum((strftime('%s', hora_fim) - strftime('%s', hora_inicio)) / 60), 0) " +
            //    "FROM PARADAS " +
            //    "WHERE strftime('%s', DATA || ' ' || hora_inicio) BETWEEN strftime('%s', '" + dataUltimoInvent + "') AND strftime('%s', '" + dataFimInventPlanejado + "') AND tipo = 'PLANEJADO'"));

            minutosParadosRestantesPlanejados = Convert.ToInt32(liteBd.ConsultaScalar("SELECT IFNULL(sum((strftime('%s', hora_fim) - strftime('%s', hora_inicio)) / 60), 0) " +
                "FROM PARADAS " +
                "WHERE strftime('%s', DATA || ' ' || hora_inicio) > strftime('%s', '" + dataUltimoInvent + "')  AND tipo = 'PLANEJADO'"));

            liteBd.FecharConexao();

            segContPercent = Convert.ToDouble(lblRealSegunda.Text.Replace("%", "")) / 100;
            terContPercent = Convert.ToDouble(lblRealTerceira.Text.Replace("%", "")) / 100;

            estimativaPosContar = posPendenteContagem + (priContActi * (segContPercent + terContPercent));

            minutosPorPosicao = ((minutosTotais - minutosParadosReal) / posicoesContadas);

            minutosParaTerminarInvent = (minutosPorPosicao * estimativaPosContar) + minutosParadosRestantesPlanejados;

            lblRealTermino.Text = ultimoInvent.AddMinutes(minutosParaTerminarInvent).ToString();
        }

        private void CarregaEvolucaoGeral()
        {
            int total, segContActi, terContActi;
            string SQL1, SQL2;

            grafContagens.Titles.Clear();                                                 //Deleta os Tìtulos do gráfico
            grafContagens.Series.Clear();                                                 //Deleta as séries do gráfico

            grafContagens.Series.Add("Contagens");
            grafContagens.Series["Contagens"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            grafContagens.Series["Contagens"].IsValueShownAsLabel = true;

            liteBd.AbrirConexao();
            SQL1 = "SELECT COUNT(posicao) " +
                "FROM(" +
                    "SELECT tab1.posicao, tab1.status_inv, tab2.contar " +
                    "FROM " +
                        "(SELECT posicao, status_inv " +
                        "FROM Inventarios " +
                        "GROUP BY ordem, posicao, status_inv) AS tab1 " +
                    "LEFT JOIN " +
                        "(SELECT posicao, count(posicao)contar " +
                        "FROM( " +
                        "SELECT posicao, status_inv " +
                        "FROM Inventarios " +
                        "WHERE status_inv not in ('DELE') " +
                        "GROUP BY ordem, posicao, status_inv) " +
                        "GROUP BY posicao) AS tab2 " +
                        "ON tab1.posicao = tab2.posicao " +
                    "ORDER BY tab1.posicao) " +
             "WHERE status_inv in ('ACTI', 'INAC') and contar = 2 ";

            SQL2 = "SELECT COUNT(posicao) " +
                "FROM(" +
                    "SELECT tab1.posicao, tab1.status_inv, tab2.contar " +
                    "FROM " +
                        "(SELECT posicao, status_inv " +
                        "FROM Inventarios " +
                        "GROUP BY ordem, posicao, status_inv) AS tab1 " +
                    "LEFT JOIN " +
                        "(SELECT posicao, count(posicao)contar " +
                        "FROM( " +
                        "SELECT posicao, status_inv " +
                        "FROM Inventarios " +
                        "WHERE status_inv not in ('DELE') " +
                        "GROUP BY ordem, posicao, status_inv) " +
                        "GROUP BY posicao) AS tab2 " +
                        "ON tab1.posicao = tab2.posicao " +
                    "ORDER BY tab1.posicao) " +
             "WHERE status_inv in ('ACTI', 'INAC') and contar > 2 ";

            segContActi = Convert.ToInt32(liteBd.ConsultaScalar(SQL1));
            terContActi = Convert.ToInt32(liteBd.ConsultaScalar(SQL2));
            liteBd.FecharConexao();

            total = posicoesContadas + priContActi + segContActi + terContActi;

            grafContagens.Series["Contagens"].Points.AddXY("Finalizado", Convert.ToDouble(posicoesContadas) / Convert.ToDouble(total));                          // Setando o valor para "Contado"
            grafContagens.Series["Contagens"].Points.AddXY("1ª Contagem", Convert.ToDouble(priContActi) / Convert.ToDouble(total));                            // Setando o valor para "Pendente"
            grafContagens.Series["Contagens"].Points.AddXY("2ª Contagem", qtdSegCont / Convert.ToDouble(total));                             // Setando o valor para "Pendente"
            grafContagens.Series["Contagens"].Points.AddXY("3ª Contagem", qtdTerCont / Convert.ToDouble(total));                             // Setando o valor para "Pendente"

            grafContagens.Series["Contagens"].Points[0].Color = Color.FromArgb(45, 204, 112);                                             // Cor da parte "Contado"
            grafContagens.Series["Contagens"].Points[0].LabelForeColor = Color.Black;                                   // Cor da Fonte
            grafContagens.Series["Contagens"].Points[0].LabelFormat = "{P2}";                                           // Formata para porcentagem
            grafContagens.Series["Contagens"].Points[0].Font = new Font("", 10, FontStyle.Bold);

            grafContagens.Series["Contagens"].Points[1].Color = Color.FromArgb(53, 152, 219);                                       // Cor da parte "Pendente"
            grafContagens.Series["Contagens"].Points[1].LabelForeColor = Color.Black;
            grafContagens.Series["Contagens"].Points[1].LabelFormat = "{P2}";
            grafContagens.Series["Contagens"].Points[1].Font = new Font("", 10, FontStyle.Bold);
            grafContagens.Series[0].ShadowColor = Color.DarkGray;

            grafContagens.Series["Contagens"].Points[2].Color = Color.FromArgb(231, 126, 35);                                          // Cor da parte "Pendente"
            grafContagens.Series["Contagens"].Points[2].LabelForeColor = Color.Black;
            grafContagens.Series["Contagens"].Points[2].LabelFormat = "{P2}";
            grafContagens.Series["Contagens"].Points[2].Font = new Font("", 10, FontStyle.Bold);
            grafContagens.Series[0].ShadowColor = Color.DarkGray;
            grafContagens.Series[0].ShadowOffset = 5;

            grafContagens.Series["Contagens"].Points[3].Color = Color.FromArgb(241, 196, 15);                                          // Cor da parte "Pendente"
            grafContagens.Series["Contagens"].Points[3].LabelForeColor = Color.Black;
            grafContagens.Series["Contagens"].Points[3].LabelFormat = "{P2}";
            grafContagens.Series["Contagens"].Points[3].Font = new Font("", 10, FontStyle.Bold);
            grafContagens.Series[0].ShadowColor = Color.DarkGray;
            grafContagens.Series[0].ShadowOffset = 5;
            
            //SQL = "SELECT ROUND((SELECT COUNT(POS) FROM (SELECT POS_DEP AS POS FROM INVENTARIO WHERE DAT_CONT BETWEEN " + dataDe + " AND " + dataAte + " GROUP BY POS_DEP)) / COUNT(CODPOS), 4) FROM POSICAO";
            //rotativoPercent = Convert.ToDouble(conex.consultaScalar(SQL));
            //grafContagens.Series["Contado"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            //grafContagens.Series["Contagens"].Points[0].YValues[0] = posicoesContadas / total;
            //grafContagens.Series["Contagens"].Points[1].YValues[0] = priContActi / total;
            //grafContagens.Series["Contagens"].Points[2].YValues[0] = qtdSegCont / total;
            //grafContagens.Series["Contagens"].Points[3].YValues[0] = qtdTerCont / total;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmProdutividadeContagem produtividade = new frmProdutividadeContagem();
            produtividade.Show();
        }
    }
}
