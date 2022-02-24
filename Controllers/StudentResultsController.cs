#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GraphQLServer.Models;

namespace GraphQLServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentResultsController : ControllerBase
    {
        private readonly GraphQLDemoDBContext _context;

        public StudentResultsController(GraphQLDemoDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentResult>>> GetStudentResults()
        {
            return await _context.StudentResults.ToListAsync();
        }

        // GET: api/StudentResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResult>> GetStudentResult(long id)
        {
            var studentResult = await _context.StudentResults.FindAsync(id);

            if (studentResult == null)
            {
                return NotFound();
            }

            return studentResult;
        }

        // PUT: api/StudentResults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentResult(long id, StudentResult studentResult)
        {
            if (id != studentResult.StudentResultId)
            {
                return BadRequest();
            }

            _context.Entry(studentResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentResultExists(id))
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

        // POST: api/StudentResults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentResult>> PostStudentResult(StudentResult studentResult)
        {
            _context.StudentResults.Add(studentResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentResult", new { id = studentResult.StudentResultId }, studentResult);
        }

        // DELETE: api/StudentResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentResult(long id)
        {
            var studentResult = await _context.StudentResults.FindAsync(id);
            if (studentResult == null)
            {
                return NotFound();
            }

            _context.StudentResults.Remove(studentResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentResultExists(long id)
        {
            return _context.StudentResults.Any(e => e.StudentResultId == id);
        }
    }
}
