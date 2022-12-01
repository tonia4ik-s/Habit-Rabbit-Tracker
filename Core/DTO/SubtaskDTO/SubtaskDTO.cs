namespace Core.DTO.SubtaskDTO;

public class SubtaskDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int UnitId { get; set; }
    public int ChallengeId { get; set; }
    public int CountOfUnits { get; set; }
}