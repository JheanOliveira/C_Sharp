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

namespace JewelleryShopMyCodeSpace
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            ListaClienteDGV();
        }

        private void Fechar_Cliente_Click(object sender, EventArgs e)
        {
            Application.Exit();//Fechar.
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Item Obj = new Item();
            Obj.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jhean\Documents\JewelleryShopBD.mdf;Integrated Security=True;Connect Timeout=30");
        private void ListaClienteDGV()//Item criado Manualmente
        {
            Con.Open();
            string query = "SELECT * FROM tblCliente";//Buscando no banco.
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//Verificar função.
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//Verificar função.
            var ds = new DataSet();
            sda.Fill(ds);
            Lista_Cliente_DGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reiniciar()
        {
            Cliente_NomeCliente_mtb.Text = "";
            Cliente_TelefoneCliente_mtb.Text = "";
            key = 0;
        }
        private void Cliente_Gravar_btn_Click(object sender, EventArgs e)
        {
            //Verificar se há campos vazios.
            if (Cliente_NomeCliente_mtb.Text == "" || Cliente_TelefoneCliente_mtb.Text == "")
            {
                MessageBox.Show("Informação Ausente!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "INSERT INTO tblCliente VALUES('" + Cliente_NomeCliente_mtb.Text + "','" + Cliente_TelefoneCliente_mtb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente gravado com sucesso!!!");
                    Con.Close();
                    ListaClienteDGV();
                    Reiniciar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Cliente_Reiniciar_btn_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        int key = 0;
        private void Lista_Cliente_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente_NomeCliente_mtb.Text = Lista_Cliente_DGV.SelectedRows[0].Cells[1].Value.ToString();
            Cliente_TelefoneCliente_mtb.Text = Lista_Cliente_DGV.SelectedRows[0].Cells[2].Value.ToString();
            if (Cliente_NomeCliente_mtb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Lista_Cliente_DGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Cliente_Excluir_btn_Click(object sender, EventArgs e)
        {
            //Verificar se há campos vazios.
            if (key == 0)
            {
                MessageBox.Show("Informação Ausente!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "DELETE FROM tblCliente WHERE IdCliente = " + key + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente excluido com sucesso!!!");
                    Con.Close();
                    ListaClienteDGV();
                    Reiniciar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    throw;
                }
            }
        }

        private void Cliente_Alterar_btn_Click(object sender, EventArgs e)
        {
            //Verificar se há campos vazios.
            if (Cliente_NomeCliente_mtb.Text == "" || Cliente_TelefoneCliente_mtb.Text == "")
            {
                MessageBox.Show("Informação Ausente!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "UPDATE tblCliente SET NomeCliente='" + Cliente_NomeCliente_mtb.Text + "',TelefoneCliente='" + Cliente_TelefoneCliente_mtb.Text + "' WHERE IdCliente=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cliente alterado com sucesso!!!");
                    Con.Close();
                    ListaClienteDGV();
                    Reiniciar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    throw;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}