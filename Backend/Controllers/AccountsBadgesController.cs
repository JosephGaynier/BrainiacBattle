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
    public class AccountsBadgesController : ControllerBase
    {
        private readonly BraniacBattleContext _context;

        public AccountsBadgesController(BraniacBattleContext context)
        {
            _context = context;
        }

        // GET: api/AccountsBadges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountsBadges>>> GetAccountsBadges()
        {
            return await _context.AccountsBadges.ToListAsync();
        }

        // GET: api/AccountsBadges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountsBadges>> GetAccountsBadges(int id)
        {
            var accountsBadges = await _context.AccountsBadges.FindAsync(id);

            if (accountsBadges == null)
            {
                return NotFound();
            }

            return accountsBadges;
        }

        // PUT: api/AccountsBadges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountsBadges(int id, AccountsBadges accountsBadges)
        {
            if (id != accountsBadges.AccountBadgeId)
            {
                return BadRequest();
            }

            _context.Entry(accountsBadges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsBadgesExists(id))
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

        // POST: api/AccountsBadges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountsBadges>> PostAccountsBadges(AccountsBadges accountsBadges)
        {
            _context.AccountsBadges.Add(accountsBadges);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountsBadges", new { id = accountsBadges.AccountBadgeId }, accountsBadges);
        }

        // DELETE: api/AccountsBadges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountsBadges>> DeleteAccountsBadges(int id)
        {
            var accountsBadges = await _context.AccountsBadges.FindAsync(id);
            if (accountsBadges == null)
            {
                return NotFound();
            }

            _context.AccountsBadges.Remove(accountsBadges);
            await _context.SaveChangesAsync();

            return accountsBadges;
        }

        private bool AccountsBadgesExists(int id)
        {
            return _context.AccountsBadges.Any(e => e.AccountBadgeId == id);
        }
    }
}
