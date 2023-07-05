using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Models;
[Table("guardian")]
public class Guardian
{
    [Key]
    [Required]
    [Column("guardian_id")]
    public string Id { get; set; }
    [Column("book_id")]
    public int BookId { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [ForeignKey("institution_id")]
    public Institution Institution { get; set; }
}
public class CreateGuardianRequestDto
{
    public int BookId { get; set; }
    public string Id { get; set; }
    public string email { get; set; }
}
public class GuardianResponseDto
{
    public int BookId { get; set; }
    public string Id { get; set; }
    public string email { get; set; }
}
