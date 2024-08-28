using KopiusLibrary.Model;
using KopiusLibrary.Model.Entities;
using KopiusLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KopiusLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(User user)
        {
            var token = _userService.Login(user);
            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = Constants.InvalidCredentials});
            }
            return Ok(token);
        }
    }
}
