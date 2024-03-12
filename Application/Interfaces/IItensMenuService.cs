using Domain.Models;

namespace Application.Interfaces
{
    public interface IItensMenuService : IDisposable
    {
        Task Adicionar(ItensMenu itemMenu);
        Task Atualizar(ItensMenu itemMenu);
        Task Remover(Guid id);
    }
}
