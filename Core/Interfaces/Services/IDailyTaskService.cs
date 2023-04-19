using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO.DailyTaskDTO;
using AddProgressDTO = Core.DTO.DailyTaskDTO.AddProgressDTO;
using DailyTaskDTO = Core.DTO.DailyTaskDTO.DailyTaskDTO;

namespace Core.Interfaces.Services;

public interface IDailyTaskService
{
    Task<List<GetDailyTaskDTO>> GetAllTasksForTodayByUser(string userId);
    Task<List<GetDailyTaskDTO>> GetAllTasksForDateByUser(string userId, DateTime date);
    Task AddProgress(AddProgressDTO addProgressDto);
    Task DeleteAllTasksByChallenge(int challengeId);
    Task RemoveProgress(int taskId);
}