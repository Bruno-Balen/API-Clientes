using clientes.Database.Models;
using clientes.Services;
using clientes.Services.DTOs;
using clientes.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ClientesService _service;


        public ClientesController(ClientesService service)
        {
            _service = service;
        }


        [HttpPost]
        public ActionResult<ClienteDTO> Adicionar([FromBody] CriarClienteDTO body)
        {

            try
            {
                var Response = _service.Criar(body);

                return Ok(Response); //200
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message); //400
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message); //500
            }


        }

        [HttpGet]
        public ActionResult<List<ClienteDTO>> Listar()
        {
            try
            {
                var Response = _service.Listar();
                return Ok(Response); //200
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message); //400
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message); //500
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDTO> ListarPorId(int id)
        {
            try
            {
                var Response = _service.GetClientesById(id);
                return Ok(Response);
            }
            catch (NotFoundException C)
            {
                return NotFound(C.Message); //404
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message); //400
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message); //500
            }

        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            try
            {
                _service.DeletarCliente(id);
                return NoContent();
            }
            catch (NotFoundException C)
            {
                return NotFound(C.Message); //404
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message); //400
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message); //500
            }


        }

        [HttpPut("{id}")]

        public ActionResult<ClienteDTO> Atualizar(int id, [FromBody] CriarClienteDTO body)
        {
            try
            {
                var Response = _service.Atualizar(body, id);
                return Ok(Response); //200
            }
            catch (NotFoundException C)
            {
                return NotFound(C.Message); //404
            }
            catch (BadRequestException B)
            {
                return BadRequest(B.Message); //400
            }
            catch (System.Exception E)
            {
                return BadRequest(E.Message); //500
            }
        }

    }
}
