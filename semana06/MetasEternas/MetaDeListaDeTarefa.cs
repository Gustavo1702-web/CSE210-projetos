public class MetaDeListaDeTarefas : Meta
{
    private int _concluidas;
    private int _total;
    private int _bonus;

    // Construtor para criar uma meta nova
    public MetaDeListaDeTarefas(string nome, string descricao, int pontos, int total, int bonus)
        : base(nome, descricao, pontos)
    {
        _concluidas = 0;
        _total = total;
        _bonus = bonus;
    }

    // Construtor para carregar uma meta salva em arquivo
    public MetaDeListaDeTarefas(string nome, string descricao, int pontos, int total, int bonus, int concluidas)
        : base(nome, descricao, pontos)
    {
        _concluidas = concluidas;
        _total = total;
        _bonus = bonus;
    }

    public override int RegistrarEvento()
    {
        // Meta já concluída: não concede mais pontos
        if (EstaConcluida())
        {
            return 0;
        }

        _concluidas++;

        // Na última vez, além dos pontos normais, vem o bônus
        if (EstaConcluida())
        {
            return Pontos + _bonus;
        }

        return Pontos;
    }

    public override bool EstaConcluida()
    {
        return _concluidas >= _total;
    }

    public override string ObterDetalhesEmTexto()
    {
        return $"{base.ObterDetalhesEmTexto()} -- Concluída {_concluidas}/{_total} vezes";
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"MetaDeListaDeTarefas:{Nome}|{Descricao}|{Pontos}|{_total}|{_bonus}|{_concluidas}";
    }
}