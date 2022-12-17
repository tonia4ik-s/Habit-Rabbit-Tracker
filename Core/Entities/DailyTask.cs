namespace Core.Entities;

public class DailyTask
{
    public int Id { get; set; }
    public int ChallengeId { get; set; }
    public Challenge Challenge { get; set; }
    public int? SubtaskId { get; set; }
    public Subtask? Subtask { get; set; }
    public DateTime AssignedDate { get; set; }
    public int CountOfUnitsDone { get; set; }
    public bool IsDone { get; set; }
}
