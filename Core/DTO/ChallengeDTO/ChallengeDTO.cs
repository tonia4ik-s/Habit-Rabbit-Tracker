using System;

namespace Core.DTO.ChallengeDTO;

public class ChallengeDTO
{
    public int Id { get; set; }
    public string AuthorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CountOfUnits { get; set; }
    public string UnitShortTitle { get; set; }
    public string UnitTitle { get; set; }
    public string FrequencyTitle { get; set; }
    public string VisibilityType { get; set; }
    public string IconName { get; set; }
    public string Color { get; set; }
    public int ChallengeTypeId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public bool IsCompleted { get; set; }
}
