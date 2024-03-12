using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("ItensMenu")]
    public class ItensMenu : Entity
    {
        [Key]
        public Guid IdItensMenu { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

    }
}
