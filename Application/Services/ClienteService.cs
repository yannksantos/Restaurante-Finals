using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ClienteService : BaseService , IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository, INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<bool> Adicionar(Clientes cliente)
        {
            if(_clienteRepository.Buscar(f => f.CPF == cliente.CPF).Result.Any())
            {
                Notificar("Ja existe cliente com esse CPF cadastrado");
                return false;
            };
            await _clienteRepository.Adicionar(cliente);

            return true;
        }

        public async Task Atualizar(Clientes cliente)
        {
            await _clienteRepository.Atualizar(cliente);
        }

        public async Task Remover(Guid id)
        {
            await _clienteRepository.Remover(id);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
             await _clienteRepository.Atualizar(endereco);

        }
        public void Dispose()
        {
            _clienteRepository.Dispose();
        }
    }
}
