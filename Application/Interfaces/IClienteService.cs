using Domain.Models;

namespace Application.Interfaces
{
    public interface IClienteService : IDisposable
    {
        Task<bool> Adicionar(Clientes cliente);
        Task Atualizar(Clientes cliente);
        Task Remover(Guid id);
        Task AtualizarEndereco(Endereco endereco);
    }
}
