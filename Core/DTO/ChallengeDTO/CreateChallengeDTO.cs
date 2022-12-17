namespace Core.DTO.ChallengeDTO;

public class CreateChallengeDTO
{
    // public string AuthorName { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int CountOfUnits { get; set; }
    public int UnitId { get; set; }
    public int FrequencyId { get; set; }
    public int IconId { get; set; }
    public int ChallengeTypeId { get; set; }
    public int VisibilityId { get; set; }
    public string Color { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public IList<SubtaskDTO.SubtaskCreateDTO>? SubtaskDtos { get; set; }
}