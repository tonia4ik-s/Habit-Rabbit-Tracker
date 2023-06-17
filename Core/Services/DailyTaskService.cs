using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Core.DTO.DailyTaskDTO;
using Core.DTO.SubtaskDTO;

namespace Core.Services;

public class DailyTaskService : IDailyTaskService
{
    private readonly IRepository<DailyTask> _dailyTaskRepository;
    private readonly IRepository<Challenge> _challengeRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public DailyTaskService(
        IMapper mapper,
        IRepository<DailyTask> dailyTaskRepository,
        IRepository<Challenge> challengeRepository,
        IRepository<User> userRepository)
    {
        _dailyTaskRepository = dailyTaskRepository;
        _mapper = mapper;
        _challengeRepository = challengeRepository;
        _userRepository = userRepository;
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
            .Include(t => t.Challenge)
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
        var challenge = await _challengeRepository.Query()
            .Where(c => c.Id == task.ChallengeId)
            .Include(c => c.Subtasks)
            .FirstAsync();
        
        var sum = task.CountOfUnitsDone + addProgressDto.ProgressToAdd;
        task.CountOfUnitsDone += addProgressDto.ProgressToAdd;
        if (sum >= addProgressDto.CountOfUnits)
        {
            if (challenge.Subtasks.Count != 0)
            {
                if (task.SubtaskId != null)
                {
                    task.IsDone = true;
                    await _dailyTaskRepository.UpdateAsync(task);
                    var date = task.AssignedDate;
                    task = await _dailyTaskRepository.Query()
                        .Where(t => t.ChallengeId == challenge.Id
                                    && t.SubtaskId == null
                                    && t.AssignedDate.Date == date.Date)
                        .FirstAsync();
                }
                var dailySubTasks = await _dailyTaskRepository.Query()
                    .Where(t => t.ChallengeId == task.ChallengeId 
                                && t.SubtaskId != null 
                                && t.AssignedDate == task.AssignedDate)
                    .ToListAsync();
                if (dailySubTasks.All(dailySub => dailySub.IsDone)
                    && task.CountOfUnitsDone >= challenge.CountOfUnits)
                {
                    await CompleteTaskAndChallenge(task, challenge);
                }
            }
            else
            {
                await CompleteTaskAndChallenge(task, challenge);
            }
        }
        await _dailyTaskRepository.UpdateAsync(task);
        await _dailyTaskRepository.SaveChangesAsync();
    }

    private async Task CompleteTaskAndChallenge(DailyTask task, Challenge challenge)
    {
        var user = await _userRepository.GetByIdAsync(challenge.CreatedById);
        task.IsDone = true;
        user.Points += 2;
        if (challenge.EndDate.Date.Equals(task.AssignedDate.Date) 
            && challenge.EndDate.Date.Equals(DateTimeOffset.Now.Date))
        {
            challenge.IsCompleted = true;
            user.Points += 5;
            await _challengeRepository.UpdateAsync(challenge);
            await _challengeRepository.SaveChangesAsync();
        }

        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
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
        var user = await _userRepository.GetByIdAsync(challenge.CreatedById);
        task.CountOfUnitsDone = 0;
        if (task.IsDone)
        {
            user.Points -= 2;
            task.IsDone = false;
        }
        if (challenge.IsCompleted)
        {
            user.Points -= 6;
            challenge.IsCompleted = false;
        }
        
        await _challengeRepository.UpdateAsync(challenge);
        await _dailyTaskRepository.UpdateAsync(task);
        await _userRepository.UpdateAsync(user);
        await _dailyTaskRepository.SaveChangesAsync();
    }
}
