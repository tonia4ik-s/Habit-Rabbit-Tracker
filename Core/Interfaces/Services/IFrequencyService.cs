using System.Collections.Generic;
using System.Threading.Tasks;
using FrequencyDTO = Core.DTO.FrequencyDTO.FrequencyDTO;

namespace Core.Interfaces.Services;

public interface IFrequencyService
{
    Task<IList<FrequencyDTO>> GetAllFrequencies();
}