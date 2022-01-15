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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        int pontoInicial = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pontoInicial += 1;
            MeuProgresso.Value = pontoInicial;
            PorcentagemBar.Text = pontoInicial + "%";//Atribuindo valor ao Label da barra.

            if(MeuProgresso.Value == 100)
            {
                MeuProgresso.Value = 0; //barra zera.
                timer1.Stop(); //Para contador.
                Login log = new Login();
                log.Show();
                this.Hide();//Hide : Esconder
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}