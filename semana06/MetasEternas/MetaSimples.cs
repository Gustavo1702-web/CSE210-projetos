public class MetaSimples : Meta
{
    private bool _estaConcluida;

    // Construtor para criar uma meta nova
    public MetaSimples(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
        _estaConcluida = false;
    }

    // Construtor para carregar uma meta salva em arquivo
    public MetaSimples(string nome, string descricao, int pontos, bool estaConcluida)
        : base(nome, descricao, pontos)
    {
        _estaConcluida = estaConcluida;
    }

    public override int RegistrarEvento()
    {
        // Só concede pontos na primeira vez
        if (_estaConcluida)
        {
            return 0;
        }

        _estaConcluida = true;
        return Pontos;
    }

    public override bool EstaConcluida()
    {
        return _estaConcluida;
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"MetaSimples:{Nome}|{Descricao}|{Pontos}|{_estaConcluida}";
    }
}