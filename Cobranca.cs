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
    public partial class Cobranca : Form
    {
        public Cobranca()
        {
            InitializeComponent();
            Armazenar();
            Visualiazar_Cliente();
        }

        private void FecharCobranca_Click(object sender, EventArgs e)
        {
            Application.Exit();//Fechar.
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jhean\Documents\JewelleryShopBD.mdf;Integrated Security=True;Connect Timeout=30");
        private void Armazenar()//Item criado Manualmente
        {
            Con.Open();
            string query = "SELECT * FROM tblItem";//Buscando no banco.
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//Verificar função.
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//Verificar função.
            var ds = new DataSet();
            sda.Fill(ds);
            Lista_Prod_DGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Visualiazar_Cliente()//Item criado Manualmente
        {
            Con.Open();
            string query = "SELECT * FROM tblCliente";//Buscando no banco.
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);//Verificar função.
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);//Verificar função.
            var ds = new DataSet();
            sda.Fill(ds);
            ClienteDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        int key = 0, stock = 0;
        int ClienteKey = 0;
        private void AlteraEstoque()
        {
            try
            {
                int NewEstoque = stock - Convert.ToInt32(Quantidade_mtb.Text);
                Con.Open();
                string query = "UPDATE tblItem SET ItQtd=" + NewEstoque + "WHERE ItId=" + key + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Item inserido na conta!!!");
                Con.Close();
                Armazenar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int n = 0,GrdTotal =0;
        private void Cobranca_AddCobranca_btn_Click(object sender, EventArgs e)
        {
            if(Quantidade_mtb.Text == "" || Convert.ToInt32(Quantidade_mtb.Text) > stock)
            {
                MessageBox.Show("Sem Estoque");
            }
            else
            {
                int total = Convert.ToInt32(Quantidade_mtb.Text) * Convert.ToInt32(Preco_mtb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(Conta_DGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = Nome_Produto_mtb.Text;
                newRow.Cells[2].Value = Preco_mtb.Text;
                newRow.Cells[3].Value = Quantidade_mtb.Text;
                newRow.Cells[4].Value = total;
                Conta_DGV.Rows.Add(newRow);
                GrdTotal = GrdTotal + total;
                Total_lbl.Text = "R$ "+GrdTotal;
                n++;
                AlteraEstoque();
            }
        }

        private void Imprimir_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "INSERT INTO tblCobranca VALUES(" +key+ ",'" +Nome_Cliente_mtb.Text+ "',"+GrdTotal+")";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Venda registrada com sucesso!!!");
                Con.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 500, 600);//A4 pixel
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        //ARQUIVO DE IMPRESSÃO
        int prodid, prodQty, prodPreco, tottal, pos = 100;

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void Exibir_Vendas_btn_Click(object sender, EventArgs e)
        {
            Visualizar_Vendas Obj = new Visualizar_Vendas();
            Obj.Show();
            this.Hide();
        }

        string prodNome;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Jewellery Shop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(125));//80
            e.Graphics.DrawString("ID        PRODUTO        PREÇO        QUANTIDADE        TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(70, 40));
            foreach(DataGridViewRow row in Conta_DGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodNome = "" + row.Cells["Column2"].Value;
                prodPreco = Convert.ToInt32(row.Cells["Column3"].Value);
                prodQty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(30, pos));
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodNome, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodPreco, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(200, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Custo Total: R$" + GrdTotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("*********** Jewellery Shop ***********", new Font("Century Gothic", 10,FontStyle.Bold),Brushes.Crimson, new Point(10, pos + 85));
            Conta_DGV.Rows.Clear();
            Conta_DGV.Refresh();
            pos = 100;
            GrdTotal = 0;

            /*
             * e.Graphics.DrawString("Jewellery Shop", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID PRODUTO PREÇO QUANTIDADE TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach(DataGridViewRow row in Conta_DGV.Rows)
            {
                prodid = Convert.ToInt32(row.Cells["Column1"].Value);
                prodNome = "" + row.Cells["Column2"].Value;
                prodPreco = Convert.ToInt32(row.Cells["Column3"].Value);
                prodQty = Convert.ToInt32(row.Cells["Column4"].Value);
                tottal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + prodid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + prodNome, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + prodPreco, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + tottal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(135, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Custo Total: R$" + GrdTotal, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("*********** Jewellery Shop ***********", new Font("Century Gothic", 10,FontStyle.Bold),Brushes.Crimson, new Point(10, pos + 85));
            Conta_DGV.Rows.Clear();
            Conta_DGV.Refresh();
            pos = 100;
            GrdTotal = 0;
            */
        }

        private void ClienteDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Nome_Cliente_mtb.Text = ClienteDGV.SelectedRows[0].Cells[1].Value.ToString();
            if (Nome_Cliente_mtb.Text == "")
            {
                ClienteKey = 0;
            }
            else
            {
                key = Convert.ToInt32(ClienteDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Lista_Prod_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Nome_Produto_mtb.Text = Lista_Prod_DGV.SelectedRows[0].Cells[1].Value.ToString();
            Preco_mtb.Text = Lista_Prod_DGV.SelectedRows[0].Cells[4].Value.ToString();
            
            if (Nome_Produto_mtb.Text == "")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(Lista_Prod_DGV.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(Lista_Prod_DGV.SelectedRows[0].Cells[5].Value.ToString());
            }
        }
    }
}