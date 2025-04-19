using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tessenger.Server.Data;
using Tessenger.Server.Models;

namespace Tessenger.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Education_ModelController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public Education_ModelController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/Education_Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Education_Model>>> GetEducation_Model()
        {
            return await _context.Education_Model.ToListAsync();
        }

        // GET: api/Education_Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Education_Model>> GetEducation_Model(ulong id)
        {
            var education_Model = await _context.Education_Model.FindAsync(id);

            if (education_Model == null)
            {
                return NotFound();
            }

            return education_Model;
        }

        // PUT: api/Education_Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducation_Model(ulong id, Education_Model education_Model)
        {
            if (id != education_Model.Id)
            {
                return BadRequest();
            }

            _context.Entry(education_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Education_ModelExists(id))
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

        // POST: api/Education_Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("POST")]
        public async Task<ActionResult<Education_Model>> PostEducation_Model(Education_Model education_Model)
        {
            _context.Education_Model.Add(education_Model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducation_Model", new { id = education_Model.Id }, education_Model);
        }

        // DELETE: api/Education_Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation_Model(ulong id)
        {
            var education_Model = await _context.Education_Model.FindAsync(id);
            if (education_Model == null)
            {
                return NotFound();
            }

            _context.Education_Model.Remove(education_Model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Education_ModelExists(ulong id)
        {
            return _context.Education_Model.Any(e => e.Id == id);
        }
    }
}
