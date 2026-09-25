using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Cria os vídeos
        Video video1 = new Video("Como lavar o carro em casa", "Garagem do Marcos", 645);
        video1.AdicionarComentario(new Comentario("Ana", "Ótima dica, não sabia que dava para usar só um balde."));
        video1.AdicionarComentario(new Comentario("Bruno", "Posso usar detergente comum ou precisa ser shampoo automotivo?"));
        video1.AdicionarComentario(new Comentario("Carla", "Meu carro ficou brilhando, obrigada!"));
        video1.AdicionarComentario(new Comentario("Diego", "Qual o melhor pano para secar sem riscar?"));

        Video video2 = new Video("Receita de pão caseiro", "Cozinha da Vovó", 512);
        video2.AdicionarComentario(new Comentario("Diego", "Fiz hoje e ficou perfeito."));
        video2.AdicionarComentario(new Comentario("Elisa", "Posso usar fermento biológico seco?"));
        video2.AdicionarComentario(new Comentario("Fábio", "Melhor receita que já vi."));
        video2.AdicionarComentario(new Comentario("Gabi", "Meu pão não cresceu, alguma dica?"));

        Video video3 = new Video("Como fazer uma pipa", "Oficina do Zé", 380);
        video3.AdicionarComentario(new Comentario("Hugo", "Fiz com meu filho e ele adorou!"));
        video3.AdicionarComentario(new Comentario("Isabela", "Dá para usar sacola plástica no lugar do papel de seda?"));
        video3.AdicionarComentario(new Comentario("João", "Qual o melhor tamanho de vareta?"));
        video3.AdicionarComentario(new Comentario("Karina", "Minha pipa não subiu, o rabo estava curto?"));

        // Coloca os vídeos em uma lista
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Percorre a lista e exibe as informações
       foreach (Video video in videos)
        {
            Console.WriteLine($"Título: {video.ObterTitulo()}");
            Console.WriteLine($"Autor: {video.ObterAutor()}");
            Console.WriteLine($"Duração: {video.ObterDuracaoEmSegundos()} segundos");
            Console.WriteLine($"Número de comentários: {video.ObterNumeroDeComentarios()}");
            Console.WriteLine("Comentários:");

            foreach (Comentario comentario in video.ObterComentarios())
            {
                Console.WriteLine($"  - {comentario.ObterNome()}: {comentario.ObterTexto()}");
            }

            Console.WriteLine();
        }
    }
}


