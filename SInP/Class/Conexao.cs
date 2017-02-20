using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace SInP
{
    public class AccessBD
    {
        OleDbConnection cnn;
        OleDbCommand cmd;

        //cnn = OleDbConnection(Properties.Settings.Default.strCon);

        string strConex = Properties.Settings.Default.strCon;
        
        //Abrir Conexão
        public void AbrirConexao()
        {
            try
            {
                cnn = new OleDbConnection(strConex);
                cnn.Open();
            }
            catch
            {
                MessageBox.Show("Erro ao se conectar com o banco de dados!", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fechar Conexão
        public void FecharConexao()
        {
            try
            {
                cnn = new OleDbConnection(strConex);
                cnn.Close();
            }
            catch
            {
                MessageBox.Show("Erro ao fechar conexão com o banco de dados!", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public OleDbDataReader consultaReader(string sql)
        { 
            cnn = new OleDbConnection(strConex);
                
            cnn.Open();
            cmd = new OleDbCommand(sql, cnn);
            return cmd.ExecuteReader();
        }

        public string consultaScalar(string sql)
        {
            cnn = new OleDbConnection(strConex);
           
            cnn.Open();
            cmd = new OleDbCommand(sql, cnn);
            return Convert.ToString(cmd.ExecuteScalar());
        }

        public void insert_Delete_Update(string sql)
        {
            cmd = new OleDbCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }        
    }

    public class LiteBD
    {
        //private SQLiteConnection liteConn = new SQLiteConnection(@"data source='\\192.168.17.8\gestao_de_estoque$\SInP - Sistema Indicador de Performance\Application Files\sinp.db'", true);
        //private SQLiteConnection liteConn = new SQLiteConnection(@"data source=|DataDirectory|..\sinp.db", true);
        private SQLiteConnection liteConn = new SQLiteConnection(@"data source='D:\Projetos\Visual Studio\ID Logistics\SInP\SInP\bin\Debug\sinp.db'", true);


        SQLiteCommand liteCmd;

        public void AbrirConexao()
        {
            if (liteConn.State != ConnectionState.Open)
            {
                liteConn.Open();
            }
        }

        public void FecharConexao()
        {
            liteConn.Close();
        }

        public SQLiteDataReader ConsultaReader(string SQL)
        {
            liteCmd = new SQLiteCommand(SQL, liteConn);
            return liteCmd.ExecuteReader();
        }

        public string ConsultaScalar(string SQL)
        {
            liteCmd = new SQLiteCommand(SQL, liteConn);
            return liteCmd.ExecuteScalar().ToString();
        }

        public int InsertDeleteUpdate(string SQL)
        {
            liteCmd = new SQLiteCommand(SQL, liteConn);
            return liteCmd.ExecuteNonQuery();
        }

        public DataTable TabelaDados(string SQL)
        {
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(SQL, liteConn);
            da.Fill(dt);
            return dt;
        }
    }

}
