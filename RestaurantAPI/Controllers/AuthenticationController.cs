using Application.DataTransfer;
using Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/Authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IServiceManager _service;
        public AuthenticationController(ILogger<AuthenticationController> logger, IServiceManager service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            if (!await _service.AuthenticationService.ValidateUser(userForAuthentication))
            {
                return Unauthorized();
            }
            var token = await _service.AuthenticationService.CreateToken();
            return Ok(token);
        }
    }
}
