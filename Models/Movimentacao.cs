using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("MOVIMENTACAO")]
public class Movimentacao
{
    [Key]
    [Column("ID_MOV")]
    public int Id { get; set; }

    [Column("DT_MOV")]
    public DateTime DataMovimentacao { get; set; }

    [Column("ID_MOTO")]
    public int IdMoto { get; set; }

    [Column("ID_SETOR")]
    public int IdSetor { get; set; }

    [Column("ID_OPERADOR_ORIGEM")]
    public int IdOperadorOrigem { get; set; }

    [Column("ID_OPERADOR_DESTINO")]
    public int? IdOperadorDestino { get; set; }
}