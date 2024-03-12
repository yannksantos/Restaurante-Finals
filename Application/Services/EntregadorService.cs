using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class EntregadorService : BaseService , IEntregadorService

    {
        private readonly IEntregadorRepository _entregadorRepository;
        public EntregadorService(IEntregadorRepository entregadorRepository, INotificador notificador ) : base(notificador)
        {
            _entregadorRepository = entregadorRepository;
        }

        public async Task Adicionar(Entregador entregador)
        {
            if (!_entregadorRepository.Buscar(f => f.CPF == entregador.CPF).Result.Any())
            {
                Notificar("Ja existe entregador com esse CPF cadastrado");
            }
            await _entregadorRepository.Adicionar(entregador);
        }

        public async Task Atualizar(Entregador entregador)
        {
            if(entregador is null) Notificar("Entregador é nulo");
            await _entregadorRepository.Atualizar(entregador);
        }

        public async Task Remover(Guid id)
        {
            await _entregadorRepository.Remover(id);
        }
        public void Dispose()
        {
            _entregadorRepository.Dispose();
        }
    }
}
