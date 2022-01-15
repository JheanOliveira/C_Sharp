using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CRUD_NS_ACCESS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string conexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+@"\Database.mdb"; //Comando Application.StartupPath : informa que o banco sempre vai está no mesmo lugar.
            //string conexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C: \Users\jhean\Documents\MEGAsync\Development\Visual Studio\C#\Projetos\Edition\CRUD_NEW_SYSTEM\CRUD_NS_ACCESS\CRUD_NS_ACCESS\bin\Debug\net6.0-windows\Database.mdb";
            string SQLcon = "INSERT INTO newSystem (nome, cargo, salario) VALUES";
            SQLcon += "('" + txbNome.Text + "','" + txbCargo.Text + "','" + mskSalario.Text + "')";

           OleDbConnection con = new OleDbConnection(conexao);
           OleDbCommand cmd = new OleDbCommand(SQLcon, con);

            

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cadastrado com sucesso!!!");

                txbNome.Clear();
                txbCargo.Clear();
                mskSalario.Clear();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);                
            }
            finally
            {
                con.Close();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string conexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\Database.mdb";
            string SQLcon = "SELECT * FROM newSystem WHERE nome='"+txbPesquisar.Text+"'";

            OleDbConnection con = new OleDbConnection(conexao);
            OleDbCommand cmd = new OleDbCommand(SQLcon, con);

            try
            {
                if(txbPesquisar.Text == "")
                {
                    throw new Exception("Digite um nome para pesquisar!!!");
                }

                con.Open();
                OleDbDataReader cs = cmd.ExecuteReader();//Para realizar consulta.

                //Verifica se o nome no txbPesquisa contém no BD.
                if (cs.HasRows == false)
                {
                    throw new Exception("Nome digitado não está cadastrado");
                }
                else
                {
                    cs.Read();//Ler todas linhas do BD.

                    //Retornar os dados nas txb/msk do forms conforme nome pesquisado.
                    txbID.Text = Convert.ToString(cs["ID"]);
                    txbNome.Text = Convert.ToString(cs["nome"]);
                    txbCargo.Text = Convert.ToString(cs["cargo"]);
                    mskSalario.Text = Convert.ToString(cs["salario"]);

                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)//Limpar campos.
        {
            txbNome.Clear();
            txbCargo.Clear();
            mskSalario.Clear();
            txbID.Clear();
            txbPesquisar.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string conexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\Database.mdb";

            //Menssagem de alerta (Realmente quer excluir).
            if (MessageBox.Show("Deseja realmente excluir este item? ", "Cuidado", 
                MessageBoxButtons.YesNo,MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2)== DialogResult.No)
            {
                MessageBox.Show("Operação cancelada!!!");
            }
            else
            {
                string SQLcon = "DELETE FROM newSystem WHERE NOME='" + txbPesquisar.Text + "'";

                OleDbConnection con = new OleDbConnection(conexao);
                OleDbCommand cmd = new OleDbCommand(SQLcon, con);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item exluido com sucesso");
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string conexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + @"\Database.mdb";

            string SQLcon = "UPDATE newSystem SET nome=@nome, cargo=@cargo, salario=@salario WHERE nome='"+txbPesquisar.Text+"'"; //### FUNCIONA ###
            //string SQLcon = "UPDATE newSystem SET nome=@nome, cargo=@cargo, salario=@salario WHERE id='" + txbID.Text + "'"; ## COM ERRO ##

            OleDbConnection con = new OleDbConnection(conexao);
            OleDbCommand cmd = new OleDbCommand(SQLcon, con);

            cmd.Parameters.Add("@nome", OleDbType.VarChar).Value = txbNome.Text;
            cmd.Parameters.Add("@cargo", OleDbType.VarChar).Value = txbCargo.Text;
            cmd.Parameters.Add("@salario", OleDbType.Currency).Value = mskSalario.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Alteração realizada com sucesso!");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}