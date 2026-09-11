using System;

class Program
{
    static Diario diario = new Diario();
    static GeradorDePerguntas geradorDePerguntas = new GeradorDePerguntas();

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Bem-vindo ao Diário Pessoal!");
        Console.WriteLine("");

        Console.ResetColor();

        while (true)
        {
            Console.WriteLine(" Menu do Diário ");
            Console.WriteLine("1 - Escrever um novo registro");
            Console.WriteLine("2 - Exibir o diário");
            Console.WriteLine("3 - Salvar o diário em um arquivo");
            Console.WriteLine("4 - Carregar o diário de um arquivo");
            Console.WriteLine("5 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    EscreverNovoRegistro();
                    break;
                case "2":
                    diario.DisplayAll();
                    break;
                case "3":
                    Console.Write("Digite o nome do arquivo para salvar: ");
                    string saveFile = Console.ReadLine();
                    diario.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Digite o nome do arquivo para carregar: ");
                    string loadFile = Console.ReadLine();
                    diario.LoadFromFile(loadFile);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void EscreverNovoRegistro()
    {
        string pergunta = geradorDePerguntas.GetRandomPrompt();
        Console.WriteLine(pergunta);
        string resposta = Console.ReadLine();

        Registro newEntry = new Registro(pergunta, resposta);
        diario.AddEntry(newEntry);
    }
}