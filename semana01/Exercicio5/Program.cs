using System;

class Program
{
    static void Main(string[] args)
    {
      ExibirMensagemBoasVindas();

      string nomeUsuario = PerguntarNomeUsuario();
      int numeroUsuario = PerguntarNumeroUsuario();

      int numeroAoQuadrado = numeroAoQuadradoQuadrado(numeroUsuario);

      ExibirResultado(nomeUsuario, numeroAoQuadrado);
    }

    static void ExibirMensagemBoasVindas()
    {
        Console.WriteLine("Bem-vindo ao programa!");
    }

    static string PerguntarNomeUsuario()
    {
        Console.Write("Por favor, digite seu nome: ");
        string nome = Console.ReadLine();
        return nome;
    }

    static int PerguntarNumeroUsuario()
    {
        Console.Write("Por favor, digite um número favorito: ");
        int numero = int.Parse(Console.ReadLine());
        return numero;
    }

    static int numeroAoQuadradoQuadrado(int numero)
    {
        int quadrado = numero * numero;
        return quadrado;
    }

    static void ExibirResultado(string nome, int quadrado)
    {
        Console.WriteLine($"Olá, {nome}! O quadrado do seu número favorito é: {quadrado}");
    }

}
