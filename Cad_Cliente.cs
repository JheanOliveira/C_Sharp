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

namespace CadastroClienteAccess
{
    public partial class FrmCadCliente : Form
    {
        public FrmCadCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string con = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jhean\Documents\MEGAsync\Development\Visual Studio\WF_BD_ACCESS\Database.mdb";
                OleDbConnection conn = new OleDbConnection(con);

                conn.Open();//Abrindo a conexão com BD.

                String SQL;
                SQL = "insert into clientes(Nome, Email, Telefone, Endereco, DataNasc) Values";
                SQL += "('"+txbNome.Text+"','"+txbEmail.Text+"','"+txbTelefone.Text+"','"+txbEndereco.Text+"','"+mskNasc.Text+"')";

                OleDbCommand cmd = new OleDbCommand(SQL,conn); //Comando SQL
                cmd.ExecuteNonQuery();//Significa Execulta sem consulta. só grava os dados.
                //Utilizado para: Inserir, Alterar e excluir dados.

                MessageBox.Show("Dados cadastrado com sucesso!!! :-)");

                //Limpando os Text Box
                txbNome.Clear();
                txbEmail.Clear();
                txbEndereco.Clear();
                txbTelefone.Clear();
                mskNasc.Clear();

                conn.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}