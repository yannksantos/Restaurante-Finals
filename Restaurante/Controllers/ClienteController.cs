using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteRepository clienteRepository, IClienteService clienteService) 
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<object> ListarClientes()
        {
            var cliente = await _clienteRepository.ObterTodos();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCliente(Guid id)
        {
            var cliente = await _clienteRepository.ObterClientePorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpGet(("/api/ObterCliente"))]
        public async Task<IActionResult> ObterClienteCpf(string cpf)
        {
            var cliente = await _clienteRepository.ObterClientePorCPF(cpf);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCliente(Clientes cliente)
        {
            try
            {
                var clienteAdicionado = await _clienteService.Adicionar(cliente);
                if (clienteAdicionado)
                {
                    return Ok(cliente);
                }
                else
                {
                    return BadRequest("Já existe cliente com esse CPF cadastrado");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCliente(Guid id, Clientes cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            await _clienteService.Atualizar(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarCliente(Guid id)
        {
            await _clienteService.Remover(id);
            return NoContent();
        }
    }
}
