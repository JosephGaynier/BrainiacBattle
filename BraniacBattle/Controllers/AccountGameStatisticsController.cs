using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BraniacBattle.Data;
using BraniacBattle.Models;

namespace BraniacBattle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountGameStatisticsController : ControllerBase
    {
        private readonly BraniacBattleContext _context;

        public AccountGameStatisticsController(BraniacBattleContext context)
        {
            _context = context;
        }

        // GET: api/AccountGameStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountGameStatistics>>> GetAccountGameStatistics()
        {
            return await _context.AccountGameStatistics.ToListAsync();
        }

        // GET: api/AccountGameStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountGameStatistics>> GetAccountGameStatistics(int id)
        {
            var accountGameStatistics = await _context.AccountGameStatistics.FindAsync(id);

            if (accountGameStatistics == null)
            {
                return NotFound();
            }

            return accountGameStatistics;
        }

        // PUT: api/AccountGameStatistics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountGameStatistics(int id, AccountGameStatistics accountGameStatistics)
        {
            if (id != accountGameStatistics.AccountGameStaticId)
            {
                return BadRequest();
            }

            _context.Entry(accountGameStatistics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountGameStatisticsExists(id))
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

        // POST: api/AccountGameStatistics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountGameStatistics>> PostAccountGameStatistics(AccountGameStatistics accountGameStatistics)
        {
            _context.AccountGameStatistics.Add(accountGameStatistics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountGameStatistics", new { id = accountGameStatistics.AccountGameStaticId }, accountGameStatistics);
        }

        // DELETE: api/AccountGameStatistics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountGameStatistics>> DeleteAccountGameStatistics(int id)
        {
            var accountGameStatistics = await _context.AccountGameStatistics.FindAsync(id);
            if (accountGameStatistics == null)
            {
                return NotFound();
            }

            _context.AccountGameStatistics.Remove(accountGameStatistics);
            await _context.SaveChangesAsync();

            return accountGameStatistics;
        }

        private bool AccountGameStatisticsExists(int id)
        {
            return _context.AccountGameStatistics.Any(e => e.AccountGameStaticId == id);
        }
    }
}
