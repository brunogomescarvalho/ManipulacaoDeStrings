namespace Exercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Informe o texto para encriptografar");
            string texto = Console.ReadLine()!;

            Console.WriteLine("Informe o quantos valores deseja modificar");
            int valor = Convert.ToInt32(Console.ReadLine());

            char[] novoTexto = texto.ToCharArray();

            for (int i = 0; i < novoTexto.Length; i++)
            {
                if (novoTexto[i] != (char)32)
                    novoTexto[i] += (char)valor;
            }

            Console.WriteLine(novoTexto);

        }
    }
}