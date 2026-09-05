using System;

internal class NewBaseType
{
    static void Main(string[] args)
    {
        Console.Write("Qual é o valor da sua nota?");
        string nota = Console.ReadLine();
        int valor = int.Parse(nota);

        string letra = "";

        if (valor >= 90)
        {
            letra = "A";
        }
        else if (valor >= 80)
        {
            letra = "B";
        }
        else if (valor >= 70)
        {
            letra = "C";
        }
        else if (valor >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }
        Console.WriteLine($"Sua nota é: {letra}.");

        if (valor >= 70)
        {
            Console.WriteLine("Parabéns, você foi aprovado!");
        }

        else
        {
            Console.WriteLine("Infelizmente, você foi reprovado.");
        }

    }
}
