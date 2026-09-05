using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        int numeroReal = -1;
        while (numeroReal != 0)
        {
            Console.Write("Digite um numero (0 para sair): ");

            string entradaUsuario = Console.ReadLine();
            numeroReal = int.Parse(entradaUsuario);

            if (numeroReal != 0)
            {
                numeros.Add(numeroReal);
            }
        }

        int soma = 0;
        foreach (int numero in numeros)
        {
            soma += numero;
        }

        Console.WriteLine($"A soma dos numeros é: {soma}");

         float media = (float)soma / numeros.Count;
        Console.WriteLine($"A média dos numeros é: {media}");

        int maior = numeros[0];
        
        foreach (int numero in numeros)
        {
            if (numero > maior)
            {
                maior = numero;
            }
        }
        Console.WriteLine($"O maior valor é: {maior}");
    }
}