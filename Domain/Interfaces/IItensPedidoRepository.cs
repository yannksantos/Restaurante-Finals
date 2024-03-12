using Domain.Models;

namespace Domain.Interfaces
{
    public interface IItensPedidoRepository  : IRepository<ItensPedido>
    {
        Task<IEnumerable<ItensPedido>> ObterTodosItensPedido(string userId);
        Task<ItensPedido> ObterItensPedidoPorPedidoId(Guid pedidoId);
    }
}
