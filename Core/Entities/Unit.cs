namespace Core.Entities;

public class Unit
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string ShortType { get; set; }
        
    public ICollection<Challenge> Challenges { get; set; }
    public ICollection<Subtask> Subtasks { get; set; }
}
