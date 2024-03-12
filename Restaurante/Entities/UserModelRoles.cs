using Domain.Models;

namespace Restaurante.Entities
{
    public class UserModelRoles
    {
        public ApplicationUser User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
