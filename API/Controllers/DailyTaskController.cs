using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Core.DTO.DailyTaskDTO;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DailyTaskController : Controller
{
    private readonly IDailyTaskService _dailyTaskService;
    private readonly IUserService _userService;

    public DailyTaskController(IDailyTaskService dailyTaskService, IUserService userService)
    {
        _dailyTaskService = dailyTaskService;
        _userService = userService;
    }  
        
    [HttpGet("today")]
    public async Task<ActionResult<IList<GetDailyTaskDTO>>> GetAllTasksForToday()
    {
        var userId = _userService.GetCurrentUserNameIdentifier(User);
        var tasks = await _dailyTaskService.GetAllTasksForTodayByUser(userId);
        return Ok(tasks);
    }
    
    [HttpPost("by-date")]
    public async Task<ActionResult<IList<GetDailyTaskDTO>>> GetAllTasksByDate([FromBody] DateTime date)
    {
        var currentDate = GetLocalDate(date);
        Console.WriteLine(currentDate);
        var userId = _userService.GetCurrentUserNameIdentifier(User);
        var tasks = await _dailyTaskService.GetAllTasksForDateByUser(userId, currentDate);
        return Ok(tasks);
    }
        
    [HttpPost("add-progress")]
    public async Task<ActionResult> AddProgress(AddProgressDTO addProgressDto)
    {
        await _dailyTaskService.AddProgress(addProgressDto);
        return Ok();
    }
        
    [HttpPost("remove-progress")]
    public async Task RemoveProgress(int taskId)
    {
        await _dailyTaskService.RemoveProgress(taskId);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteTasksByChallenge(int challengeId)
    {
        await _dailyTaskService.DeleteAllTasksByChallenge(challengeId);
        return Ok();
    }

    private static DateTime GetLocalDate(DateTime date)
    {
        try
        {
            return date.Kind != DateTimeKind.Local ? TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.Local) : date;

        }
        catch (Exception)
        {
            return DateTime.Now;
        }
    }
}
