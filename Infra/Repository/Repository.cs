using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity , new()
    {
        protected ContextBase _context;
        protected DbSet<TEntity>? _dbSet;

        public Repository(ContextBase context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task<bool> Adicionar(TEntity id)
        {
            try
            {
                _context.Add(id);
                await SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false ;
            }
        }

        public async Task Remover(Guid id)
        {
            var transaction = _context.Database.BeginTransaction();

            try
            {
                // Desativar a restrição de chave estrangeira temporariamente
                await _context.Database.ExecuteSqlRawAsync("ALTER TABLE ItensPedido NOCHECK CONSTRAINT FK_ItensPedido_Pedidos_PedidosId");

                // Excluir o pedido
                var pedido = await _dbSet.FindAsync(id);
                if (pedido != null)
                {
                    _context.Remove(pedido);
                    await _context.SaveChangesAsync();
                }

                // Reativar a restrição de chave estrangeira
                await _context.Database.ExecuteSqlRawAsync("ALTER TABLE ItensPedido CHECK CONSTRAINT FK_ItensPedido_Pedidos_PedidosId");

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task Atualizar(Entity entity)
        {
            _context.Update(entity);
            await SaveChanges();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }   

        public async void Dispose()
        {
            _context.Dispose();
        }
    }
}
