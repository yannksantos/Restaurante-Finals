using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class EntregadorRepositort : Repository<Entregador> , IEntregadorRepository
    {
        public EntregadorRepositort(ContextBase context) : base(context) { }

        public async Task<Entregador> ObterEntregador(Guid id)
        {
            return await _context.Entregador
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Entregador> ObterEntregadorEmRota(Guid id)
        {
            return await _context.Entregador
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
