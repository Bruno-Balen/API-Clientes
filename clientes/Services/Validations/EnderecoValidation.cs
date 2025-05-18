using clientes.Services.DTOs;
using clientes.Services.Exceptions;

namespace clientes.Services.Validations
{
    public class EnderecoValidation
    {
        public static void ValidarCriarEndereco(CriarEnderecoDTO criarEnderecoDTO)
        {
            if (string.IsNullOrEmpty(criarEnderecoDTO.logradouro))
                throw new BadRequestException("Logradouro é Obrigatório");

            if (string.IsNullOrEmpty(criarEnderecoDTO.numero))
                throw new BadRequestException("Número é Obrigatório");

            if (string.IsNullOrEmpty(criarEnderecoDTO.cidade))
                throw new BadRequestException("Cidade é Obrigatório");
            
            if (string.IsNullOrEmpty(criarEnderecoDTO.uf))
                throw new BadRequestException("UF é Obrigatório");

            if (string.IsNullOrEmpty(criarEnderecoDTO.bairro))
                throw new BadRequestException("Bairro é Obrigatório");

            if (criarEnderecoDTO.cep < 0)
                throw new BadRequestException("CEP é obrigatório");

        }

    }
}
