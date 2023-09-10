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
    public class StudentDetailsNoCombinedsController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentDetailsNoCombinedsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/StudentDetailsNoCombineds
        [HttpGet]
       
        public IActionResult GetStudentDetailsNoCombineds()
        {
          if (_context.StudentDetailsNoCombineds == null)
          {
              return NotFound();
          }
            return Ok(_context.StudentDetailsNoCombineds.ToList());
        }

        // GET: api/StudentDetailsNoCombineds/5
        [HttpGet("{id}")]
        
        public IActionResult GetStudentDetailsNoCombined(short id)
        {
          
            var studentDetailsNoCombined =  _context.StudentDetailsNoCombineds.Find(id);

            if (studentDetailsNoCombined == null)
            {
                return NotFound();
            }

            return Ok(studentDetailsNoCombined);
        }

        // PUT: api/StudentDetailsNoCombineds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        
        public IActionResult PutStudentDetailsNoCombined(short id,StudentDetailsNoCombined studentDetailsNoCombined)
        { 

             _context.Entry(studentDetailsNoCombined).State = EntityState.Modified;
             _context.SaveChanges();
            
    
            return Ok (_context.StudentDetailsNoCombineds.FirstOrDefault(x => x.StudentId == id)) ;

            

            
        }

        // POST: api/StudentDetailsNoCombineds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       
        public IActionResult PostStudentDetailsNoCombined([FromBody] StudentDetailsNoCombined studentDetailsNoCombined)
        {
            _context.StudentDetailsNoCombineds.Add(studentDetailsNoCombined);
            _context.SaveChanges();

            return Ok(true);
        }

        // DELETE: api/StudentDetailsNoCombineds/5
        [HttpDelete("{id}")]
        
        public IActionResult DeleteStudentDetailsNoCombined(short id)
        {
            if (_context.StudentDetailsNoCombineds == null)
            {
                return NotFound();
            }
            var studentDetailsNoCombined =  _context.StudentDetailsNoCombineds.Find(id);
            if (studentDetailsNoCombined == null)
            {
                return NotFound();
            }

            _context.StudentDetailsNoCombineds.Remove(studentDetailsNoCombined);
             _context.SaveChanges();

            return Ok();
        }

       
    }
}
