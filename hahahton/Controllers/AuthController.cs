using hahahton.Dtos;
using hahahton.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace hahahton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowFrontend")] // Применяем CORS к этому контроллеру
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Registration")]
        public ActionResult Registration([FromBody] RegistrationDto dto)
        {
            var user = _authService.Registration(dto);
            return Ok(user);
        }

        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            var token = _authService.Login(dto);
            return Ok(new { Token = token });
        }

        [Authorize]
        [HttpGet("CheckAuthorization")]
        public ActionResult CheckAuthorization()
        {
            return Ok(new { ImageUrl = "https://www.meme-arsenal.com/create/template/11468987" });
        }
    }
}
