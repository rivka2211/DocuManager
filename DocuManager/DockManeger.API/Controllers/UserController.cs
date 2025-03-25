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

        private bool IsAdmin() => HttpContext.Items["UserRole"]?.ToString() == "admin";

        //user functions

        [HttpGet("user")]
        public async Task<ActionResult<UserDTO>> GetUserById()
        {

            var user = await _userService.GetUserByIdAsync(UserId());
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO UserDTO)
        {
            var user = await _userService.UpdateUserAsync(UserId(), UserDTO);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }

        [HttpPatch]
        public async Task<IActionResult> DeleteUser()
        {
            var good = await _userService.SoftDeleteUserAsync(UserId());
            if (good)
                return NoContent();
            return BadRequest();
        }

        //admin functions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            if (!IsAdmin())
                return Forbid();
            var users = await _userService.GetAllActiveUsersAsync();
            return Ok(users);
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllAllUsers()
        {
            if (!IsAdmin())
                return Forbid();
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> HardDeleteUser(int id)
        {
            if (!IsAdmin())
                return Forbid();
            var good = await _userService.DeleteUserAsync(id);
            if (good)
                return NoContent();
            return BadRequest();
        }

        [HttpPatch("{id}/role")]
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] string role)
        {
            if (!IsAdmin())
                return Forbid();
            var good = await _userService.UpdateUserRoleAsync(id, role);
            if (good)
                return NoContent();
            return BadRequest();
        }


    }

}

