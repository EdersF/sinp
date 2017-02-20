using System.Data.SQLite;
using System.Data;

namespace SInP
{
    public class LiteBD
    {
        private SQLiteConnection liteConn = new SQLiteConnection("Data Source=Banco.db");
        SQLiteCommand liteCmd;

        public void FecharConexao()
        {
            liteConn.Close();
        }

        public SQLiteDataReader ConsultaReader(string SQL)
        {
            liteConn.Open();
            liteCmd = new SQLiteCommand(SQL, liteConn);
            return liteCmd.ExecuteReader();
        }

        public string ConsultaScalar(string SQL)
        {
            liteConn.Open();
            liteCmd = new SQLiteCommand(SQL, liteConn);
            return liteCmd.ExecuteScalar().ToString();
        }

        public int InsertDeleteUpdate(string SQL)
        {
            liteConn.Open();
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
