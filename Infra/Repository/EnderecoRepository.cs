using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{  
    public class EnderecoRepository : Repository<Endereco> , IEnderecoRepository
    {
        public EnderecoRepository(ContextBase context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorId(Guid id)
        {
            return await _context.Endereco
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Endereco>> ObterTodosEndereco()
        {
            return await _context.Endereco
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
 