using System;

public class Fracao
{
    private int Numerador;
    private int Denominador;

    public Fracao()
    {
        Numerador = 1;
        Denominador = 1;
    }

    public Fracao(int numeroInteiro)
    {
        Numerador = numeroInteiro;
        Denominador = 1;
    }
    
    public Fracao(int numerador, int denominador)
    {
        Numerador = numerador;
        Denominador = denominador;
    }

    public string ObterFracaoEmTexto()
    {
        string texto = $"{Numerador}/{Denominador}";

        return texto;
    }

    public double ObterFracaoEmDecimal()
    {
        return (double)Numerador / (double)Denominador;
    }
}