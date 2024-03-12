using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Clientes")]
    public class Clientes : Entity
    {
        [Key]
        public Guid IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public Guid EnderecoId { get; set; }
        [ForeignKey("EnderecoId")]
        public virtual Endereco Endereco { get; set; }
    }
}
