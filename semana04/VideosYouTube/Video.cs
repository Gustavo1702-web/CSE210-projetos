using System.Collections.Generic;

public class Video
{
    private string _titulo;
    private string _autor;
    private int _duracaoEmSegundos;
    private List<Comentario> _comentarios = new List<Comentario>();

    public Video(string titulo, string autor, int duracaoEmSegundos)
    {
        _titulo = titulo;
        _autor = autor;
        _duracaoEmSegundos = duracaoEmSegundos;
    }

    public string ObterTitulo()
    {
        return _titulo;
    }

    public string ObterAutor()
    {
        return _autor;
    }

    public int ObterDuracaoEmSegundos()
    {
        return _duracaoEmSegundos;
    }

    public void AdicionarComentario(Comentario comentario)
    {
        _comentarios.Add(comentario);
    }

    public List<Comentario> ObterComentarios()
    {
        return _comentarios;
    }

    public int ObterNumeroDeComentarios()
    {
        return _comentarios.Count;
    }
}