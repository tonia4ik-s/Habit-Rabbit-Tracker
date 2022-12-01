namespace Core.Entities;

public class Visibility
{
    public int Id { get; set; }
    public string Type { get; set; }
    
    public ICollection<Challenge> Challenges { get; set; }
}