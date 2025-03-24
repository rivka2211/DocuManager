using DocuManager.Core.DTOs;
using DocuManager.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using File = DocuManager.Core.Entities.File;


namespace DocuManager.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        private int UserId() => int.Parse(HttpContext.Items["UserId"]?.ToString());

        private bool IsAdmin() => HttpContext.Items["Role"]?.ToString() == "admin";

        //user functions

        [HttpGet("user")]
        public async Task<ActionResult<UserDTO>> GetUserById()
        {

            var user = await _userService.GetUserByIdAsync(UserId());
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser( UserUpdateDTO UserDTO)
        {
            await _userService.UpdateUserAsync(UserId(), UserDTO);
            return NoContent();
        }

        //admin functions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            if (!IsAdmin())
                return Forbid();
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!IsAdmin())
                return Forbid();
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    
        [HttpPatch("{id}/role")]
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] string role)
        {
            if (!IsAdmin())
                return Forbid();
            await _userService.UpdateUserRoleAsync(id, role);
            return NoContent();
        }


    }

}

