namespace Core.DTO.SubtaskDTO;

public class GetSubtaskDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CountOfUnits { get; set; }
    public string UnitShortName { get; set; }
    public string UnitName { get; set; }
    public int CountOfUnitsDone { get; set; }
    public int PercentOfDone { get; set; }
    public bool IsDone { get; set; }
}
