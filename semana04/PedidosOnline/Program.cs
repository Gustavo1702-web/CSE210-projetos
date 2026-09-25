using System;

class Program
    {
        static void Main(string[] args)
        {
            // ----- Pedido 1: cliente nos EUA -----
            Endereco enderecoJoao = new Endereco(
                "Rua das Flores, 123",
                "Austin",
                "TX",
                "EUA"
            );
            Cliente joao = new Cliente("João Silva", enderecoJoao);

            Pedido pedido1 = new Pedido(joao);
            pedido1.AdicionarProduto(new Produto("Fone de Ouvido Bluetooth", "P-1001", 89.90, 1));
            pedido1.AdicionarProduto(new Produto("Cabo USB-C", "P-1002", 15.50, 3));
            pedido1.AdicionarProduto(new Produto("Suporte para Notebook", "P-1003", 45.00, 1));

            // ----- Pedido 2: cliente fora dos EUA -----
            Endereco enderecoMaria = new Endereco(
                "Av. Jose Cardoso, 1000",
                "São Paulo",
                "SP",
                "Brasil"
            );
            Cliente maria = new Cliente("Maria Souza", enderecoMaria);

            Pedido pedido2 = new Pedido(maria);
            pedido2.AdicionarProduto(new Produto("Teclado Mecânico", "P-2001", 250.00, 1));
            pedido2.AdicionarProduto(new Produto("Mouse Sem Fio", "P-2002", 60.00, 2));

            // ----- Exibindo os resultados -----
            ExibirPedido("PEDIDO 1", pedido1);
            ExibirPedido("PEDIDO 2", pedido2);
        }

        static void ExibirPedido(string titulo, Pedido pedido)
        {
            Console.WriteLine("");
            Console.WriteLine(titulo);
            Console.WriteLine("");

            Console.WriteLine(pedido.ObterEtiquetaEmbalagem());
            Console.WriteLine(pedido.ObterEtiquetaEnvio());

            Console.WriteLine($"Preço Total: {pedido.CalcularCustoTotal():C2}");
            Console.WriteLine();
        }
    }
