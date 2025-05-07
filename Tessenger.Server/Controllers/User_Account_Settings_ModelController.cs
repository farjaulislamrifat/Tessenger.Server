using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tessenger.Server.Algorithoms;
using Tessenger.Server.Authentications;
using Tessenger.Server.Data;
using Tessenger.Server.Models;

namespace Tessenger.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(Service_AuthFillter))]

    public class User_Account_Settings_ModelController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public IAlgorithoms algorithoms { get; set; }
        public IConfiguration configuration { get; set; }

        public User_Account_Settings_ModelController(TessengerServerContext context  , IAlgorithoms algorithoms , IConfiguration configuration)
        {
            _context = context;
            this.algorithoms = algorithoms;
            this.configuration = configuration;
        }

        // GET: api/User_Account_Settings_Model
        [HttpGet]
        public async Task<ActionResult<string>> GetUser_Account_Settings_Model()
        {
            return await algorithoms.Decryption("Yjp0lopgtVc=", configuration.GetSection("PublicKey").Value , configuration.GetSection("SecretKey").Value);
        }

        // GET: api/User_Account_Settings_Model/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_Account_Settings_Model>> GetUser_Account_Settings_Model(ulong id)
        {
            var user_Account_Settings_Model = await _context.User_Account_Settings_Model.FindAsync(id);

            if (user_Account_Settings_Model == null)
            {
                return NotFound();
            }

            return user_Account_Settings_Model;
        }

        // PUT: api/User_Account_Settings_Model/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_Account_Settings_Model(ulong id, User_Account_Settings_Model user_Account_Settings_Model)
        {
            if (id != user_Account_Settings_Model.Id)
            {
                return BadRequest();
            }

            _context.Entry(user_Account_Settings_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_Account_Settings_ModelExists(id))
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

        // POST: api/User_Account_Settings_Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_Account_Settings_Model>> PostUser_Account_Settings_Model(User_Account_Settings_Model user_Account_Settings_Model)
        {
            _context.User_Account_Settings_Model.Add(user_Account_Settings_Model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_Account_Settings_Model", new { id = user_Account_Settings_Model.Id }, user_Account_Settings_Model);
        }

        // DELETE: api/User_Account_Settings_Model/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_Account_Settings_Model(ulong id)
        {
            var user_Account_Settings_Model = await _context.User_Account_Settings_Model.FindAsync(id);
            if (user_Account_Settings_Model == null)
            {
                return NotFound();
            }

            _context.User_Account_Settings_Model.Remove(user_Account_Settings_Model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool User_Account_Settings_ModelExists(ulong id)
        {
            return _context.User_Account_Settings_Model.Any(e => e.Id == id);
        }
    }
}
