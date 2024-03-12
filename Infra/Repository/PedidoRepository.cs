using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class PedidoRepository : Repository<Pedidos> , IPedidosRepository
    {
        public PedidoRepository(ContextBase context) : base(context) { }

        public async Task<Pedidos> ObterPedidoEmRota(Guid id)
        {
            return await _context.Pedidos
                .Include(p => p.Entregador)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedidos>> ObterTodosPedidos(string userId)
        {
            return await _context.Pedidos
                .Include( c => c.Cliente)
                .ThenInclude( c => c.Endereco)
                .Include(c => c.Entregador)
                .Include( c => c.ItensPedido)
                .AsNoTracking()
                .Where(i => i.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pedidos>> ObterPedidosPorClienteId(Guid clienteId)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .ThenInclude(p => p.Endereco)
                .AsNoTracking()
                .Where(p => p.Cliente.Id == clienteId)
                .ToListAsync();
        }

        public async Task<Clientes> ObterClientePorId(Guid id)
        {
            return await _context.Cliente
                .Include( c => c.Endereco)
                .FirstOrDefaultAsync(c => c.IdCliente == id);
        }

        public async Task<ItensPedido> ObterItemPedidoPorId(Guid id)
        {
            return await _context.ItensPedido
                .FirstOrDefaultAsync(c => c.IdItensPedido == id);
        }

        public async Task<Entregador> ObterEntregadorPorId(Guid id)
        {
            return await _context.Entregador
                .FirstOrDefaultAsync(c => c.IdEntregador == id);
        }
    }
}
