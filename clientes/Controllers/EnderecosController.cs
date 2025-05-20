using clientes.Services;
using clientes.Services.DTOs;
using clientes.Services.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace clientes.Controllers
{
    [Route("api/Clientes/{id}/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly EnderecoService _service;

        public EnderecosController(EnderecoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<EnderecoDTO>> GetEnderecos(int id)
        {
            try
            {
                var Response = _service.GetEnderecos(id);
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

        [HttpGet("{idEndereco}")]
        public ActionResult<EnderecoDTO> GetEnderecoById(int id, int idEndereco)
        {
            try
            {
                var Response = _service.GetEnderecoById(id, idEndereco);
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

        [HttpPost]
        public ActionResult<EnderecoDTO> PostEndereco(int id, [FromBody] CriarEnderecoDTO body)
        {
            try
            {
                var Response = _service.PostEndereco(id, body);
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


        [HttpDelete]
        public ActionResult DeleteEndereco(int id, int idEndereco)
        {
            try
            {
                _service.DeleteEndereco(idEndereco);
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

        [HttpPut]
        public ActionResult<EnderecoDTO> PutEndereco(int id, int idEndereco, [FromBody] CriarEnderecoDTO body)
        {
            try
            {
                var Response = _service.PutEndereco(body, idEndereco);
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
