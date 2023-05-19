
namespace dal.Models;
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Edition { get; set; }
    public string Publisher { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }
    public Boolean IsExchanged { get; set; }
    public int Year { get; set; }
    public string Language { get; set; }

}