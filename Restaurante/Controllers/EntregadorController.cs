using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregadorController : BaseController
    {
        private readonly IEntregadorRepository _entregadorRepository;
        private readonly IEntregadorService _entregadorService;
        public EntregadorController(IEntregadorRepository entregadorRepository, IEntregadorService entregadorService) 
        {
            _entregadorRepository = entregadorRepository;
            _entregadorService = entregadorService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<object> ListarEntregadores()
        {
            var cliente = await _entregadorRepository.ObterTodos();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedido(Guid id)
        {
            var entregador = await _entregadorRepository.ObterPorId(id);
            if (entregador == null)
            {
                return NotFound();
            }
            return Ok(entregador);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEntregador(Entregador entregador)
        {
            try
            {
                await _entregadorService.Adicionar(entregador);
                return Ok(entregador);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEntregador(Guid id, Entregador entregador)
        {
            if (id != entregador.Id)
            {
                return BadRequest();
            }
            await _entregadorService.Atualizar(entregador);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPedido(Guid id)
        {
            await _entregadorService.Remover(id);
            return NoContent();
        }
    }
}
