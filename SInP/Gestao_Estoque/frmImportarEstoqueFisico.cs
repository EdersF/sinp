using System.Data;
using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SInP.Gestao_Estoque
{
    public partial class frmImportarEstoqueFisico : Form
    {
        AccessBD conex = new AccessBD();
        frmPrincipal frmPrincipal;

        public frmImportarEstoqueFisico(frmPrincipal frm1)
        {
            InitializeComponent();
            frmPrincipal = frm1;
        }

        private void frmImportarEstoqueFisico_Load(object sender, EventArgs e)
        {
            int MesAno = Convert.ToInt32(DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString());                     //Concatena o mês e o ano atual
            
            byte retornoBD1;                                                                                                //Armazena o retorno da primeira consulta
            IDataReader retornoBD2;                                                                                         //Armazena o retorno da segunda consulta

            AccessBD conex = new AccessBD();                                                                                  //Instancia a classe Conexao
            conex.AbrirConexao();                                                                                           //Abre a conexão com o banco de dadoos

            retornoBD1 = Convert.ToByte(conex.consultaScalar("SELECT COUNT(*) FROM VALOR_ESTOQUE WHERE MES = " + MesAno));  //Caso o Mês e o ano atual já exista no banco de dados retorna 1 caso não exista retorna 0

            if (retornoBD1 == 0)
            {//Se o mês+ano não exista no banco de dados, inseri no banco do mês 1 ao 12
                for (int i = 1; i < 13; i++)
                {
                    conex.insert_Delete_Update("INSERT INTO VALOR_ESTOQUE (MES) VALUES ("+ i+DateTime.Now.Year +")");
                }
            }

            retornoBD2 = conex.consultaReader("SELECT DISTINCT right(MES, 4) FROM VALOR_ESTOQUE");                          //Retorna a lista com os anos
            while (retornoBD2.Read())
            {//Preenche o combobox
                cmbAno.Items.Add(retornoBD2.GetString(0));
            }

            cmbAno.SelectedIndex = cmbAno.Items.Count - 1;                                                                  //Seleciona o ano mais recente no combobox
            conex.FecharConexao();                                                                                          //Fecha a conexão
        }

        private string ConverteNumEmMes(int Num)
        {
            string mes;
            switch (Num)
            {
                case 1:
                    mes = "JANEIRO";
                    break;
                case 2:
                    mes = "FEVEREIRO";
                    break;
                case 3:
                    mes = "MARÇO";
                    break;
                case 4:
                    mes = "ABRIL";
                    break;
                case 5:
                    mes = "MAIO";
                    break;
                case 6:
                    mes = "JUNHO";
                    break;
                case 7:
                    mes = "JULHO";
                    break;
                case 8:
                    mes = "AGOSTO";
                    break;
                case 9:
                    mes = "SETEMBRO";
                    break;
                case 10:
                    mes = "OUTUBRO";
                    break;
                case 11:
                    mes = "NOVEMBRO";
                    break;
                case 12:
                    mes = "DEZEMBRO";
                    break;
                default:
                    mes = "ERRO";
                    break;
            }
            return mes;
        }

        private void cmbAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Conexao conex = new Conexao();
            //string mes;
            //IDataReader retornoBD;
            atualizarGrid();
            
            //try
            //{
            //    dgvImportarEstoque.Rows.Clear();

            //    retornoBD = conex.consultaReader("SELECT Mes, ValorEstoque, qtdItens FROM VALOR_ESTOQUE WHERE RIGHT(MES, 4) = " + cmbAno.Text);

            //    while (retornoBD.Read())
            //    {
            //        mes = ConverteNumEmMes(Convert.ToInt32(retornoBD.GetInt32(0).ToString("000000").Substring(0,2)));
            //        dgvImportarEstoque.Rows.Add(mes, retornoBD.GetInt32(1), retornoBD.GetInt32(2));
            //    }
            //    conex.FecharConexao();
            //    }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}            
        }

        private void dgvImportarEstoque_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvImportarEstoque.CurrentCell.ColumnIndex == 4)
            {
                ImportarExcel();
            }
        }

        private void ImportarExcel()
        {
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            // ======================IMPORTANDO PLANILHA PARA DATASET
            AccessBD conex = new AccessBD();
            conex.AbrirConexao();
            conex.insert_Delete_Update("DELETE * FROM ESTOQUE");
            conex.FecharConexao();

            string arquivo = ofd.FileName;
            OleDbConnection conn = new OleDbConnection(("Provider=Microsoft.ACE.OLEDB.12.0; " + ("data source="+ arquivo +"; " + "Extended Properties=Excel 12.0;")));
            // Select the data from Sheet1 of the workbook.

            OleDbDataAdapter ada = new OleDbDataAdapter("select * from [Sheet1$]", conn);
            DataSet ds = new DataSet();

            ada.Fill(ds);
            conn.Close();
            //====================== SALVANDO DATASET NO ACCESS
            string SQL, posicao, lm, descricao, umb, tipo_estoque, uma, uc;
            int tipo_pos, qtd_umb, qtd_uma;
            ToolStripProgressBar BarraProgresso = new ToolStripProgressBar();
            ToolStripLabel lblStripSalvar = new ToolStripLabel();

            BarraProgresso.Maximum = ds.Tables[0].Rows.Count;
            BarraProgresso.Value = 0;

            lblStripSalvar.Text = "Salvando Estoque:";
            frmPrincipal.statusStrip1.Items.Add(lblStripSalvar);
            frmPrincipal.statusStrip1.Items.Add(BarraProgresso);

            conex.AbrirConexao();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                tipo_pos = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                posicao = ds.Tables[0].Rows[i][1].ToString();
                lm = ds.Tables[0].Rows[i][2].ToString();
                descricao = ds.Tables[0].Rows[i][3].ToString().Replace("\"", "").Replace("'", "");
                qtd_umb = Convert.ToInt32(ds.Tables[0].Rows[i][4]);
                umb = ds.Tables[0].Rows[i][5].ToString();
                tipo_estoque = ds.Tables[0].Rows[i][6].ToString();
                qtd_uma = Convert.ToInt32(ds.Tables[0].Rows[i][7]);
                uma = ds.Tables[0].Rows[i][8].ToString();
                uc = ds.Tables[0].Rows[i][9].ToString();

                SQL = "INSERT INTO ESTOQUE (TIPO_POS, POSICAO, PRODUTO, DESCRICAO, QTD_UMB, UMB, TIPO_ESTOQUE, QTD_UMA, UC) " + 
                    "VALUES("+ tipo_pos +", '"+ posicao +"', '"+ lm +"', '"+ descricao +"', "+ qtd_umb +", '"+ umb +"', '"+ tipo_estoque +"', "+ qtd_uma +", '"+ uc +"')";

                conex.insert_Delete_Update(SQL);
                BarraProgresso.Value = i;    
            }
            BarraProgresso.Value = 0;
            BarraProgresso.Dispose();
            lblStripSalvar.Dispose();
            //==================== PREENCHENDO tabela VALOR ESTOQUE e DATA GRID 
            string[] mes = new string[12];
            int mes2;
            int qtdItens = Convert.ToInt32(conex.consultaScalar("SELECT COUNT(PRODUTO) FROM (SELECT DISTINCT PRODUTO FROM ESTOQUE)"));
            int valorEstoque = Convert.ToInt32(conex.consultaScalar("SELECT SUM(VALOR2) FROM (SELECT A.PRODUTO, A.QTD_UMB * B.VALOR as Valor2 FROM ESTOQUE AS A LEFT JOIN VALPROD AS B ON A.PRODUTO = B.PRODUTO)"));
            int qtdItensSemPreco = Convert.ToInt32(conex.consultaScalar("SELECT COUNT(PRODUTO) FROM (SELECT A.PRODUTO, A.QTD_UMB, B.VALOR FROM ESTOQUE AS A LEFT JOIN VALPROD AS B ON A.PRODUTO = B.PRODUTO) WHERE VALOR  IS NULL"));
            string data = DateTime.Now.ToString();
            //Preenchendo array
            mes[0] = "JANEIRO";
            mes[1] = "FEVEREIRO";
            mes[2] = "MARÇO";
            mes[3] = "ABRIL";
            mes[4] = "MAIO";
            mes[5] = "JUNHO";
            mes[6] = "JULHO";
            mes[7] = "AGOSTO";
            mes[8] = "SETEMBRO";
            mes[9] = "OUTUBRO";
            mes[10] = "NOVEMBRO";
            mes[11] = "DEZEMBRO";

            for (int i = 0; i < 12; i++)
            {
                if(mes[i] == dgvImportarEstoque.CurrentRow.Cells[0].Value.ToString())
                {
                    mes2 = i + 1;
                    conex.insert_Delete_Update("UPDATE VALOR_ESTOQUE SET valorestoque = " + valorEstoque + ", qtditens = " + qtdItens + ", atualizado = '"+ data +"' WHERE MES = " + mes2.ToString()+DateTime.Now.Year);
                }
            }
            if(qtdItensSemPreco > 0)
            {
                MessageBox.Show(qtdItensSemPreco.ToString() + " itens estão sem preço! favor importar planilha com o preço dos itens atualizados!", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conex.FecharConexao();
            atualizarGrid();
        }

        private void atualizarGrid()
        {
            dgvImportarEstoque.Rows.Clear();
            string mes;
            IDataReader retornoBD = conex.consultaReader("SELECT * FROM VALOR_ESTOQUE WHERE RIGHT(MES, 4) = " + cmbAno.Text);

            while (retornoBD.Read())
            {
                if(retornoBD[1].ToString().Length == 5) //Verifica se o total de caracteres é = 5
                {//Se sim pega o primeiro digito da esquerda
                    mes = ConverteNumEmMes(Convert.ToInt16(retornoBD[1].ToString().Substring(0, 1)));                    
                }
                else
                {//se não, pega os dois primeiros digitos da esquerda
                    mes = ConverteNumEmMes(Convert.ToInt16(retornoBD[1].ToString().Substring(0, 2)));
                }
                dgvImportarEstoque.Rows.Add(mes, retornoBD[2], retornoBD[3], retornoBD[4]);
            }
            conex.FecharConexao();
        }
    }
}
