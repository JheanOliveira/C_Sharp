//Anotações

/* OBSERVAÇÕES - ATENÇÃO
- Quando inserir img de fundo em um forms, atentar ao tamanho, devido ao maximinizar, pode haver distorções.

*/

/* DLL
https://docs2.bunifuframework.com/docs/getting-started/install


*/


/*
CURSO BASICO CSHARP COM VISUAL STUDIO AULA 02 CONTROLES
https://www.youtube.com/watch?v=2neT45JD228


*/

/*BIBLIOTÉCA

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

*/

/*Acesso BD (ACCESS) NEW SYSTEM ##COM ERRO

		private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string conexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+@"\Database.mdb"; //Comando Application.StartupPath : informa que o banco sempre vai está no mesmo lugar.
            //string conexao = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C: \Users\jhean\Documents\MEGAsync\Development\Visual Studio\C#\Projetos\Edition\CRUD_NEW_SYSTEM\CRUD_NS_ACCESS\CRUD_NS_ACCESS\bin\Debug\net6.0-windows\Database.mdb";
            string SQLcon = "INSERT INTO newSystem (nome, cargo, salario) VALUES (@nome, @cargo, @salario)";

           OleDbConnection con = new OleDbConnection(conexao);
           OleDbCommand cmd = new OleDbCommand(SQLcon, con);

            cmd.Parameters.Add("@nome", OleDbType.VarChar).Value = txbNome.Text;
            cmd.Parameters.Add("@cargo", OleDbType.VarChar).Value = txbCargo.Text;
            cmd.Parameters.Add("@salario",OleDbType.Currency).Value = mskSalario.Text; //Currency, pq no access está declarado como moeda.

            try
            {
                con.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Cadastrado com sucesso!!!");
            }
            catch (Exception E)
            {
                MessageBox.Show("Erro: ",E.Message);                
            }
            finally
            {
                con.Close();
            }
        }


*/

/*Acesso BD (ACCESS) Autor Desconhecido.

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

*/

/* CRUD New System

Aula 02 : https://www.youtube.com/watch?v=SpR_Z8MaerE

- Ao selecionar vários objetos ao mesmo tempo, é possível alterar a propriedade de todos juntos ao mesmo tempo.
- Objeto [ MaskedTextBox ] : permite inserir uma mascara na caixa de texto exemplo [ (##) # #### - #### ]
- è possível colocar imagem dentro do objetos.
- Ao utilizar o ACCESS é importante usar a bibliotéca : using System.Data.OleDb;
- Colar o BD do access dentro da pasta bin, faz com que o mesmo seja compilado na hora de criar o setup de instalação.

*/

/*Acesso BD SQLSERVER (Samara Ferreira) CRUD : https://www.youtube.com/watch?v=-6YI62Gq-N0&t=164s
	
	CHAMAR OUTRO FORMS
	Inserir o códigos abaixo em um evento de botão: 
	addFuncionario addFun = new addFuncionario();
    addFun.ShowDialog();//Exibi forms invocado.
	
	
	# txb_PesquisaNome.Enabled = false; Para desabilitar objeto. avaliar depois (inserir esse código abaixo do [ InitializeComponent(); ] ).
	
*/

private void btn_Pesquisar_Click(object sender, EventArgs e) //RETORNA DADOS DO BD.
        {
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
private void cmb_Modelos_SelectedIndexChanged(object sender, EventArgs e) //RETORNA IMAGEM PICTUREBOX.
        {
            string[] nomeFotosCarros = Directory.GetFiles(@"C:\Users\jhean\Documents\MEGAsync\Development\Visual Studio\C#\Projetos\Edition\Visualizador_Produtos\Visualizador_Produtos\bin\Debug\net6.0-windows\img_modelos");//Array para armazenar os nomes dos carros.

            foreach(string img in nomeFotosCarros)
            {
                string[] separador = img.Split('\\'); //Recortar o nome que está sendo armazenado na string img, utilizando Split atraves do delimitador '\'.

                int i = separador.Length;//Tmanho do Array separador.
                string[] nomeSelecionado = separador[i-1].Split('.');//Array : Nome.extensão ( -1 retorna somente Nome ).
                
                if(cmb_Modelos.Text == nomeSelecionado[0])
                {
                    pictureBox2.ImageLocation = @"C:\Users\jhean\Documents\MEGAsync\Development\Visual Studio\C#\Projetos\Edition\Visualizador_Produtos\Visualizador_Produtos\bin\Debug\net6.0-windows\img_modelos\" + cmb_Modelos.Text + "." +nomeSelecionado[1];
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom; //Redimensionando a saída da imagem.
                }
                
            }
        }

		