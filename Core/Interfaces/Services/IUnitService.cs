using UnitDTO = Core.DTO.UnitDTO.UnitDTO;

namespace Core.Interfaces.Services;

public interface IUnitService
{
    IList<UnitDTO> GetAllUnits();
}