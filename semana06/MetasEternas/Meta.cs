public abstract class Meta
{
    private string _nome;
    private string _descricao;
    private int _pontos;

    public Meta(string nome, string descricao, int pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
    }

    protected string Nome => _nome;
    protected string Descricao => _descricao;
    protected int Pontos => _pontos;

    // Público para o GerenciadorDeMetas listar os nomes
    public string ObterNome()
    {
        return _nome;
    }

    public abstract int RegistrarEvento();
    public abstract bool EstaConcluida();
    public abstract string ObterRepresentacaoEmTexto();

    public virtual string ObterDetalhesEmTexto()
    {
        string marca = EstaConcluida() ? "X" : " ";
        return $"[{marca}] {_nome} ({_descricao})";
    }
}