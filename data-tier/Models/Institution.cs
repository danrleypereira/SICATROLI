using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dal.Models;
[Table("institution")]
public class Institution
{
    [Key]
    [Column("organization_id")]
    public string organization_id { get; set; }
    [Column("moderator_id")]
    public String Moderator_id { get; set; }
    [ForeignKey("guardian_id")]
    public ICollection<Guardian> guardians { get; set; }
    [Column("name")]
    [Required]
    public string Name { get; set; }
    [Column("address_id")]
    [ForeignKey("address_id")]
    public Address AddressId { get; set; }
    [Column("telephone")]
    public String Telephone { get; set; }
}