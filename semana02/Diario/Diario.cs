using System;
using System.Collections.Generic;
using System.IO;

public class Diario
{
    private List<Registro> entradas = new List<Registro>();

    public void AddEntry(Registro newEntry)
    {
        entradas.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Registro entrada in entradas)
        {
            Console.WriteLine(entrada);
            Console.WriteLine("-----------------------------");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Registro entrada in entradas)
            {
                string line = $"{entrada.Pergunta}~|~{entrada.Resposta}~|~{entrada.Date}";
                outputFile.WriteLine(line);
            }
        }
        Console.WriteLine("Diário salvo com sucesso!");
    }

    public void LoadFromFile(string filename)
    {
        entradas.Clear();

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            if (parts.Length == 3)
            {
                Registro entrada = new Registro(parts[0], parts[1]);
                entrada.Date = DateTime.Parse(parts[2]);
                entradas.Add(entrada);
            }
        }
        Console.WriteLine("Diário carregado com sucesso!");
    }
}