using IdentityService.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class InitController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public InitController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult<string>> InitIdentity()
    {
        // 创建用户名为"admin"的账户
        User? masterUser = await _userManager.FindByNameAsync("admin");
        if (masterUser == null)
        {
            masterUser = new User("admin");
            IdentityResult result = await _userManager.CreateAsync(masterUser, "admin12345");
            if (result.Succeeded == false)
            {
                return BadRequest("admin账号创建失败");
            }
        }

        return Ok();
    }
}
