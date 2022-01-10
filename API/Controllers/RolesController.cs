using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "superadmin")]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, 
        
        TokenService tokenService, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if(role != null)
            {
                return BadRequest("There is already a role with this name.");
            }

            await _roleManager.CreateAsync(new IdentityRole(roleName));

            return Ok("Successfully created the role.");
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddUserRole(string username, string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if(role == null)
            {
                return NotFound("Couldn't find the requested role");
            }

            var user = await _userManager.FindByNameAsync(username);
            if(user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, role.Name);
                return Ok("Success adding role to the user");
            }

            return BadRequest("Problem adding the role to the user");
        }

    }
}