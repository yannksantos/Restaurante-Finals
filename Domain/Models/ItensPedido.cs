using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("ItensPedido")]
    public class ItensPedido : Entity
    {
        [Key]
        public Guid IdItensPedido { get; set; }
        public Guid PedidoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public string UserId { get; set; }
    }
}
