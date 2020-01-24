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
    public class LevelQuestionsController : ControllerBase
    {
        private readonly Context _context;

        public LevelQuestionsController(Context context)
        {
            _context = context;
        }

        // GET: api/LevelQuestions
        [HttpGet]
        public IEnumerable<LevelQuestion> GetLevelQuestion()
        {
            return _context.LevelQuestion;
        }

        // GET: api/LevelQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLevelQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var levelQuestion = await _context.LevelQuestion.FindAsync(id);

            if (levelQuestion == null)
            {
                return NotFound();
            }

            return Ok(levelQuestion);
        }

        // PUT: api/LevelQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevelQuestion([FromRoute] int id, [FromBody] LevelQuestion levelQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != levelQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(levelQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelQuestionExists(id))
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

        // POST: api/LevelQuestions
        [HttpPost]
        public async Task<IActionResult> PostLevelQuestion([FromBody] LevelQuestion levelQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.LevelQuestion.Add(levelQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevelQuestion", new { id = levelQuestion.Id }, levelQuestion);
        }

        // DELETE: api/LevelQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevelQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var levelQuestion = await _context.LevelQuestion.FindAsync(id);
            if (levelQuestion == null)
            {
                return NotFound();
            }

            _context.LevelQuestion.Remove(levelQuestion);
            await _context.SaveChangesAsync();

            return Ok(levelQuestion);
        }

        private bool LevelQuestionExists(int id)
        {
            return _context.LevelQuestion.Any(e => e.Id == id);
        }
    }
}