using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SInP.Gestao_Estoque.Racional;

namespace SInP
{
    public partial class frmIndicadoresMensal : Form
    {
        string SQL;
        string dataDe, dataAte;
        bool rupturaPkAtualizado = false;
        LiteBD liteBD = new LiteBD();
        Func func = new Func();

        public frmIndicadoresMensal()
        {
            InitializeComponent();
        }

        private void frmIndicadores_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            AccessBD conex = new AccessBD();
            conex.AbrirConexao();

            dtpDe1.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            dtpDe2.Text = "01/01/"+ DateTime.Now.Year.ToString();
            
            dtpAte1.Text = DateTime.Now.ToString();
            dtpAte2.Text = DateTime.Now.ToString();

            dataDe = dtpDe1.Text.Substring(6, 4) + dtpDe1.Text.Substring(3, 2) + dtpDe1.Text.Substring(0, 2);
            dataAte = dtpAte1.Text.Substring(6, 4) + dtpAte1.Text.Substring(3, 2) + dtpAte1.Text.Substring(0, 2);

            //Carrega os gráficos nas Threads
            bgwGrafEvolucaoRotativo.RunWorkerAsync();
            bgwAcuracidadeMensal.RunWorkerAsync();
            bgwEanPosicaoMensal.RunWorkerAsync();
            bgwRupturaPK.RunWorkerAsync();
            conex.FecharConexao();
            liteBD.FecharConexao();
        }
       
        private void bgwGrafEvolucaoRotativo_DoWork_1(object sender, DoWorkEventArgs e)
        {
            AccessBD conex = new AccessBD();
            conex.AbrirConexao();
            double rotativoPercent = 0;
            int totalPos, pendentePos;
            
            lblUltimoInvent.Text = conex.consultaScalar("SELECT RIGHT(DAT_post, 2) &'/'& MID(DAT_post, 5, 2) &'/'& LEFT(DAT_post, 4)   & ' ÀS ' & MAX(hr_post) AS hr_post FROM INVENTARIO WHERE (((INVENTARIO.[DAT_POST])=(SELECT Max(dat_POST) FROM INVENTARIO))) group by dat_post");
            SQL = "SELECT COUNT(POS_DEP) FROM(SELECT DAT_CONT, POS_DEP FROM INVENTARIO WHERE DAT_CONT Between 20160701 And 20160705 GROUP BY DAT_CONT, POS_DEP, DOC_INV1)";
            totalPos = Convert.ToInt32(conex.consultaScalar("SELECT COUNT(POSICAO) FROM POSICAO"));
            pendentePos = Convert.ToInt32(conex.consultaScalar(SQL));

            lblPosContadas.Text = pendentePos.ToString();
            lblPosPendentes.Text = (totalPos - pendentePos).ToString();

            grafRotativoPercent.Titles.Clear();                                                 //Deleta os Tìtulos do gráfico
            grafRotativoPercent.Series.Clear();                                                 //Deleta as séries do gráfico

            grafRotativoPercent.Titles.Add("Evolução da contagem Rotativa (" + dtpDe1.Text + " à " + dtpAte1.Text + ")");                                 // adiciona título
            grafRotativoPercent.Titles[0].Font = new Font("", 14, FontStyle.Bold);                  // coloca o título como negrito

            grafRotativoPercent.Series.Add("Contado");
            grafRotativoPercent.Series["Contado"].ChartType = SeriesChartType.Pie;
            grafRotativoPercent.Series["Contado"].IsValueShownAsLabel = true;

            grafRotativoPercent.Series["Contado"].Points.AddXY("Contado", 0);                                  // Setando o valor para "Contado"
            grafRotativoPercent.Series["Contado"].Points.AddXY("Pendente", 1);                             // Setando o valor para "Pendente"

            grafRotativoPercent.Series["Contado"].Points[0].Color = Color.FromArgb(45, 204, 112);                                             // Cor da parte "Contado"
            grafRotativoPercent.Series["Contado"].Points[0].LabelForeColor = Color.White;                                   // Cor da Fonte
            grafRotativoPercent.Series["Contado"].Points[0].LabelFormat = "{P2}";                                           // Formata para porcentagem
            grafRotativoPercent.Series["Contado"].Points[0].Font = new Font("", 10, FontStyle.Bold);

            grafRotativoPercent.Series["Contado"].Points[1].Color = Color.FromArgb(63, 86, 100);                                          // Cor da parte "Pendente"
            grafRotativoPercent.Series["Contado"].Points[1].LabelForeColor = Color.White;
            grafRotativoPercent.Series["Contado"].Points[1].LabelFormat = "{P2}";
            grafRotativoPercent.Series["Contado"].Points[1].Font = new Font("", 10, FontStyle.Bold);
            grafRotativoPercent.Series[0].ShadowColor = Color.DarkGray;
            grafRotativoPercent.Series[0].ShadowOffset = 5;            

            SQL = "SELECT ROUND((SELECT COUNT(POS) FROM (SELECT POS_DEP AS POS FROM INVENTARIO WHERE DAT_CONT BETWEEN " + dataDe + " AND " + dataAte + " GROUP BY POS_DEP)) / COUNT(CODPOS), 4) FROM POSICAO";
            rotativoPercent = Convert.ToDouble(conex.consultaScalar(SQL));
            grafRotativoPercent.Series["Contado"].YValueType = ChartValueType.Double;

            grafRotativoPercent.Series["Contado"].Points[0].YValues[0] = rotativoPercent;
            grafRotativoPercent.Series["Contado"].Points[1].YValues[0] = Math.Round(1 - rotativoPercent, 4);
        }       

        private void bgwAcuracidadeMensal_DoWork(object sender, DoWorkEventArgs e)
        {   //::::::::::::::::::::: ACURACIDADE MENSAL :::::::::::::::::::::::::::::::::::::::::::::::::::
            AccessBD conex = new AccessBD();
            IDataReader retornoBD;

            grafAcuracidadeMensal.Titles.Clear();                                                   //Deleta os Tìtulos do gráfico
            grafAcuracidadeMensal.Series.Clear();                                                   //Deleta as séries do gráfico

            grafAcuracidadeMensal.Titles.Add("Acuracidade de estoque mensal");                             // adiciona título
            grafAcuracidadeMensal.Titles[0].Font = new Font("", 14, FontStyle.Bold);                    // coloca o título como negrito

            grafAcuracidadeMensal.Series.Add("acuracidade");                                           // Adiciona a série "Quantidade contada"
            grafAcuracidadeMensal.Series[0].Color = Color.FromArgb(231, 126, 35);
            grafAcuracidadeMensal.Series["acuracidade"].BackHatchStyle = ChartHatchStyle.BackwardDiagonal;
            grafAcuracidadeMensal.Series["acuracidade"].IsValueShownAsLabel = true;                     // Abilita rótulos para a série
            grafAcuracidadeMensal.Series[0].Font = new Font("", 12, FontStyle.Bold);                    // coloca o título como negrito
            //TODO: refazer racional do SQL abaixo
            SQL = "SELECT D.MES, ROUND((1-(D.VALDIF / E.VALORESTOQUE))*100, 2) " +
                "FROM " +
                "(SELECT A.MES, A.VALDIF " +
                "FROM " +
                "(SELECT MID(A.DAT_CONT, 5, 2) + MID(A.DAT_CONT, 1, 4)  AS MES, ABS(SUM(A.QTD_DIFER * B.VALOR)) AS VALDIF " +
                "FROM(INVENTARIO AS A LEFT JOIN VALPROD AS B ON A.PRODUTO = B.PRODUTO) " +
                "WHERE A.TIPO_DEP IN(1001, 1002, 1003, 2001, 2002, 3003, 3001, 3005, 3008, 5002) " +
                "GROUP BY MID(A.DAT_CONT, 5, 2) + MID(A.DAT_CONT, 1, 4))  AS A) AS D " +
                "LEFT JOIN VALOR_ESTOQUE AS E ON D.MES = FORMAT(E.MES, \"000000\") " +
                "WHERE RIGHT(D.MES, 4) = 2016";
            //SQL = conex.consultaScalar("SELECT valor FROM Acuracidade_Mensal_Config WHERE config = 'SQL'");
            try
            {
                retornoBD = conex.consultaReader(SQL);
                while (retornoBD.Read())
                {
                    string sMes = "";
                    switch (retornoBD.GetString(0))
                    {
                        case "01":
                            sMes = "Janeiro";
                            break;
                        case "02":
                            sMes = "Fevereiro";
                            break;
                        case "03":
                            sMes = "Março";
                            break;
                        case "04":
                            sMes = "Abril";
                            break;
                        case "05":
                            sMes = "Maio";
                            break;
                        case "06":
                            sMes = "Junho";
                            break;
                        case "07":
                            sMes = "Julho";
                            break;
                        case "08":
                            sMes = "Agosto";
                            break;
                        case "09":
                            sMes = "Setembro";
                            break;
                        case "10":
                            sMes = "Outubro";
                            break;
                        case "11":
                            sMes = "Novembro";
                            break;
                        case "12":
                            sMes = "Dezembro";
                            break;
                    }
                    grafAcuracidadeMensal.Series["acuracidade"].Points.AddXY(sMes, retornoBD.GetDouble(1));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgwEanPosicaoMensal_DoWork(object sender, DoWorkEventArgs e)
        {  //::::::::::::::::::::::: EAN X POSICAO (MENSAL) ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            AccessBD conex = new AccessBD();
            IDataReader retornoBD;

            grafEanPosicaoMensal.Titles.Clear();
            grafEanPosicaoMensal.Series.Clear();

            grafEanPosicaoMensal.Titles.Add("EAN x Posição Mensal");
            grafEanPosicaoMensal.Titles[0].Font = new Font("", 14, FontStyle.Bold);

            grafEanPosicaoMensal.Series.Add("acuracia");
            grafEanPosicaoMensal.Series["acuracia"].BackHatchStyle = ChartHatchStyle.BackwardDiagonal;
            grafEanPosicaoMensal.Series["acuracia"].IsValueShownAsLabel = true;
            grafEanPosicaoMensal.Series["acuracia"].Color = Color.FromArgb(53, 152, 219);
            grafEanPosicaoMensal.Series["acuracia"].XValueType = ChartValueType.String;
            grafEanPosicaoMensal.Series["acuracia"].YValueType = ChartValueType.Double;
            grafEanPosicaoMensal.Series[0].Font = new Font("", 12, FontStyle.Bold);                  // coloca o título como negrito

            SQL = Properties.Settings.Default.sqlEANxPosicaoMensal;
            retornoBD = conex.consultaReader(SQL);
            while (retornoBD.Read())
            {
                string sMes = "";
                switch (retornoBD.GetString(0))
                {
                    case "01":
                        sMes = "Janeiro";
                        break;
                    case "02":
                        sMes = "Fevereiro";
                        break;
                    case "03":
                        sMes = "Março";
                        break;
                    case "04":
                        sMes = "Abril";
                        break;
                    case "05":
                        sMes = "Maio";
                        break;
                    case "06":
                        sMes = "Junho";
                        break;
                    case "07":
                        sMes = "Julho";
                        break;
                    case "08":
                        sMes = "Agosto";
                        break;
                    case "09":
                        sMes = "Setembro";
                        break;
                    case "10":
                        sMes = "Outubro";
                        break;
                    case "11":
                        sMes = "Novembro";
                        break;
                    case "12":
                        sMes = "Dezembro";
                        break;
                }
                grafEanPosicaoMensal.Series["acuracia"].Points.AddXY(sMes, retornoBD.GetDouble(1));
            }
        }

        private void btnAtulizar2_Click(object sender, EventArgs e)
        {
            bgwRupturaPK.RunWorkerAsync();
        }

        private void racionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRacionalRupturaMensal frmRacionalRupturaMensal = new frmRacionalRupturaMensal();
            frmRacionalRupturaMensal.Show();
        }

        private void btnAtualizar1_Click(object sender, EventArgs e)
        {
            dataDe = dtpDe1.Text.Substring(6, 4) + dtpDe1.Text.Substring(3, 2) + dtpDe1.Text.Substring(0, 2);
            dataAte = dtpAte1.Text.Substring(6, 4) + dtpAte1.Text.Substring(3, 2) + dtpAte1.Text.Substring(0, 2);

            btnAtualizar1.Enabled = false;
            btnAtualizar1.Text = "Atualizando...";

            bgwGrafEvolucaoRotativo.RunWorkerAsync();
        }

        private void bgwRupturaPK_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            rupturaPkAtualizado = true;
            habilitaBotaoAtualizar();           // Caso as outras threads já tenham terminado, habilita o botão Atualizar
        }

        private void bgwGrafEvolucaoRotativo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnAtualizar1.Enabled = true;
            btnAtualizar1.Text = "Atualizar";
        }

        private void bgwRupturaPK_DoWork(object sender, DoWorkEventArgs e)
        {
            string SQL1;
            IDataReader retornoBD;

            grafRupturaPK.Titles.Clear();                                                            //Deleta os Tìtulos do gráfico
            grafRupturaPK.Series.Clear();                                                            //Deleta as séries do gráfico

            grafRupturaPK.Titles.Add("Ruptura de Picking");                                         // adiciona título
            grafRupturaPK.Titles[0].Font = new Font("", 14, FontStyle.Bold);                        // coloca o título como negrito
            grafRupturaPK.Series.Add("ruptura");                                                    // Adiciona a série
            grafRupturaPK.Series["ruptura"].LabelFormat = "{0.00} %";                               // Formatando o rótulo como porcentagem
            grafRupturaPK.Series["ruptura"].Color = Color.FromArgb(231, 126, 35);
            grafRupturaPK.Series["ruptura"].BackHatchStyle = ChartHatchStyle.BackwardDiagonal;
            grafRupturaPK.Series["ruptura"].IsValueShownAsLabel = true;                               // Abilita rótulos para a série
            grafRupturaPK.Series["ruptura"].Font = new Font("", 12, FontStyle.Regular);               // coloca o título como negrito
            grafRupturaPK.Series["ruptura"].IsVisibleInLegend = true;
            grafRupturaPK.Series["ruptura"].LegendText = "Ruptura";
            
            grafRupturaPK.Series.Add("target");                                                         // Adiciona a série "Quantidade contada"
            grafRupturaPK.Series["target"].Color = Color.Red;
            grafRupturaPK.Series["target"].ChartType = SeriesChartType.Line;                            // TIpo do gráfico (linha)
            grafRupturaPK.Series["target"].BorderWidth = 2;
            grafRupturaPK.Series["target"].IsVisibleInLegend = true;
            grafRupturaPK.Series["target"].LegendText = "Target (0,1%)";

            SQL1 = "SELECT SUBSTR(B.data2, 5, 2)||'/'||SUBSTR(B.data2, 1, 4), ifnull(a.rupt, 0), ifnull(b.fat, 0) " +
                  "FROM " +
                        "(SELECT substr(data, 1, 6) data2, SUM(linhas) fat " +
                        "FROM Faturamento " +
                        "WHERE data BETWEEN "+ func.ConvertDataParaBD(dtpDe2.Text) +" and "+ func.ConvertDataParaBD(dtpAte2.Text) + " " +
                        "GROUP BY substr(data, 1, 6) " +
                        ") B " +
                "LEFT JOIN " +
                        "(SELECT substr(data, 1, 6) data2, COUNT(data) rupt " +
                        "FROM Ruptura_PK " +
                        "WHERE tipo_ruptura = 'RUPTURA DE PICKING'"+
                        "GROUP BY substr(data, 1, 6) " +
                        ") A " +
                "on a.data2 = b.data2 ";

            liteBD.AbrirConexao();
            retornoBD = liteBD.ConsultaReader(SQL1);
            while (retornoBD.Read())
            {
                grafRupturaPK.Series["ruptura"].Points.AddXY(retornoBD[0],((retornoBD.GetDouble(1) / retornoBD.GetDouble(2))*100));
                grafRupturaPK.Series["target"].Points.AddXY(retornoBD[0], 0.1);
            }
        }

        private bool habilitaBotaoAtualizar()   // Verifica se todas as threads já terminaram para habilitar o botão atualizar
        {
            if(rupturaPkAtualizado)
            {
                btnAtulizar2.Enabled = true;
                return true;
            }else
            {
                return false;
            }
        }

    }
}
