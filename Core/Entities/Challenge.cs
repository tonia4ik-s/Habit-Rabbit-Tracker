namespace Core.Entities;

public class Challenge
{
    public int Id { get; set; }
    public string CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CountOfUnits { get; set; }
    public int UnitId { get; set; }
    public Unit Unit { get; set; }
    public string Frequency { get; set; }
    public string IconName { get; set; }
    public string Color { get; set; }
    public int ChallengeTypeId { get; set; }
    public ChallengeType ChallengeType { get; set; }
    public int VisibilityId { get; set; }
    public Visibility Visibility { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public bool IsCompleted { get; set; }

    public ICollection<DailyTask> DailyTasks { get; set; }
    public ICollection<Subtask> Subtasks { get; set; }
}