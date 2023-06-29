using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;
[Table("book")]
public class Book
{
    [Key]
    [Required]
    [Column("book_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Required]
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [Column("edition")]
    public int Edition { get; set; }

    [Required]
    [Column("year")]
    [MaxLength(4)]
    public string Year { get; set; }

    [Required]
    [Column("language")]
    [MaxLength(10)]
    public string Language { get; set; }

    [Required]
    [Column("exchangable")]
    public bool Exchangable { get; set; }

    [Required]
    [Column("publisher")]
    [MaxLength(255)]
    public string Publisher { get; set; }
    
    [Required]
    [Column("author")]
    [MaxLength(100)]
    public string Author { get; set; }

    [ForeignKey("guardian_id")]
    public int GuardianId { get; set; }
    public Guardian Guardian { get; set; }
    
}