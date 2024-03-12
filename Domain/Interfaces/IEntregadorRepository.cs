using Domain.Models;

namespace Domain.Interfaces
{
    public interface IEntregadorRepository : IRepository<Entregador>
    {
        Task<Entregador> ObterEntregador(Guid id);
        Task<Entregador> ObterEntregadorEmRota(Guid id);
    }
}
