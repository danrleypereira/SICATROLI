namespace dal.Models;
public class Category
{
    public int Id { get; set; }
    public string Genre { get; set; }
    public int Pages { get; set; }
    public string Rarity { get; set; }
    public string Conservation { get; set; }
    public double Price { get; set; }
}