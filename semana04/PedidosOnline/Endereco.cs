using System;


 public class Endereco
    {
        private string _rua;
        private string _cidade;
        private string _estado;
        private string _pais;

        public Endereco(string rua, string cidade, string estado, string pais)
        {
            _rua = rua;
            _cidade = cidade;
            _estado = estado;
            _pais = pais;
        }

        public string Rua
        {
            get { return _rua; }
            set { _rua = value; }
        }

        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }

        public bool EhNosEUA()
        {
            string paisNormalizado = _pais.Trim().ToLower();
            return paisNormalizado == "eua" ||
                   paisNormalizado == "usa" ||
                   paisNormalizado == "estados unidos" ||
                   paisNormalizado == "united states" ||
                   paisNormalizado == "united states of america";
        }

        public string RetornarEnderecoCompleto()
        {
            return _rua + "\n" +
                   _cidade + ", " + _estado + "\n" +
                   _pais;
        }
    }
