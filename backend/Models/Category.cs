using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;
[Table("category")]
public class Category
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("category_id")]
    public int CategoryId { get; set; }
    [Column("genre")]
    public string Genre { get; set; }
    [Column("pages")]
    public string Pages { get; set; }
    [Column("rarity")]
    public string Rarity { get; set; }
    [Column("conservation")]
    public string Conservation { get; set; }
    [Column("price")]
    public string Price { get; set; }
}