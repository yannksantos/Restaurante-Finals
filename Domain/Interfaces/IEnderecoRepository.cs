using Domain.Models;

namespace Domain.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorId(Guid id);
        Task<IEnumerable<Endereco>> ObterTodosEndereco();
    }
}
