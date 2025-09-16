using UserApi.Models;
using Microsoft.AspNetCore.Mvc;
using UserApi.Services;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("v1/login")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginmodel)
        {
            var response = _authService.GetLogin(loginmodel);
            if (response == null)
                return Unauthorized(new { Message = "Usuário ou senha inválidos" });
            
            return Ok(response);

        }

    }
}
