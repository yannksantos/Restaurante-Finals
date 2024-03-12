using Application.Interfaces;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class PedidoService : BaseService , IPedidosService
    {
        private readonly IPedidosRepository _pedidosRepository;
        public PedidoService(IPedidosRepository pedidosRepository, INotificador notificador) : base(notificador)
        {
            _pedidosRepository = pedidosRepository;
        }

        public async Task<bool> Adicionar(Pedidos pedidos)
        {
            var clienteExistente = await _pedidosRepository.ObterClientePorId(pedidos.Cliente.IdCliente);

            if (clienteExistente == null)
            {
                Notificar("Nao existe cliente com esse CPF cadastrado");
                return false;
            }

            var itensExistentes = new List<ItensPedido>();

            foreach (var item in pedidos.ItensPedido)
            {
                var itemExistente = await _pedidosRepository.ObterItemPedidoPorId(item.IdItensPedido);

                if (itemExistente == null)
                {
                    Notificar("Nao existe item com esse ID cadastrado");
                    return false;
                }

                itensExistentes.Add(itemExistente);
            }

            var entregadorExistente = await _pedidosRepository.ObterEntregadorPorId(pedidos.Entregador.IdEntregador);

            if (entregadorExistente == null)
            {
                Notificar("Nao existe entregador cadastrado");
                return false;
            }

            pedidos.Cliente = clienteExistente;
            pedidos.ItensPedido = itensExistentes;
            pedidos.Entregador = entregadorExistente;

            pedidos.Status = PedidoEnum.Iniciado;
            var pedidosAdd = await _pedidosRepository.Adicionar(pedidos);
            if (pedidosAdd)
            {
                return true;
            }
            return false;
        }



        public async Task Atualizar(Pedidos pedidos)
        {
            await _pedidosRepository.Atualizar(pedidos);
        }

        public async Task Remover(Guid id)
        {
            await _pedidosRepository.Remover(id);
        }

        public async Task ColocarEmRota(Pedidos pedidos)
        {
            if (pedidos.Status != PedidoEnum.Iniciado)
            pedidos.Status = PedidoEnum.EmRota;
            await _pedidosRepository.Atualizar(pedidos);
        }

        public void Dispose()
        {
            _pedidosRepository.Dispose();
        }
    }
}
