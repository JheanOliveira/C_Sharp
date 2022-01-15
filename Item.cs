using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JewelleryShopMyCodeSpace
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
            ListaProdDGV_Item();
        }

        private void FecharItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//Fechar.
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jhean\Documents\JewelleryShopBD.mdf;Integrated Security=True;Connect Timeout=30");
        private void ListaProdDGV_Item()//Item criado Manualmente
        {
            Con.Open();
            string query = "SELECT * FROM tblItem";//Buscando no banco.
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//Verificar função.
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//Verificar função.
            var ds = new DataSet();
            sda.Fill(ds);
            Lista_Prod_DGV_Item.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Filtro_Item_Categoria()//Item criado Manualmente
        {
            Con.Open();
            string query = "SELECT * FROM tblItem WHERE ItCategoria='"+Item_Filtro_Categoria_cmb.SelectedItem.ToString()+"'";//Buscando no banco.
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//Verificar função.
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//Verificar função.
            var ds = new DataSet();
            sda.Fill(ds);
            Lista_Prod_DGV_Item.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Filtro_Item_Tipo()//Item criado Manualmente
        {
            Con.Open();
            string query = "SELECT * FROM tblItem WHERE ItTipo='" + Item_Filtro_Tipo_cmb.SelectedItem.ToString() + "'";//Buscando no banco.
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//Verificar função.
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//Verificar função.
            var ds = new DataSet();
            sda.Fill(ds);
            Lista_Prod_DGV_Item.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Gravar_btn_Item_Click(object sender, EventArgs e)
        {
            //Verificar se há campos vazios.
            if(Item_Nome_mTxtB.Text =="" || Item_Preco_mTxtB.Text =="" || Item_Qtd_mTxtB.Text=="" || Item_Categoria_cmb.SelectedIndex ==-1 || Item_Tipo_cmb.SelectedIndex == -1)
            {
                MessageBox.Show("Informação Ausente!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "INSERT INTO tblItem VALUES('"+Item_Nome_mTxtB.Text+"','"+Item_Categoria_cmb.SelectedItem.ToString()+"','"+Item_Tipo_cmb.SelectedItem.ToString()+"','"+Item_Preco_mTxtB.Text+"','"+Item_Qtd_mTxtB.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item gravado com sucesso!!!");
                    Con.Close();
                    ListaProdDGV_Item();
                    Reiniciar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        int key = 0;
        private void Lista_Prod_DGV_Item_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Item_Nome_mTxtB.Text = Lista_Prod_DGV_Item.SelectedRows[0].Cells[1].Value.ToString();
            Item_Categoria_cmb.SelectedItem = Lista_Prod_DGV_Item.SelectedRows[0].Cells[2].Value.ToString();
            Item_Tipo_cmb.SelectedItem = Lista_Prod_DGV_Item.SelectedRows[0].Cells[3].Value.ToString();
            Item_Preco_mTxtB.Text = Lista_Prod_DGV_Item.SelectedRows[0].Cells[4].Value.ToString();
            Item_Qtd_mTxtB.Text = Lista_Prod_DGV_Item.SelectedRows[0].Cells[5].Value.ToString();
            if(Item_Nome_mTxtB.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Lista_Prod_DGV_Item.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void Reiniciar()//Método para limpar campos.
        {
            Item_Nome_mTxtB.Text = "";
            Item_Categoria_cmb.SelectedIndex = -1;
            Item_Tipo_cmb.SelectedIndex = -1;
            Item_Preco_mTxtB.Text = "";
            Item_Qtd_mTxtB.Text = "";
            key = 0;
        }
        private void ReiniciarFiltro()//Método para limpar campos.
        {
            Item_Filtro_Categoria_cmb.SelectedIndex = -1;
            Item_Filtro_Tipo_cmb.SelectedIndex = -1;
            key = 0;
        }
        private void Reiniciar_btn_Item_Click(object sender, EventArgs e)
        {
            Reiniciar();//invocando o método.
        }

        private void Excluir_btn_Item_Click(object sender, EventArgs e)
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
                    string query = "DELETE FROM tblItem WHERE ItId = "+key+"";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item excluido com sucesso!!!");
                    Con.Close();
                    ListaProdDGV_Item();
                    Reiniciar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    throw;
                }
            }
        }

        private void Alterar_btn_Item_Click(object sender, EventArgs e)
        {
            //Verificar se há campos vazios.
            if (Item_Nome_mTxtB.Text == "" || Item_Preco_mTxtB.Text == "" || Item_Qtd_mTxtB.Text == "" || Item_Categoria_cmb.SelectedIndex == -1 || Item_Tipo_cmb.SelectedIndex == -1)
            {
                MessageBox.Show("Informação Ausente!!!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "UPDATE tblItem SET ItNome='" + Item_Nome_mTxtB.Text + "',ItCategoria='" + Item_Categoria_cmb.SelectedItem.ToString() + "',ItTipo='" + Item_Tipo_cmb.SelectedItem.ToString() + "',ItPreco='" + Item_Preco_mTxtB.Text + "',ItQtd='" + Item_Qtd_mTxtB.Text + "'WHERE ItId="+key+";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item alterado com sucesso!!!");
                    Con.Close();
                    ListaProdDGV_Item();
                    Reiniciar();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Item_Cliente_lbl_Click(object sender, EventArgs e)
        {
            Clientes Obj = new Clientes();
            Obj.Show();
            this.Hide();
        }

        private void Item_Filtro_Categoria_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filtro_Item_Categoria();
        }

        private void Item_Filtro_Tipo_cmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filtro_Item_Tipo();
        }

        private void Item_Atualizar_ptb_Click(object sender, EventArgs e)
        {
            ListaProdDGV_Item();
            ReiniciarFiltro();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}