using System;
using System.Collections.Generic;

public class AtividadeDeListagem : Atividade
{
    private int _contador;
    private List<string> _perguntas;
    private List<string> _perguntasRestantes = new List<string>();   // novo

    public AtividadeDeListagem()
        : base("Listagem",
               "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
    {
        _contador = 0;
        _perguntas = new List<string>
        {
            "Quem são as pessoas que você aprecia?",
            "Quais são seus pontos fortes pessoais?",
            "Quem são as pessoas que você ajudou esta semana?",
            "Quando você sentiu o Espírito Santo neste mês?",
            "Quem são alguns dos seus heróis pessoais?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Console.WriteLine("Liste o máximo de itens que puder na seguinte área:");
        Console.WriteLine();
        Console.WriteLine($"--- {ObterPerguntaAleatoria()} ---");
        Console.WriteLine();
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.WriteLine();

        List<string> itens = ObterListaDoUsuario();
        _contador = itens.Count;

        Console.WriteLine();
        Console.WriteLine($"Você listou {_contador} itens!");

        ExibirMensagemFinal();
    }

    private string ObterPerguntaAleatoria()
    {
    return ObterAleatorioSemRepeticao(_perguntas, _perguntasRestantes);
    }
    private List<string> ObterListaDoUsuario()
    {
        List<string> itens = new List<string>();
        DateTime fim = DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < fim)
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(item))
            {
                itens.Add(item);
            }
        }

        return itens;
    }
}