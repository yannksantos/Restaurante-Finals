using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class ClienteRepository : Repository<Clientes> , IClienteRepository 
    {
        public ClienteRepository(ContextBase context) : base(context) { }

        public async Task<Clientes> ObterClientePorId(Guid id)
        {
            return await _context.Cliente
                .Include(c => c.Endereco)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.IdCliente == id);
        }

        public async Task<Clientes> ObterClientePorCPF(string cpf)
        {
            return await _context.Cliente
                .Include(c => c.Endereco)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CPF == cpf);
        }
    }
}
