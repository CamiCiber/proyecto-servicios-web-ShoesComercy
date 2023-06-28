using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LOGIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
   
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            // Verificar las credenciales de administrador
            if (model.Username == "admin" && model.Password == "admin")
            {
                // Crear una identidad para el administrador
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

                var identity = new ClaimsIdentity(claims, "AdminAuth");
                var principal = new ClaimsPrincipal(identity);

                // Autenticar al administrador
                await HttpContext.SignInAsync(principal);

                // Redireccionar a la página deseada para el administrador
                return Redirect("/admin/dashboard");
            }

            // Las credenciales no son válidas
            return Unauthorized();
        }

        // Clase modelo para la solicitud de inicio de sesión
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}

