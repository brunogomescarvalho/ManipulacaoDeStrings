namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o texto para converter em Title Case:");
            string textoParaConverter = Console.ReadLine()!;

            string[] palavras = new string[textoParaConverter.Length];
            palavras = textoParaConverter.Split(" ");

            string novoTexto = " ";

            for (int i = 0; i < palavras.Length; i++)
            {
                string palavra = palavras[i].First().ToString().ToUpper() + palavras[i].Substring(1);
                novoTexto += $"{palavra} ";
            }

            Console.WriteLine(novoTexto);

        }
    }
}