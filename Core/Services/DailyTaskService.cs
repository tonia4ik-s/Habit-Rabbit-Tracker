using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    private readonly UserManager<User> _userManager;
    private readonly IChallengeService _challengeService;
    private readonly IMapper _mapper;

    public DailyTaskService(
        IRepository<DailyTask> dailyTaskRepository,
        UserManager<User> userManager,
        IChallengeService challengeService,
        IMapper mapper)
    {
        _dailyTaskRepository = dailyTaskRepository;
        _userManager = userManager;
        _challengeService = challengeService;
        _mapper = mapper;
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
        var sum = task.CountOfUnitsDone + addProgressDto.ProgressToAdd;
        if (sum > task.Challenge.CountOfUnits) { return; }
        task.CountOfUnitsDone += addProgressDto.ProgressToAdd;
        if (sum == addProgressDto.CountOfUnits)
        {
            task.IsDone = true;
        }
        await _dailyTaskRepository.UpdateAsync(task);
        await _dailyTaskRepository.SaveChangesAsync();
    }
        
    public async Task DeleteAllTasksByChallenge(int challengeId)
    {
        var tasks = await _dailyTaskRepository.Query()
            .Where(t => t.ChallengeId == challengeId).ToListAsync();
        await _dailyTaskRepository.DeleteRange(tasks);
        // await _dailyTaskRepository.SaveChangesAsync();
    }

    public async Task RemoveProgress(int taskId)
    {
        var task = await _dailyTaskRepository.GetByIdAsync(taskId);
        task.CountOfUnitsDone = 0;
        task.IsDone = false;
        await _dailyTaskRepository.UpdateAsync(task);
        await _dailyTaskRepository.SaveChangesAsync();
    }
}
