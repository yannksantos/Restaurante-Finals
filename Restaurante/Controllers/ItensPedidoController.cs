using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidoController : BaseController
    {
        private readonly IItensPedidoRepository _itensPedidoRepository;
        private readonly IItensPedidoService _itensPedidoService;
        public ItensPedidoController(IItensPedidoRepository itensPedidoRepository, IItensPedidoService itensPedidoService) 
        {
            _itensPedidoRepository = itensPedidoRepository;
            _itensPedidoService = itensPedidoService;
        }


        [HttpGet]
        [Produces("application/json")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> ListarItensPedidos()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var itensPedido = await _itensPedidoRepository.ObterTodosItensPedido(userId);
            return Ok(itensPedido);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> ObterItensPedido(Guid id)
        {
            var itensPedido = await _itensPedidoRepository.ObterItensPedidoPorPedidoId(id);
            if (itensPedido == null)
            {
                return NotFound();
            }
            return Ok(itensPedido);
        }

        [HttpPost]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> AdicionarItensPedido(ItensPedido itensPedido)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);
                    
                itensPedido.UserId = userId;

                await _itensPedidoService.Adicionar(itensPedido);
                return Ok(itensPedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> AtualizarItensPedido(Guid id, ItensPedido itensPedido)
        {
            if (id != itensPedido.Id)
            {
                return BadRequest();
            }
            await _itensPedidoService.Atualizar(itensPedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> DeletarItensPedido(Guid id)
        {
            await _itensPedidoService.Remover(id);
            return NoContent();
        }
    }
}
