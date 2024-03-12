using Domain.Models;

namespace Domain.Interfaces
{
    public interface IItensMenuRepository : IRepository<ItensMenu>
    {
        Task<ItensMenu> ObterItemMenuPorId(Guid id);
        Task<IEnumerable<ItensMenu>> ObterTodosItensMenu();
    }
}
