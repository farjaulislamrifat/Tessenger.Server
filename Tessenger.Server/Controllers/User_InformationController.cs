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
    public class User_InformationController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public User_InformationController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/User_Information
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_Information>>> GetUser_Information()
        {
            return await _context.User_Information.ToListAsync();
        }

        // GET: api/User_Information/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_Information>> GetUser_Information(int id)
        {
            var user_Information = await _context.User_Information.FindAsync(id);

            if (user_Information == null)
            {
                return NotFound();
            }

            return user_Information;
        }

        // PUT: api/User_Information/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_Information(int id, User_Information user_Information)
        {
            if (id != user_Information.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_Information).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_InformationExists(id))
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

        // POST: api/User_Information
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_Information>> PostUser_Information(User_Information user_Information)
        {
            _context.User_Information.Add(user_Information);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_Information", new { id = user_Information.Id }, user_Information);
        }

        // DELETE: api/User_Information/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_Information(int id)
        {
            var user_Information = await _context.User_Information.FindAsync(id);
            if (user_Information == null)
            {
                return NotFound();
            }

            _context.User_Information.Remove(user_Information);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_InformationExists(int id)
        {
            return _context.User_Information.Any(e => e.Id == id);
        }
    }
}
