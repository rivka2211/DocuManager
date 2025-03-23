﻿using DocuManager.Core.DTOs;
using DocuManager.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using File = DocuManager.Core.Entities.File;


namespace DocuManager.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //auth function

        [HttpPost]//register
        public async Task<IActionResult> AddUser(UserDTO UserDTO)
        {
            await _userService.AddUserAsync(UserDTO);
            return CreatedAtAction(nameof(GetUserById), new { id = UserDTO }, UserDTO);
        }

        //user functions
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
           
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDTO UserDTO)
        {
            await _userService.UpdateUserAsync(id, UserDTO);
            return NoContent();
        }

        //admin functions
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        [Authorize]
        [HttpPatch("{id}/role")]
        public async Task<IActionResult> UpdateUserRole(int id, [FromBody] string role)
        {
            await _userService.UpdateUserRoleAsync(id, role);
            return NoContent();
        }


    }

}

