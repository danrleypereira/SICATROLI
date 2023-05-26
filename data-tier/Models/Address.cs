using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace dal.Models;
[Table("address")]
public class Address
{
    [Key]
    [Required]
    [Column("address_id")]
    public int id { get; set; }
    [Required]
    [Column("number")]
    public int Number { get; set; }
    [Required]
    [Column("cep")]
    public int Cep { get; set; }
    [Column("city")]
    public String City { get; set; }
    [Column("uf")]
    [MaxLength(2), MinLength(2)]
    public String UF { get; set; }
    [Column("neighbourhood")]
    public String Neighbourhood { get; set; }
    [Column("country")]
    [MaxLength(30), MinLength(3)]
    public String Country { get; set; }
    [Column("address")]
    [Required]
    public String Descricao { get; set; }
}