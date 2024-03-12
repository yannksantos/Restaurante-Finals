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
    public class PedidosController : BaseController
    {
        private readonly IPedidosService _pedidoService;
        private readonly IPedidosRepository _pedidoRepository;

        public PedidosController(IPedidosService pedidoService, IPedidosRepository pedidoRepository) 
        {
            _pedidoService = pedidoService;
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        [Produces("application/json")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<object> ListarPedidos()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var pedidos = await _pedidoRepository.ObterTodosPedidos(userId);
            return Ok(pedidos);
        }


        [HttpGet("{id}")]
        [Produces("application/json")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> ObterPedido(Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        [Produces("application/json")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> AdicionarPedido(Pedidos pedido)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);
                pedido.UserId = userId;
                var addPedido =  await _pedidoService.Adicionar(pedido);
                if (addPedido)
                {
                    return Ok(pedido);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> AtualizarPedido(Guid id, Pedidos pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }
            await _pedidoService.Atualizar(pedido);
            return NoContent();
        }

        [HttpPut("{id}/em-rota")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> ColocarEmRota(Guid id , Pedidos pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }
            await _pedidoService.ColocarEmRota(pedido);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [Produces("application/json")]
        [Authorize(Roles = "Cliente , Admin")]
        public async Task<IActionResult> DeletarPedido(Guid id)
        {
            await _pedidoService.Remover(id);
            return NoContent();
        }


    }
}
