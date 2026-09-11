using System;

public class Registro
{
    public string Pergunta { get; set; }
    public string Resposta { get; set; }
    public DateTime Date { get; set; }

    public Registro(string pergunta, string resposta)
    {
        Pergunta = pergunta;
        Resposta = resposta;
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Data: {Date.ToShortDateString()}\nPergunta: {Pergunta}\nResposta: {Resposta}\n";
    }
}