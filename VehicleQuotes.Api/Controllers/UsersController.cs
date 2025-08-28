using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehicleQuotes.Api.ResourceModels;

namespace VehicleQuotes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController: ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public UsersController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        if(!ModelState.IsValid) return BadRequest();
        var result = await _userManager.CreateAsync(
            new IdentityUser { UserName = user.UserName, Email = user.Email }, user.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        user.Password = null;
        return CreatedAtAction(nameof(GetUser), new {username = user.UserName}, user);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<User>> GetUser(string username)
    {
        IdentityUser user = await _userManager.FindByNameAsync(username);
        if(user == null) return NotFound();
        return new User
        {
            UserName = user.UserName,
            Email = user.Email
        };
    }

}