public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
    }

    public override int RegistrarEvento()
    {
        // Sempre concede pontos, a meta nunca termina
        return Pontos;
    }

    public override bool EstaConcluida()
    {
        return false;
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"MetaEterna:{Nome}|{Descricao}|{Pontos}";
    }
}