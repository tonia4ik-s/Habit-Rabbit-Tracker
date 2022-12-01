namespace Core.Entities;

public class Subtask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int UnitId { get; set; }
    public Unit Unit { get; set; }
    public int ChallengeId { get; set; }
    public Challenge Challenge { get; set; }
    public int CountOfUnits { get; set; }
    
    public ICollection<DailyTask> DailyTasks { get; set; }
}