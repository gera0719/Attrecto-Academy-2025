﻿using Academy2025.DTOs;
using Academy2025.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAsync()
        {
            return await _userService.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetAsync(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            return user == null ? NotFound() : user;
        }
        [Authorize]
        [HttpGet("over18")]
        public async Task<IEnumerable<UserDTO>> GetUsersOverEighteenAsync()
        {
            var users = await _userService.GetAllOverEighteenAsync();
            return users;
        }

        // POST api/<UsersController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UserDTO value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.CreateAsync(value);
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] UserDTO data)
        {
            var user = await _userService.UpdateAsync(id, data);
            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _userService.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
