namespace Exercicio6
{
    class Program
    {
        static string estado = "";
        static IEnumerable<string> query = null!;
        static string[] municipios = File.ReadAllLines("Cidades.csv");

        static void Main(string[] args)
        {
            byte opcao = MostrarMenu();

            switch (opcao)
            {
                case 1:
                    query = OrdenarCidadesOrdemAlfabetica();
                    break;
                case 2:
                    query = OrdenarCidadesEstado();
                    break;
                case 3:
                    query = OrdenarCidadesEstadoSolicitado();
                    break;
                default:
                    break;
            }

            if (opcao == 3)
            {
                MostrarCidadesEstadoSolicitado();
            }
            else
            {
                MostrarListaCidadesOrdenada();
            }
        }


        static void MostrarCidadesEstadoSolicitado()
        {
            bool encontrou = false;
            Console.Clear();
            Console.WriteLine("Aguarde...Carregando dados!");
            int controleMensagemAguarde = 0;

            for (int i = 0; i < municipios.Length; i++)
            {
                if (query.ElementAt(i).StartsWith($" {estado}", StringComparison.InvariantCultureIgnoreCase))
                {
                    encontrou = true;
                    if (encontrou && controleMensagemAguarde == 0)
                    {
                        Console.Clear();
                        controleMensagemAguarde++;
                    }

                    Console.WriteLine(query.ElementAt(i));
                }

                if (encontrou && query.ElementAt(i)[2] != estado[1])
                {
                    break;
                }
            }
        }

        static IEnumerable<string> OrdenarCidadesOrdemAlfabetica()
        {
            return from line in municipios
                   let x = line.Split(';')
                   orderby x[2]
                   select x[2];
        }

        static IEnumerable<string> OrdenarCidadesEstado()
        {
            return from line in municipios
                   let x = line.Split(';')
                   orderby x[3], x[2]
                   select x[3] + ", " + x[2];
        }


        static IEnumerable<string> OrdenarCidadesEstadoSolicitado()
        {
            estado = SolicitarEstado();
            return OrdenarCidadesEstado();
        }

        static byte MostrarMenu()
        {
            byte opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("--- Municípios do Brasil ---\n");
                Console.WriteLine("Escolha sua opção:");
                Console.WriteLine("[1] Ordenar Por Ordem Alfabética");
                Console.WriteLine("[2] Ordenar Por Estados");
                Console.WriteLine("[3] Ordenar Municípios Por Estado Determinado");
                opcao = byte.Parse(Console.ReadLine()!);

            } while (opcao != 1 && opcao != 2 && opcao != 3);

            return opcao;
        }

        static void MostrarListaCidadesOrdenada()
        {
            Console.Clear();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        static string SolicitarEstado()
        {
            Console.Clear();
            Console.WriteLine("Informe o estado:");
            return Console.ReadLine()!;
        }

    }
}
