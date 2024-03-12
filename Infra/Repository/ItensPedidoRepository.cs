using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ItensPedidoRepository : Repository<ItensPedido> , IItensPedidoRepository
    {
        public ItensPedidoRepository(ContextBase context) : base(context) { }
             
        public async Task<IEnumerable<ItensPedido>> ObterTodosItensPedido(string userId)
        {
            return await _context.ItensPedido
                .AsNoTracking()
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

        public async Task<ItensPedido> ObterItensPedidoPorPedidoId(Guid pedidoId)
        {
            return await _context.ItensPedido
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.IdItensPedido == pedidoId);
        }

    }
}
