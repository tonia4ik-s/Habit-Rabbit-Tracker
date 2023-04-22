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

    public ChallengeService(
        IRepository<Challenge> challengeRepository,
        IMapper mapper,
        IUserService userService,
        IRepository<DailyTask> dailyTaskRepository,
        IRepository<Subtask> subtaskRepository)
    {
        _challengeRepository = challengeRepository;
        _mapper = mapper;
        _userService = userService;
        _dailyTaskRepository = dailyTaskRepository;
        _subtaskRepository = subtaskRepository;
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
        var user = await _userService.GetUserById(userId);
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
        await CreateDailyTasksByChallenge(challenge, sub);
    }

    private async Task CreateDailyTasksByChallenge(
        Challenge challenge,
        List<Subtask> subtasks
        )
    {
        var startDate = challenge.StartDate.Date;
        var endDate = challenge.EndDate;
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
        var user = await _userService.GetUserById(userId);
        var challenge = _mapper.Map<Challenge>(updateChallengeDto);
        challenge.CreatedById = user.Id;
        await _challengeRepository.UpdateAsync(challenge);
        await _challengeRepository.SaveChangesAsync();
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
}
