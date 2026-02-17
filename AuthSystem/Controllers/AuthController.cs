using Microsoft.AspNetCore.Mvc;
using AuthSystem.Application.Interfaces;
namespace AuthSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            try
            {
                var user = _authService.Register(request.Email, request.Password);
                return Ok(new { user.Id, user.Email });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("change-email")]
        public IActionResult ChangeUserEmail([FromBody] ChangeEmailRequest request)
        {
            try
            {
                var user = _authService.ChangeUserEmail(request.CurrentEmail, request.NewEmail);
                return Ok(user);

            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        public record RegisterRequest(string Email, string Password);
        public record ChangeEmailRequest(string CurrentEmail, string NewEmail);
    }
}
