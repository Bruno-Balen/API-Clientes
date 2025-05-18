using System;

namespace clientes.Services.DTOs
{

    public class CriarEnderecoDTO
    {
        public string cidade { get; set; }

        public string bairro { get; set; }

        public string uf { get; set; }

        public string complemento { get; set; }

        public string logradouro { get; set; }

        public string numero { get; set; }

        public int status { get; set; }

        public int cep { get; set; }
    }


    public class EnderecoDTO
    {
        public int id { get; set; }

        public int idcliente { get; set; }

        public string cidade { get; set; }

        public string bairro { get; set; }

        public string uf { get; set; }

        public string complemento { get; set; }

        public string logradouro { get; set; }

        public string numero { get; set; }

        public int status { get; set; }

        public int cep { get; set; }
    }

}
