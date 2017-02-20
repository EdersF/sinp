using System.Data;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using System;
using System.Windows.Forms;
using FireSharp.Response;

namespace SInP
{
    public class FB
    {
        LiteBD liteBD = new LiteBD();
        string SQL;
        //Configurando Firebase
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "joH00JAXpQg8d43ji8elTLO9ucRUO0iiZSzmg9wS",
            BasePath = "https://project-5280949790712613125.firebaseio.com/"
        };

        public void AtualizaRupturaPK()
        {
            IFirebaseClient firebase = new FirebaseClient(config);
            IDataReader retornoBD;

            SQL = "SELECT B.data2, ROUND(CAST(ifnull(a.rupt, 0) AS FLOAT) / CAST(ifnull(b.fat, 0) AS FLOAT)*100, 2) " +
                "FROM " +
                "(SELECT substr(data, 1, 6) data2, SUM(linhas) fat " +
                    "FROM Faturamento " +
                    "GROUP BY substr(data, 1, 6)) B " +
                "LEFT JOIN " +
                "(SELECT substr(data, 1, 6) data2, COUNT(data) rupt " +
                    "FROM Ruptura_PK " +
                    "WHERE tipo_ruptura = 'RUPTURA DE PICKING'" +
                    "GROUP BY substr(data, 1, 6)) A " +
                "ON a.data2 = b.data2";
            liteBD.AbrirConexao();
            retornoBD = liteBD.ConsultaReader(SQL);
            try
            {
                while (retornoBD.Read())
                {
                    firebase.Set("ruptura/"+ retornoBD[0] +"/percent", retornoBD[1]);
                    firebase.Set("ruptura/"+retornoBD[0]+"/target", 0.1);
                }
                firebase.Set("ruptura/ultima_atualizacao", DateTime.Now.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("O aplicativo não foi atualizado, verifique sua conexão com a internet!", "Falha na atualização do aplicativo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            liteBD.FecharConexao();
        }

        public  async void Consulta(string caminho)
        {
            IFirebaseClient firebase = new FirebaseClient(config);
            
            FirebaseResponse response = await firebase.GetAsync(caminho);           //Assíncrono
            //FirebaseResponse response = firebase.Get("ruptura/201701/percent");   //Síncrono
            MessageBox.Show(response.Body);

        }

        public async void Listener()            // exemplo de um listener
        {
            IFirebaseClient firebase = new FirebaseClient(config);

            await firebase.OnAsync("ruptura",
                //added
                (sender, args, context) =>
                {
                    //MessageBox.Show(args.Data + " foi adicionado n/");
                },
                //changed
                (sender, args, context) =>
                {
                    MessageBox.Show(args.Path + " foi alterado de " + args.OldData + " para "+ args.Data);
                },
                // removed
                (sender, args, context) =>
                {
                    //MessageBox.Show(args.Path + " foi deletado");

                });
            
         }
    }
}
