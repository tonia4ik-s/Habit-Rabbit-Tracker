using System.Collections.Generic;
using System.Threading.Tasks;
using AddProgressDTO = Core.DTO.DailyTaskDTO.AddProgressDTO;
using DailyTaskDTO = Core.DTO.DailyTaskDTO.DailyTaskDTO;

namespace Core.Interfaces.Services;

public interface IDailyTaskService
{
    Task<IList<DailyTaskDTO>> GetAllTasksForTodayByUser(string userId);
    Task AddProgress(AddProgressDTO addProgressDto);
    Task DeleteAllTasksByChallenge(int challengeId);
    Task RemoveProgress(int taskId);
}