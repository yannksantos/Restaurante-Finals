using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Entities;
using Restaurante.Token;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService; // Adicione isto

        public TokenController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager) // Use IdentityRole aqui
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = new TokenService(userManager); // Inicialize o TokenService aqui
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] InputModel Input)
        {
            if (string.IsNullOrWhiteSpace(Input.Email) || string.IsNullOrWhiteSpace(Input.Password))
            {
                return Unauthorized();
            }

            var result =
                await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var appUser = await _userManager.FindByEmailAsync(Input.Email);
                var token = await _tokenService.GenerateToken(appUser); // Use _tokenService aqui
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
