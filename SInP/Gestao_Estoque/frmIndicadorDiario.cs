using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SInP
{
    public partial class frmIndicadorDiario : Form
    {
        string dataDe, dataAte;
        bool rupturaPkAtualizado=false;
        LiteBD liteBD = new LiteBD();
        Func func = new Func();

        public frmIndicadorDiario()
        {
            InitializeComponent();
        }

        private void frmIndicadorDiario_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            CheckForIllegalCrossThreadCalls = false;

            dtpDataDe2.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            dtpDataAte2.Text = DateTime.Now.ToString();

            btnAtualizar2.Enabled = false;

            //bgwEanPosicaoDiario.RunWorkerAsync();
            //bgwPosicoesContadas.RunWorkerAsync();
            //bgwAcuracidadeDiaria.RunWorkerAsync();
            bgwRupturaPKdiaria.RunWorkerAsync();
        }

        private void btnAtualizar2_Click(object sender, EventArgs e)
        {
            btnAtualizar2.Enabled = false;
            bgwRupturaPKdiaria.RunWorkerAsync();
        }

        private void bgwEanPosicao_DoWork(object sender, DoWorkEventArgs e)//:::::::::: EAN x Posição (Diário):::
        {
            AccessBD conex = new AccessBD();
            string SQL;
            IDataReader retornoBD;

            grafEanPosicaoDiario.Titles.Clear();
            grafEanPosicaoDiario.Series.Clear();

            grafEanPosicaoDiario.Titles.Add("Acompanhamento diário de EAN x Posição");
            grafEanPosicaoDiario.Titles[0].Font = new Font("", 14, FontStyle.Bold);

            grafEanPosicaoDiario.Series.Add("acuracia");
            grafEanPosicaoDiario.Series["acuracia"].BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            grafEanPosicaoDiario.Series["acuracia"].IsValueShownAsLabel = true;
            grafEanPosicaoDiario.Series["acuracia"].Color = Color.FromArgb(53, 152, 219);
            grafEanPosicaoDiario.Series["acuracia"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            grafEanPosicaoDiario.Series["acuracia"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            SQL = "SELECT RIGHT(DAT_CONT, 2) & '/' & MID(DAT_CONT, 5, 2) & '/' & LEFT(DAT_CONT, 4), ROUND(AVG(ACUR) * 100, 2) " +
                "FROM(SELECT DAT_CONT, DOC_INV1, POS_DEP, IIF(COUNT(PRODUTO) > 1,0,1) AS ACUR " +
                "FROM(SELECT A.DAT_CONT, A.DOC_INV1, A.POS_DEP, A.PRODUTO FROM INVENTARIO AS A LEFT JOIN POSICAO AS B ON A.POS_DEP = B.POSICAO WHERE A.DAT_CONT BETWEEN " + dataDe + " AND " + dataAte + " and B.TIPO_DEP NOT IN (1003,7001,7004) AND A.PRODUTO <> '' GROUP BY A.DOC_INV1, A.POS_DEP, A.PRODUTO, A.DAT_CONT) " +
                "GROUP BY DOC_INV1, POS_DEP, DAT_CONT) " +
                "GROUP BY DAT_CONT";
            retornoBD = conex.consultaReader(SQL);
            while (retornoBD.Read())
            {
                grafEanPosicaoDiario.Series["acuracia"].Points.AddXY(retornoBD.GetString(0), retornoBD.GetDouble(1));
            }
            grafEanPosicaoDiario.Titles.Add("Acompanhamento diário de  EAN x Posição (" + dtpDataDe2.Text + " à " + dtpDataAte2.Text + ")");
            grafEanPosicaoDiario.Titles[0].Font = new Font("", 14, FontStyle.Bold);
        }

        private void bgwPosicoesContadas_DoWork(object sender, DoWorkEventArgs e)//::::::Posições contadas ::::::
        {
            AccessBD conex = new AccessBD();
            string SQL;
            IDataReader retornoBD;

            grafRotativoDia.Titles.Clear();                                                   //Deleta os Tìtulos do gráfico
            grafRotativoDia.Series.Clear();                                                   //Deleta as séries do gráfico

            grafRotativoDia.Titles.Add("Posições Contadas (" + dtpDataDe2.Text + " à " + dtpDataAte2.Text + ")");                                 // adiciona título
            grafRotativoDia.Titles[0].Font = new Font("", 14, FontStyle.Bold);                  // coloca o título como negrito

            grafRotativoDia.Series.Add("Qtd. Contada");                                       // Adiciona a série "Quantidade contada"
            grafRotativoDia.Series["Qtd. Contada"].BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            grafRotativoDia.Series["Qtd. Contada"].IsValueShownAsLabel = true;                 // Abilita rótulos para a série
            grafRotativoDia.Series["Qtd. Contada"].Color = Color.FromArgb(232, 189, 15);              // seta cor vermelha para a série


            grafRotativoDia.Series.Add("Target = 461 posições/dia");                            // adiciona outra série
            grafRotativoDia.Series["Target = 461 posições/dia"].Color = Color.Red;              // seta cor vermelha para a série
            grafRotativoDia.Series["Target = 461 posições/dia"].IsValueShownAsLabel = true;     // Abilita rótulos para a série
            grafRotativoDia.Series["Target = 461 posições/dia"].BorderWidth = 2;                // Largura da borda como 2
            grafRotativoDia.Series["Target = 461 posições/dia"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;   // Tipo do gráfico

            SQL = "SELECT RIGHT(DAT_CONT, 2) & '/' &MID(DAT_CONT, 5, 2) & '/' & LEFT(DAT_CONT, 4), COUNT(POS_DEP) FROM" +
                "(SELECT DAT_CONT, POS_DEP FROM INVENTARIO WHERE DAT_CONT Between " + dataDe + " And " + dataAte + " GROUP BY DAT_CONT, POS_DEP, DOC_INV1) " +
                "GROUP BY DAT_CONT " +
                "ORDER BY dat_cont; ";
            retornoBD = conex.consultaReader(SQL);

            while (retornoBD.Read())
            {
                grafRotativoDia.Series["Qtd. Contada"].Points.AddXY(retornoBD.GetString(0), retornoBD.GetInt32(1));
                grafRotativoDia.Series["Target = 461 posições/dia"].Points.AddXY(retornoBD.GetString(0), 461);
            }
        }

        private void bgwAcuracidadeDiaria_DoWork(object sender, DoWorkEventArgs e)//:: ACURACIDADE DIÁRIA :::
        {
            AccessBD conex = new AccessBD();
            string SQL;
            IDataReader retornoBD;

            //dtpDataDe2.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            //dtpDataAte2.Text = DateTime.Now.ToString();

            grafAcuracidadeDiario.Titles.Clear();
            grafAcuracidadeDiario.Series.Clear();

            grafAcuracidadeDiario.Titles.Add("Acuracidade de estoque diária (" + dtpDataDe2.Text + " à " + dtpDataAte2.Text + ")");
            grafAcuracidadeDiario.Titles[0].Font = new Font("", 14, FontStyle.Bold);

            grafAcuracidadeDiario.Series.Add("acuracia");
            grafAcuracidadeDiario.Series["acuracia"].BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.BackwardDiagonal;
            grafAcuracidadeDiario.Series["acuracia"].IsValueShownAsLabel = true;
            grafAcuracidadeDiario.Series["acuracia"].Color = Color.FromArgb(231, 126, 35);
            grafAcuracidadeDiario.Series["acuracia"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            grafAcuracidadeDiario.Series["acuracia"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;

            SQL =
                "SELECT RIGHT(DAT_CONT, 2) & '/' & MID(DAT_CONT, 5, 2) & '/' & LEFT(DAT_CONT, 4), ROUND((1 - (SUM(VALOR2) / " +
                            "(SELECT SUM(VALOR2) FROM(SELECT A.DAT_CONT, A.ORDEM, A.POS_DEP, A.PRODUTO, ABS(A.DIFER * B.VALOR) AS VALOR2 " +
                            "FROM " +
                            "(SELECT DAT_CONT, ORDEM, POS_DEP, PRODUTO, SUM(QTD_DIFER) AS DIFER " +
                            "FROM INVENTARIO " +
                            "WHERE TIPO_DEP IN(1001, 1002, 1003, 2001, 2002, 3003, 3008, 5002) AND DAT_CONT BETWEEN " + dataDe + " AND " + dataAte +
                            " GROUP BY DAT_CONT, ORDEM, POS_DEP, PRODUTO) AS A LEFT JOIN VALPROD AS B ON A.PRODUTO = B.PRODUTO)))) *100, 2) " +

                 "FROM " +
                 "(SELECT A.DAT_CONT, A.ORDEM, A.POS_DEP, A.PRODUTO, ABS(A.DIFER * B.VALOR) AS VALOR2 " +
                 "FROM " +
                 "(SELECT DAT_CONT, ORDEM, POS_DEP, PRODUTO, SUM(QTD_DIFER) AS DIFER " +
                 "FROM INVENTARIO " +
                 "WHERE TIPO_DEP IN(1001, 1002, 1003, 2001, 2002, 3003, 3008, 5002) AND DAT_CONT BETWEEN " + dataDe + " AND " + dataAte +
                 " GROUP BY DAT_CONT, ORDEM, POS_DEP, PRODUTO) AS A LEFT JOIN VALPROD AS B ON A.PRODUTO = B.PRODUTO) " +
                 "GROUP BY DAT_CONT; ";

            retornoBD = conex.consultaReader(SQL);
            while (retornoBD.Read())
            {
                grafAcuracidadeDiario.Series["acuracia"].Points.AddXY(retornoBD.GetString(0), retornoBD.GetDouble(1));
            }
        }

        private void bgwRupturaPKdiaria_DoWork(object sender, DoWorkEventArgs e)
        {
            string SQL1;
            IDataReader retornoBD;

            grafRupturaPKdiaria.Titles.Clear();                                                            //Deleta os Tìtulos do gráfico
            grafRupturaPKdiaria.Series.Clear();                                                            //Deleta as séries do gráfico

            grafRupturaPKdiaria.Titles.Add("Ruptura de Picking");                                         // adiciona título
            grafRupturaPKdiaria.Titles[0].Font = new Font("", 14, FontStyle.Bold);                        // coloca o título como negrito
            grafRupturaPKdiaria.Series.Add("ruptura");                                                    // Adiciona a série
            grafRupturaPKdiaria.Series["ruptura"].LabelFormat = "{0.00} %";                               // Formatando o rótulo como porcentagem
            grafRupturaPKdiaria.Series["ruptura"].Color = Color.FromArgb(231, 126, 35);
            grafRupturaPKdiaria.Series["ruptura"].BackHatchStyle = ChartHatchStyle.BackwardDiagonal;
            grafRupturaPKdiaria.Series["ruptura"].IsValueShownAsLabel = true;                               // Abilita rótulos para a série
            grafRupturaPKdiaria.Series["ruptura"].Font = new Font("", 12, FontStyle.Regular);               // coloca o título como negrito
            grafRupturaPKdiaria.Series["ruptura"].IsVisibleInLegend = true;
            grafRupturaPKdiaria.Series["ruptura"].LegendText = "Ruptura";
            grafRupturaPKdiaria.Series["ruptura"].XValueType = ChartValueType.String;

            grafRupturaPKdiaria.Series.Add("target");                                                         // Adiciona a série "Quantidade contada"
            grafRupturaPKdiaria.Series["target"].Color = Color.Red;
            grafRupturaPKdiaria.Series["target"].ChartType = SeriesChartType.Line;                            // TIpo do gráfico (linha)
            grafRupturaPKdiaria.Series["target"].BorderWidth = 2;
            grafRupturaPKdiaria.Series["target"].IsVisibleInLegend = true;
            grafRupturaPKdiaria.Series["target"].LegendText = "Target (0,1%)";

            //grafRupturaPKdiaria.Series["ruptura"].IsXValueIndexed = true;

            SQL1 = "SELECT SUBSTR(B.data2, 7,2) ||'/'|| SUBSTR(B.data2, 5,2), ifnull(a.rupt, 0), ifnull(b.fat, 0) " +
                  "FROM " +
                        "(SELECT data data2, SUM(linhas) fat " +
                        "FROM Faturamento " +
                        "WHERE data BETWEEN " + func.ConvertDataParaBD(dtpDataDe2.Text) + " and " + func.ConvertDataParaBD(dtpDataAte2.Text) + " " +
                        "GROUP BY data " +
                        ") B " +
                "LEFT JOIN " +
                        "(SELECT data data2, COUNT(data) rupt " +
                        "FROM Ruptura_PK " +
                        "WHERE tipo_ruptura = 'RUPTURA DE PICKING'" +
                        "GROUP BY data " +
                        ") A " +
                "on a.data2 = b.data2 ";

            liteBD.AbrirConexao();
            retornoBD = liteBD.ConsultaReader(SQL1);
            while (retornoBD.Read())
            {
                grafRupturaPKdiaria.Series["ruptura"].Points.AddXY(retornoBD.GetValue(0),(decimal) Math.Round((retornoBD.GetDouble(1) / retornoBD.GetDouble(2)) * 100,2));
                grafRupturaPKdiaria.Series["target"].Points.AddXY(retornoBD[0], 0.1);
            }
            grafRupturaPKdiaria.Invalidate(); // invoke redraw
        }//::RUPTURA DE PICKING DIÁRIA

        private void bgwRupturaPKdiaria_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            rupturaPkAtualizado = true;
            habilitaBotaoAtualizar();
        }

        private bool habilitaBotaoAtualizar()   // Verifica se todas as threads já terminaram para habilitar o botão atualizar
        {
            if (rupturaPkAtualizado)
            {
                btnAtualizar2.Enabled = true;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
