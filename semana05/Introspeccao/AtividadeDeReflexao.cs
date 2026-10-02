using System;
using System.Collections.Generic;

public class AtividadeDeReflexao : Atividade
{
    private List<string> _reflexoes;
    private List<string> _perguntas;
    private List<string> _reflexoesRestantes = new List<string>();   // novo
    private List<string> _perguntasRestantes = new List<string>();   // novo
    

    public AtividadeDeReflexao()
        : base("Reflexão",
               "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida.")
    {
        _reflexoes = new List<string>
        {
            "Pense em uma ocasião em que você defendeu outra pessoa.",
            "Pense em uma ocasião em que você fez algo realmente difícil.",
            "Pense em uma ocasião em que você ajudou alguém necessitado.",
            "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
        };

        _perguntas = new List<string>
        {
            "Por que essa experiência foi significativa para você?",
            "Você já fez algo assim antes?",
            "Como você começou?",
            "Como você se sentiu quando terminou?",
            "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
            "Qual é a sua coisa favorita sobre essa experiência?",
            "O que você pode aprender com essa experiência que se aplica a outras situações?",
            "O que você aprendeu sobre si mesmo por meio dessa experiência?",
            "Como você pode manter essa experiência em mente no futuro?"
        };
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        ExibirReflexoes();

        Console.WriteLine();
        Console.WriteLine("Agora pondere sobre as seguintes perguntas relacionadas à sua experiência.");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.Clear();

        ExibirPerguntas();

        ExibirMensagemFinal();
    }

    private string ObterReflexoesAleatorias()
    {
    return ObterAleatorioSemRepeticao(_reflexoes, _reflexoesRestantes);
    }

    private string ObterPerguntasAleatorias()
    {
    return ObterAleatorioSemRepeticao(_perguntas, _perguntasRestantes);
    }
    private void ExibirReflexoes()
    {
        Console.WriteLine("Reflita sobre a seguinte situação:");
        Console.WriteLine();
        Console.WriteLine($"--- {ObterReflexoesAleatorias()} ---");
        Console.WriteLine();
        Console.Write("Quando tiver algo em mente, pressione Enter para continuar.");
        Console.ReadLine();
    }

    private void ExibirPerguntas()
    {
        DateTime fim = DateTime.Now.AddSeconds(ObterDuracao());

        while (DateTime.Now < fim)
        {
            Console.Write($"> {ObterPerguntasAleatorias()} ");
            ExibirProgresso(10);
            Console.WriteLine();
        }
    }
}