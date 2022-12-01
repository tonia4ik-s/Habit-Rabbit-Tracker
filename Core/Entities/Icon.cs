namespace Core.Entities;

public class Icon
{
    public int Id { get; set; }
    public string MdiName { get; set; }
    
    public ICollection<Challenge> Challenges { get; set; }
}