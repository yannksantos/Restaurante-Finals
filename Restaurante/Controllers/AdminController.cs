using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Entities;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet("/api/GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new List<UserModelRoles>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles.Add(new UserModelRoles { User = user, Roles = roles });
            }

            return Ok(userRoles);
        }

        [HttpPost("/api/ChangeUserRole")]
        public async Task<IActionResult> ChangeUserRole([FromBody] RoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            if (!await _roleManager.RoleExistsAsync(model.NewRole))
            {
                var role = new IdentityRole(model.NewRole);
                var roleResult = await _roleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    return BadRequest("Erro ao criar a role!");
                }
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            var result = await _userManager.AddToRoleAsync(user, model.NewRole);
            if (!result.Succeeded)
            {
                return BadRequest("Erro ao adicionar usuário à nova role");
            }

            return Ok("Role do usuário alterada com sucesso");
        }
    }
}
