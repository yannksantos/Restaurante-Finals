using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Endereco")]
    public class Endereco : Entity
    {
        [Key]
        public Guid IdEndereco { get; set; }
        public string Rua { get; set; }
        public string NumeroCasa { get; set; }
        public string CEP { get; set; }
    }
}
