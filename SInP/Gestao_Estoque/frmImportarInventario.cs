using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;

namespace SInP
{
    public partial class frmImportarInventario : Form
    {   //Declaração de variáveis
        string SQL;
        public string arquivo;
        frmPrincipal frmPrincipal;
        ToolStripLabel lblStripImportar;
        ToolStripProgressBar BarraProgresso = new ToolStripProgressBar();
        ToolStripLabel lblStripSalvar = new ToolStripLabel();
        ToolStripLabel lblStripPorcent = new ToolStripLabel();
        DataSet output;

        //Configurando Firebase
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "joH00JAXpQg8d43ji8elTLO9ucRUO0iiZSzmg9wS",
            BasePath = "https://project-5280949790712613125.firebaseio.com/"
        };


        public frmImportarInventario(frmPrincipal frm1)
        {
            InitializeComponent();
            frmPrincipal = frm1;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            lblStripImportar = new ToolStripLabel();
            arquivo = Arquivo();

            if (arquivo != "cancelado")
            {
                bgwImportaExcel.RunWorkerAsync(arquivo);

                lblStripImportar.Text = "Importando Planilha:";
                frmPrincipal.statusStrip1.Items.Add(lblStripImportar);

                BarraProgresso.Style = ProgressBarStyle.Marquee;
                BarraProgresso.MarqueeAnimationSpeed = 4;
                frmPrincipal.statusStrip1.Items.Add(BarraProgresso);
            }

        }

        //::Salva o conteúdo do dataGrid no banco de dados::
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dgvPos.Rows.Count > 0)
            {
                salvarInvent();
            }
            else
            {
                MessageBox.Show("Não há nada para salvar aqui!!!", "Espere aí", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //::Importar do Excel para o DataGridView::
        public void importa_Excel(string arquivo, DataGridView dataGridView)
        {
            // Microsoft.ACE.OLEDB.12.0 - Funciona apenas para ambientes de 64bits
            string strConexao = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"", arquivo);
            OleDbConnection conn = new OleDbConnection(strConexao);
            conn.Open();

            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            //Cria o objeto dataset para receber o conteúdo do arquivo Excel
            output = new DataSet();
            foreach (DataRow row in dt.Rows)
            {
                // obtem o noma da planilha corrente
                string sheet = row["TABLE_NAME"].ToString();
                // obtem todos as linhas da planilha corrente
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                cmd.CommandType = CommandType.Text;
                // copia os dados da planilha para o datatable
                DataTable outputTable = new DataTable(sheet);
                output.Tables.Add(outputTable);
                new OleDbDataAdapter(cmd).Fill(outputTable);
            }
            conn.Close();
            // Neste momento, o conteúdo de todas as planilhas presentes no arquivo Excel foi copiado para os DataTables consolidados no Dataset "output".

            //dataGridView.DataSource = output.Tables[0];
            //dataGridView.AutoGenerateColumns = true;
        }

        //::Salva pos do DataGrid para o BD::
        public void salvarInvent()
        {
            int cont = 0;                                                   // Contador de linhas
            int contEx = 0;                                                 // Contador de exceções
            string posicao, descProd, umb, referencia, metodo, chave, produto, uc, contador, qtdRegistrada, qtdContada, qtdDif, ordem, docInv1, tipoDep;
            string hrCriacao, hrAtivacao, hrContagem, hrPostagem;
            int datCriacao2, datAtivacao2, datContagem2, datPostagem2;             
            DateTime datContagem, datPostagem, datAtivacao, datCriacao;
            AccessBD AccessBD = new AccessBD();
            AccessBD.AbrirConexao();
            
            ToolStripProgressBar BarraProgresso = new ToolStripProgressBar();

            lblStripSalvar.Text = "Salvando Inventários:";
            frmPrincipal.statusStrip1.Items.Add(lblStripSalvar);
            frmPrincipal.statusStrip1.Items.Add(BarraProgresso);

            BarraProgresso.Maximum = dgvPos.RowCount;
            lblStripPorcent.Text = "0%";
            frmPrincipal.statusStrip1.Items.Add(lblStripPorcent);

            Thread backgroundThread = new Thread(
                new ThreadStart(() =>           
                {
                    for (cont = 0; cont < dgvPos.RowCount; cont++)
                    {
                        try
                        {
                            docInv1 = dgvPos.Rows[cont].Cells[0].Value.ToString();
                            ordem = dgvPos.Rows[cont].Cells[1].Value.ToString();
                            posicao = dgvPos.Rows[cont].Cells[2].Value.ToString();
                            produto = dgvPos.Rows[cont].Cells[3].Value.ToString();
                            descProd = dgvPos.Rows[cont].Cells[4].Value.ToString().Replace("\"", "").Replace("'", "");
                            qtdRegistrada = dgvPos.Rows[cont].Cells[5].Value.ToString().Replace(",", ".");
                            qtdContada = dgvPos.Rows[cont].Cells[6].Value.ToString().Replace(",", ".");
                            qtdDif = dgvPos.Rows[cont].Cells[7].Value.ToString().Replace(",", ".");
                            umb = dgvPos.Rows[cont].Cells[8].Value.ToString();
                            referencia = dgvPos.Rows[cont].Cells[9].Value.ToString();
                            metodo = dgvPos.Rows[cont].Cells[10].Value.ToString();
                            datCriacao = DateTime.Parse(dgvPos.Rows[cont].Cells[11].Value.ToString().Substring(0, 10));
                            hrCriacao = dgvPos.Rows[cont].Cells[12].Value.ToString().Substring(11, 5);
                            datAtivacao = DateTime.Parse(dgvPos.Rows[cont].Cells[13].Value.ToString().Substring(0, 10));
                            hrAtivacao = dgvPos.Rows[cont].Cells[14].Value.ToString().Substring(11, 5);
                            datContagem = DateTime.Parse(dgvPos.Rows[cont].Cells[15].Value.ToString().Substring(0, 10));
                            hrContagem = dgvPos.Rows[cont].Cells[16].Value.ToString().Substring(11, 5);
                            contador = dgvPos.Rows[cont].Cells[17].Value.ToString();
                            datPostagem = DateTime.Parse(dgvPos.Rows[cont].Cells[18].Value.ToString().Substring(0, 10));
                            hrPostagem = dgvPos.Rows[cont].Cells[19].Value.ToString().Substring(11, 5);
                            uc = dgvPos.Rows[cont].Cells[20].Value.ToString();
                            tipoDep = dgvPos.Rows[cont].Cells[21].Value.ToString();
                            chave = docInv1 + posicao + produto + qtdDif;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dado inconsistente, por favor, importe a planilha novamente!" + "\n \n" + "Detalhe: " + ex.Message, "Erro na importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //Convertendo datas para o formato do banco de dados
                        datPostagem2 = Convert.ToInt32(datPostagem.Year.ToString() + string.Format("{0,2:00}",datPostagem.Month) + string.Format("{0,2:00}",datPostagem.Day));
                        datAtivacao2 = Convert.ToInt32(datAtivacao.Year.ToString() + string.Format("{0,2:00}",datAtivacao.Month) + string.Format("{0,2:00}", datAtivacao.Day));
                        datContagem2 = Convert.ToInt32(string.Format("{0,2:00}", datContagem.Year) + string.Format("{0,2:00}", datContagem.Month) + string.Format("{0,2:00}", datContagem.Day));
                        datCriacao2 = Convert.ToInt32(string.Format("{0,2:00}", datCriacao.Year) + string.Format("{0,2:00}", datCriacao.Month) + string.Format("{0,2:00}", datCriacao.Day));

                        SQL = "INSERT INTO inventario (chave, doc_inv1, ordem, pos_dep, produto, desc_prod, qtd_regist, qtd_cont, qtd_difer, umb, " +
                            "ref, metodo, dat_criacao, hr_criacao, dat_ativ, hr_ativ, dat_cont, hr_cont, contador, dat_post, hr_post, uc, tipo_dep)" +
                            "values ('"
                            + chave + "', " + docInv1 + "," + ordem + ",'"
                            + posicao + "','" + produto + "','" + descProd + "', " + qtdRegistrada + "," + qtdContada + ","
                            + qtdDif + ",'" + umb + "','" + referencia + "', '" + metodo + "'," + datCriacao2 + ",#" + hrCriacao + "#,"
                            + datAtivacao2 + ",#" + hrAtivacao + "#," + datContagem2 + ", #" + hrContagem + "#," + contador + "," + datPostagem2 + ",#"
                            + hrPostagem + "#,'" + uc + "', "+ tipoDep +" )";
                        try
                        {
                            AccessBD.insert_Delete_Update(SQL);
                        }
                        catch (OleDbException)
                        {
                            contEx += 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro desconhecido, contate o administrador do sistema! n/n/ " + ex.Message, "Importação de Inventários", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        BarraProgresso.Value = cont;
                        lblStripPorcent.Text = Math.Round(((decimal)cont / (decimal)dgvPos.RowCount) * 100, 1).ToString() + "%";

                        if (produto == "") { produto = "0"; }
                            
                        if (cont == dgvPos.RowCount - 1)
                        {// Se a thread já finalizou, destrói a Progressbar
                            BarraProgresso.Dispose();
                            lblStripSalvar.Dispose();
                            lblStripPorcent.Dispose();
                            if (contEx == 0)
                            {
                                MessageBox.Show("Inventários salvo com sucesso!!!", "Importação de Inventários", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possível salvar " + contEx + " linhas!", "Importação de Inventários", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            txtUltimoInventario.Text = AccessBD.consultaScalar("SELECT DAT_post & ' ÀS ' & MAX(hr_post) AS hr_post FROM INVENTARIO WHERE (((INVENTARIO.[DAT_POST])=(SELECT Max(dat_POST) FROM INVENTARIO))) group by dat_post");
                        }//if
                    }//for
                     atualizaFirebase();
                }
                ));//thread
            backgroundThread.Start();
        }
        //::Pega o caminho do Arquivo::
        public string Arquivo()
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Title = "Selecionar planilha de Inventários";
            ofd1.InitialDirectory = @"C:\";
            //filtra para exibir somente arquivos de imagens
            ofd1.Filter = "Excel (*.xlsx;*.xlsm;*.xlsb)|*.xlsx;*.xlsm;*.xlsb|" + "All files (*.*)|*.*";

            DialogResult resultadoDialog = this.ofd1.ShowDialog();

            if (resultadoDialog == DialogResult.OK)
            {
                return ofd1.FileName;
            }
            else
            {
                return "cancelado";
            }
        }

        private void bgwImportaExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            importa_Excel(arquivo, dgvPos);  //Importar do Excel para o DataGrid
        }

        private void bgwImportaExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AccessBD AccessBD = new AccessBD();
            AccessBD.FecharConexao();
            BarraProgresso.Dispose();
            lblStripImportar.Dispose();

            dgvPos.DataSource = output.Tables[0];
            dgvPos.AutoGenerateColumns = true;
        }

        private void frmImportarInventario_Load(object sender, EventArgs e)
        {
            AccessBD AccessBD = new AccessBD();

            txtUltimoInventario.Text = AccessBD.consultaScalar("SELECT RIGHT(DAT_post, 2) &'/'& MID(DAT_post, 5, 2) &'/'& LEFT(DAT_post, 4)   & ' ÀS ' & MAX(hr_post) AS hr_post FROM INVENTARIO WHERE (((INVENTARIO.[DAT_POST])=(SELECT Max(dat_POST) FROM INVENTARIO))) group by dat_post");

            
        }

        private void atualizaFirebase()
        {
            IFirebaseClient firebase = new FirebaseClient(config);
            IDataReader retornoBD;
            AccessBD conex = new AccessBD();
            conex.AbrirConexao();
            string dataDe, dataAte;
            decimal rotativoPercent = 0;
            string mes = DateTime.Now.Month.ToString();
            string ano = DateTime.Now.Year.ToString();


            //:::::::::::::::::::::::::::: Setando FireBase:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //EAN x Posicao
            dataDe = Convert.ToString(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + "01");
            dataAte = Convert.ToString(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"));
            SQL = "SELECT EXPR1, EXPR2 FROM (SELECT Mid(DAT_CONT,5,2) AS Expr1, Round(Avg(ACUR)*100,2) AS Expr2 " +
                        "FROM(SELECT DAT_CONT, DOC_INV1, POS_DEP, IIf(COUNT(PRODUTO) > 2, 1, IIf(COUNT(PRODUTO) = 1, 1, 0)) AS ACUR FROM(SELECT INVENTARIO.DAT_CONT, INVENTARIO.DOC_INV1, INVENTARIO.POS_DEP, INVENTARIO.PRODUTO FROM INVENTARIO RIGHT JOIN POSICAO ON INVENTARIO.POS_DEP = POSICAO.POSICAO WHERE POSICAO.TIPO_DEP <> 1003 GROUP BY INVENTARIO.DOC_INV1, INVENTARIO.POS_DEP, INVENTARIO.PRODUTO, INVENTARIO.DAT_CONT)  AS[%$##@_Alias] GROUP BY DOC_INV1, POS_DEP, DAT_CONT) AS [%$##@_Alias] " +
                        "GROUP BY Mid(DAT_CONT, 5, 2)) WHERE EXPR1 <> 0; ";
            string ultimaAtualizacao = conex.consultaScalar("SELECT RIGHT(DAT_post, 2) &'/'& MID(DAT_post, 5, 2) &'/'& LEFT(DAT_post, 4)   & ' ÀS ' & MAX(hr_post) AS hr_post FROM INVENTARIO WHERE (((INVENTARIO.[DAT_POST])=(SELECT Max(dat_POST) FROM INVENTARIO))) group by dat_post");
            retornoBD = conex.consultaReader(SQL);
            while ( retornoBD.Read())
            {
                firebase.Set("EanPosicao/" + retornoBD.GetString(0) + ano + "/Acuracidade", retornoBD.GetDouble(1));
                firebase.Set("EanPosicao/" + retornoBD.GetString(0) + ano + "/UltimaAtualizacao", ultimaAtualizacao);                
            }

            // Evolução Rotativo
            switch (DateTime.Now.Month)
            {
                case 1:
                case 2:
                case 3:
                    dataDe = DateTime.Now.Year + "0101";
                    dataAte = Convert.ToString(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"));
                    break;
                case 4:
                case 5:
                case 6:
                    dataDe = DateTime.Now.Year + "0401";
                    dataAte = Convert.ToString(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"));
                    break;
                case 7:
                case 8:
                case 9:
                    dataDe = DateTime.Now.Year + "0701";
                    dataAte = Convert.ToString(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"));
                    break;
                case 10:
                case 11:
                case 12:
                    dataDe = DateTime.Now.Year + "1001";
                    dataAte = Convert.ToString(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00"));
                    break;
            }
                SQL = "SELECT (SELECT COUNT(POS) FROM (SELECT POS_DEP AS POS FROM INVENTARIO WHERE DAT_CONT BETWEEN " + dataDe + " AND " + dataAte + " GROUP BY POS_DEP)) / COUNT(CODPOS) FROM POSICAO";
                rotativoPercent = Convert.ToDecimal(conex.consultaScalar(SQL));
                firebase.Set("Rotativo/" + mes + ano + "/Concluido", Convert.ToDouble((rotativoPercent * 100).ToString("0.00")));
                firebase.Set("Rotativo/" + mes + ano + "/ultimaAtualizacao", ultimaAtualizacao);



        }


    }        
}
