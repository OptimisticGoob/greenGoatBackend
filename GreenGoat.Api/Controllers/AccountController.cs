using GreenGoat.Api.DTO;
using GreenGoat.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/[Controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

     [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserLoginDTO model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User
        {
            UserName = model.UserName,
            Email = model.Email
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return Ok("User Registered Successfully");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return BadRequest(ModelState);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return Ok("User Logged In Successfully");
        }
        else if (result.IsLockedOut)
        {
            return StatusCode(StatusCodes.Status423Locked, "User account locked out.");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return BadRequest(ModelState);
        }
    }



}