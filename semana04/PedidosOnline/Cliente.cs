using System;

 public class Cliente
    {
        private string _nome;
        private Endereco _endereco;

        public Cliente(string nome, Endereco endereco)
        {
            _nome = nome;
            _endereco = endereco;
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public Endereco Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        
        public bool MoraNosEUA()
        {
            return _endereco.EhNosEUA();
        }
    }
