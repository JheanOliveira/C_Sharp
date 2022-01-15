using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JewelleryShopMyCodeSpace
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();//Fechar.
        }

        private void EntrarLogin_Click(object sender, EventArgs e)
        {
            if(UsuarioLogin.Text == "" || SenhaLogin.Text == "")//Verificar se o usuário digitou nos campos (Usuário/Senha)
            {
                MessageBox.Show("Entre com Usuário e Senha!!!");
            }
            else if(UsuarioLogin.Text == "Admin" && SenhaLogin.Text == "admin")
            {
                Item Obj = new Item();
                Obj.Show();
                this.Hide();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Cobranca Obj = new Cobranca();
            Obj.Show();
            this.Hide();
        }
    }
}