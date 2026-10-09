using System;
using System.Collections.Generic;
using System.IO;

public class GerenciadorDeMetas
{
    private List<Meta> _metas;
    private int _pontos;

    public GerenciadorDeMetas()
    {
        _metas = new List<Meta>();
        _pontos = 0;
    }

    public void Iniciar()
    {
        int opcao = 0;

        while (opcao != 6)
        {
            Console.WriteLine();
            ExibirInfoJogador();

            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("  1. Criar nova meta");
            Console.WriteLine("  2. Listar metas");
            Console.WriteLine("  3. Salvar metas");
            Console.WriteLine("  4. Carregar metas");
            Console.WriteLine("  5. Registrar evento");
            Console.WriteLine("  6. Sair");

            opcao = LerInteiro("Selecione uma opção: ");

            switch (opcao)
            {
                case 1:
                    CriarMeta();
                    break;
                case 2:
                    ListarDetalhesDasMetas();
                    break;
                case 3:
                    SalvarMetas();
                    break;
                case 4:
                    CarregarMetas();
                    break;
                case 5:
                    RegistrarEvento();
                    break;
                case 6:
                    Console.WriteLine("Até a próxima!");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    public void ExibirInfoJogador()
    {
        Console.WriteLine($"Você tem {_pontos} pontos.");
    }

    public void ListarNomesDasMetas()
    {
        Console.WriteLine("As metas são:");

        int numero = 1;
        foreach (Meta meta in _metas)
        {
            Console.WriteLine($"{numero}. {meta.ObterNome()}");
            numero++;
        }
    }

    public void ListarDetalhesDasMetas()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        Console.WriteLine("As metas são:");

        int numero = 1;
        foreach (Meta meta in _metas)
        {
            Console.WriteLine($"{numero}. {meta.ObterDetalhesEmTexto()}");
            numero++;
        }
    }

    public void CriarMeta()
    {
        Console.WriteLine("Os tipos de metas são:");
        Console.WriteLine("  1. Meta simples");
        Console.WriteLine("  2. Meta eterna");
        Console.WriteLine("  3. Meta de lista de tarefas");
        int tipo = LerInteiro("Qual tipo de meta você gostaria de criar? ");

        if (tipo < 1 || tipo > 3)
        {
            Console.WriteLine("Tipo inválido.");
            return;
        }

        Console.Write("Qual é o nome da sua meta? ");
        string nome = Console.ReadLine();

        Console.Write("Faça uma breve descrição dela: ");
        string descricao = Console.ReadLine();

        int pontos = LerInteiro("Quantos pontos esta meta vale? ");

        if (tipo == 1)
        {
            _metas.Add(new MetaSimples(nome, descricao, pontos));
        }
        else if (tipo == 2)
        {
            _metas.Add(new MetaEterna(nome, descricao, pontos));
        }
        else
        {
            int total = LerInteiro("Quantas vezes essa meta precisa ser cumprida para ganhar o bônus? ");
            int bonus = LerInteiro("Qual é o bônus por concluir essa meta? ");
            _metas.Add(new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus));
        }

        Console.WriteLine("Meta criada!");
    }

    public void RegistrarEvento()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        ListarNomesDasMetas();
        int escolha = LerInteiro("Qual meta você cumpriu? ");

        if (escolha < 1 || escolha > _metas.Count)
        {
            Console.WriteLine("Meta inválida.");
            return;
        }

        Meta meta = _metas[escolha - 1];
        int pontosGanhos = meta.RegistrarEvento();
        _pontos += pontosGanhos;

        Console.WriteLine($"Parabéns! Você ganhou {pontosGanhos} pontos.");
        Console.WriteLine($"Agora você tem {_pontos} pontos.");
    }

    public void SalvarMetas()
    {
        Console.Write("Qual é o nome do arquivo? ");
        string arquivo = Console.ReadLine();

        using (StreamWriter escritor = new StreamWriter(arquivo))
        {
            // A primeira linha guarda a pontuação
            escritor.WriteLine(_pontos);

            foreach (Meta meta in _metas)
            {
                escritor.WriteLine(meta.ObterRepresentacaoEmTexto());
            }
        }

        Console.WriteLine("Metas salvas!");
    }

    public void CarregarMetas()
    {
        Console.Write("Qual é o nome do arquivo? ");
        string arquivo = Console.ReadLine();

        if (!File.Exists(arquivo))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        string[] linhas = File.ReadAllLines(arquivo);

        if (linhas.Length == 0 || !int.TryParse(linhas[0], out int pontosCarregados))
        {
            Console.WriteLine("Arquivo inválido.");
            return;
        }

        List<Meta> metasCarregadas = new List<Meta>();

        for (int i = 1; i < linhas.Length; i++)
        {
            Meta meta = CriarMetaAPartirDoTexto(linhas[i]);
            if (meta != null)
            {
                metasCarregadas.Add(meta);
            }
        }

        // Só substitui os dados atuais depois de ler tudo com sucesso
        _pontos = pontosCarregados;
        _metas = metasCarregadas;

        Console.WriteLine("Metas carregadas!");
    }

    // Converte uma linha do arquivo de volta em um objeto Meta
    private Meta CriarMetaAPartirDoTexto(string linha)
    {
        int posicao = linha.IndexOf(':');
        if (posicao < 0)
        {
            return null;
        }

        string tipo = linha.Substring(0, posicao);
        string[] partes = linha.Substring(posicao + 1).Split('|');

        try
        {
            if (tipo == "MetaSimples" && partes.Length == 4)
            {
                return new MetaSimples(partes[0], partes[1], int.Parse(partes[2]), bool.Parse(partes[3]));
            }

            if (tipo == "MetaEterna" && partes.Length == 3)
            {
                return new MetaEterna(partes[0], partes[1], int.Parse(partes[2]));
            }

            if (tipo == "MetaDeListaDeTarefas" && partes.Length == 6)
            {
                return new MetaDeListaDeTarefas(
                    partes[0], partes[1], int.Parse(partes[2]),
                    int.Parse(partes[3]), int.Parse(partes[4]), int.Parse(partes[5]));
            }
        }
        catch (FormatException)
        {
            // Linha corrompida: ignora
        }

        return null;
    }

    // Repete a pergunta até o usuário digitar um número válido
    private int LerInteiro(string pergunta)
    {
        int valor;
        Console.Write(pergunta);

        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Digite um número válido: ");
        }

        return valor;
    }
}