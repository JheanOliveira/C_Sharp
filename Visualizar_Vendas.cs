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
    public partial class Visualizar_Vendas : Form
    {
        public Visualizar_Vendas()
        {
            InitializeComponent();
            Armazenar();
        }

        private void Voltar_btn_Click(object sender, EventArgs e)
        {
            Cobranca Obj = new Cobranca();
            Obj.Show();
            this.Hide();
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
            Vendas_DGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Vendas_DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}