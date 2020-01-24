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
    public class QuestionAnswersController : ControllerBase
    {
        private readonly Context _context;

        public QuestionAnswersController(Context context)
        {
            _context = context;
        }

        // GET: api/QuestionAnswers
        [HttpGet]
        public IEnumerable<QuestionAnswer> GetQuestionAnswer()
        {
            return _context.QuestionAnswer;
        }

        // GET: api/QuestionAnswers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionAnswer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionAnswer = await _context.QuestionAnswer.FindAsync(id);

            if (questionAnswer == null)
            {
                return NotFound();
            }

            return Ok(questionAnswer);
        }

        // PUT: api/QuestionAnswers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionAnswer([FromRoute] int id, [FromBody] QuestionAnswer questionAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questionAnswer.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionAnswerExists(id))
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

        // POST: api/QuestionAnswers
        [HttpPost]
        public async Task<IActionResult> PostQuestionAnswer([FromBody] QuestionAnswer questionAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.QuestionAnswer.Add(questionAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionAnswer", new { id = questionAnswer.Id }, questionAnswer);
        }

        // DELETE: api/QuestionAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionAnswer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionAnswer = await _context.QuestionAnswer.FindAsync(id);
            if (questionAnswer == null)
            {
                return NotFound();
            }

            _context.QuestionAnswer.Remove(questionAnswer);
            await _context.SaveChangesAsync();

            return Ok(questionAnswer);
        }

        private bool QuestionAnswerExists(int id)
        {
            return _context.QuestionAnswer.Any(e => e.Id == id);
        }
    }
}