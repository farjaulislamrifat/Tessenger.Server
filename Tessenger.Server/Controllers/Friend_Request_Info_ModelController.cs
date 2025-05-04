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
    public class Friend_Request_Info_ModelController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public Friend_Request_Info_ModelController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/Friend_Request_Info_Model
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friend_Request_Info_Model>>> GetFriend_Request_Info_Model()
        {
            return await _context.Friend_Request_Info_Model.ToListAsync();
        }

        // GET: api/Friend_Request_Info_Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Friend_Request_Info_Model>> GetFriend_Request_Info_Model(ulong id)
        {
            var friend_Request_Info_Model = await _context.Friend_Request_Info_Model.FindAsync(id);

            if (friend_Request_Info_Model == null)
            {
                return NotFound();
            }

            return friend_Request_Info_Model;
        }

        // PUT: api/Friend_Request_Info_Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriend_Request_Info_Model(ulong id, Friend_Request_Info_Model friend_Request_Info_Model)
        {
            if (id != friend_Request_Info_Model.Id)
            {
                return BadRequest();
            }

            _context.Entry(friend_Request_Info_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Friend_Request_Info_ModelExists(id))
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

        // POST: api/Friend_Request_Info_Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Friend_Request_Info_Model>> PostFriend_Request_Info_Model(Friend_Request_Info_Model friend_Request_Info_Model)
        {
            _context.Friend_Request_Info_Model.Add(friend_Request_Info_Model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriend_Request_Info_Model", new { id = friend_Request_Info_Model.Id }, friend_Request_Info_Model);
        }

        // DELETE: api/Friend_Request_Info_Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriend_Request_Info_Model(ulong id)
        {
            var friend_Request_Info_Model = await _context.Friend_Request_Info_Model.FindAsync(id);
            if (friend_Request_Info_Model == null)
            {
                return NotFound();
            }

            _context.Friend_Request_Info_Model.Remove(friend_Request_Info_Model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Friend_Request_Info_ModelExists(ulong id)
        {
            return _context.Friend_Request_Info_Model.Any(e => e.Id == id);
        }
    }
}
