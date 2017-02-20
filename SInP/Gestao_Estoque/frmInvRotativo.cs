using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp;
using System.Threading;

using System.Data.OleDb;

namespace SInP
{
    public partial class frmInvRotativo : Form
    {
        string SQL;       

        public frmInvRotativo()
        {
            InitializeComponent();
        }

        protected internal void frmInvRotativo_Load(object sender, EventArgs e)
        {
            AccessBD conex = new AccessBD();
            string SQL, posicao, rua = "0", nivel = "0";
            int qtdCont;
            IDataReader retornoBD;

            dtpDe.Text = "01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            dtpAte.Text = DateTime.Now.ToString();
            cmbPesquisa.SelectedIndex = 0;

            conex.AbrirConexao();
            lblUltimoInvent.Text = conex.consultaScalar("SELECT RIGHT(DAT_post, 2) &'/'& MID(DAT_post, 5, 2) &'/'& LEFT(DAT_post, 4)   & ' ÀS ' & MAX(hr_post) AS hr_post FROM INVENTARIO WHERE (((INVENTARIO.[DAT_POST])=(SELECT Max(dat_POST) FROM INVENTARIO))) group by dat_post");
            
            try
            {
                //Preenche o datagridview
                SQL = "SELECT INVENTARIO.POS_DEP, COUNT(INVENTARIO.POS_DEP), POSICAO.DAT_CONT " +
                  "FROM(" +
                    "SELECT DOC_INV1, POS_DEP " +
                    "FROM INVENTARIO " +
                    "GROUP BY POS_DEP, DOC_INV1 " +
                  ") , POSICAO " +
                  "WHERE INVENTARIO.POS_DEP = POSICAO.POSICAO " +
                  "GROUP BY  INVENTARIO.POS_DEP, POSICAO.DAT_CONT " +
                  "order by INVENTARIO.POS_DEP ";
                retornoBD = conex.consultaReader(SQL);

                cmbNivel.Items.Add("");
                cmbRua.Items.Add("");

                while (retornoBD.Read())
                {
                    posicao = retornoBD.GetString(0);
                    qtdCont = retornoBD.GetInt32(1);
                    dgvPos.Rows.Add(posicao, qtdCont);

                    //carrega Combo box RUA
                    if (rua != posicao.Substring(0, 5))
                    {
                        rua = posicao.Substring(0, 5);
                        cmbRua.Items.Add(posicao.Substring(0, 5));
                    }
                    if (posicao.Length >= 13)
                        nivel = posicao.Substring(11, 2);
                    //Carrega combo box Nivel  
                    if (cmbNivel.FindStringExact(nivel) < 0)
                    {
                        cmbNivel.Items.Add(posicao.Substring(11, 2));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conex.FecharConexao();
        }

        protected internal void btnAtualizar_Click(object sender, EventArgs e)
        {
            string dataDe, dataAte;
            AccessBD conex = new AccessBD();
            IDataReader retornoBD;

            dataDe = dtpDe.Text.Substring(6, 4) + dtpDe.Text.Substring(3, 2) + dtpDe.Text.Substring(0, 2);
            dataAte = dtpAte.Text.Substring(6, 4) + dtpAte.Text.Substring(3, 2) + dtpAte.Text.Substring(0, 2);

            dgvPos.Rows.Clear();
                switch (cmbPesquisa.SelectedIndex)
                {
                    case 0: //TODAS AS POSIÇÕES
                        if(cmbNivel.Text == "" && cmbRua.Text == "")
                        {
                            SQL = "SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) " +
                            "FROM POSICAO LEFT JOIN (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP " +
                                "GROUP BY POSICAO.POSICAO, INV.POS_DEP";
                        }
                        else if(cmbNivel.Text != "" && cmbRua.Text != "")
                        {
                            SQL = "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) " +
                                "FROM POSICAO left join (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP WHERE RIGHT(POSICAO.POSICAO, 2) = '"+ cmbNivel.Text + "' AND LEFT(POSICAO.POSICAO, 5) =  '" + cmbRua.Text +
                                "' GROUP BY POSICAO.POSICAO, INV.POS_DEP)";
                        }
                        else if (cmbNivel.Text == "" && cmbRua.Text != "")
                        {
                            SQL = "SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) " +
                                 "FROM POSICAO LEFT JOIN (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                 "ON POSICAO.POSICAO = INV.POS_DEP WHERE LEFT(POSICAO.POSICAO, 5) =  '" + cmbRua.Text +
                                 "' GROUP BY POSICAO.POSICAO, INV.POS_DEP";
                        }
                        else if (cmbNivel.Text != "" && cmbRua.Text == "")
                        {
                            SQL = "SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) " +
                                "FROM POSICAO left join (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP WHERE RIGHT(POSICAO.POSICAO, 2) = '" + cmbNivel.Text + 
                                "' GROUP BY POSICAO.POSICAO, INV.POS_DEP";
                        }
                        break;
                    case 1: // Somente posições não contadas
                        if (cmbNivel.Text == "" && cmbRua.Text == "")
                        {
                            SQL = "SELECT POSICAO, CONTINV FROM " + 
                                "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) AS CONTINV " +
                                "FROM POSICAO LEFT JOIN (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP " +
                                "GROUP BY POSICAO.POSICAO, INV.POS_DEP) " +
                                "WHERE CONTINV = 0";
                        }
                        else if (cmbNivel.Text != "" && cmbRua.Text != "")
                        {
                            SQL = "SELECT POSICAO, CONTINV FROM" +
                                "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) AS CONTINV " +
                                "FROM POSICAO left join (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP " +
                                "WHERE RIGHT(POSICAO.POSICAO, 2) = '" + cmbNivel.Text + "' AND LEFT(POSICAO.POSICAO, 5) =  '" + cmbRua.Text +
                                "' GROUP BY POSICAO.POSICAO, INV.POS_DEP) " +
                                "WHERE CONTINV = 0";
                        }
                        else if (cmbNivel.Text == "" && cmbRua.Text != "")
                        {
                            SQL = "SELECT POSICAO, CONTINV FROM " +
                                "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) AS CONTINV " +
                                 "FROM POSICAO LEFT JOIN (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                 "ON POSICAO.POSICAO = INV.POS_DEP " + 
                                 "WHERE LEFT(POSICAO.POSICAO, 5) =  '" + cmbRua.Text +
                                 "' GROUP BY POSICAO.POSICAO, INV.POS_DEP) " +
                                 "WHERE CONTINV = 0";
                        }
                        else if (cmbNivel.Text != "" && cmbRua.Text == "")
                        {
                            SQL = "SELECT POSICAO, CONTINV FROM " +
                                "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) AS CONTINV " +
                                "FROM POSICAO left join (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP " + 
                                "WHERE AND RIGHT(POSICAO.POSICAO, 2) = '" + cmbNivel.Text +
                                "' GROUP BY POSICAO.POSICAO, INV.POS_DEP) " +
                                "WHERE CONTINV = 0";
                        }
                        break;
                    case 2: // Somente posições 
                        if (cmbNivel.Text == "" && cmbRua.Text == "")
                        {
                            SQL = "SELECT POSICAO, CONTINV FROM " +
                                "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) AS CONTINV " +
                                "FROM POSICAO LEFT JOIN (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP " +
                                "GROUP BY POSICAO.POSICAO, INV.POS_DEP) " +
                                "WHERE CONTINV <> 0";
                        }
                        else if (cmbNivel.Text != "" && cmbRua.Text != "")
                        {
                            SQL = "SELECT POSICAO, CONTINV FROM" +
                                "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) AS CONTINV " +
                                "FROM POSICAO left join (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP " +
                                "WHERE RIGHT(POSICAO.POSICAO, 2) = '" + cmbNivel.Text + "' AND LEFT(POSICAO.POSICAO, 5) =  '" + cmbRua.Text +
                                "' GROUP BY POSICAO.POSICAO, INV.POS_DEP) " +
                                "WHERE CONTINV <> 0";
                        }
                        else if (cmbNivel.Text == "" && cmbRua.Text != "")
                        {
                            SQL = "SELECT POSICAO, CONTINV FROM " +
                                "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) AS CONTINV " +
                                 "FROM POSICAO LEFT JOIN (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                 "ON POSICAO.POSICAO = INV.POS_DEP " +
                                 "WHERE LEFT(POSICAO.POSICAO, 5) =  '" + cmbRua.Text +
                                 "' GROUP BY POSICAO.POSICAO, INV.POS_DEP) " +
                                 "WHERE CONTINV <> 0";
                        }
                        else if (cmbNivel.Text != "" && cmbRua.Text == "")
                        {
                            SQL = "SELECT POSICAO, CONTINV FROM " +
                                "(SELECT POSICAO.POSICAO, COUNT(INV.POS_DEP) AS CONTINV " +
                                "FROM POSICAO left join (SELECT INVENTARIO.POS_DEP, DOC_INV1 FROM INVENTARIO WHERE DAT_POST BETWEEN " + dataDe + " and " + dataAte + " GROUP BY INVENTARIO.POS_DEP, DOC_INV1) AS INV " +
                                "ON POSICAO.POSICAO = INV.POS_DEP " +
                                "WHERE AND RIGHT(POSICAO.POSICAO, 2) = '" + cmbNivel.Text +
                                "' GROUP BY POSICAO.POSICAO, INV.POS_DEP) " +
                                "WHERE CONTINV <> 0";
                        }
                        break;
                }
                try
                {
                        conex.AbrirConexao();
                        retornoBD = conex.consultaReader(SQL);

                        while (retornoBD.Read())
                        {
                            dgvPos.Rows.Add(retornoBD.GetString(0), retornoBD.GetInt32(1));
                        }
                }
                catch
                {
                    MessageBox.Show("Erro de conexão com o banco de dados!");
                }
        }

       
    }
}