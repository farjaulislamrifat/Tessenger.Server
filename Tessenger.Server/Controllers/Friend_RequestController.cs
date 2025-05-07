using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tessenger.Server.Authentications;
using Tessenger.Server.Data;
using Tessenger.Server.Models;

namespace Tessenger.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(Service_AuthFillter))]

    public class Friend_RequestController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public Friend_RequestController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/Friend_Request_Send
        [HttpGet("GET")]
        public async Task<ActionResult<IEnumerable<Friend_Request_Model>>> GetFriend_Request_Send()
        {
            return await _context.Friend_Request_Model.ToListAsync();
        }


        [HttpGet("GET/USERNAME/{username}")]
        public async Task<ActionResult<Friend_Request_Model>> GetFriend_Request_Send(string username)
        {
            var friend_Request_Send = _context.Friend_Request_Model.FirstOrDefault(c => c.Username == username);

            if (friend_Request_Send == null)
            {
                return NotFound();
            }

            return friend_Request_Send;
        }

        // PUT: api/Friend_Request_Send/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("PUT/USERNAME/{username}")]
        public async Task<IActionResult> PutFriend_Request_Send(string username, Friend_Request_Model friend_Request_Send)
        {
            if (username != friend_Request_Send.Username)
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
                if (!Friend_Request_SendExists(username))
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

   
        [HttpPost("POST")]
        public async Task<ActionResult<Friend_Request_Model>> PostFriend_Request_Send(Friend_Request_Model friend_Request_Send)
        {
            _context.Friend_Request_Model.Add(friend_Request_Send);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriend_Request_Send", new { id = friend_Request_Send.Id }, friend_Request_Send);
        }

        // DELETE: api/Friend_Request_Send/5
        [HttpDelete("DELETE/USERNAME/{username}")]
        public async Task<IActionResult> DeleteFriend_Request_Send(string username)
        {
            var friend_Request_Send = _context.Friend_Request_Model.FirstOrDefault(c => c.Username == username);
            if (friend_Request_Send == null)
            {
                return NotFound();
            }

            _context.Friend_Request_Model.Remove(friend_Request_Send);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("DELETE/USERNAME_Id/{username}&{id}")]
        public async Task<IActionResult> DeleteFriend_Request_Send(string username, ulong id)
        {
            var friend_Request_Send = _context.Friend_Request_Model.FirstOrDefault(c => c.Username == username);
            if (friend_Request_Send == null)
            {
                return NotFound();
            }
            friend_Request_Send.Members_Info.Remove(id);
            _context.Entry(friend_Request_Send).State = EntityState.Modified;

            try
            {

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }

            return NoContent();
        }

        private bool Friend_Request_SendExists(string username)
        {
            return _context.Friend_Request_Model.Any(e => e.Username == username);
        }
    }
}
