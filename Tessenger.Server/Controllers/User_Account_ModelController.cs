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
    public class User_Account_ModelController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public User_Account_ModelController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/User_Account_Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_Account_Model>>> GetUser_Account_Model()
        {
            return await _context.User_Account_Model.ToListAsync();
        }

        // GET: api/User_Account_Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_Account_Model>> GetUser_Account_Model(ulong id)
        {
            var user_Account_Model = await _context.User_Account_Model.FindAsync(id);

            if (user_Account_Model == null)
            {
                return NotFound();
            }

            return user_Account_Model;
        }

        // PUT: api/User_Account_Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_Account_Model(ulong id, User_Account_Model user_Account_Model)
        {
            if (id != user_Account_Model.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_Account_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_Account_ModelExists(id))
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

        // POST: api/User_Account_Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_Account_Model>> PostUser_Account_Model(User_Account_Model user_Account_Model)
        {
            _context.User_Account_Model.Add(user_Account_Model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_Account_Model", new { id = user_Account_Model.Id }, user_Account_Model);
        }

        // DELETE: api/User_Account_Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_Account_Model(ulong id)
        {
            var user_Account_Model = await _context.User_Account_Model.FindAsync(id);
            if (user_Account_Model == null)
            {
                return NotFound();
            }

            _context.User_Account_Model.Remove(user_Account_Model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_Account_ModelExists(ulong id)
        {
            return _context.User_Account_Model.Any(e => e.Id == id);
        }
    }
}
