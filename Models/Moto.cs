using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("MOTO")]
public class Moto
{
    [Key]
    [Column("ID_MOTO")]
    public int Id { get; set; }

    [Column("MT_PLACA")]
    public string Placa { get; set; }

    [Column("MT_STATUS")]
    public string Status { get; set; }

    [Column("ID_MODELO")]
    public int IdModelo { get; set; }
}