using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ItensMenuRepository : Repository<ItensMenu> , IItensMenuRepository
    {
        public ItensMenuRepository(ContextBase context) : base(context) { }

        public async Task<ItensMenu> ObterItemMenuPorId(Guid id)
        {
            return await _context.ItensMenu
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<ItensMenu>> ObterTodosItensMenu()
        {
            return await _context.ItensMenu
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
