using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class ItensMenuService : BaseService , IItensMenuService
    {
        private readonly IItensMenuRepository _itensMenuRepository;
        public ItensMenuService(IItensMenuRepository itensMenuRepository, INotificador notificador ) : base( notificador )
        {
            _itensMenuRepository = itensMenuRepository;
        }

        public async Task Adicionar(ItensMenu itemMenu)
        {
            await _itensMenuRepository.Adicionar(itemMenu);
        }

        public async Task Atualizar(ItensMenu itemMenu)
        {
            await _itensMenuRepository.Atualizar(itemMenu);
        }

        public async Task Remover(Guid id)
        {
            await _itensMenuRepository.Remover(id);
        }
        public void Dispose()
        {
            _itensMenuRepository.Dispose();
        }
    }
}
