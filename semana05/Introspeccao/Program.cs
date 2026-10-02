using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
    
        string escolha = "";

        while (escolha != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu de Opções:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            Console.WriteLine("  4. Sair");
            Console.Write("Selecione uma opção do menu: ");
            escolha = Console.ReadLine();

            if (escolha == "1")
            {
                new AtividadeDeRespiracao().Executar();
            }
            else if (escolha == "2")
            {
                new AtividadeDeReflexao().Executar();
            }
            else if (escolha == "3")
            {
                new AtividadeDeListagem().Executar();
            }
        }
    }
}