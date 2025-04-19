using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Tessenger.Server.Algorithoms;
using Tessenger.Server.Authentications;
using Tessenger.Server.Data;
using Tessenger.Server.Models;

namespace Tessenger.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(Service_AuthFillter))]
    public class User_Account_ModelController : ControllerBase
    {
        private readonly TessengerServerContext _context;
        private readonly IDbContextFactory<TessengerServerContext> _contextFactory;
        IConfiguration configuration { get; set; }
        IAlgorithoms algorithoms { get; set; }
        public User_Account_ModelController(TessengerServerContext context, IDbContextFactory<TessengerServerContext> dbContext, IAlgorithoms algorithoms, IConfiguration configuration)
        {
            this.configuration = configuration;
            _context = context;
            this.algorithoms = algorithoms;
            _contextFactory = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_Account_Model>>> GetUser_Account_Model()
        {
            return await _context.User_Account_Model.ToListAsync();
        }


        [HttpGet("GET/USERNAME/{username}")]
        public async Task<ActionResult<User_Account_Model>> GetUser_Account_Model(string username)
        {
            username = await algorithoms.Decryption(username, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);

            var user_Account_Model = _context.User_Account_Model.FirstOrDefault(c => c.Username == username);

            if (user_Account_Model == null)
            {
                return NotFound();
            }

            return user_Account_Model;
        }

        [HttpGet("GET/ID/{id}")]
        public async Task<ActionResult<User_Account_Model>> GetUser_Account_Model(ulong id)
        {
            var user_Account_Model = _context.User_Account_Model.FirstOrDefault(c => c.Id == id);

            if (user_Account_Model == null)
            {
                return NotFound();
            }
            return user_Account_Model;
        }
        [HttpGet("GET/Email/{email}")]
        public async Task<ActionResult<User_Account_Model>> GetUser_Account_ModelByEmail(string email)
        {
            email = await algorithoms.Decryption(email, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);
            var username = (await _contextFactory.CreateDbContextAsync()).User_Information_Model.FirstOrDefault(c => c.Email == email).Username;

            var user_Account_Model = _context.User_Account_Model.FirstOrDefault(c => c.Username == username);

            if (user_Account_Model == null)
            {
                return NotFound();
            }
            return user_Account_Model;
        }

        [ServiceFilter(typeof(Service_AuthFillter_Without_Connect))]
        [HttpGet("GET/Email_Password/Temp/{email}&{password}")]
        public async Task<ActionResult<User_Account_Model>> GetUser_Account_Model(string email, string password)
        {
            email = await algorithoms.Decryption(email, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);
            password = await algorithoms.Decryption(password, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);

            var username = (await _contextFactory.CreateDbContextAsync()).User_Information_Model.FirstOrDefault(c => c.Email == email).Username;
            var user_Account_Model = _context.User_Account_Model.FirstOrDefault(c => c.Username == username && c.Password == password);

            if (user_Account_Model == null)
            {
                return NotFound();
            }
            return user_Account_Model;
        }

        [ServiceFilter(typeof(Service_AuthFillter_Without_Connect))]
        [HttpGet("GET/Username_Password/Temp/{username}&{password}")]
        public async Task<ActionResult<User_Account_Model>> GetUser_Account_ModelUsername_Password(string username, string password)
        {
            username = await algorithoms.Decryption(username, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);
            password = await algorithoms.Decryption(password, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);


            var user_Account_Model = _context.User_Account_Model.FirstOrDefault(c => c.Username == username && c.Password == password);

            if (user_Account_Model == null)
            {
                return NotFound();
            }
            return user_Account_Model;
        }

        [HttpGet("GET/User_Exists/{username}")]
        public async Task<ActionResult<bool>> GetUser_Exists(string username)
        {
            username = await algorithoms.Decryption(username, configuration.GetSection("PublicKey").Value, configuration.GetSection("SecretKey").Value);
            var User = (await _contextFactory.CreateDbContextAsync()).User_Account_Model.Any(c => c.Username == username);
            return Ok(User);
        }

        [ServiceFilter(typeof(Service_AuthFillter_Without_Connect))]
        [HttpGet("GET/UniqueUsername/Temp/{name}")]
        public async Task<ActionResult<string>> GetUser_UniqueUsername(string name)
        {
            return await Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    var user = await (await _contextFactory.CreateDbContextAsync()).User_Account_Model.FirstOrDefaultAsync(c => c.Username.ToLower() == $"{name.ToLower().Replace(" ", ".")}.{i}");
                    if (user == null)
                    {
                        return Ok($"{name.ToLower().Replace(" ", ".")}.{i}");
                    }
                    else
                    {
                        i++;
                    }
                }
            });
        }

        [HttpPut("PUT/Username/{username}")]
        public async Task<ActionResult<bool>> PutUser_Account_Model(string username, User_Account_Model user_Account_Model)
        {
           
            if (username != user_Account_Model.Username)
            {
                return Ok(false);
            }

            _context.Entry(user_Account_Model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_Account_ModelExists(username))
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

        // POST: api/User_Account_Model
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("POST")]
        public async Task<ActionResult<User_Account_Model>> PostUser_Account_Model(User_Account_Model user_Account_Model)
        {
            _context.User_Account_Model.Add(user_Account_Model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser_Account_Model", new { id = user_Account_Model.Id }, user_Account_Model);
        }

        // DELETE: api/User_Account_Model/5
        [HttpDelete("DELETE/Username/{username}")]
        public async Task<ActionResult<bool>> DeleteUser_Account_Model(string username)
        {
            var user_Account_Model = _context.User_Account_Model.FirstOrDefault(c => c.Username == username);
            if (user_Account_Model == null)
            {
                return Ok(false);
            }

            _context.User_Account_Model.Remove(user_Account_Model);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        private bool User_Account_ModelExists(string username)
        {
            return _context.User_Account_Model.Any(e => e.Username == username);
        }
    }
}
