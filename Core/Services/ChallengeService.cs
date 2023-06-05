using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Core.DTO.ChallengeDTO;

namespace Core.Services;

public class ChallengeService : IChallengeService
{
    private readonly IRepository<Challenge> _challengeRepository;
    private readonly IRepository<Subtask> _subtaskRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IRepository<DailyTask> _dailyTaskRepository;
    private readonly IRepository<User> _userRepository;

    public ChallengeService(
        IRepository<Challenge> challengeRepository,
        IMapper mapper,
        IUserService userService,
        IRepository<DailyTask> dailyTaskRepository,
        IRepository<Subtask> subtaskRepository,
        IRepository<User> userRepository)
    {
        _challengeRepository = challengeRepository;
        _mapper = mapper;
        _userService = userService;
        _dailyTaskRepository = dailyTaskRepository;
        _subtaskRepository = subtaskRepository;
        _userRepository = userRepository;
    }
    
    public async Task<IList<ChallengeDTO>> GetAllChallengesByUser(string userId)
    {
        var challenges = await _challengeRepository.Query()
            .Where(c => c.CreatedById == userId)
            .Include(ch => ch.Unit)
            .Include(ch => ch.CreatedBy)
            .Include(ch => ch.Subtasks)
            .Include(ch => ch.Visibility)
            .ToListAsync();
        return challenges.Select(challenge => _mapper.Map<ChallengeDTO>(challenge)).ToList();
    }

    public async Task AddChallenge(string userId, CreateChallengeDTO createChallengeDto)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        var challenge = _mapper.Map<Challenge>(createChallengeDto);
        challenge.CreatedById = user.Id;
        challenge = await _challengeRepository.AddAsync(challenge);
        await _challengeRepository.SaveChangesAsync();
        var sub = new List<Subtask>();
        if (createChallengeDto.SubtaskDtos != null)
        {
            var subtasks = _mapper.Map<List<Subtask?>>(createChallengeDto.SubtaskDtos);
            
            foreach (var subtask in subtasks.Where(subtask => subtask != null))
            { 
                subtask.ChallengeId = challenge.Id;
            }

            sub = (await _subtaskRepository.AddRangeAsync(subtasks!)).ToList();
            await _subtaskRepository.SaveChangesAsync();
        }
        await CreateDailyTasksByChallenge(challenge, sub, challenge.StartDate, challenge.EndDate);
        user.Points++;
        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
    }

    private async Task CreateDailyTasksByChallenge(
        Challenge challenge,
        List<Subtask> subtasks,
        DateTimeOffset startDate,
        DateTimeOffset endDate
        )
    {
        var days = (endDate - startDate).Days + 1;
            
        for (var i = 0; i < days; i++)
        {
            var assignedDate = startDate.AddDays(i);
            var isAssigned = challenge.Frequency[(int)assignedDate.DayOfWeek];
            if (isAssigned == '0')
            {
                continue;
            }
            var dailyTask = new DailyTask
            {
                ChallengeId = challenge.Id,
                AssignedDate = assignedDate,
                CountOfUnitsDone = 0,
                IsDone = false
            };
            await _dailyTaskRepository.AddAsync(dailyTask);
            foreach (var subtask in subtasks)
            {
                var dailySubtask = new DailyTask
                {
                    ChallengeId = challenge.Id,
                    SubtaskId = subtask.Id,
                    AssignedDate = startDate.AddDays(i),
                    CountOfUnitsDone = 0,
                    IsDone = false
                };
                await _dailyTaskRepository.AddAsync(dailySubtask);
            }
        }
        await _dailyTaskRepository.SaveChangesAsync();
    }

    public async Task UpdateChallenge(string userId, UpdateChallengeDTO updateChallengeDto)
    {
        var oldChallenge = await _challengeRepository.GetByIdAsync(updateChallengeDto.Id);
        var challenge = oldChallenge;
        challenge.Title = updateChallengeDto.Title;
        challenge.Description = updateChallengeDto.Description;
        challenge.CountOfUnits = updateChallengeDto.CountOfUnits;
        challenge.UnitId = updateChallengeDto.UnitId;
        challenge.Color = updateChallengeDto.Color;
        challenge.IconName = updateChallengeDto.IconName;
        challenge.StartDate = updateChallengeDto.StartDate;
        challenge.EndDate = updateChallengeDto.EndDate;

        await _challengeRepository.UpdateAsync(challenge);
        await _challengeRepository.SaveChangesAsync();
        
        if (challenge.StartDate.Date > oldChallenge.StartDate.Date)
        {
            var extraDailyTasks = await _dailyTaskRepository.Query()
                .Where(t => t.ChallengeId == challenge.Id && 
                            t.AssignedDate.Date < challenge.StartDate)
                .ToListAsync();
            await _dailyTaskRepository.DeleteRange(extraDailyTasks);
            await _dailyTaskRepository.SaveChangesAsync();
        }
        else if (challenge.StartDate.Date < oldChallenge.StartDate)
        {
            await CreateDailyTasksByChallenge(
                challenge,
                challenge.Subtasks.ToList(),
                challenge.StartDate,
                oldChallenge.StartDate.AddDays(-1)
            );
        }

        if (challenge.EndDate > oldChallenge.EndDate)
        {
            await CreateDailyTasksByChallenge(
                challenge,
                challenge.Subtasks.ToList(),
                oldChallenge.EndDate.AddDays(1),
                challenge.EndDate
            );
        }
        else if (challenge.EndDate < oldChallenge.EndDate)
        {
            var extraDailyTasks = await _dailyTaskRepository.Query()
                .Where(t => t.ChallengeId == challenge.Id && 
                            t.AssignedDate.Date > challenge.EndDate)
                .ToListAsync();
            await _dailyTaskRepository.DeleteRange(extraDailyTasks);
            await _dailyTaskRepository.SaveChangesAsync();
        }

        if (challenge.CountOfUnits != oldChallenge.CountOfUnits)
        {
            var dailyTasks = await _dailyTaskRepository.Query()
                .Where(t => t.ChallengeId == challenge.Id).ToListAsync();
            foreach (var task in dailyTasks)
            {
                task.IsDone = task.CountOfUnitsDone >= challenge.CountOfUnits;
                await _dailyTaskRepository.UpdateAsync(task);
            }

            await _dailyTaskRepository.SaveChangesAsync();
        }

    }

    public async Task DeleteChallenge(int challengeId)
    {
        var challenge = await _challengeRepository.GetByIdAsync(challengeId);
        var tasks = await _dailyTaskRepository.Query()
            .Where(t => t.ChallengeId == challengeId).ToListAsync();
        var subtasks = await _subtaskRepository.Query()
            .Where(t => t.ChallengeId == challengeId).ToListAsync();
        await _dailyTaskRepository.DeleteRange(tasks);
        await _subtaskRepository.DeleteRange(subtasks);
        await _challengeRepository.DeleteAsync(challenge);
        await _challengeRepository.SaveChangesAsync();
    }
        
    public async Task<ChallengeDTO> GetChallengeById(int challengeId)
    {
        var challenge = await _challengeRepository.Query()
            .Where(c => c.Id == challengeId)
            .Include(ch => ch.Subtasks)
            .Include(ch => ch.Visibility)
            .Include(ch => ch.Unit)
            .Include(ch => ch.CreatedBy)
            .FirstOrDefaultAsync();
        return _mapper.Map<ChallengeDTO>(challenge);
    }

    public async Task<List<StatisticsGeneralDTO>> GetStatisticsAsync(string userId)
    {
        var startDate = DateTimeOffset.Now.AddDays(-6);
        var dailyTasks = await _dailyTaskRepository.Query()
            .Where(t => t.Challenge.CreatedById == userId 
                        && t.AssignedDate <= DateTimeOffset.Now 
                        && t.AssignedDate >= startDate)
            .OrderBy(t => t.AssignedDate)
            .Include(t => t.Subtask)
            .Include(t => t.Challenge).ToListAsync();

        return GetStatistic(dailyTasks, startDate);
    }
    
    public async Task<List<StatisticsGeneralDTO>> GetStatisticsAsync(int challengeId)
    {
        var startDate = DateTimeOffset.Now.AddDays(-6);
        var dailyTasks = await _dailyTaskRepository.Query()
            .Where(t => t.ChallengeId == challengeId 
                        && t.AssignedDate <= DateTimeOffset.Now 
                        && t.AssignedDate >= startDate)
            .OrderBy(t => t.AssignedDate)
            .Include(t => t.Subtask)
            .Include(t => t.Challenge).ToListAsync();

        return GetStatistic(dailyTasks, startDate);
    }

    private static List<StatisticsGeneralDTO> GetStatistic(
        IReadOnlyList<DailyTask> dailyTasks,
        DateTimeOffset startDate
        )
    {
        var statistics = new List<StatisticsGeneralDTO>();
        var k = 0;
        for (var date = startDate; date.Date <= DateTimeOffset.Now.Date; date = date.AddDays(1))
        {
            var stats = new StatisticsGeneralDTO
            {
                Date = date,
                PercentageDone = 0
            };
            var countOfDone = 0;
            var countOfTotal = 0;

            while(k < dailyTasks.Count && dailyTasks[k].AssignedDate.Date <= date.Date)
            {
                if (dailyTasks[k].AssignedDate.Date == date.Date)
                {
                    countOfDone += dailyTasks[k].CountOfUnitsDone;
                    countOfTotal += dailyTasks[k].Subtask != null
                        ? dailyTasks[k].Subtask.CountOfUnits
                        : dailyTasks[k].Challenge.CountOfUnits;   
                }
                k++;
            }
            
            stats.PercentageDone = countOfTotal == 0 ? 0 : Math.Round((double)countOfDone / (double) countOfTotal * 100);
            statistics.Add(stats);
        }
        
        return statistics;
    }
}
