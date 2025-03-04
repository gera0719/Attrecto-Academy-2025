﻿using Academy2025.Data;
using Academy2025.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            return user == null ? null : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] User value)
        {
            await _repository.CreateAsync(value);
            
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] User data)
        {
            var user = await _repository.UpdateAsync(id, data);
            return user == null? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
}
