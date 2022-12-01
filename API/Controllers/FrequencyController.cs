using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Core.DTO.FrequencyDTO;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FrequencyController : Controller
{
    private readonly IFrequencyService _frequencyService;
    public FrequencyController(IFrequencyService frequencyService)
    {
        _frequencyService = frequencyService;
    }
        
    [HttpGet]
    public async Task<ActionResult<IList<FrequencyDTO>>> GetAll()
    {
        return Ok(await _frequencyService.GetAllFrequencies());
    }
}