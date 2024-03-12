using Domain.Models;

namespace Application.Interfaces
{
    public interface IItensPedidoService : IDisposable
    {
        Task Adicionar(ItensPedido itensPedido);
        Task Atualizar(ItensPedido itensPedido);
        Task Remover(Guid id);
    }
}
