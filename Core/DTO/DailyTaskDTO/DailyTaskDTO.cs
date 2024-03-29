using System;

namespace Core.DTO.DailyTaskDTO;

public class DailyTaskDTO
{
    public int Id { get; set; }
    public string ChallengeTitle { get; set; }
    public string Description { get; set; }
    public int CountOfUnits { get; set; }
    public string UnitShortName { get; set; }
    public string UnitName { get; set; }
    public string FrequencyType { get; set; }
    public DateTime Date { get; set; }
    public int CountOfUnitsDone { get; set; }
    public int PercentOfDone { get; set; }
    public bool IsDone { get; set; }
}
