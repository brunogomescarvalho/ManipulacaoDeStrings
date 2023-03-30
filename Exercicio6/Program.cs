namespace Exercicio6
{
    class Program
    {
        static IEnumerable<string> listaOrdenada = null!;
        static string[] municipios = File.ReadAllLines("Cidades.csv");

        static void Main(string[] args)
        {
            byte opcao = MostrarMenu();

            switch (opcao)
            {
                case 1: listaOrdenada = OrdenarCidadesOrdemAlfabetica(); break;
                case 2: listaOrdenada = OrdenarCidadesEstado(); break;
                case 3: listaOrdenada = BuscarEstado(SolicitarEstado()); break;
                case 4: listaOrdenada = BuscarCidade(SolicitarCidade()); break;
            }

            MostrarListaCidadesOrdenada();
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

        static IEnumerable<string> BuscarCidade(string cidade)
        {
            return from line in municipios
                   let x = line.Split(';')
                   where x[2].StartsWith(cidade, StringComparison.InvariantCultureIgnoreCase)
                   orderby x[2], x[3]
                   select x[2] + ", " + x[3] + ", " + x[4] + ", " + x[1];
        }


        static IEnumerable<string> BuscarEstado(string estado)
        {
            return from line in municipios
                   let x = line.Split(';')
                   where x[3].StartsWith(" " + estado, StringComparison.InvariantCultureIgnoreCase)
                   orderby x[3], x[2]
                   select x[3] + ", " + x[2];
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
                Console.WriteLine("[4] Buscar Município Por Nome");
                
                opcao = byte.Parse(Console.ReadLine()!);

            } while (opcao != 1 && opcao != 2 && opcao != 3 && opcao != 4);

            return opcao;
        }

        static void MostrarListaCidadesOrdenada()
        {
            Console.Clear();

            foreach (var item in listaOrdenada)
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

        static string SolicitarCidade()
        {
            Console.Clear();
            Console.WriteLine("Informe a cidade:");
            return Console.ReadLine()!;
        }

    }
}
