using System;

namespace DIO.series
{    
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaopUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                        ListarSeries();
                        break;
                   case "2":
                        InserirSerie();
                        break; 
                   case "3":
                        AtualizarSerie();
                        break;
                   case "4":
                        ExcluirSerie();
                        break;
                   case "5":
                        VisualizarSerie();
                        break;
                   case "C":
                        Console.Clear();
                        break;                   
                   default:
                    throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaopUsuario();
           }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(entradaId);

            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            repositorio.Exclui(entradaId);
        }

        private static void AtualizarSerie()
        {

            Console.Write("Digite o id da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: entradaId, (Genero) entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Atualiza(entradaId,atualizaSerie);
        }

        private static void InserirSerie()
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), (Genero) entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Insere(novaSerie);

        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();

            if (lista.Count == 0) {
                Console.WriteLine("Nenhuma série foi cadastrada");
                return;
            }

            var temSerie = false;

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();

                if(!excluido) {
                    temSerie = true;
                    Console.WriteLine("#ID {0}: - {1}", serie.RetornaId(), serie.retornaTitulo());
                }
            }

            if (!temSerie) 
            Console.WriteLine("Nenhuma série foi cadastrada");
        }

        private static string ObterOpcaopUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar Série");            
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
