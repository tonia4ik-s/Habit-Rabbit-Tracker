using System.Collections.Generic;
using System.Threading.Tasks;
using UnitDTO = Core.DTO.UnitDTO.UnitDTO;

namespace Core.Interfaces.Services;

public interface IUnitService
{
    IList<UnitDTO> GetAllUnits();
}