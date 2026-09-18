using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Escritura> biblioteca = CriarBiblioteca();

        Random random = new Random();
        Escritura escritura = biblioteca[random.Next(biblioteca.Count)];

        const int palavrasParaOcultarPorRodada = 3;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(escritura.ObterTexto());
            Console.WriteLine("Pressione Enter para continuar ou digite 'sair' para encerrar.");
            string entrada = Console.ReadLine();

            if (entrada != null && entrada.Trim().ToLower() == "sair")
            {
                break;
            }

            escritura.OcultarPalavrasAleatorias(palavrasParaOcultarPorRodada);

            if (escritura.EstaCompletamenteOculta())
            {
                Console.Clear();
                Console.WriteLine(escritura.ObterTexto());
                Console.WriteLine("Todas as palavras foram escondidas. Fim do programa!");
                break;
            }
        }
    }

    
    static List<Escritura> CriarBiblioteca()
    {
        List<Escritura> biblioteca = new List<Escritura>();

        biblioteca.Add(new Escritura(
            new Referencia("João", 3, 16),
            "Porque Deus amou o mundo de tal maneira que deu o seu Filho unigênito, para que todo aquele que nele crê não pereça, mas tenha a vida eterna."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("Provérbios", 3, 5, 6),
            "Confia no Senhor de todo o teu coração, e não te estribes no teu próprio entendimento. Reconhece-o em todos os teus caminhos, e ele endireitará as tuas veredas."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("Filipenses", 4, 13),
            "Posso todas as coisas naquele que me fortalece."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("Josué", 1, 9),
            "Não to mandei eu? Esforça-te, e tem bom ânimo; não temas, nem te espantes; porque o Senhor teu Deus é contigo, por onde quer que andares."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("Salmos", 23, 1),
            "O Senhor é o meu pastor, nada me faltará."
        ));

        // Escrituras do Livro de Mórmon
        biblioteca.Add(new Escritura(
            new Referencia("2 Néfi", 2, 25),
            "Adão caiu para que os homens existissem; e os homens existem para que tenham alegria."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("2 Néfi", 32, 3),
            "Pois eis que, novamente vos digo que, se entrardes pelo caminho e receberdes o Espírito Santo, ele vos mostrará todas as coisas que deveis fazer."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("Mosias", 2, 17),
            "Quando estiverdes a serviço de vosso proximo, estareis apenas a serviço de vosso Deus."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("Alma", 37, 6),
            "Por meios de coisas pequenas e simples, o Senhor pode realizar grandes coisas."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("Éter", 12, 6),
            "A fé não é ter conhecimento perfeito das coisas; portanto, se tendes fé, tendes esperança de coisas que não se veem, mas que são verdadeiras."
        ));

        biblioteca.Add(new Escritura(
            new Referencia("Morôni", 10, 4, 5),
            "E quando receberdes estas coisas, desejo exortar-vos a perguntar a Deus, o Pai Eterno, em nome de Cristo, se estas coisas não são verdadeiras; e se pedirdes com um coração sincero, com verdadeira intenção, tendo fé em Cristo, ele vos manifestará a verdade delas, pelo poder do Espírito Santo. E pelo poder do Espírito Santo podereis saber a verdade de todas as coisas."
        ));

        return biblioteca;
    }
}