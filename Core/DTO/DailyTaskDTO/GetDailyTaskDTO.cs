using Core.DTO.SubtaskDTO;

namespace Core.DTO.DailyTaskDTO;

public class GetDailyTaskDTO
{
    public int Id { get; set; }
    public int ChallengeId { get; set; }
    public string ChallengeTitle { get; set; }
    public string Description { get; set; }
    public int CountOfUnits { get; set; }
    public string Color { get; set; }
    public string UnitShortName { get; set; }
    public string UnitName { get; set; }
    public string IconName { get; set; }
    public DateTimeOffset Date { get; set; }
    public int CountOfUnitsDone { get; set; }
    public int PercentOfDone { get; set; }
    public bool IsDone { get; set; }
    
    public ICollection<GetSubtaskDTO> Subtasks { get; set; }
}
