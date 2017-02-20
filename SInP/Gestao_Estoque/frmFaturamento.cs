using System;
using System.Globalization;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SInP.Gestão_de_Estoque
{
    public partial class frmFaturamento : Form
    {
        LiteBD liteBd = new LiteBD();
        Func func = new Func();
        FB firebase = new FB();
        
        SQLiteDataReader retornoBD;

        public frmFaturamento()
        {
            InitializeComponent();
        }

        private void frmDespesas_Load(object sender, EventArgs e)
        {
            CarregaDGV();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            //Remove previous formatting, or the decimal check will fail including leading zeros
            string value = txtValor.Text.Replace(",", "")
                .Replace("R$", "").Replace(".", "").TrimStart('0');
            decimal ul;
            //Check we are indeed handling a number
            if (decimal.TryParse(value, out ul))
            {
                ul /= 100;
                //Unsub the event so we don't enter a loop
                txtValor.TextChanged -= txtValor_TextChanged;
                //Format the text as currency
                txtValor.Text = string.Format(CultureInfo.CreateSpecificCulture("pt-BR"), "{0:C2}", ul);
                txtValor.TextChanged += txtValor_TextChanged;
                txtValor.Select(txtValor.Text.Length, 0);
            }
        }

        private void btnLancar_Click(object sender, EventArgs e)
        {
            int data = func.ConvertDataParaBD(dtpData.Text);
            try
            {
                liteBd.AbrirConexao();
                liteBd.InsertDeleteUpdate("INSERT INTO Faturamento (data, linhas, valor) " +
                    "VALUES ("+ data +", "+ txtLinhas.Text +","+ txtValor.Text.Replace(".","").Replace(",", ".").Replace("R$ ", "") + ")");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Esta data já foi lançada ou os caracteres digitados são inválidos, verifique! \n\n " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            liteBd.FecharConexao();
            CarregaDGV();
            firebase.AtualizaRupturaPK();
        }

        private void CarregaDGV()
        {
            string SQL, data;
            dgvFaturamento.Rows.Clear();
            SQL = "SELECT * FROM Faturamento ORDER BY data DESC, Id DESC ";

            liteBd.AbrirConexao();
            retornoBD = liteBd.ConsultaReader(SQL);
            while (retornoBD.Read())
            {
                data = func.ConvertDataParaUser(retornoBD.GetInt32(1)); // Função converte data do BD para formato a ser exibido para o usuário - vide classe Func
                dgvFaturamento.Rows.Add(retornoBD[0], data, retornoBD[2], retornoBD[3]);
            }
            liteBd.FecharConexao();
        }

        private void dgvDespesas_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string SQL;

            SQL = "DELETE FROM Faturamento WHERE id = "+ dgvFaturamento.CurrentRow.Cells[0].Value;

            liteBd.AbrirConexao();
            liteBd.InsertDeleteUpdate(SQL);
            liteBd.FecharConexao();
            firebase.AtualizaRupturaPK();
        }

        private void dgvFaturamento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string data, linhas, valor, id;
            liteBd.AbrirConexao();
            id = dgvFaturamento.CurrentRow.Cells[0].Value.ToString();
            data = func.ConvertDataParaBD(dgvFaturamento.CurrentRow.Cells[1].Value.ToString()).ToString();
            linhas = dgvFaturamento.CurrentRow.Cells[2].Value.ToString();
            valor = dgvFaturamento.CurrentRow.Cells[3].Value.ToString().Replace("R$", "").Replace(".", "").Replace(",", ".");
            try
            {
                liteBd.InsertDeleteUpdate("UPDATE Faturamento SET data = " + data + ", linhas = " + linhas + ", valor = "+ valor +" WHERE id = " + id);
            }
            catch (Exception)
            {
                MessageBox.Show("Algo deu errado, contate o administrador do sistema!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            liteBd.FecharConexao();

            CarregaDGV();
            firebase.AtualizaRupturaPK();

        }
    }
}
