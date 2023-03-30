namespace Exercicio5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Informe a frase desejada:");
            string frase = Console.ReadLine()!;

            Console.WriteLine("\nFrase em Letras Maiúsculas:");
            string fraseEmMaiusculas = frase.ToUpper();
            Console.WriteLine(fraseEmMaiusculas);

            Console.WriteLine("\nFrase em Letras Minúsculas:");
            string fraseEmMinusculas = frase.ToLower();
            Console.WriteLine(fraseEmMinusculas);

            Console.WriteLine("\nQuantidade de Caracteres:");
            Console.WriteLine(frase.Length);

            string[] arrayPalavras = frase.Split(" ");

            Console.WriteLine("\nPrimeira Palavra:");
            Console.WriteLine(arrayPalavras[0]);

            Console.WriteLine("\nÚltima Palavra:");
            Console.WriteLine(arrayPalavras[arrayPalavras.Length - 1]);

        }
    }
}