namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Digite o texto para contar as palavras:");
            string texto = Console.ReadLine()!;

            int qtdDePalavras = texto.Split(" ").Count();

            Console.WriteLine($"\nO texto contém {qtdDePalavras} palavras.\n");

        }
    }
}