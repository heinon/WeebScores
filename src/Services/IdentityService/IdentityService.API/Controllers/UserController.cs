using IdentityService.API.DTOs.UserDTOs;
using IdentityService.Application.UserApplication.Command.ChangePassword;
using IdentityService.Application.UserApplication.Command.LogIn;
using IdentityService.Application.UserApplication.Command.RegisterUser;
using IdentityService.Application.UserApplication.Query.GetUserByEmail;
using IdentityService.Application.UserApplication.Query.GetUserById;
using IdentityService.Application.UserApplication.Query.GetUserByUsername;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.CQRS.Command;
using SharedKernel.CQRS.Query;

namespace IdentityService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(ICommandBus commandBus, IQueryBus queryBus, ILogger<UserController> logger) : ControllerBase
    {
        private readonly ICommandBus _commandBus = commandBus;
        private readonly IQueryBus _queryBus = queryBus;
        private readonly ILogger<UserController> _logger = logger;

        [Authorize]
        [HttpPut("user/{id}/changepassword")]
        public async Task<IActionResult> ChangePassword([FromRoute] Guid id, [FromBody] ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var command = new ChangePasswordCommand(
                id,
                request.NewPassword);

            var test = await _commandBus.SendAsync(command, cancellationToken).ConfigureAwait(false);

            return Ok(test.UserId);
        }

        [Authorize]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {

            var input = new GetUserByIdQuery(id);
            var test = await _queryBus.SendAsync(input);

            return Ok(test);
        }

        [Authorize]
        [HttpGet("user/username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var input = new GetUserByUsernameQuery(username);
            var test = await _queryBus.SendAsync(input);

            return Ok(test);
        }

        [Authorize]
        [HttpGet("user/email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var input = new GetUserByEmailQuery(email);
            var test = await _queryBus.SendAsync(input);

            return Ok(test);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInRequest request, CancellationToken cancellationToken)
        {
            var input = new LogInCommand(request.Username, request.Email, request.Password);
            var result = await _commandBus.SendAsync(input, cancellationToken);

            if (!result.IsSuccess)
            {
                return Unauthorized(new { message = result.Message, Success = false });
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(30)
            };

            Response.Cookies.Append("jwt", result.Token!, cookieOptions);

            return Ok(new { userId = result.UserId, Success = true });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message = "Logged out successfully" });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequset request, CancellationToken cancellationToken)
        {
            var command = new RegisterUserCommand(
                request.Username,
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password,
                request.Role);

            var test = await _commandBus.SendAsync(command, cancellationToken).ConfigureAwait(false);

            return Ok(test.UserId);
        }
    }
}
