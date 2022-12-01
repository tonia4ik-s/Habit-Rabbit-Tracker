namespace Core.Entities;

public class ChallengeType
{
    public int Id { get; set; }
    public string Type { get; set; }
    
    public ICollection<Challenge> Challenges { get; set; }
}
