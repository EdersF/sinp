using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;

namespace SInP
{
    public partial class frmImportarPosicoes : Form
    {   //Declaração de variáveis
        public string arquivo;
        frmPrincipal frmPrincipal;
        ToolStripLabel lblStripImportar;
        ToolStripProgressBar BarraProgresso;
        DataSet output;

        public frmImportarPosicoes(frmPrincipal frm1)
        {
            InitializeComponent();
            frmPrincipal = frm1;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {

            lblStripImportar = new ToolStripLabel();
            BarraProgresso = new ToolStripProgressBar();
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
                salvarPos();
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
        public void salvarPos()
        {
            int contador = 0;
            int datCont2 = 0;
            string posicao, vazia, bloqueioSaida, bloqueioEntrada, bloqueioInvent, tipoPos,
                unidadePeso, pesoMax, pesoOcupado, qtdUcs, tipoDep;
            DateTime datCont;


            AccessBD Conexao = new AccessBD();
            Conexao.AbrirConexao();
            Conexao.insert_Delete_Update("DELETE * FROM POSICAO");

            ToolStripLabel lblStripSalvar = new ToolStripLabel();
            lblStripSalvar.Text = "Salvando Posições:";
            frmPrincipal.statusStrip1.Items.Add(lblStripSalvar);
            ToolStripProgressBar BarraProgresso = new ToolStripProgressBar();
            BarraProgresso.Maximum = dgvPos.RowCount;
            frmPrincipal.statusStrip1.Items.Add(BarraProgresso);

            ToolStripLabel lblStripPorcent = new ToolStripLabel();
            lblStripPorcent.Text = "0";
            frmPrincipal.statusStrip1.Items.Add(lblStripPorcent);


            Thread backgroundThread = new Thread(
                new ThreadStart(() =>
                {
                    try
                    {
                        for (contador = 0; contador < dgvPos.RowCount; contador++)
                        {
                            posicao = dgvPos.Rows[contador].Cells[0].Value.ToString();
                            vazia = dgvPos.Rows[contador].Cells[1].Value.ToString();
                            bloqueioSaida = dgvPos.Rows[contador].Cells[2].Value.ToString();
                            bloqueioEntrada = dgvPos.Rows[contador].Cells[3].Value.ToString();
                            bloqueioInvent = dgvPos.Rows[contador].Cells[4].Value.ToString();
                            tipoPos = dgvPos.Rows[contador].Cells[5].Value.ToString();
                            qtdUcs = dgvPos.Rows[contador].Cells[6].Value.ToString();
                            pesoMax = dgvPos.Rows[contador].Cells[7].Value.ToString().Replace(",", ".");
                            unidadePeso = dgvPos.Rows[contador].Cells[8].Value.ToString();
                            pesoOcupado = dgvPos.Rows[contador].Cells[9].Value.ToString().Replace(",", ".");
                            //datCont2 = Convert.ToInt32(dgvPos.Rows[contador].Cells[10].Value);
                            tipoDep = dgvPos.Rows[contador].Cells[11].Value.ToString();

                            if (dgvPos.Rows[contador].Cells[10].Value.ToString() == "")
                            {// Se a data da contagem estiver vazia
                                datCont2 = 0;
                            }
                            else
                            {//Se não, converte a data para o formato do banco de dados
                                datCont = DateTime.Parse(dgvPos.Rows[contador].Cells[10].Value.ToString());
                                datCont2 = Convert.ToInt32(datCont.Year.ToString() + string.Format("{0,2:00}", datCont.Month) + string.Format("{0,2:00}", datCont.Day));
                            }

                            Conexao.insert_Delete_Update("INSERT INTO POSICAO (Posicao, vazia, bloqueio_saida, bloqueio_entrada, bloqueio_invent, tipo_posicao, qtd_uc, peso_max, uni_peso, peso_ocupado, dat_cont, tipo_dep) values ('"
                                + posicao + "', '" + vazia + "','" + bloqueioSaida + "','" + bloqueioEntrada + "','"
                                + bloqueioInvent + "','" + tipoPos + "'," + qtdUcs + ", " + pesoMax + ",'" + unidadePeso + "'," + pesoOcupado + ", " + datCont2 + ", " + tipoDep +")");
                            
                            BarraProgresso.Value = contador;
                            lblStripPorcent.Text = Math.Round(((decimal)contador / (decimal)dgvPos.RowCount) * 100, 1).ToString() + "%";

                            if (contador == dgvPos.RowCount - 1)
                            {// Se a thread já finalizou, destrói a Progressbar
                                BarraProgresso.Dispose();
                                lblStripSalvar.Dispose();
                                lblStripPorcent.Dispose();
                            }
                        }//for
                    }// try
                    catch (Exception ex)
                    {
                        MessageBox.Show("Parece que o arquivo não está no formato esperado. Verifique!!! /n" + ex, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BarraProgresso.Dispose();
                        lblStripSalvar.Dispose();
                        lblStripPorcent.Dispose();
                    }

                }
                ));
            backgroundThread.Start();
        }

        //::Pega o caminho do Arquivo::
        public string Arquivo()
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Title = "Selecionar planilha de posições";
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
            BarraProgresso.Dispose();
            lblStripImportar.Dispose();

            dgvPos.DataSource = output.Tables[0];
            dgvPos.AutoGenerateColumns = true;
        }

        private void frmImportarPosicoes_Load(object sender, EventArgs e)
        {

        }
    }
}
