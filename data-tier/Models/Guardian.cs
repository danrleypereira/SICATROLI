using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dal.Models;
[Table("guardian")]
public class Guardian
{
    [Key]
    [Column("guardian_id")]
    [Required]
    public String GuardianId { get; set; }
    [Column("book_id")]
    public int BookId { get; set; }
    [Column("contributions")]
    public int ContributionsId { get; set; }
    [Column("email")]
    public String Email { get; set; }
}