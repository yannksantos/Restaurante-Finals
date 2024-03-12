using Domain.Models;

namespace Application.Interfaces
{
    public interface IPedidosService : IDisposable
    {
        Task<bool> Adicionar(Pedidos pedidos);
        Task Atualizar(Pedidos pedidos);
        Task Remover(Guid id);
        Task ColocarEmRota (Pedidos pedidos);
    }
}
