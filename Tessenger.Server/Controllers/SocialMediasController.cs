﻿using System;
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
    public class SocialMediasController : ControllerBase
    {
        private readonly TessengerServerContext _context;

        public SocialMediasController(TessengerServerContext context)
        {
            _context = context;
        }

        // GET: api/SocialMedias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Social_Media_Model>>> GetSocialMedia()
        {
            return await _context.Social_Media_Model.ToListAsync();
        }

        // GET: api/SocialMedias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Social_Media_Model>> GetSocialMedia(uint id)
        {
            var socialMedia = await _context.Social_Media_Model.FindAsync(id);

            if (socialMedia == null)
            {
                return NotFound();
            }

            return socialMedia;
        }

        // PUT: api/SocialMedias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocialMedia(uint id, Social_Media_Model socialMedia)
        {
            if (id != socialMedia.Id)
            {
                return BadRequest();
            }

            _context.Entry(socialMedia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SocialMediaExists(id))
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

        // POST: api/SocialMedias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("POST")]
        public async Task<ActionResult<Social_Media_Model>> PostSocialMedia(Social_Media_Model socialMedia)
        {
            _context.Social_Media_Model.Add(socialMedia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSocialMedia", new { id = socialMedia.Id }, socialMedia);
        }

        // DELETE: api/SocialMedias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(uint id)
        {
            var socialMedia = await _context.Social_Media_Model.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            _context.Social_Media_Model.Remove(socialMedia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SocialMediaExists(uint id)
        {
            return _context.Social_Media_Model.Any(e => e.Id == id);
        }
    }
}
