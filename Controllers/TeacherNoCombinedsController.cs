using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.Models;

namespace Student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherNoCombinedsController : ControllerBase
    {
        private readonly StudentContext _context;

        public TeacherNoCombinedsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/TeacherNoCombineds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherNoCombined>>> GetTeacherNoCombineds()
        {
          if (_context.TeacherNoCombineds == null)
          {
              return NotFound();
          }
            return await _context.TeacherNoCombineds.ToListAsync();
        }

        // GET: api/TeacherNoCombineds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherNoCombined>> GetTeacherNoCombined(string id)
        {
          if (_context.TeacherNoCombineds == null)
          {
              return NotFound();
          }
            var teacherNoCombined = await _context.TeacherNoCombineds.FindAsync(id);

            if (teacherNoCombined == null)
            {
                return NotFound();
            }

            return teacherNoCombined;
        }

        // PUT: api/TeacherNoCombineds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherNoCombined(string id, TeacherNoCombined teacherNoCombined)
        {
            if (id != teacherNoCombined.TeacherId)
            {
                return BadRequest();
            }

            _context.Entry(teacherNoCombined).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherNoCombinedExists(id))
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

        // POST: api/TeacherNoCombineds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherNoCombined>> PostTeacherNoCombined(TeacherNoCombined teacherNoCombined)
        {
          if (_context.TeacherNoCombineds == null)
          {
              return Problem("Entity set 'StudentContext.TeacherNoCombineds'  is null.");
          }
            _context.TeacherNoCombineds.Add(teacherNoCombined);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TeacherNoCombinedExists(teacherNoCombined.TeacherId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTeacherNoCombined", new { id = teacherNoCombined.TeacherId }, teacherNoCombined);
        }

        // DELETE: api/TeacherNoCombineds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherNoCombined(string id)
        {
            if (_context.TeacherNoCombineds == null)
            {
                return NotFound();
            }
            var teacherNoCombined = await _context.TeacherNoCombineds.FindAsync(id);
            if (teacherNoCombined == null)
            {
                return NotFound();
            }

            _context.TeacherNoCombineds.Remove(teacherNoCombined);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeacherNoCombinedExists(string id)
        {
            return (_context.TeacherNoCombineds?.Any(e => e.TeacherId == id)).GetValueOrDefault();
        }
    }
}
