using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Core.DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IUserService _userService;

    public UserController(UserManager<User> manager, IHttpContextAccessor contextAccessor, IUserService userService)
    {
        _userManager = manager;
        _contextAccessor = contextAccessor;
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<UserDTO>> GetCurrentUser()
    {
        var userId = _userService.GetCurrentUserNameIdentifier(User);
        var user = await _userService.GetUserById(userId);
        return Ok(user);
    }

    [HttpPost ("update")]
    public async Task<ActionResult> UpdateUserInfo(UpdateUserDTO updateUserDto)
    {
        await _userService.UpdateUserInfo(updateUserDto);
        return Ok();
    }

    [HttpPost("delete")]
    public async Task<ActionResult> DeleteUser(string userName)
    {
        await _userService.DeleteUser(userName);
        return Ok();
    }
}
