/*
Program.cs
Author = César Calafrioli
Date = 28/05/2021
Last Modified = 29/05/2021

Classe principal
*/
using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while ( opcaoUsuario.ToUpper() != "X" )
            {
                Console.Clear();
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
                    default:
                        ObterOpcaoUsuario();
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
                Console.ReadKey();
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Agradecemos a sua preferência.");
        }

        // Exibe na tela o menu
        private static string ObterOpcaoUsuario()
        {
            Console.Clear();
            Console.WriteLine("=========================================================");
            Console.WriteLine("|                       DIO SERIES                      |");
            Console.WriteLine("=========================================================");
            Console.WriteLine();
            Console.WriteLine("Opções:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("X - Encerrar");
            Console.WriteLine();            
            Console.Write("Informe a opção desejada : ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        // Lista todas as séries cadastradas
        private static void ListarSeries()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|      LISTAR SÉRIES       |");
            Console.WriteLine("----------------------------");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach ( var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluído" : ""));
            }
            
        }

        // Criar uma nova série
        private static void InserirSerie()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|         NOVA SÉRIE       |");
            Console.WriteLine("----------------------------");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            // Verifica se já existe alguma conta com o nome informado pelo usuário
            // if ( contaExiste(entradaNome, 0, 2)){
            //     Console.WriteLine("Já existe uma conta com este nome");
            //     return;
            // }

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao        
            );
       
            repositorio.Insere(novaSerie);
           
        }

        // Atualiza uma série já existente
        private static void AtualizarSerie()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|     ATUALIZA SÉRIE       |");
            Console.WriteLine("----------------------------");

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao        
            );            

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        // Exclui uma série cadastrada
        private static void ExcluirSerie()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine("|      EXCLUIR SÉRIE       |");
            Console.WriteLine("----------------------------");

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        // Retorna o nome da série após digitar o ID
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
    }
}
