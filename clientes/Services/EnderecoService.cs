using clientes.Database.Models;
using clientes.Services.DTOs;
using clientes.Services.Exceptions;
using clientes.Services.Parses;
using clientes.Services.Validations;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace clientes.Services
{
    public class EnderecoService
    {
        private readonly ClientesContext _dbcontext;

        public EnderecoService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public List<EnderecoDTO> Listar(int id)
        {
            List<EnderecoDTO> Response = new();
            var enderecos = _dbcontext.TbEnderecos.Where(e => e.Clienteid == id).ToList();
            foreach (var endereco in enderecos)
            {
                Response.Add(EnderecoParser.ToEnderecoDTO(endereco));
            }
            return Response;
        }

        public EnderecoDTO GetEnderecoById(int id, int idEndereco)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Clienteid == id && e.Id == idEndereco);
            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado");
            }
            return EnderecoParser.ToEnderecoDTO(endereco);
        }

        public EnderecoDTO Criar(int idcliente, CriarEnderecoDTO dto)
        {
            EnderecoValidation.ValidarCriarEndereco(dto);

            TbEndereco novoEndereco = EnderecoParser.ToTbEndereco(dto);
            
            novoEndereco.Clienteid = idcliente;
            
            _dbcontext.TbEnderecos.Add(novoEndereco);
            _dbcontext.SaveChanges();
            
            return EnderecoParser.ToEnderecoDTO(novoEndereco);

        }

        public void Deletar(int idEndereco)
        {
            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == idEndereco);
            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado");
            }

            _dbcontext.TbEnderecos.Remove(endereco);
            _dbcontext.SaveChanges();
        }

        public EnderecoDTO Atualizar(CriarEnderecoDTO dto, int id)
        {
            EnderecoValidation.ValidarCriarEndereco(dto);

            var endereco = _dbcontext.TbEnderecos.FirstOrDefault(e => e.Id == id);

            if (endereco == null)
            {
                throw new NotFoundException("Endereço não encontrado");
            }

            endereco.Logradouro = dto.logradouro;
            endereco.Numero = dto.numero;
            endereco.Bairro = dto.bairro;
            endereco.Cidade = dto.cidade;
            endereco.Uf = dto.uf;
            endereco.Cep = dto.cep;
            endereco.Complemento = dto.complemento;
            endereco.Status = dto.status;

            _dbcontext.SaveChanges();
            return EnderecoParser.ToEnderecoDTO(endereco);
        }
    }
}