using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Core.DTO.DailyTaskDTO;
using Core.DTO.SubtaskDTO;

namespace Core.Services;

public class DailyTaskService : IDailyTaskService
{
    private readonly IRepository<DailyTask> _dailyTaskRepository;
    private readonly IRepository<Challenge> _challengeRepository;
    private readonly IChallengeService _challengeService;
    private readonly IMapper _mapper;

    public DailyTaskService(
        IRepository<DailyTask> dailyTaskRepository,
        IChallengeService challengeService,
        IMapper mapper, IRepository<Challenge> challengeRepository)
    {
        _dailyTaskRepository = dailyTaskRepository;
        _challengeService = challengeService;
        _mapper = mapper;
        _challengeRepository = challengeRepository;
    }

    public async Task<List<GetDailyTaskDTO>> GetAllTasksForTodayByUser(string userId)
    {
        var tasks = await _dailyTaskRepository.Query()
            .Where(t => t.Challenge.CreatedById == userId 
                        && t.AssignedDate.Date == DateTimeOffset.Now.Date
                        && t.SubtaskId == null)
            .Include(t => t.Challenge.Unit)
            .ToListAsync();
        var mappedTasks = new List<GetDailyTaskDTO>();
        foreach (var task in tasks)
        {
            var taskDTO = _mapper.Map<GetDailyTaskDTO>(task);
            var subtasks = await _dailyTaskRepository.Query()
                .Where(t => t.ChallengeId == task.ChallengeId 
                            && t.AssignedDate.Date == DateTimeOffset.Now.Date
                            && t.SubtaskId != null)
                .Include(t => t.Subtask)
                .ThenInclude(s => s!.Unit).ToListAsync();
            taskDTO.Subtasks = subtasks.Select(s => _mapper.Map<GetSubtaskDTO>(s)).ToList();
            mappedTasks.Add(taskDTO);
        }

        return mappedTasks;
    }

    public async Task<List<GetDailyTaskDTO>> GetAllTasksForDateByUser(string userId, DateTime date)
    {
        var tasks = await _dailyTaskRepository.Query()
            .Where(t => t.Challenge.CreatedById == userId 
                        && t.AssignedDate.Date == date.Date
                        && t.SubtaskId == null)
            .Include(t => t.Challenge.Unit)
            .ToListAsync();
        var mappedTasks = new List<GetDailyTaskDTO>();
        foreach (var task in tasks)
        {
            var taskDTO = _mapper.Map<GetDailyTaskDTO>(task);
            var subtasks = await _dailyTaskRepository.Query()
                .Where(t => t.ChallengeId == task.ChallengeId 
                            && t.AssignedDate.Date == date.Date
                            && t.SubtaskId != null)
                .Include(t => t.Subtask)
                .ThenInclude(s => s!.Unit).ToListAsync();
            taskDTO.Subtasks = subtasks.Select(s => _mapper.Map<GetSubtaskDTO>(s)).ToList();
            mappedTasks.Add(taskDTO);
        }

        return mappedTasks;
    }
        
    public async Task AddProgress(AddProgressDTO addProgressDto)
    {
        var task = await _dailyTaskRepository.GetByIdAsync(addProgressDto.DailyTaskId);
        if (task.AssignedDate.Date > DateTimeOffset.Now.Date) return;
        var challenge = await _challengeRepository.GetByIdAsync(task.ChallengeId);
        if (task.SubtaskId == null)
        {
            if (challenge.Subtasks.Count != 0)
            {
                var dailySubTasks = await _dailyTaskRepository.Query()
                    .Where(t => t.ChallengeId == task.ChallengeId && t.SubtaskId != null)
                    .ToListAsync();
                if (dailySubTasks.Any(dailySub => !dailySub.IsDone))
                {
                    return;
                }
            }
        }
        var sum = task.CountOfUnitsDone + addProgressDto.ProgressToAdd;
        if (sum > addProgressDto.CountOfUnits) { return; }
        task.CountOfUnitsDone += addProgressDto.ProgressToAdd;
        if (sum >= addProgressDto.CountOfUnits)
        {
            task.IsDone = true;
            if (challenge.EndDate.Date.Equals(task.AssignedDate.Date) 
                && challenge.EndDate.Date.Equals(DateTimeOffset.Now.Date))
            {
                challenge.IsCompleted = true;
                await _challengeRepository.UpdateAsync(challenge);
                await _challengeRepository.SaveChangesAsync();
            }
        }
        await _dailyTaskRepository.UpdateAsync(task);
        await _dailyTaskRepository.SaveChangesAsync();
    }
        
    public async Task DeleteAllTasksByChallenge(int challengeId)
    {
        var tasks = await _dailyTaskRepository.Query()
            .Where(t => t.ChallengeId == challengeId).ToListAsync();
        await _dailyTaskRepository.DeleteRange(tasks);
        await _dailyTaskRepository.SaveChangesAsync();
    }

    public async Task RemoveProgress(int taskId)
    {
        var task = await _dailyTaskRepository.GetByIdAsync(taskId);
        var challenge = await _challengeRepository.GetByIdAsync(task.ChallengeId);
        task.CountOfUnitsDone = 0;
        task.IsDone = false;
        challenge.IsCompleted = false;
        await _challengeRepository.UpdateAsync(challenge);
        await _dailyTaskRepository.UpdateAsync(task);
        await _dailyTaskRepository.SaveChangesAsync();
    }
}
