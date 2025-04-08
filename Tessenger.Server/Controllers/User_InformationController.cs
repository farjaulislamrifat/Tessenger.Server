using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Tessenger.Server.Authentications;
using Tessenger.Server.Data;
using Tessenger.Server.Models;

namespace Tessenger.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(Service_AuthFillter))]
    public class User_InformationController : ControllerBase
    {
        private readonly IDbContextFactory<TessengerServerContext> _context;
        private readonly IConfiguration _configuration;
        private readonly TessengerServerContext tessengerServerContext;


        public User_InformationController(IDbContextFactory<TessengerServerContext> context, IConfiguration configuration, TessengerServerContext tessengerServerContext)
        {
            _context = context;
            _configuration = configuration;
            this.tessengerServerContext = tessengerServerContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_Information_Model>>> GetUser_Information()
        {
            return await tessengerServerContext.User_Information_Model.ToListAsync();
        }


        [HttpGet("GET/USERNAME/{username}")]
        public async Task<ActionResult<User_Information_Model>> GetUser_Information(string username)
        {
            var user_Information = tessengerServerContext.User_Information_Model.FirstOrDefault(c => c.Username == username);

            if (user_Information == null)
            {
                return NotFound();
            }

            return user_Information;
        }
        [HttpGet("GET/ID/{id}")]
        public async Task<ActionResult<User_Information_Model>> GetUser_Information(ulong id)
        {
            var user_Information = tessengerServerContext.User_Information_Model.FirstOrDefault(c => c.Id == id);

            if (user_Information == null)
            {
                return NotFound();
            }

            return user_Information;
        }


        [HttpGet("GET/Email/{email}")]
        public async Task<ActionResult<User_Information_Model>> GetUser_Information_Email(string email)
        {
            var user_Information = tessengerServerContext.User_Information_Model.FirstOrDefault(c => c.Email == email);
            if (user_Information == null)
            {
                return NotFound();
            }
            return user_Information;
        }

        [HttpGet("GET/Phone/{phone}")]
        public async Task<ActionResult<User_Information_Model>> GetUser_Information_Phone(string phone)
        {
            var user_Information = tessengerServerContext.User_Information_Model.FirstOrDefault(c => c.Phone_Number == phone);
            if (user_Information == null)
            {
                return NotFound();
            }
            return user_Information;
        }


        [HttpPut("PUT/USERNAME/{username}")]
        public async Task<ActionResult<bool>> PutUser_Information(string username, User_Information_Model user_Information)
        {
            if (username != user_Information.Username)
            {
                return Ok(false);
            }

            tessengerServerContext.Entry(user_Information).State = EntityState.Modified;

            try
            {
                await tessengerServerContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_InformationExists(username))
                {
                    return Ok(false);
                }
                else
                {
                    throw;
                }
            }

            return Ok(true);
        }

        // POST: api/User_Information
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("POST")]
        public async Task<ActionResult<User_Information_Model>> PostUser_Information(User_Information_Model user_Information)
        {
            tessengerServerContext.User_Information_Model.Add(user_Information);
            await tessengerServerContext.SaveChangesAsync();

            return CreatedAtAction("GetUser_Information", new { id = user_Information.Id }, user_Information);
        }

        // DELETE: api/User_Information/5
        [HttpDelete("DELETE/USERNAME/{username}")]
        public async Task<ActionResult<bool>> DeleteUser_Information(string username)
        {
            var user_Information = tessengerServerContext.User_Information_Model.FirstOrDefault(c => c.Username == username);
            if (user_Information == null)
            {
                return Ok(false);
            }

            tessengerServerContext.User_Information_Model.Remove(user_Information);
            await tessengerServerContext.SaveChangesAsync();

            return Ok(true);
        }

        private bool User_InformationExists(string username)
        {
            return tessengerServerContext.User_Information_Model.Any(e => e.Username == username);
        }
    }
}
