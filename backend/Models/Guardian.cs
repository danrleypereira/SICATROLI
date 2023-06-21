using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models;
[Table("guardian")]
public class Guardian
{
    [Key]
    [Required]
    [Column("guardian_id")]
    
    public String GuardianId { get; set; }
    [Column("book_id")]
    public int BookId { get; set; }
    [Column("email")]
    public String Email { get; set; }
}