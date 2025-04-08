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
    public class Group_Account_ModelController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public Group_Account_ModelController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/Group_Account_Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group_Account_Model>>> GetGroup_Account_Model()
        {
            return await _context.Group_Account_Model.ToListAsync();
        }

        // GET: api/Group_Account_Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group_Account_Model>> GetGroup_Account_Model(ulong id)
        {
            var group_Account_Model = await _context.Group_Account_Model.FindAsync(id);

            if (group_Account_Model == null)
            {
                return NotFound();
            }

            return group_Account_Model;
        }

        // PUT: api/Group_Account_Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup_Account_Model(ulong id, Group_Account_Model group_Account_Model)
        {
            if (id != group_Account_Model.Id)
            {
                return BadRequest();
            }

            _context.Entry(group_Account_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Group_Account_ModelExists(id))
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

        // POST: api/Group_Account_Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group_Account_Model>> PostGroup_Account_Model(Group_Account_Model group_Account_Model)
        {
            _context.Group_Account_Model.Add(group_Account_Model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup_Account_Model", new { id = group_Account_Model.Id }, group_Account_Model);
        }

        // DELETE: api/Group_Account_Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup_Account_Model(ulong id)
        {
            var group_Account_Model = await _context.Group_Account_Model.FindAsync(id);
            if (group_Account_Model == null)
            {
                return NotFound();
            }

            _context.Group_Account_Model.Remove(group_Account_Model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Group_Account_ModelExists(ulong id)
        {
            return _context.Group_Account_Model.Any(e => e.Id == id);
        }
    }
}
