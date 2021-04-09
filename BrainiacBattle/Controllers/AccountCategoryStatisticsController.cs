using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrainiacBattle.Data;
using BrainiacBattle.Models;

namespace BrainiacBattle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCategoryStatisticsController : ControllerBase
    {
        private readonly BrainiacBattleContext _context;

        public AccountCategoryStatisticsController(BrainiacBattleContext context)
        {
            _context = context;
        }

        // GET: api/AccountCategoryStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountCategoryStatistics>>> GetAccountCategoryStatistics()
        {
            return await _context.AccountCategoryStatistics.ToListAsync();
        }

        // GET: api/AccountCategoryStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountCategoryStatistics>> GetAccountCategoryStatistics(int id)
        {
            var accountCategoryStatistics = await _context.AccountCategoryStatistics.FindAsync(id);

            if (accountCategoryStatistics == null)
            {
                return NotFound();
            }

            return accountCategoryStatistics;
        }

        // PUT: api/AccountCategoryStatistics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountCategoryStatistics(int id, AccountCategoryStatistics accountCategoryStatistics)
        {
            if (id != accountCategoryStatistics.AccountCategoryStaticId)
            {
                return BadRequest();
            }

            _context.Entry(accountCategoryStatistics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountCategoryStatisticsExists(id))
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

        // POST: api/AccountCategoryStatistics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AccountCategoryStatistics>> PostAccountCategoryStatistics(AccountCategoryStatistics accountCategoryStatistics)
        {
            _context.AccountCategoryStatistics.Add(accountCategoryStatistics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountCategoryStatistics", new { id = accountCategoryStatistics.AccountCategoryStaticId }, accountCategoryStatistics);
        }

        // DELETE: api/AccountCategoryStatistics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AccountCategoryStatistics>> DeleteAccountCategoryStatistics(int id)
        {
            var accountCategoryStatistics = await _context.AccountCategoryStatistics.FindAsync(id);
            if (accountCategoryStatistics == null)
            {
                return NotFound();
            }

            _context.AccountCategoryStatistics.Remove(accountCategoryStatistics);
            await _context.SaveChangesAsync();

            return accountCategoryStatistics;
        }

        private bool AccountCategoryStatisticsExists(int id)
        {
            return _context.AccountCategoryStatistics.Any(e => e.AccountCategoryStaticId == id);
        }
    }
}
