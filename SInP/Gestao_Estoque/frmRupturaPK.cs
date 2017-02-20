using System;
using System.Data;
using System.Windows.Forms;

namespace SInP.Gestão_de_Estoque
{
    public partial class frmRupturaPK : Form
    {
        public string codMot1;
        LiteBD liteBd = new LiteBD();
        FB firebase = new FB();

        public frmRupturaPK()
        {
            InitializeComponent();
        }

        private void frmRupturaPK_Load(object sender, EventArgs e)
        {
            cmbTipoRuptura.SelectedIndex = 0;

            dgvLancamento.Rows.Add();
            CarregaDGVMotivo();
            CarregaComboBox();
            CarregaDGVRuptura();
        }

        private void dgvRuptura_KeyUp(object sender, KeyEventArgs e)
        {
            OnDataGridViewPaste(sender, e);
        }

        public void OnDataGridViewPaste(object grid, KeyEventArgs e)
        {
            if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                PasteTSV((DataGridView)grid);
                PreencheCampos(); 
            }
        }

        public static void PasteTSV(DataGridView grid)
        {
            char[] rowSplitter = { '\r', '\n' };
            char[] columnSplitter = { '\t' };

            // Get the text from clipboard
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

            // Split it into lines
            string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

            // Get the row and column of selected cell in grid
            int r = grid.SelectedCells[0].RowIndex;
            int c = grid.SelectedCells[0].ColumnIndex;

            // Add rows into grid to fit clipboard lines
            if (grid.Rows.Count < (r + rowsInClipboard.Length))
            {
                grid.Rows.Add(r + rowsInClipboard.Length - grid.Rows.Count);
            }

            // Loop through the lines, split them into cells and place the values in the corresponding cell.
            for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
            {
                // Split row into cell values
                string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);

                // Cycle through cell values
                for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                {
                    // Assign cell value, only if it within columns of the grid
                    if (grid.ColumnCount - 1 >= c + iCol)
                    {
                        DataGridViewCell cell = grid.Rows[r + iRow].Cells[c + iCol];

                        if (!cell.ReadOnly)
                        {
                            cell.Value = valuesInRow[iCol];
                        }                       
                    }
                }
            }
        }

        public void CarregaDGVRuptura()
        {
            IDataReader retornoBD;
            string SQL, data;
            //DateTime data;

            dgvRuptura.Rows.Clear();

            SQL = "SELECT Data, Produto, DescProd, Quantidade, UM, Tipo_Ped, Cod_Mot, Documento, TU, Pacote, Pedido, Loja, Obs, Cod_Ruptura " +
                "FROM Ruptura_PK " +
                "WHERE tipo_ruptura = '"+cmbTipoRuptura.Text+"' " +
                "ORDER BY Data DESC, cod_ruptura desc, tipo_ruptura";
            try
            {
                liteBd.AbrirConexao();
                retornoBD = liteBd.ConsultaReader(SQL);
                while (retornoBD.Read())
                {                    
                    data = retornoBD.GetInt32(0).ToString().Substring(6, 2) + "/" + retornoBD.GetInt32(0).ToString().Substring(4, 2) + "/" + retornoBD.GetInt32(0).ToString().Substring(0, 4);
                    dgvRuptura.Rows.Add(Convert.ToDateTime(data), retornoBD[1], retornoBD[2], retornoBD[3], retornoBD[4], retornoBD[5], retornoBD[6], retornoBD[7], retornoBD[8], retornoBD[9], retornoBD[10], retornoBD[11], retornoBD[12], retornoBD[13]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            liteBd.FecharConexao();
        }

        public void CarregaDGVMotivo()
        {
            string SQL;
            liteBd.AbrirConexao();
            IDataReader retornoBD;
            dgvMotivo.Rows.Clear();
            SQL = "SELECT * FROM Motivo_Ruptura WHERE tipo_ruptura = '"+ cmbTipoRuptura.Text +"' ORDER BY cod_mot";
            retornoBD = liteBd.ConsultaReader(SQL);
            while (retornoBD.Read())
            {
                dgvMotivo.Rows.Add(retornoBD.GetInt32(1).ToString(), retornoBD.GetString(3).ToString(), "x");       // Add no DataGrid (Cod., Descrição, "x" - para saber se o dado veio do BD)
            }
            liteBd.FecharConexao();
        }

        public void CarregaComboBox()
        {
            string SQL;
            IDataReader retornoBD;
            cmbCodMotivo.Items.Clear();
            cmbCodMotivo.Items.Add("");
            liteBd.AbrirConexao();
            SQL = "SELECT * FROM Motivo_Ruptura WHERE tipo_ruptura = '"+cmbTipoRuptura.Text+"' ORDER BY cod_mot";
            retornoBD = liteBd.ConsultaReader(SQL);
            while (retornoBD.Read())
            {
                cmbCodMotivo.Items.Add(retornoBD.GetInt32(1).ToString());
            }
            liteBd.FecharConexao();
        }

        private void PreencheCampos()
        {
            try
            {
                txtProduto.Text = dgvLancamento.Rows[0].Cells[colProduto.Index].Value.ToString();
                txtDesc.Text = dgvLancamento.Rows[0].Cells[colDesc.Index].Value.ToString();
                txtTipoPedido.Text = dgvLancamento.Rows[0].Cells[colDenominacao.Index].Value.ToString();            
            }
            catch (NullReferenceException)
            {
                
            }            
        }

        private void dgvMotivo_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show(dgvMotivo.CurrentRow.Index.ToString());
        }

        private void dgvMotivo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dgvMotivo.CurrentRow.Cells[2].Value != null)
            codMot1 = dgvMotivo.CurrentRow.Cells[0].Value.ToString();
        }

        private void dgvMotivo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string codMot2;
            string descMot;

            if (dgvMotivo.CurrentRow.Cells[0].Value != null && dgvMotivo.CurrentRow.Cells[1].Value != null)         //Verifica se o código e a Descrição estão vazios
            {
                if(dgvMotivo.CurrentRow.Cells[2].Value == null)                                                     //Verifica se a linha foi importada do BD (Vide linha 95)
                {//Se a linha não foi importada do BD
                    liteBd.AbrirConexao();
                    codMot2 = dgvMotivo.CurrentRow.Cells[0].Value.ToString();
                    descMot = dgvMotivo.CurrentRow.Cells[1].Value.ToString();
                    try
                    {
                        liteBd.InsertDeleteUpdate("INSERT INTO Motivo_Ruptura VALUES ('"+ codMot2+cmbTipoRuptura.Text+ "'," + codMot2 + ",'"+ cmbTipoRuptura.Text +"', '" + descMot + "')");
                        //System.Threading.Thread.Sleep(1000);
                        CarregaComboBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possível adicionar o motivo, talvez o código do motivo que você está tentando inserir já esteja cadastrado. \n\n" +
                            "Informação Técnica: " + ex.Message.ToString(), "Falha ao salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvMotivo.Rows.RemoveAt(dgvMotivo.CurrentRow.Index);
                        //System.Threading.Thread.Sleep(1000);
                        CarregaComboBox();
                    }
                    liteBd.FecharConexao();
                }else
                {
                    liteBd.AbrirConexao();
                    codMot2 = dgvMotivo.CurrentRow.Cells[0].Value.ToString();
                    descMot = dgvMotivo.CurrentRow.Cells[1].Value.ToString();
                    liteBd.InsertDeleteUpdate("UPDATE Motivo_Ruptura SET id_mot = '" +codMot2+cmbTipoRuptura.Text+ "' ,cod_mot = " + codMot2 + ", [DESC] = '" + descMot + "' WHERE cod_mot = "+ codMot1);
                    liteBd.FecharConexao();
                    //System.Threading.Thread.Sleep(1000);
                    CarregaComboBox();
                }
            }
        }
                       
        private void dgvMotivo_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string codMot1;
            liteBd.AbrirConexao();
            codMot1 = dgvMotivo.CurrentRow.Cells[0].Value.ToString();
            liteBd.InsertDeleteUpdate("DELETE FROM Motivo_Ruptura WHERE cod_mot= " + codMot1);
            liteBd.FecharConexao();
            //System.Threading.Thread.Sleep(1000);
            CarregaComboBox();
            
        }

        private void cmbCodMotivo_TextChanged(object sender, EventArgs e)
        {
            if (cmbCodMotivo.Text == "")
            {
                txtDescMotivo.Text = null;
                return;
            }

            liteBd.AbrirConexao();
            txtDescMotivo.Text = liteBd.ConsultaScalar("SELECT DESC FROM Motivo_Ruptura WHERE tipo_ruptura = '"+cmbTipoRuptura.Text+"' and COD_MOT = "+ cmbCodMotivo.Text );
            liteBd.FecharConexao();
        }

        private void btnLancar_Click(object sender, EventArgs e)
        {// TODO: incluir possibilidade de lançar mais de uma ruptura de uma vez
            string tipoRuptura, produto, descProd, UM, loja, SQL, obs, chave, qtde;
            int data, codMot, documento, pacote, tipoPed;
            long TU, pedido;

            if (cmbCodMotivo.Text == "")
            {
                MessageBox.Show("Campo Código Motivo não pode estar em branco!", "Campo vazio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                for (int i = 0; i < dgvMotivo.Rows.Count; i++)
                {

                    tipoRuptura = cmbTipoRuptura.Text;
                    data = Convert.ToInt32(dtpData.Text.Substring(6, 4) + dtpData.Text.Substring(3, 2) + dtpData.Text.Substring(0, 2));    //trasforma a data no padrão do BD ex. 20160815
                    produto = dgvLancamento.Rows[i].Cells["colProduto"].Value.ToString();
                    descProd = dgvLancamento.Rows[i].Cells["colDesc"].Value.ToString();
                    qtde = dgvLancamento.Rows[i].Cells["colQtd2"].Value.ToString().Replace(",",".");
                    UM = dgvLancamento.Rows[i].Cells["colUn"].Value.ToString();
                    tipoPed = Convert.ToInt32(dgvLancamento.Rows[i].Cells["colDenominacao"].Value.ToString().Substring(0, 3));
                    codMot = Convert.ToInt32(cmbCodMotivo.Text.ToString());
                    documento = Convert.ToInt32(dgvLancamento.Rows[i].Cells["colNumDoc"].Value);
                    TU = Convert.ToInt64(dgvLancamento.Rows[i].Cells["colTransportUT"].Value);
                    pacote = Convert.ToInt32(dgvLancamento.Rows[i].Cells["colPacote"].Value);
                    pedido = Convert.ToInt64(dgvLancamento.Rows[i].Cells["colPedido"].Value);
                    loja = dgvLancamento.Rows[i].Cells["colReceberMercadoria"].Value.ToString();
                    obs = txtObs.Text.ToString();
                    chave = pedido.ToString()+produto+documento;

                    liteBd.AbrirConexao();

                    SQL = "INSERT INTO ruptura_pk (chave, data, tipo_ruptura, produto, descprod, quantidade, um, tipo_Ped, Cod_Mot, Documento, TU, Pacote, Pedido, Loja, Obs) "+
                    "VALUES('"+ chave +"', "+ data +", '"+ tipoRuptura +"', '"+ produto +"', '"+ descProd + "', "+ qtde +", '"+ UM +"',"+ tipoPed +", "+ codMot +", "+
                    documento +", "+ TU +", "+ pacote +", "+ pedido +", '"+ loja +"', '"+ obs +"')";

                    liteBd.InsertDeleteUpdate(SQL);
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Os campos PRODUTO, DESCRIÇÃO, UM, DENOMINAÇÃO, RECEBEDOR MERCADORIA, QUANTIDADE, NUM. DOC, TRANSPORTADORA UT, PACOTE E PEDIDO não podem estar em branco ou com valores não correspondentes. Por favor verifique!" + 
                    "\n\n Informação Técnica: " + ex.Message ,
                    "Falha no lançamento!", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            //System.Threading.Thread.Sleep(1000);
            CarregaDGVRuptura();
            liteBd.FecharConexao();
            firebase.AtualizaRupturaPK();
        }

        private void dgvRuptura_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult resposta;

            resposta = MessageBox.Show("Tem certeza que deseja deletar esta ruptura???", "CUIDADO!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(resposta == DialogResult.Yes)
            {
                string codRuptura;
                liteBd.AbrirConexao();
                codRuptura = dgvRuptura.CurrentRow.Cells[13].Value.ToString();
                liteBd.InsertDeleteUpdate("DELETE FROM Ruptura_PK WHERE cod_Ruptura = " + codRuptura);
                liteBd.FecharConexao();
                //System.Threading.Thread.Sleep(1000);
                firebase.AtualizaRupturaPK();                
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cmbTipoRuptura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipoRuptura.SelectedIndex == 0)
            {
                panel2.BackColor = System.Drawing.Color.LightSteelBlue;
                lblTipoRuptura.Text = "Ruptura de Onda";
                dgvRuptura.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
                dgvMotivo.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
                dgvLancamento.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSteelBlue;

                dgvRuptura.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                dgvMotivo.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                dgvLancamento.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

                CarregaDGVRuptura();
                CarregaDGVMotivo();
                CarregaComboBox();
            }else
            {
                panel2.BackColor = System.Drawing.Color.FromArgb(241,196,15);
                dgvRuptura.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(241, 196, 15);
                dgvMotivo.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(241, 196, 15);
                dgvLancamento.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(241, 196, 15);

                dgvRuptura.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                dgvMotivo.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
                dgvLancamento.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;


                lblTipoRuptura.Text = "Ruptura de Picking";

                CarregaDGVRuptura();
                CarregaDGVMotivo();
                CarregaComboBox();
            }
        }
    }
}
