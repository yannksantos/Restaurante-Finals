using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ItensPedidoService : BaseService , IItensPedidoService
    {
        private readonly IItensPedidoRepository _itensPedidoRepository;
        public ItensPedidoService(IItensPedidoRepository itensPedidoRepository, INotificador notificador ) : base ( notificador )
        {
            _itensPedidoRepository = itensPedidoRepository;
        }

        public async Task Adicionar(ItensPedido itensPedido)
        {
            await _itensPedidoRepository.Adicionar(itensPedido);
        }

        public async Task Atualizar(ItensPedido itensPedido)
        {
            await _itensPedidoRepository.Atualizar(itensPedido);
        }

        public async Task Remover(Guid id)
        {
            await _itensPedidoRepository.Remover(id);
        }

        public void Dispose()
        {
            _itensPedidoRepository.Dispose();
        }
    }
}
