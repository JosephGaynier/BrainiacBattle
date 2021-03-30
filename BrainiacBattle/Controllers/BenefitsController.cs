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
    public class BenefitsController : ControllerBase
    {
        private readonly BrainiacBattleContext _context;

        public BenefitsController(BrainiacBattleContext context)
        {
            _context = context;
        }

        // GET: api/Benefits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Benefits>>> GetBenefits()
        {
            return await _context.Benefits.ToListAsync();
        }

        // GET: api/Benefits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Benefits>> GetBenefits(int id)
        {
            var benefits = await _context.Benefits.FindAsync(id);

            if (benefits == null)
            {
                return NotFound();
            }

            return benefits;
        }

        // PUT: api/Benefits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBenefits(int id, Benefits benefits)
        {
            if (id != benefits.BenefitId)
            {
                return BadRequest();
            }

            _context.Entry(benefits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BenefitsExists(id))
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

        // POST: api/Benefits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Benefits>> PostBenefits(Benefits benefits)
        {
            _context.Benefits.Add(benefits);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBenefits", new { id = benefits.BenefitId }, benefits);
        }

        // DELETE: api/Benefits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Benefits>> DeleteBenefits(int id)
        {
            var benefits = await _context.Benefits.FindAsync(id);
            if (benefits == null)
            {
                return NotFound();
            }

            _context.Benefits.Remove(benefits);
            await _context.SaveChangesAsync();

            return benefits;
        }

        private bool BenefitsExists(int id)
        {
            return _context.Benefits.Any(e => e.BenefitId == id);
        }
    }
}
