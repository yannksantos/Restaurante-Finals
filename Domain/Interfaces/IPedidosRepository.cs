using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPedidosRepository : IRepository<Pedidos>
    {
        Task<Pedidos> ObterPedidoEmRota(Guid id);
        Task<IEnumerable<Pedidos>> ObterTodosPedidos(string userId);
        Task<IEnumerable<Pedidos>> ObterPedidosPorClienteId(Guid clienteId);
        Task<Clientes> ObterClientePorId(Guid id);
        Task<ItensPedido> ObterItemPedidoPorId(Guid id);
        Task<Entregador> ObterEntregadorPorId(Guid id);
    }
}
