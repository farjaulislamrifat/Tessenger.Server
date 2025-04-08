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
    public class Friend_Request_SendController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public Friend_Request_SendController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/Friend_Request_Send
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Friend_Request_Send_Model>>> GetFriend_Request_Send()
        {
            return await _context.Friend_Request_Send_Model.ToListAsync();
        }

        // GET: api/Friend_Request_Send/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Friend_Request_Send_Model>> GetFriend_Request_Send(uint id)
        {
            var friend_Request_Send = await _context.Friend_Request_Send_Model.FindAsync(id);

            if (friend_Request_Send == null)
            {
                return NotFound();
            }

            return friend_Request_Send;
        }

        // PUT: api/Friend_Request_Send/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriend_Request_Send(uint id, Friend_Request_Send_Model friend_Request_Send)
        {
            if (id != friend_Request_Send.Id)
            {
                return BadRequest();
            }

            _context.Entry(friend_Request_Send).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Friend_Request_SendExists(id))
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

        // POST: api/Friend_Request_Send
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Friend_Request_Send_Model>> PostFriend_Request_Send(Friend_Request_Send_Model friend_Request_Send)
        {
            _context.Friend_Request_Send_Model.Add(friend_Request_Send);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriend_Request_Send", new { id = friend_Request_Send.Id }, friend_Request_Send);
        }

        // DELETE: api/Friend_Request_Send/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFriend_Request_Send(uint id)
        {
            var friend_Request_Send = await _context.Friend_Request_Send_Model.FindAsync(id);
            if (friend_Request_Send == null)
            {
                return NotFound();
            }

            _context.Friend_Request_Send_Model.Remove(friend_Request_Send);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Friend_Request_SendExists(uint id)
        {
            return _context.Friend_Request_Send_Model.Any(e => e.Id == id);
        }
    }
}
