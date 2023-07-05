using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace backend.Models;
[Table("address")]
public class Address
{
    [Key]
    [Required]
    [Column("address_id")]
    public int Id { get; set; }
    [Required]
    [Column("number")]
    public int Number { get; set; }
    [Required]
    [Column("cep")]
    public int Cep { get; set; }
    [Column("city")]
    public string? City { get; set; } = "NA";
    [Column("uf")]
    [MaxLength(2), MinLength(2)]
    public string? UF { get; set; }  = "NA";
    [Column("neighbourhood")]
    public string? Neighbourhood { get; set; }  = "NA";
    [Column("country")]
    [MaxLength(30), MinLength(3)]
    public string? Country { get; set; }  = "BR";
    [Column("address")]
    [Required]
    public string? Descricao { get; set; }
}