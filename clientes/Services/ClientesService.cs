using api_clientes.Services.Parses;
using clientes.Database.Models;
using clientes.Services.DTOs;
using clientes.Services.Exceptions;
using clientes.Services.Validations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.ResponseCaching;
using System;
using System.Collections.Generic;
using System.Linq;

namespace clientes.Services
{
    public class ClientesService
    {

        private readonly ClientesContext _dbcontext;

        public ClientesService(ClientesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public ClienteDTO Criar(CriarClienteDTO dto)
        {

            ClienteValidation.ValidarCriarCliente(dto);

            TbCliente novoCliente = ClienteParser.ToTbCliente(dto);


            _dbcontext.TbClientes.Add(novoCliente);
            _dbcontext.SaveChanges();


            return ClienteParser.ToClienteDTO(novoCliente);

        }

        public List<ClienteDTO> Listar()
        {
            List<ClienteDTO> Response = new();
            var clientes = _dbcontext.TbClientes.ToList();
            foreach (var cliente in clientes)
            {
                Response.Add(ClienteParser.ToClienteDTO(cliente));
            }
            return Response;
        }

        public ClienteDTO GetClientesById(int id)
        {
            TbCliente Response = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (Response == null)
                throw new NotFoundException("Cliente não encontrado");


            ClienteDTO cliente = ClienteParser.ToClienteDTO(Response);

            return cliente;
        }

        public void DeletarCliente(int id)
        {

            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado");
            _dbcontext.TbClientes.Remove(cliente);
            _dbcontext.SaveChanges();
        }

        public ClienteDTO Atualizar(CriarClienteDTO dto, int id)
        {
            ClienteValidation.ValidarCriarCliente(dto);

            var cliente = _dbcontext.TbClientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado");

            cliente.Nome = dto.Nome;
            cliente.Telefone = dto.Telefone;
            cliente.Nascimento = dto.Nascimento;
            cliente.Documento = dto.Documento;
            cliente.Tipodoc = dto.Tipodoc;
            cliente.Alteradoem = DateTime.Now.ToUniversalTime();
            _dbcontext.SaveChanges();
            return ClienteParser.ToClienteDTO(cliente);
        }

    }
}
