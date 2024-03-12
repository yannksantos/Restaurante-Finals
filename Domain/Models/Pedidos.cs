using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Models
{
    [Table("Pedidos")]
    public class Pedidos : Entity
    {
        [Key]
        public Guid PedidosId { get; set; }

        public string NumeroPedido { get; set; }

        public Guid ClientesId { get; set; }
        [ForeignKey("ClientesId")]
        public virtual Clientes Cliente { get; set; }

        public Guid EntregadorId { get; set; }
        [ForeignKey("EntregadorId")]
        public virtual Entregador Entregador { get; set; }

        public decimal Total { get; set; }
        public PedidoEnum Status { get; set; }
        public virtual ICollection<ItensPedido> ItensPedido { get; set; }

        public string UserId { get; set; }
    }
}
