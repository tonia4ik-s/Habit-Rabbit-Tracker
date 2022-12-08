using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Core.DTO.ChallengeDTO;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ChallengeController : Controller
{
    private readonly IChallengeService _challengeService;
    private readonly IUserService _userService;

    public ChallengeController(IChallengeService challengeService, IUserService userService)
    {
        _challengeService = challengeService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult> GetChallengesByUserId(string userName)
    {
        var user = _userService.GetUserByName(userName);
        var challenges = await _challengeService.GetAllChallengesByUser(user.Id);
        return Ok(challenges);
    }
        
    [HttpGet("{id:int}")]
    public async Task<ChallengeDTO> GetChallengeById(int id)
    {
        var challenge = await _challengeService.GetChallengeById(id);
        return challenge;
    }

    [HttpPost("create")]
    public async Task<ActionResult> AddChallenge(CreateChallengeDTO createChallengeDto)
    {
        await _challengeService.AddChallenge(createChallengeDto);
        return Ok();
    }
        
    [HttpPost("update")]
    public async Task<ActionResult> UpdateChallenge(UpdateChallengeDTO updateChallengeDto)
    {
        await _challengeService.UpdateChallenge(updateChallengeDto);
        return Ok();
    }
        

    [HttpDelete("delete")]
    public async Task<ActionResult> DeleteChallenge(int challengeId)
    {
        await _challengeService.DeleteChallenge(challengeId);
        return Ok();
    }
        
}