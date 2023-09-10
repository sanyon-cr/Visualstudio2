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
    public class StudentGradeNoCombinedsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentGradeNoCombinedsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentGradeNoCombineds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentGradeNoCombined>>> GetStudentGradeNoCombineds()
        {
          if (_context.StudentGradeNoCombineds == null)
          {
              return NotFound();
          }
            return await _context.StudentGradeNoCombineds.ToListAsync();
        }

        // GET: api/StudentGradeNoCombineds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentGradeNoCombined>> GetStudentGradeNoCombined(string id)
        {
          if (_context.StudentGradeNoCombineds == null)
          {
              return NotFound();
          }
            var studentGradeNoCombined = await _context.StudentGradeNoCombineds.FindAsync(id);

            if (studentGradeNoCombined == null)
            {
                return NotFound();
            }

            return studentGradeNoCombined;
        }

        // PUT: api/StudentGradeNoCombineds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentGradeNoCombined(string id, StudentGradeNoCombined studentGradeNoCombined)
        {
            if (id != studentGradeNoCombined.CourseCode)
            {
                return BadRequest();
            }

            _context.Entry(studentGradeNoCombined).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentGradeNoCombinedExists(id))
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

        // POST: api/StudentGradeNoCombineds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentGradeNoCombined>> PostStudentGradeNoCombined(StudentGradeNoCombined studentGradeNoCombined)
        {
          if (_context.StudentGradeNoCombineds == null)
          {
              return Problem("Entity set 'StudentContext.StudentGradeNoCombineds'  is null.");
          }
            _context.StudentGradeNoCombineds.Add(studentGradeNoCombined);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentGradeNoCombinedExists(studentGradeNoCombined.CourseCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentGradeNoCombined", new { id = studentGradeNoCombined.CourseCode }, studentGradeNoCombined);
        }

        // DELETE: api/StudentGradeNoCombineds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentGradeNoCombined(string id)
        {
            if (_context.StudentGradeNoCombineds == null)
            {
                return NotFound();
            }
            var studentGradeNoCombined = await _context.StudentGradeNoCombineds.FindAsync(id);
            if (studentGradeNoCombined == null)
            {
                return NotFound();
            }

            _context.StudentGradeNoCombineds.Remove(studentGradeNoCombined);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentGradeNoCombinedExists(string id)
        {
            return (_context.StudentGradeNoCombineds?.Any(e => e.CourseCode == id)).GetValueOrDefault();
        }
    }
}
