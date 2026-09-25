using System;
using System.Collections.Generic;
using System.Text;


 public class Pedido
    {
        private const double CUSTO_ENVIO_EUA = 5.0;
        private const double CUSTO_ENVIO_INTERNACIONAL = 35.0;

        private List<Produto> _produtos;
        private Cliente _cliente;

        public Pedido(Cliente cliente)
        {
            _cliente = cliente;
            _produtos = new List<Produto>();
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public List<Produto> Produtos
        {
            get { return _produtos; }
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        private double CalcularCustoEnvio()
        {
            if (_cliente.MoraNosEUA())
            {
                return CUSTO_ENVIO_EUA;
            }
            else
            {
                return CUSTO_ENVIO_INTERNACIONAL;
            }
        }

        public double CalcularCustoTotal()
        {
            double total = 0;
            foreach (Produto produto in _produtos)
            {
                total += produto.CalcularCustoTotal();
            }
            total += CalcularCustoEnvio();
            return total;
        }

        public string ObterEtiquetaEmbalagem()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--- Etiqueta de Embalagem ---");
            foreach (Produto produto in _produtos)
            {
                sb.AppendLine($"Produto: {produto.Nome} (ID: {produto.IdProduto})");
            }
            return sb.ToString();
        }

        public string ObterEtiquetaEnvio()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--- Etiqueta de Envio ---");
            sb.AppendLine(_cliente.Nome);
            sb.AppendLine(_cliente.Endereco.RetornarEnderecoCompleto());
            return sb.ToString();
        }
     }
