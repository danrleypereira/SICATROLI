public class Reader
{
    public int Id { get; set; }
    // from the group model (Entity framework will connect the Primarykey and forign key)
    public Institution Institution { get; set; }
    public int InstitutionId { get; set; }
}