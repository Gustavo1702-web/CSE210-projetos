using System;
using System.Collections.Generic;

public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras;
    private static Random _random = new Random();

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = new List<Palavra>();

        
        string[] palavrasTexto = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string p in palavrasTexto)
        {
            _palavras.Add(new Palavra(p));
        }
    }

    public void OcultarPalavrasAleatorias(int numeroParaOcultar)
    {
        
        List<Palavra> palavrasVisiveis = new List<Palavra>();
        foreach (Palavra p in _palavras)
        {
            if (!p.EstaOculta())
            {
                palavrasVisiveis.Add(p);
            }
        }

        for (int i = 0; i < numeroParaOcultar && palavrasVisiveis.Count > 0; i++)
        {
            int indice = _random.Next(palavrasVisiveis.Count);
            palavrasVisiveis[indice].Ocultar();
            palavrasVisiveis.RemoveAt(indice);
        }
    }

    public string ObterTexto()
    {
        string textoReferencia = _referencia.ObterTexto();

        string textoPalavras = "";
        for (int i = 0; i < _palavras.Count; i++)
        {
            textoPalavras += _palavras[i].ObterTexto();
            if (i < _palavras.Count - 1)
            {
                textoPalavras += " ";
            }
        }

        return $"{textoReferencia}\n\n{textoPalavras}";
    }

    public bool EstaCompletamenteOculta()
    {
        foreach (Palavra p in _palavras)
        {
            if (!p.EstaOculta())
            {
                return false;
            }
        }
        return true;
    }
}