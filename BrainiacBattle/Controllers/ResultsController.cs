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
    public class ResultsController : ControllerBase
    {
        private readonly BrainiacBattleContext _context;

        public ResultsController(BrainiacBattleContext context)
        {
            _context = context;
        }

        // GET: api/Results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Results>>> GetResults()
        {
            return await _context.Results.ToListAsync();
        }

        // GET: api/Results/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Results>> GetResults(int id)
        {
            var results = await _context.Results.FindAsync(id);

            if (results == null)
            {
                return NotFound();
            }

            return results;
        }

        // PUT: api/Results/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResults(int id, Results results)
        {
            if (id != results.ResultId)
            {
                return BadRequest();
            }

            _context.Entry(results).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultsExists(id))
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

        // POST: api/Results
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Results>> PostResults(Results results)
        {
            _context.Results.Add(results);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResults", new { id = results.ResultId }, results);
        }

        // DELETE: api/Results/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Results>> DeleteResults(int id)
        {
            var results = await _context.Results.FindAsync(id);
            if (results == null)
            {
                return NotFound();
            }

            _context.Results.Remove(results);
            await _context.SaveChangesAsync();

            return results;
        }

        private bool ResultsExists(int id)
        {
            return _context.Results.Any(e => e.ResultId == id);
        }
    }
}
