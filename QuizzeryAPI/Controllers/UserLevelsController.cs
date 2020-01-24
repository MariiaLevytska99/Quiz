using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizzeryDB;
using QuizzeryDB.Quizzery;

namespace QuizzeryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLevelsController : ControllerBase
    {
        private readonly Context _context;

        public UserLevelsController(Context context)
        {
            _context = context;
        }

        // GET: api/UserLevels
        [HttpGet]
        public IEnumerable<UserLevel> GetUserLevel()
        {
            return _context.UserLevel;
        }

        // GET: api/UserLevels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserLevel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLevel = await _context.UserLevel.FindAsync(id);

            if (userLevel == null)
            {
                return NotFound();
            }

            return Ok(userLevel);
        }

        // PUT: api/UserLevels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLevel([FromRoute] int id, [FromBody] UserLevel userLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserLevels
        [HttpPost]
        public async Task<IActionResult> PostUserLevel([FromBody] UserLevel userLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserLevel.Add(userLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLevel", new { id = userLevel.Id }, userLevel);
        }

        // DELETE: api/UserLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLevel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLevel = await _context.UserLevel.FindAsync(id);
            if (userLevel == null)
            {
                return NotFound();
            }

            _context.UserLevel.Remove(userLevel);
            await _context.SaveChangesAsync();

            return Ok(userLevel);
        }

        private bool UserLevelExists(int id)
        {
            return _context.UserLevel.Any(e => e.Id == id);
        }
    }
}