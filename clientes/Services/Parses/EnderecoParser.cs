using clientes.Database.Models;
using clientes.Services.DTOs;

namespace clientes.Services.Parses
{
    public class EnderecoParser
    {
        // função estática auto-instancia um objeto
        public static TbEndereco ToTbEndereco(CriarEnderecoDTO dto)
        {
            //instanciando
            TbEndereco novoEndereco = new();

            //passando o que vem no dto que é as colunas da table endereco para o novoEndereco que foi instanciado
            novoEndereco.Logradouro = dto.logradouro;
            novoEndereco.Numero = dto.numero;
            novoEndereco.Bairro = dto.bairro;
            novoEndereco.Cidade = dto.cidade;
            novoEndereco.Uf = dto.uf;
            novoEndereco.Cep = dto.cep;
            novoEndereco.Complemento = dto.complemento;
            novoEndereco.Status = dto.status;
            return novoEndereco;
        }
        public static EnderecoDTO ToEnderecoDTO(TbEndereco endereco)
        {
            EnderecoDTO Response = new();
            Response.idcliente = endereco.Clienteid;
            Response.id = endereco.Id;
            Response.logradouro = endereco.Logradouro;
            Response.numero = endereco.Numero;
            Response.bairro = endereco.Bairro;
            Response.cidade = endereco.Cidade;
            Response.uf = endereco.Uf;
            Response.cep = endereco.Cep;
            Response.complemento = endereco.Complemento;
            Response.status = endereco.Status;
            return Response;
        }
    }
}
