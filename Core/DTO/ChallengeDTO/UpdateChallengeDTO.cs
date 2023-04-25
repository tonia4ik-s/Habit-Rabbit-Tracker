using System;

namespace Core.DTO.ChallengeDTO;

public class UpdateChallengeDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CountOfUnits { get; set; }
    public int UnitId { get; set; }
    public string IconName { get; set; }
    public string Color { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}
