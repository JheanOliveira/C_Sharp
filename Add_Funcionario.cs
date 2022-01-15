using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_SAMARA_FERREIRA
{
    public partial class addFuncionario : Form
    {
        public addFuncionario()
        {
            InitializeComponent();

            txb_PesquisaNome.Enabled = false; //Para desabilitar objeto. avaliar depois.
            txb_Nome.Enabled = false;
            msk_Tefefone.Enabled = false;
            txb_email.Enabled = false;
            txb_Endereco.Enabled = false;
            txb_Numero.Enabled = false;
            txb_Bairro.Enabled = false;
            txb_RG.Enabled = false;
            msk_CPF.Enabled = false;
            msk_Celular.Enabled = false;

        }

        //String Canexão.
        SqlConnection sqlcon = null;
        private string strCon = @"Data Source=JHEAN\SQLEXPRESS;Initial Catalog=BANCO;Integrated Security=True";
        private string strSql = string.Empty; //informa que está fazia.

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txb_Nome.Enabled = true;
            msk_Tefefone.Enabled = true;
            txb_email.Enabled = true;
            txb_Endereco.Enabled = true;
            txb_Numero.Enabled = true;
            txb_Bairro.Enabled = true;
            txb_RG.Enabled = true;
            msk_CPF.Enabled = true;
            msk_Celular.Enabled = true;

        }
        private void btn_Gravar_Click(object sender, EventArgs e)
        {
            strSql = "INSERT INTO tbl_sf_crud(nome, telefone, celular, email, endereco, numero, bairro, rg, cpf)";
            strSql += "VALUES(@nome, @telefone,@celular, @email, @endereco, @numero, @bairro, @rg, @cpf)";//Continuação do código acima.

            sqlcon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql,sqlcon);

            comando.Parameters.Add("@nome",SqlDbType.VarChar).Value = txb_Nome.Text;
            comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = msk_Tefefone.Text;
            comando.Parameters.Add("@celular", SqlDbType.VarChar).Value = msk_Celular.Text;
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = txb_email.Text;
            comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = txb_Endereco.Text;
            comando.Parameters.Add("@numero", SqlDbType.VarChar).Value = txb_Numero.Text;
            comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = txb_Bairro.Text;
            comando.Parameters.Add("@rg", SqlDbType.VarChar).Value = txb_RG.Text;
            comando.Parameters.Add("@cpf", SqlDbType.VarChar).Value = msk_CPF.Text;

            try
            {
                sqlcon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro efetuado com sucesso!!!");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                sqlcon.Close();
            }

            //Limpar campos após cadastrar.

            txb_PesquisaNome.Enabled = true;//Habilitando pesquisa.
            txb_Nome.Clear();
            txb_Bairro.Clear();
            txb_email.Clear();
            txb_Endereco.Clear();
            txb_Numero.Clear();
            txb_RG.Clear();
            msk_Celular.Clear();
            msk_CPF.Clear();
            msk_Tefefone.Clear();

        }

        private void btn_Pesquisar_Click(object sender, EventArgs e)
        {
            txb_PesquisaNome.Enabled = true;

            strSql = "SELECT * FROM tbl_sf_crud WHERE nome=@pesquisar";

            sqlcon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlcon);

            comando.Parameters.Add("@pesquisar", SqlDbType.VarChar).Value = txb_PesquisaNome.Text;

            try
            {
                if (txb_PesquisaNome.Text == string.Empty)
                {
                    MessageBox.Show("Digite um nome!!! ");
                }

                sqlcon.Open();

                SqlDataReader dr = comando.ExecuteReader();

                if (dr.HasRows == false)
                {
                    throw new Exception("Este nome não está cadastrado");
                }
                dr.Read();

                txb_Nome.Text = Convert.ToString(dr["nome"]);
                txb_Bairro.Text = Convert.ToString(dr["bairro"]);
                txb_email.Text = Convert.ToString(dr["email"]);
                txb_Endereco.Text = Convert.ToString(dr["endereco"]);
                txb_Numero.Text = Convert.ToString(dr["numero"]);
                txb_RG.Text = Convert.ToString(dr["rg"]);
                msk_Celular.Text = Convert.ToString(dr["celular"]);
                msk_CPF.Text = Convert.ToString(dr["cpf"]);
                msk_Tefefone.Text = Convert.ToString(dr["telefone"]);

                txb_PesquisaNome.Enabled = true;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            txb_PesquisaNome.Clear();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            strSql = "UPDATE tbl_sf_crud SET nome=@nome, telefone=@telefone, celular=@celular, email=@email, endereco=@endereco,";
            strSql += "numero=@numero, bairro=@bairro, rg=@rg, cpf=@cpf WHERE nome=@nome";

            sqlcon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlcon);

            comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = txb_Nome.Text;
            comando.Parameters.Add("@telefone", SqlDbType.VarChar).Value = msk_Tefefone.Text;
            comando.Parameters.Add("@celular", SqlDbType.VarChar).Value = msk_Celular.Text;
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = txb_email.Text;
            comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = txb_Endereco.Text;
            comando.Parameters.Add("@numero", SqlDbType.VarChar).Value = txb_Numero.Text;
            comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = txb_Bairro.Text;
            comando.Parameters.Add("@rg", SqlDbType.VarChar).Value = txb_RG.Text;
            comando.Parameters.Add("@cpf", SqlDbType.VarChar).Value = msk_CPF.Text;

            try
            {
                sqlcon.Open();

                comando.ExecuteNonQuery();

                MessageBox.Show("Itens alterado com sucesso!!!");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                sqlcon.Close();
            }

            txb_Nome.Clear();
            txb_Bairro.Clear();
            txb_email.Clear();
            txb_Endereco.Clear();
            txb_Numero.Clear();
            txb_RG.Clear();
            msk_Celular.Clear();
            msk_CPF.Clear();
            msk_Tefefone.Clear();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            strSql = "DELETE FROM tbl_sf_crud WHERE nome=@nome";

            sqlcon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlcon);

            comando.Parameters.Add("@nome",SqlDbType.VarChar).Value = txb_Nome.Text;

            try
            {
                sqlcon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Item excluido com sucesso!!!");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            txb_Nome.Clear();
            txb_Bairro.Clear();
            txb_email.Clear();
            txb_Endereco.Clear();
            txb_Numero.Clear();
            txb_RG.Clear();
            msk_Celular.Clear();
            msk_CPF.Clear();
            msk_Tefefone.Clear();
        }
    }
}