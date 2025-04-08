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
    public class Group_Information_ModelController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public Group_Information_ModelController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/Group_Information_Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group_Information_Model>>> GetGroup_Information_Model()
        {
            return await _context.Group_Information_Model.ToListAsync();
        }

        // GET: api/Group_Information_Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group_Information_Model>> GetGroup_Information_Model(ulong id)
        {
            var group_Information_Model = await _context.Group_Information_Model.FindAsync(id);

            if (group_Information_Model == null)
            {
                return NotFound();
            }

            return group_Information_Model;
        }

        // PUT: api/Group_Information_Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup_Information_Model(ulong id, Group_Information_Model group_Information_Model)
        {
            if (id != group_Information_Model.Id)
            {
                return BadRequest();
            }

            _context.Entry(group_Information_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Group_Information_ModelExists(id))
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

        // POST: api/Group_Information_Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group_Information_Model>> PostGroup_Information_Model(Group_Information_Model group_Information_Model)
        {
            _context.Group_Information_Model.Add(group_Information_Model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup_Information_Model", new { id = group_Information_Model.Id }, group_Information_Model);
        }

        // DELETE: api/Group_Information_Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup_Information_Model(ulong id)
        {
            var group_Information_Model = await _context.Group_Information_Model.FindAsync(id);
            if (group_Information_Model == null)
            {
                return NotFound();
            }

            _context.Group_Information_Model.Remove(group_Information_Model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Group_Information_ModelExists(ulong id)
        {
            return _context.Group_Information_Model.Any(e => e.Id == id);
        }
    }
}
