using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;
[Table("institution")]
public class Institution
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("institution_id")]
    public int Id { get; set; }
    [Column("moderator_id")]
    public String ModeratorId { get; set; }
    [InverseProperty("Institution")]
    public ICollection<Guardian>? guardians { get; set; }
    [Column("name")]
    [Required]
    public string Name { get; set; }
    //[Column("address_id")]
    //[ForeignKey("address_id")]
    //public Address AddressId { get; set; }
    [Column("telephone")]
    public String? Telephone { get; set; }
}

public class InstitutionDtoRequestBody
{
    public string Name { get; set; }
    public string? Telephone { get; set; }
}

public class InstitutionBodyDto
{
    public int Id { get; set; }
    public string ModeratorId { get; set; }
    public string Name { get; set; }
    public string? Telephone { get; set; }
}