using System;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Windows.Forms;

namespace SInP.Gestao_Estoque
{
    public partial class frmImportarInventarioGeral : Form
    {
        string SQL;
        public string arquivo;
        frmPrincipal frmPrincipal;
        ToolStripLabel lblStripImportar;
        ToolStripProgressBar BarraProgresso = new ToolStripProgressBar();
        ToolStripLabel lblStripSalvar = new ToolStripLabel();
        ToolStripLabel lblStripPorcent = new ToolStripLabel();
        DataSet output;

        public frmImportarInventarioGeral(frmPrincipal frm1)
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
                importa_Excel(arquivo, dgvPos);  //Importar do Excel para o DataGrid

                lblStripImportar.Text = "Importando Planilha:";
                frmPrincipal.statusStrip1.Items.Add(lblStripImportar);

                BarraProgresso.Style = ProgressBarStyle.Marquee;
                BarraProgresso.MarqueeAnimationSpeed = 4;
                frmPrincipal.statusStrip1.Items.Add(BarraProgresso);
            }
        }

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

            dataGridView.DataSource = output.Tables[0];
            dataGridView.AutoGenerateColumns = true;
        }

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

                    //::Salva pos do DataGrid para o BD::
        public void salvarInvent()
        {
            int cont = 0;                                                   // Contador de linhas
            int contEx = 0;                                                 // Contador de exceções
            string posicao, produto, descricao, umb, referencia, metodo_inv, uc, tipo_dep, status_inv;
            string data_criacao2, hora_criacao2, data_ativacao2, hora_ativacao2, data_contagem2, tempo_contagem2, data_lancamento2, hora_registro2;
            double qtd_registrada, qtd_cont_inv, qtd_dif;
            DateTime data_criacao, hora_criacao, data_ativacao, hora_ativacao, data_contagem, tempo_contagem, data_lancamento, hora_registro;
            int doc_inv, ordem, contador;
            LiteBD LiteBD = new LiteBD();

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
                    LiteBD.AbrirConexao();
                    LiteBD.InsertDeleteUpdate("DELETE FROM Inventarios");
                    for (cont = 0; cont < dgvPos.RowCount; cont++)
                    {
                        try
                        {
                            doc_inv = Convert.ToInt32(string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[0].Value.ToString()) ? 0 : dgvPos.Rows[cont].Cells[0].Value);
                            ordem = Convert.ToInt32(string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[1].Value.ToString()) ? 0 : dgvPos.Rows[cont].Cells[1].Value);
                            posicao = dgvPos.Rows[cont].Cells[2].Value.ToString();
                            produto = dgvPos.Rows[cont].Cells[3].Value.ToString();
                            descricao = dgvPos.Rows[cont].Cells[4].Value.ToString().Replace("\"", "").Replace("'", "");
                            qtd_registrada = Convert.ToDouble(dgvPos.Rows[cont].Cells[5].Value.ToString());
                            qtd_cont_inv = Convert.ToDouble(dgvPos.Rows[cont].Cells[6].Value.ToString());
                            qtd_dif = Convert.ToDouble(dgvPos.Rows[cont].Cells[7].Value.ToString());
                            umb = dgvPos.Rows[cont].Cells[8].Value.ToString();
                            referencia = dgvPos.Rows[cont].Cells[9].Value.ToString();
                            metodo_inv = dgvPos.Rows[cont].Cells[10].Value.ToString();
                            data_criacao = DateTime.Parse(
                                string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[11].Value.ToString()) ? "01/01/9999": dgvPos.Rows[cont].Cells[11].Value.ToString().Substring(0, 10));
                            hora_criacao = DateTime.Parse(
                                string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[12].Value.ToString()) ? "99:99" : dgvPos.Rows[cont].Cells[12].Value.ToString());
                            data_ativacao = DateTime.Parse(
                                string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[13].Value.ToString()) ? "01/01/9999" : dgvPos.Rows[cont].Cells[13].Value.ToString().Substring(0, 10));
                            hora_ativacao = DateTime.Parse(
                                string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[14].Value.ToString()) ? "99:99" : dgvPos.Rows[cont].Cells[14].Value.ToString());
                            data_contagem = DateTime.Parse(
                                string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[15].Value.ToString()) ? "01/01/9999" : dgvPos.Rows[cont].Cells[15].Value.ToString().Substring(0, 10));
                            tempo_contagem = DateTime.Parse(
                                string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[16].Value.ToString()) ? "99:99" : dgvPos.Rows[cont].Cells[16].Value.ToString());
                            contador = Convert.ToInt32(
                                string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[17].Value.ToString()) ? 0 : dgvPos.Rows[cont].Cells[17].Value); // se a célula for vazia então 0
                            data_lancamento = DateTime.Parse(
                                string.IsNullOrEmpty(dgvPos.Rows[cont].Cells[18].Value.ToString()) ? "01/01/9999" : dgvPos.Rows[cont].Cells[18].Value.ToString());
                            hora_registro = DateTime.Parse(dgvPos.Rows[cont].Cells[19].Value.ToString());
                            uc = dgvPos.Rows[cont].Cells[20].Value.ToString();
                            tipo_dep = dgvPos.Rows[cont].Cells[21].Value.ToString();
                            status_inv = dgvPos.Rows[cont].Cells[22].Value.ToString();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Dado inconsistente, por favor, importe a planilha novamente!" + "\n \n" + "Detalhe: " + ex.Message, "Erro na importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //Convertendo datas para o formato do banco de dados
                        data_criacao2 = (string.Format("{0,2:00}", data_criacao.Year) +"-"+ string.Format("{0,2:00}", data_criacao.Month) +"-"+ string.Format("{0,2:00}", data_criacao.Day));
                        data_ativacao2 = data_ativacao.Year.ToString() + "-" + string.Format("{0,2:00}", data_ativacao.Month) + "-" + string.Format("{0,2:00}", data_ativacao.Day);
                        data_contagem2 = string.Format("{0,2:00}", data_contagem.Year) +"-"+ string.Format("{0,2:00}", data_contagem.Month) +"-"+ string.Format("{0,2:00}", data_contagem.Day);
                        data_lancamento2 = data_lancamento.Year.ToString() +"-"+ string.Format("{0,2:00}", data_lancamento.Month) +"-"+ string.Format("{0,2:00}", data_lancamento.Day);
                        hora_criacao2 = hora_criacao.Hour.ToString("00") + ":" + hora_ativacao.Minute.ToString("00");
                        hora_ativacao2 = hora_ativacao.Hour.ToString("00") + ":" + hora_ativacao.Minute.ToString("00");
                        tempo_contagem2 = tempo_contagem.Hour.ToString("00") + ":" + tempo_contagem.Minute.ToString("00");
                        hora_registro2 = hora_registro.Hour.ToString("00") + ":" + hora_registro.Minute.ToString("00");

                        SQL = "INSERT INTO Inventarios (doc_inv, ordem, posicao, produto, descricao_produto, qtd_registrada, qtd_cont_inv, qtd_dif, umb, " +
                            "referencia, metodo_inv, data_criacao, hora_criacao, data_ativacao, hora_ativacao, data_contagem, tempo_contagem, contador, data_lancamento, hora_registro, uc, tipo_dep, status_inv)" +
                            "values ("
                            + doc_inv + ", " + ordem + ",'" + posicao + "','"
                            + produto + "','" + descricao + "',REPLACE('"+ qtd_registrada +"',',', '.'), REPLACE('" + qtd_cont_inv +"',',','.'), REPLACE('"+ qtd_dif + "', ',', '.'),'"
                            + umb + "','" + referencia + "', '" + metodo_inv + "','" + data_criacao2 + "','" + hora_criacao2 + "','"
                            + data_ativacao2 + "','" + hora_ativacao2 + "','" + data_contagem2 + "', '" + tempo_contagem2 + "'," + contador + ",'" + data_lancamento2 + "','"
                            + hora_registro2 + "','" + uc + "', '" + tipo_dep + "', '"+ status_inv +"' )";
                        try
                        {
                            LiteBD.InsertDeleteUpdate(SQL);
                        }
                        catch (OleDbException)
                        {
                            contEx += 1;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro desconhecido, contate o administrador do sistema! \n"+ ex.Message, "Importação de Inventários", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            //txtUltimoInventario.Text = Conexao.consultaScalar("SELECT DAT_post & ' ÀS ' & MAX(hr_post) AS hr_post FROM INVENTARIO WHERE (((INVENTARIO.[DAT_POST])=(SELECT Max(dat_POST) FROM INVENTARIO))) group by dat_post");
                        }//if
                    }//for
                    LiteBD.FecharConexao();
                }                
                ));//thread
            backgroundThread.Start();
        }

    }
}

