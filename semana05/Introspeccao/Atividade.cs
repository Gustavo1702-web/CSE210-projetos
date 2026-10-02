using System;
using System.Collections.Generic;   // novo
using System.Threading;

public class Atividade
{
    private string _nome;
    private string _descricao;
    private int _duracao;
    private Random _aleatorio = new Random();   

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
        _duracao = 0;
    }

    protected int ObterDuracao()
    {
        return _duracao;
    }

    public void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à Atividade de {_nome}.");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();

        Console.Write("Quanto tempo, em segundos, você gostaria para a sua sessão? ");
        _duracao = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Prepare-se para começar...");
        ExibirProgresso(5);
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem!!");
        ExibirProgresso(5);

        Console.WriteLine();
        Console.WriteLine($"Você completou {_duracao} segundos da Atividade de {_nome}.");
        ExibirProgresso(5);
    }

    public void ExibirProgresso(int segundos)
    {
        string[] animacao = { "|", "/", "-", "\\" };
        DateTime fim = DateTime.Now.AddSeconds(segundos);
        int i = 0;

        while (DateTime.Now < fim)
        {
            Console.Write(animacao[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % animacao.Length;
        }
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            string numero = i.ToString();
            Console.Write(numero);
            Thread.Sleep(1000);
            Console.Write(new string('\b', numero.Length) + new string(' ', numero.Length) + new string('\b', numero.Length));
        }
    }

     protected string ObterAleatorioSemRepeticao(List<string> todos, List<string> restantes)
    {
        if (restantes.Count == 0)                                                                                                                             
        {
            restantes.AddRange(todos);   // todos já foram usados: recomeça o ciclo
        }

        int indice = _aleatorio.Next(restantes.Count);
        string escolhido = restantes[indice];
        restantes.RemoveAt(indice);

        return escolhido;
    }
}