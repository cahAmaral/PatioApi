using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatioApi.Models
{
    [Table("OPERADOR")] // Nome da tabela no Oracle
    public class Operador
    {
        [Key]
        [Column("ID_OPERADOR")]
        public int Id { get; set; }

        [Column("NM_OPERADOR")]
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Column("CARGO_OPERADOR")]
        [MaxLength(50)]
        public string? Cargo { get; set; }

        [Column("ID_PATIO")]
        [Required]
        public int IdPatio { get; set; }
    }
}