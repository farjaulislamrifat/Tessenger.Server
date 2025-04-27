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
        [HttpGet("GET/USERNAME_WithFillter/{username}&{fillterquray}")]
        public async Task<ActionResult<User_Information_Model>> GetUser_Information_withFillter(string username , string fillterquray)
        {
            var user_Information = tessengerServerContext.User_Information_Model.FirstOrDefault(c => c.Username == username);

            if (user_Information == null)
            {
                return NotFound();
            }

            return await fillter(user_Information , fillterquray);
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
        [HttpGet("GET/ID_WithFillter/{id}&{fillterquary}")]
        public async Task<ActionResult<User_Information_Model>> GetUser_Information_withFillter(ulong id , string fillterquary)
        {
            var user_Information = tessengerServerContext.User_Information_Model.FirstOrDefault(c => c.Id == id);

            if (user_Information == null)
            {
                return NotFound();
            }

            return await fillter(user_Information, fillterquary);

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
            User_Information_Model? user_Information = tessengerServerContext.User_Information_Model.FirstOrDefault(c => c.Username == username);
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


        async Task<User_Information_Model> fillter(User_Information_Model obj, string quary)
        {
            return await Task.Run(() =>
            {
                quary = quary.Trim(' ');
                var quaryList = quary.Split(",");
                var newObj = new User_Information_Model();

                if (quaryList.Contains(nameof(User_Information_Model.Id)))
                    newObj.Id = obj.Id;

                if (quaryList.Contains(nameof(User_Information_Model.Username)))
                    newObj.Username = obj.Username;

                if (quaryList.Contains(nameof(User_Information_Model.Email)))
                    newObj.Email = obj.Email;

                if (quaryList.Contains(nameof(User_Information_Model.Phone_Number)))
                    newObj.Phone_Number = obj.Phone_Number; 
                
                if (quaryList.Contains(nameof(User_Information_Model.Middle_Name)))
                    newObj.Middle_Name = obj.Middle_Name;
                
                if (quaryList.Contains(nameof(User_Information_Model.Full_Name)))
                    newObj.Full_Name = obj.Full_Name;

                if (quaryList.Contains(nameof(User_Information_Model.First_Name)))
                    newObj.First_Name = obj.First_Name;

                if (quaryList.Contains(nameof(User_Information_Model.Last_Name)))
                    newObj.Last_Name = obj.Last_Name;

                if (quaryList.Contains(nameof(User_Information_Model.Profile_Picture)))
                    newObj.Profile_Picture = obj.Profile_Picture;

                if (quaryList.Contains(nameof(User_Information_Model.Bio)))
                    newObj.Bio = obj.Bio;

                if (quaryList.Contains(nameof(User_Information_Model.Date_Of_Birth)))
                    newObj.Date_Of_Birth = obj.Date_Of_Birth;

                if (quaryList.Contains(nameof(User_Information_Model.Social_Medias)))
                    newObj.Social_Medias = obj.Social_Medias;

                if (quaryList.Contains(nameof(User_Information_Model.WebSites)))
                    newObj.WebSites = obj.WebSites;

                if (quaryList.Contains(nameof(User_Information_Model.Educations)))
                    newObj.Educations = obj.Educations;

                if (quaryList.Contains(nameof(User_Information_Model.Nationality)))
                    newObj.Nationality = obj.Nationality;

                if (quaryList.Contains(nameof(User_Information_Model.Isactive)))
                    newObj.Isactive = obj.Isactive;

                if (quaryList.Contains(nameof(User_Information_Model.Authentation_Email)))
                    newObj.Authentation_Email = obj.Authentation_Email;

                if (quaryList.Contains(nameof(User_Information_Model.Authentation_Phone_Number)))
                    newObj.Authentation_Phone_Number = obj.Authentation_Phone_Number;

                if (quaryList.Contains(nameof(User_Information_Model.Authentation_Authenticator_App)))
                    newObj.Authentation_Authenticator_App = obj.Authentation_Authenticator_App;

                if (quaryList.Contains(nameof(User_Information_Model.Authentation_Security_Questions)))
                    newObj.Authentation_Security_Questions = obj.Authentation_Security_Questions;

                if (quaryList.Contains(nameof(User_Information_Model.Authentation_Security_Key)))
                    newObj.Authentation_Security_Key = obj.Authentation_Security_Key;

                if (quaryList.Contains(nameof(User_Information_Model.Religion)))
                    newObj.Religion = obj.Religion;

                if (quaryList.Contains(nameof(User_Information_Model.Address)))
                    newObj.Address = obj.Address;

                return newObj;
            });
        }


    }
}
