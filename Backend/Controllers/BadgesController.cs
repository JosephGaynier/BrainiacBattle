using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DbContexts;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly BraniacBattleContext _context;

        public BadgesController(BraniacBattleContext context)
        {
            _context = context;
        }

        // GET: api/Badges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Badges>>> GetBadges()
        {
            return await _context.Badges.ToListAsync();
        }

        // GET: api/Badges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Badges>> GetBadges(int id)
        {
            var badges = await _context.Badges.FindAsync(id);

            if (badges == null)
            {
                return NotFound();
            }

            return badges;
        }

        // PUT: api/Badges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBadges(int id, Badges badges)
        {
            if (id != badges.BadgeId)
            {
                return BadRequest();
            }

            _context.Entry(badges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadgesExists(id))
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

        // POST: api/Badges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Badges>> PostBadges(Badges badges)
        {
            _context.Badges.Add(badges);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBadges", new { id = badges.BadgeId }, badges);
        }

        // DELETE: api/Badges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Badges>> DeleteBadges(int id)
        {
            var badges = await _context.Badges.FindAsync(id);
            if (badges == null)
            {
                return NotFound();
            }

            _context.Badges.Remove(badges);
            await _context.SaveChangesAsync();

            return badges;
        }

        private bool BadgesExists(int id)
        {
            return _context.Badges.Any(e => e.BadgeId == id);
        }
    }
}
