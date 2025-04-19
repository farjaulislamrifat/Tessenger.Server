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
    public class Website_ModelController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public Website_ModelController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/Website_Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Website_Model>>> GetWebsite_Model()
        {
            return await _context.Website_Model.ToListAsync();
        }

        // GET: api/Website_Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Website_Model>> GetWebsite_Model(ulong id)
        {
            var website_Model = await _context.Website_Model.FindAsync(id);

            if (website_Model == null)
            {
                return NotFound();
            }

            return website_Model;
        }

        // PUT: api/Website_Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebsite_Model(ulong id, Website_Model website_Model)
        {
            if (id != website_Model.Id)
            {
                return BadRequest();
            }

            _context.Entry(website_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Website_ModelExists(id))
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

        // POST: api/Website_Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("POST")]
        public async Task<ActionResult<Website_Model>> PostWebsite_Model(Website_Model website_Model)
        {
            _context.Website_Model.Add(website_Model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebsite_Model", new { id = website_Model.Id }, website_Model);
        }

        // DELETE: api/Website_Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWebsite_Model(ulong id)
        {
            var website_Model = await _context.Website_Model.FindAsync(id);
            if (website_Model == null)
            {
                return NotFound();
            }

            _context.Website_Model.Remove(website_Model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Website_ModelExists(ulong id)
        {
            return _context.Website_Model.Any(e => e.Id == id);
        }
    }
}
