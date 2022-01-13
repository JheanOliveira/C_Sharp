using System;
class Script
{
	class Aula03{ //Aula 03 : Propriedades (variaveis).
		
		static void Main()
		{
			//static int num00 = 0; variavel precisa ser static devido ao método.
			
			//variavel
			int num = 0;
			char letra = 'A';
			float valor = 5.3f;
			string texto = "Jhean";

			var aux = "Miguel"; //variavel sem atribuição de tipo.

			//Ler variavel:
			Console.WriteLine(aux);
		}
	}	
	class Aula04{ //Aula 04 : Variavel Local e Global.
		
		static void Main() 
		{
			int num = 110; //Variavel local.
			Console.WriteLine(num);

			Console.ReadKey();
		}
	}
	class Aula05{ //Aula 05 : Operadores Lógicos.
		
		static void Main() 
		{
			// & = and / E
			// | = OR / OU
			int res = 10 + 5;
			bool res = 10 < 5;
			bool res = 10 != 5;//Diferente (igual ao <> do excel).
			res = res + 1;
			res += 1; //(pode usar + - / *)
			res ++;
			booll res = 
			Console.WriteLine(res);
			Console.ReadKey();
		}
	}
	class Aula06{ //Aula 06 : Formatando a saída no console.
		
		static void Main() 
		{
			*int n1, n2, n3;

			n1 = 10; n2 = 20; n3 = 30;

			Console.Write("\n n1={0},\n n2={1},\n n3={2}",n1,n2,n3);//\n funciona aqui também
			

			double valorCompra = 5.50;
			double valorVenda;
			double lucro = 0.1;
			string produto = "Pastel";

			valorVenda=valorCompra+(valorCompra*lucro);

			Console.WriteLine("Produto .......{0,15}",produto);
			Console.WriteLine("Val.Compra.....{0,15:c}",valorCompra);
			Console.WriteLine("Lucro..........{0,15:p}", lucro);
			Console.WriteLine("Val.Venda......{0,15:c}",valorVenda);
		}
	}
	class Aula07{ //Aula 07 : Constantes.
		
		static void Main() 
		{
			const string autor = "Jhean"; //O valor de uma constante é imutavel.
			const double pi = 3.1415;

			Console.WriteLine("Autor: {0} \nPi: {1}",autor, pi);
		}
	}
	class Aula08{ //Aula 08 : Lendo valores do teclado.
		static void Main() 
		{
			int v1, v2, soma;
			string nome;

			Console.Write("Digite seu nome: ");
			nome = Console.ReadLine(); //ReadLine : Salta uma linha após a leitura da variavel.

			Console.Write("Digite o primeiro valor: ");
			v1 = int.Parse(Console.ReadLine()); //Ou v1 = convert.Toint32(Console.ReadLine());

			Console.Write("Digite o segundo valor: ");
			v2 = Convert.ToInt32(Console.ReadLine());

			soma = v1 + v2;


			Console.WriteLine("Nome digitado pelo usuário: " + nome);
			Console.WriteLine("A soma entre "+ v1 + " e " + v2 + " São: " +soma);
		}
	}
	class Aula09{ //Aula 09 : operações de Bitwise.
		static void Main() 
		{
			//Bitwise para direita: >> (Dobra o valor).
			//Bitwise para esquerda: << (resulta na metade do valor).
			
			int num = 10;

			num = num << 1; //Dobrou ovalor de "num".
			num = num >> 1;

			Console.WriteLine(num);
		}
	}
	class Aula10{ //Aula 10 : Enumeradores (Enum)
		enum DiasSemana { Domingo, Segunda, Terça, Quarta, Quinta, Sexta, Sábado }; //Atrinuição de enumenradores.
		static void Main() 
		{
			//DiasSemana ds = DiasSemana.Sábado; 
			//DiasSemana ds = (DiasSemana)3; //Atribuíndo pelo índice "Retorna o valor do enumenrador".
			int ds = (int)DiasSemana.Terça;

			Console.WriteLine(ds);
		}
	}
	class Aula11{ //Aula 11 : Typecast.Converte o tipo de propriedade quando é implicita.
		static void Main() 
		{
			int n1 = 10;
			float n2 = n1;
			
			float n1 = 10.5f;
			int n2 = (int)n1;//operação de converção (typeCast).

			int vInt = 10;
			short vShort = (short)vInt;

			Console.WriteLine(vShort);
			
		}
	}
	class Aula12{ //Aula 12 : 13 - Condicional IF - ELSE.		
		static void Main() 
		{
			int nota = 46;
			
			if (nota >= 100)
			{
				Console.WriteLine("Aprovado - Gênio");
			}
			else if(nota >= 60 & nota < 100)
			{
				Console.WriteLine("Aprovado - fez o suficiente");
			}
			else
			{
				Console.WriteLine("reprovado - deu mole");
			}
		}
	}
	class Aula14{ //Aula 14 : IF aninhado.
		static void Main() 
		{
			int n1, n2, n3, n4, res;
			n1=n2=n3= n4= res = 0;

			Console.Write("Digite a N1: ");
			n1 = int.Parse(Console.ReadLine());

			Console.Write("Digite a N2: ");
			n2 = int.Parse(Console.ReadLine());

			Console.Write("Digite a N3: ");
			n3 = int.Parse(Console.ReadLine());

			Console.Write("Digite a N4: ");
			n4 = int.Parse(Console.ReadLine());

			res = n1 + n2 + n3 + n4;

			if(res >= 60)
			{
				if(res >= 90)
				{
					Console.WriteLine("Sua nota foi: "+res +" Aprovado com louvor");
				}
				else
				{
					Console.WriteLine("Sua nota foi: "+ res + " Aprovado");
				}
			}
			else if(res < 60)
			{
				if(res < 40)
				{
					Console.WriteLine("Sua nota foi: " + res + " Reprovado");
				}
				else
				{
					Console.WriteLine("Sua nota foi: " + res + " Recuperação");
				}
			}
		}
	}
	class Aula15{ //Aula 15 : Switch Case.
		static void Main() 
		{
			int tempo;
			char escolha;

			Console.Write("Escolha qual tipo de transporte: [a] Aviação | [c] Carro | [o] Ônibus :");
			escolha = char.Parse(Console.ReadLine());

			switch (escolha)
			{
				case 'a': //Case sensitive, ou seja maícuslo e mínusculo faz diferença.
				case 'A': //tratamento de formatação de caracter.
					tempo = 50;
					break;
				case 'c':
				case 'C':
					tempo = 460;
					break;
				case 'o':
				case 'O':
					tempo = 660;
					break;
				default:
					tempo = -1;
					break;
			}
			if(tempo < 0) //Tratamento do default, ou seja caso o usuário digite valor não atribuído no sistema.
			{
				Console.WriteLine("Transporte escolhido inválido!!!");
			}
			else
			{
				Console.Write("Tempo de viagem é: " + tempo);
			} 
		}
	}
	class Aula16{ //Aula 16 : GO TO gera um desvio para ponto determinado.
		static void Main() 
		{
			int tempo;
			char escolha;

			inicio://Label . ponto de reinicio do programa, quando solicitado.
			Console.Clear();

			Console.Write("Escolha qual tipo de transporte: [a] Aviação | [c] Carro | [o] Ônibus :");
			escolha = char.Parse(Console.ReadLine());

			switch (escolha)
			{
				case 'a': //Case sensitive, ou seja maícuslo e mínusculo faz diferença.
				case 'A': //tratamento de formatação de caracter.
					tempo = 50;
					break;
				case 'c':
				case 'C':
					tempo = 460;
					break;
				case 'o':
				case 'O':
					tempo = 660;
					break;
				default:
					tempo = -1;
					break;
			}
			if (tempo < 0) //Tratamento do default, ou seja caso o usuário digite valor não atribuído no sistema.
			{
				Console.WriteLine("\n----------------------------------------------------\n" +
					"Transporte escolhido inválido!!!" +
					"\n----------------------------------------------------\n");
			}
			else
			{
				Console.WriteLine("\n----------------------------------------------------\n" +
					"Tempo de viagem é: " + tempo+
					"\n----------------------------------------------------\n");
			}
			Console.Write("Calcular outro transporte? [ S / N ] ");
			escolha = char.Parse(Console.ReadLine());

			if(escolha == 's' || escolha == 'S')
			{
				goto inicio; //o Goto precisa apontar um label.
			}
			else
			{
				Console.Clear();
				Console.WriteLine("Fim do programa");
			}
		}
	}
	class Aula17{ //Aula 17 : Array Unidimensional / Vetor (Coleção de dados no mesmo tipo.
		static void Main() 
		{
			int[] n = new int[5];//Declarando o Array.
			int[] num = new int[3] { 11, 22, 33 };//Declarando array e inicializando.
			int[] num1 = { 15, 25, 35 }; //O tamanho do array é definido pela quantidade inserida entre chaves, que no caso é 3 posições.
			//Atribuindo valor ao Array; forma base.
			n[0] = 10;
			n[1] = 20;
			n[2] = 30;
			n[3] = 40;
			n[4] = 50;

			//imprimindo o valor do índice do array.
			Console.Write(n[0]);
		}
	}
	class Aula18{ //Aula 18 : Array Bidimensional.
		static void Main(){
			int[,] n = new int[2, 2];//Linha / Coluna.
			int[,] num = new int[2, 2] { { 1000, 2000 }, { 100, 200 } };
			n[0, 0] = 10;
			n[0, 1] = 20;
			n[1, 0] = 30;
			n[1, 1] = 40;
			
			Console.Write(n[0, 0] + " ");
			Console.Write(n[0, 1] + "\n");
			Console.Write(n[1, 0] + " ");
			Console.Write(n[1, 1] + "\n");
		}
	}
	class Aula19{ //Aula 19 : For loop; comando de iteração.
		
		static void Main() 
		{
			int[] num = new int[10];
			//Utilizando quando se saber a quantidade de vezes que irá repetir.
				for (int i = 0; i < num.Length; i++)//Length : tamanho.
				{
					Console.WriteLine(i);
				}

				//Exemplo:
				 int num,ini,de;
				Console.Write("Contar até: ");
				num = int.Parse(Console.ReadLine());

				Console.Write("Iniciar a contagem em: ");
				ini = int.Parse(Console.ReadLine());

				Console.Write("Intervalo: ");
				de = int.Parse(Console.ReadLine());

				for(int i=ini; i <= num; i+=de)
				{
					Console.WriteLine("Valor: " + i);
				}
		}
	}
	class Aula20{ //Aula 20 : While loop. //Enquanto.
		static void Main() 
		{
			int n, i;

			Console.Write("Iniciar: ");
			i = int.Parse(Console.ReadLine());//O índice do While deve ser inicializar fora do mesmo.

			Console.Write("Fim em: ");
			n = int.Parse(Console.ReadLine());

			while (i<=n)//Expressão logíca.
			{
				
				Console.WriteLine("Valor: "+i);
				i++;
			}
			Console.WriteLine("\nFim da contagem!...");
		}
	}
	class Aula21{ //Aula 21 : Do While // Faça...Enquanto.
		static void Main()
		{
			int n=10, i=0;
			do
			{
				Console.WriteLine("Valor [i]: " + ++i);
				//i++;outra opção.
			} while (i<n);//Pelo o menos uma vez o comando será execultado.
			

			//Algoritmo de login.
			string senha = "123";
			string senhauser;
			int tentativa = 0;

			do
			{
				Console.Clear();
				Console.Write("Digite a Senha: ");
				senhauser=Console.ReadLine();
				tentativa++;
			}while(senha != senhauser);
			Console.Clear();
			Console.WriteLine("Senha correta, {0}",tentativa);
		}
	}
	class Aula22{ //Aula 22 : Foreach //
		static void Main() 
		{
			int[] num = new int[5] { 11, 12, 13,14,15 };

			foreach (int n in num)//Busca os elementos de uma coleção, em cada índice de num e atribui na variavel n.
			{   //Foreach : indicado para ler os elementos.
				Console.WriteLine(n);
			}
		}
	}
	class Aula24{ //Aula 24 : Criação de métodos.
		static void Main() 
		{
			int v1, v2, r;
			string user;

			//Console.Write("Usuário: ");
			//user = Console.ReadLine();
			Console.Write("Valor 1: ");
			v1 = int.Parse(Console.ReadLine());
			Console.Write("Valor 2: ");
			v2 = int.Parse(Console.ReadLine());

			//soma(user, v1,v2);//Método criado.
			r = soma2(v1 , v2);
			Console.WriteLine("A soma de {0} e {1} é: {2}",v1, v2, r);
		}
        static void teste()
        {
            Console.WriteLine("Olá mundo!");
        }
        static void soma(string nome, int n1, int n2)
        {
            int res = n1 + n2;
            Console.WriteLine("Usuário: {0} - A soma de {1} e {2} é: {3}",nome, n1,n2,res);
        }
        static int soma2(int n1, int n2)// Método de retorno.
        {
            int res = n1 + n2;
            return res;//Res está retornando a soma dentro do método soma2.
        }
	}	
	class Aula25{ //Aula 25 : Passagem de referencia. (Estilo ponteiros)
		static void Main() 
		{
			int num = 10;
			dobrar(ref num);//ref é como se fosse um ponteiro.
			Console.WriteLine(num);
		}
        static void dobrar(ref int valor) //ref precisa ser inserido no parâmetro do método e na invocação.
        {
            valor *= 2;
        }
	}
	class Aula26{ //Aula 26 : Argumento Out. (Out : Permite ter mais de um valor de saída, e pode ter vários.)
		static void Main() 
		{
			int divid, divis,quoc, rest;
			divid = 10;
			divis = 3;
			quoc = divide(divid, divis, out rest);

			Console.WriteLine("{0}/{1}: quociente ={2} e resto={3}", divid, divis, quoc, rest);
		}    
        static int divide(int dividendo, int divisor, out int resto)
        {
            int quociente;
            quociente = dividendo / divisor;
            resto = dividendo % divisor;
            return quociente;
		}
	}	
	class Aula27{ //Aula 27 : Argumento params
			static void Main() 
			{
			   // soma(100,20,354,157);
			} 
			static void soma(params int[]n)
			{
				int res = 0;

				if(n.Length < 1)
				{
					Console.WriteLine("Não existem valores a serem somados!");
				}
				else if(n.Length < 2)
				{
					Console.WriteLine("Valores insuficiente para soma: {0} ", n[0]);
				}
				else
				{
					for (int i = 0; i < n.Length; i++)
					{
						res+=n[i];
					}
					Console.WriteLine("A soma dos valores são: {0}", res);
				}  
			}
	}
	class Aula28{ //Aula 28 : Class e Objects
		public class Jogador 
		{
			public int energia = 100;
			public bool vivo = true;
		}
	
		static void Main()
		{
			Jogador j1 = new Jogador();
			Jogador j2 = new Jogador();

			j1.energia = 50; //Alterando valor da propriedade (variavel) do objeto jogador.

			Console.WriteLine("Energia do jogador 1: {0}", j1.energia);
			Console.WriteLine("Energia do jogador 2: {0}", j2.energia);
		}
	}
	class Aula29{ //Aula 29 : Construtores e Destrustores
			public class Jogador
			{
				public int energia;
				public bool vivo;
				public string nome;
				public Jogador(string n, int e)//Método Construtor.
				{//indicado inserir as propriedades dentro do construtor.
					energia = e;
					vivo = true;
					nome = n;
				}
				~Jogador() //Método Destrutor. serve para destruir o método construtor.
				{
					Console.WriteLine("Jogador foi destruído");
				}
			}

		static void Main()
		{
			//Entrada de dados.
			string nome1;
			Console.Write("Digite o nome do jogador 1: ");
			nome1 = Console.ReadLine();

			Jogador j1 = new Jogador(nome1, 100);
			Jogador j2 = new Jogador("Théo", 85);
			Jogador j3 = new Jogador("Vinck", 67);

			//j1.energia = 50; //Alterando valor da propriedade (variavel) do objeto jogador.

			//Saída de dados.
			Console.WriteLine("Nome do jogador 1: {0}", j1.nome);
			Console.WriteLine("Energia do jogador 1: {0}", j1.energia);
		}
	}	
	class Aula30{ //Aula 30 : Sobrecarga de Construtores.
		public class Jogador
		{
			public int energia;
			public bool vivo;
			public string nome;

			//Métodos Construtores.
			public Jogador()
			{
				energia = 100;
				vivo = true;
				nome = "Jogador";
			}
			public Jogador(string n)
			{//indicado inserir as propriedades dentro do construtor.
				energia = 100;
				vivo = true;
				nome = n;
			}
			public Jogador(string n, int e)
			{
				energia = e;
				vivo = true;
				nome = n;
			}
			public Jogador(string n, int e, bool v)
			{
				energia = e;
				vivo = v;
				nome = n;
			}
			public void info()
			{
				Console.WriteLine("Nome do Jogador.....{0}", nome);
				Console.WriteLine("Energia do Jogador..{0}", energia);
				Console.WriteLine("Situação do Jogador {0}", vivo);
			}
			/*
			~Jogador() //Método Destrutor. serve para destruir o método construtor.
			{
				Console.WriteLine("Jogador {0} foi destruído", nome);
			}
			*/
		}

		static void Main()
		{
			//Entrada de dados.
			string nome1;
			//Console.Write("Digite o nome do jogador 1: ");
			//nome1 = Console.ReadLine();

			Jogador j1 = new Jogador();
			Jogador j2 = new Jogador("Théo", 85);
			Jogador j3 = new Jogador("Vinck", 67);

			//j1.energia = 50; //Alterando valor da propriedade (variavel) do objeto jogador.

			//Saída de dados.
			Console.WriteLine("Nome do jogador 1: {0}", j1.nome);
			Console.WriteLine("Energia do jogador 1: {0}", j1.energia);
		}
	}
	class Aula31{ //Aula 31 : Classe Static
	//Classe Static: não permite construtores, e não permite instancia detro delas.
		
	}
	class Aula32{ //Aula 31 : This.
		class Calculos
		{
			public int v1;
			public int v2;

			public Calculos(int v1, int v2)
			{
				this.v1 = v1; //This vai fazer referencia ao objeto.
				this.v2 = v2;
			}

			public int Somar()
			{
				return v1 + v2;
			}
			
		}
			class Aula32
			{
				static void Main()
				{
					Calculos c = new Calculos(10, 2);

					Console.WriteLine(c.Somar());
				}
			}
	}
	class Aula33{ //Aula 33 : Diferença Public e Private.
		class Jogador
		{
			private int energia;
			private string nome;

			public Jogador(string nome)
			{
				this.nome = nome;
				this.energia = 100;
			}

			public int getEnergia() // Método para buscar os valor em propriedade private.
			{
				return energia;
			}

			public string getNome()
			{
				return nome;
			}

			public void setEnergia(int e) //Método para fazer alteração na propriedade private.
			{
				if(e < 0)// Regra do if : Energia é minimo: 0 e maximo 100.
				{
					if( energia + e < 0)
					{
						energia = 0;
					}
					else
					{
						energia += e;
					}
				}else if(e > 0)
				{
					if (energia + e > 100)
					{
						energia = 100;
					}
					else
					{
						energia += e;
					}
				}
			}

			static void Main()
			{
				Jogador j1 = new Jogador("Jhean");

				j1.setEnergia(-130);

				Console.WriteLine("Nome.....{0}",j1.getNome());
				Console.WriteLine("Energia..{0}", j1.getEnergia());
			}
		}
	}
	class Aula34{ //Aula 34 : Herança.
		class Veiculo //Classe base
		{
			public int rodas;
			public int velMax;
			private bool ligado;

			public void ligar()
			{
				ligado = true;
			}
			public void desligar()
			{
				ligado = false;
			}
			public string getLigado()
			{
				if (ligado)
				{
					return "Sim";
				}
				else
				{
					return "Não";
				}
			}
		}
		class Carro : Veiculo //Carro << herda de Veiculo as propriedades.
		{
			public string nome;
			public string cor;
			public Carro(string nome, string cor)
			{
				desligar();
				rodas = 4;
				velMax = 120;
				this.nome = nome;
				this.cor = cor;
			}
		}
		static void Main()
		{
			Carro c1 = new Carro("Pálio","Prata");
			
			//c1.ligado = true; //Só é possível acessar o (ligado) pq a propriedade é public.

			Console.WriteLine("Nome....: {0}", c1.nome);
			Console.WriteLine("Cor.....: {0}", c1.cor);
			Console.WriteLine("Rodas...: {0}", c1.rodas);
			Console.WriteLine("V.Max...: {0}", c1.velMax);
			Console.WriteLine("Ligado..: {0}", c1.getLigado());
		}
	}
	class Aula35{ //Aula 35 : Cadeia de Herança, e Construtor classe base.
		class Veiculo //Classe base
		{
			private int rodas;
			public int velMax;
			private bool ligado;

			public Veiculo(int rodas)//Construtor.
			{
				this.rodas = rodas;
			}

			public void ligar()
			{
				ligado = true;
			}
			public void desligar()
			{
				ligado = false;
			}
			public string getLigado()
			{
				return (ligado ? "Sim" : "Não"); //Operador Ternário, elimina a necessidade do IF.
				/*
				if (ligado)
				{
					return "Sim";
				}
				else
				{
					return "Não";
				}
				*/
			}
			public int getRodas()
			{
				return rodas;
			}
			public void setRodas(int rodas)
			{
				if(rodas < 0)
				{
					this.rodas = 0;
				}else if(rodas > 0)
				{
					this.rodas = 40;
				}
				else
				{
					this.rodas = rodas;
				}
			}
		}
		class Carro : Veiculo //Carro << herda de Veiculo as propriedades.
		{
			public string nome;
			public string cor;
			public Carro(string nome, string cor):base(4)
			{
				desligar();
				velMax = 120;
				this.nome = nome;
				this.cor = cor;
			}
		}
		class CarroCombate: Carro
		{
			public int municao;

			public CarroCombate():base("Carro de combate", "Preto")//Construtor
			{
				municao = 100;
				setRodas(6);//Chamando método de alteração de valores de uma propriedade private.
			}
		}
		static void Main()
		{
			Carro c1 = new Carro("Pálio","Prata");
			CarroCombate cc1 = new CarroCombate();
			
			//c1.ligado = true; //Só é possível acessar o (ligado) pq a propriedade é public.

			Console.WriteLine("Nome....: {0}", c1.nome);
			Console.WriteLine("Cor.....: {0}", c1.cor);
			Console.WriteLine("Rodas...: {0}", c1.getRodas());
			Console.WriteLine("V.Max...: {0}", c1.velMax);
			Console.WriteLine("Ligado..: {0}", c1.getLigado());

			Console.WriteLine("---------------------------------------");

			Console.WriteLine("Nome....: {0}", cc1.nome);
			Console.WriteLine("Cor.....: {0}", cc1.cor);
			Console.WriteLine("Rodas...: {0}", cc1.getRodas());
			Console.WriteLine("V.Max...: {0}", cc1.velMax);
			Console.WriteLine("Ligado..: {0}", cc1.getLigado());
			Console.WriteLine("Munição.: {0}", cc1.municao);
		}
	}
	class Aula36{ //Aula 36 : Membro Protected. diferença entre protected e private.
		class Veiculo //Clase base.
		{
			public int velAtual;
			private int velMax; //Restringe o acesso somente a class.
			protected bool ligado; //Permite acesso aos membros pelas classes derivadas(filhos)

			public Veiculo(int velMax)
			{
				velAtual = 0;
				this.velMax = velMax;
				ligado = false;
			}
			public bool getLigado()
			{
				return ligado;
			}
			public int getVelMax()
			{
				return velMax;
			}
		}
		class Carro : Veiculo
		{
			public string nome;
			public Carro(string nome, int vm) : base(vm)
			{ //Inicializando um construtor da classe base que precise de um parâmetro.
				this.nome = nome;
				ligado=true;
			}
		}
		static void Main()
		{
			Carro c1 = new Carro("Monza", 160);

			Console.WriteLine("Nome................{0}",c1.nome);
			Console.WriteLine("Velocidade Maxima...{0}",c1.getVelMax());
			Console.WriteLine("ligado..............{0}",c1.getLigado());
		}
	}
	class Aula37{ //Aula 37 : Ordem de execução da Classe base e Derivadas.
		class Base
		{
			public Base(){
				Console.WriteLine("Construtor da classe Base");
			}
		}
		class Derivada1 : Base
		{
			public Derivada1()
			{
				Console.WriteLine("Construor da classe Derivada 1");
			}
		}
		class Derivada2 : Derivada1
		{
			public Derivada2()
			{
				Console.WriteLine("Construtor da classe Derivada 2");
			}
		}

		static void Main()
		{
			Derivada2 derivada2 = new Derivada2();
		}
	}
	class Aula38{ //Aula 38 : Métodos Virtuais. (Métodos virtuais: são métodos que tem o mesmo nome em classes diferentes.)
		class Base
		{
			public Base(){
				Console.WriteLine("Construtor da classe Base");
			}
			virtual public void info() //Método virtual (pode ser sobescrito).
			{
			  //  Console.WriteLine("Base"); Não precisa de comando dentro, poís será sobrescrito.
			}
		}
		class Derivada1 : Base
		{
			public Derivada1()
			{
				Console.WriteLine("Construor da classe Derivada 1");
			}
			override public void info()// Quando encontrar overrride em um método, identificamos que tem outro parecido na classe base, é o mesmo será sobescrito.
			{
				Console.WriteLine("Derivada 1");
			}
		}
		class Derivada2 : Derivada1
		{
			public Derivada2()
			{
				Console.WriteLine("Construtor da classe Derivada 2");
			}
			override public void info()
			{
				Console.WriteLine("Derivada 2");
			}
		}

		static void Main()
		{
			Base Ref; //utilizando a base como referentencia.
			Derivada1 derivada1 = new Derivada1();
			Derivada2 derivada2 = new Derivada2();
			//derivada1.info();//invocando o método info.
			//derivada2.info();

			Ref = derivada1;
			Ref.info();
		}
	}
	class Aula39{ //Aula 39 : Classe abstract e Metodos abstract
    //Metodos obstract serve como protótipo para as classe que estão herdando.

		abstract class Veiculo //Classe base abstrata.
		{
			protected int velMax;
			protected int velAtual;
			protected bool ligado;

			public Veiculo()
			{
				ligado = false;
				velAtual = 0;
			}
			public void setLigado(bool ligado)
			{
				this.ligado = ligado;
			}
			public int getVelAtual()
			{
				return velAtual;
			}
			abstract public void aceleracao(int mult);//por ser tratar de abstract não é obrigatório implementar.
		}
		class Carro : Veiculo
		{
			public Carro()
			{
				velMax = 120;
			}
			override public void aceleracao(int mult)
			{
				velAtual +=10 * mult;
			}
		}
		class Aula
		{
			static void Main()
			{
				Carro carro1 = new Carro();
				carro1.aceleracao(1);

				Console.WriteLine(carro1.getVelAtual());
			}
		}
	}
	class Aula40{ //Aula 40 : Classe Sealed (Classe que não pode ser Herdada).
		sealed class Veiculo //Está classe não pode ser herdada.
		{

		}
		class Aula_40 { 
			static void Main()
			{

			}
		}
	}
	class Aula41{ //Aula 41 : Propriedade de acesso GET e SET.
		class Carro //Está classe não pode ser herdada.
		{
			private int velMax;

			public int vm //Isso é uma propriedade (Variavel).
			{
				//Não é obritorio implementar os dois, pode ser (GET ou SET)
				get //Leitura
				{
					return velMax;
				}
				set //Escrita.
				{
					if(value < 0)
					{
						velMax = 0;
					}
					else if(value > 300)
					{
						velMax = 300;
					}
					else
					{
						velMax = value;
					}
				}
			}
			public Carro()
			{
				this.velMax = 120; //Qualquer carro que for instancia terá 120 no seu velMax.
			}
			/*
			public void vm(int velMax)
			{
				this.velMax = velMax;
			}
			*/
		}
		class Aula_41 { 
			static void Main()
			{
				Carro c1 = new Carro();

				c1.vm = 350; //Acesso SET

				Console.WriteLine("Velocidade: {0}", c1.vm); //Acesso GET.
			}
		}
	}
	class Aula42{ //Aula 42 : Indexadores.
		class Carro //Está classe não pode ser herdada.
		{
			private int[] velMax = new int[5] {80, 120, 160, 240, 300};

			public int this[int i]  //Isso é uma propriedade (Variavel).
			{
				//Não é obritorio implementar os dois, pode ser (GET ou SET)
				get //Leitura
				{
					return velMax[i];
				}
				set //Escrita.
				{
					if(value < 0)
					{
						velMax[i] = 0;
					}
					else if(value > 300)
					{
						velMax[i] = 300;
					}
					else
					{
						velMax[i] = value;
					}
				}
			}
			public Carro()
			{
			}
			/*
			public void vm(int velMax)
			{
				this.velMax = velMax;
			}
			*/
		}
		class Aula_42{
			static void Main()
			{
				Carro c1 = new Carro();

				c1[4] = 167; //Acesso SET

				Console.WriteLine("Velocidade: {0}", c1[4]); //Acesso GET.
			}
		}
	}
	class Aula43{ //Aula 43 : Interfaces (Só implementam métodos ou protótipo dos métodos.)
		public interface Veiculo //Insere assinatura dos métodos.
		{
			void ligar();
			void desligar();
			void info();
		}
		public interface Combate
		{
			void disparar();
		}
		class Carro:Veiculo,Combate
		{
			public bool ligado;
			private int municao;
			public Carro()
			{
				setMunicao(100);
			}
			public void setMunicao(int qtde)
			{
				this.municao = qtde;
			}
			public void ligar()
			{
				this.ligado = true;
			}
			public void desligar()
			{
				this.ligado = false;
			}
			public void disparar()
			{

			}
			public void info() { }
		}

		class Aula_43 { 
			static void Main()
			{
				
			}
		}
	}
}