using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;
[Table("guardian")]
public class Guardian
{
    [Key]
    [Required]
    [Column("guardian_id")]
    public string GuardianId { get; set; }
    [Column("book_id")]
    public int BookId { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [ForeignKey("institution_id")]
    public Institution Institution { get; set; }
}
public class GuardianDto
{
    public int BookId { get; set; }
    public string GuardianId { get; set; }
    public string email { get; set; }
}