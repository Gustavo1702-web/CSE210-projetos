using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual é o numero magico?");
        int numeroMagico = int.Parse(Console.ReadLine());

        Random geradorAleatorio = new Random();
        int numeroAleatorio = geradorAleatorio.Next(1, 100);

        int palpite = -1;

        while (palpite != numeroMagico)
        {
            Console.Write("Qual é o seu palpite?");
            palpite = int.Parse(Console.ReadLine());

            if (palpite < numeroMagico)
            {
                Console.WriteLine("menor");
            }
            else if (palpite > numeroMagico)
            {
                Console.WriteLine("maior");
            }
            else
            {
                Console.WriteLine("Parabéns, você acertou o numero magico!");
            }


           
        }

    }
}