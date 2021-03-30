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
    public class MultiplayerResultsController : ControllerBase
    {
        private readonly BrainiacBattleContext _context;

        public MultiplayerResultsController(BrainiacBattleContext context)
        {
            _context = context;
        }

        // GET: api/MultiplayerResults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultiplayerResult>>> GetMultiplayerResult()
        {
            return await _context.MultiplayerResult.ToListAsync();
        }

        // GET: api/MultiplayerResults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MultiplayerResult>> GetMultiplayerResult(int id)
        {
            var multiplayerResult = await _context.MultiplayerResult.FindAsync(id);

            if (multiplayerResult == null)
            {
                return NotFound();
            }

            return multiplayerResult;
        }

        // PUT: api/MultiplayerResults/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMultiplayerResult(int id, MultiplayerResult multiplayerResult)
        {
            if (id != multiplayerResult.MultiplayerResultId)
            {
                return BadRequest();
            }

            _context.Entry(multiplayerResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MultiplayerResultExists(id))
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

        // POST: api/MultiplayerResults
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MultiplayerResult>> PostMultiplayerResult(MultiplayerResult multiplayerResult)
        {
            _context.MultiplayerResult.Add(multiplayerResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMultiplayerResult", new { id = multiplayerResult.MultiplayerResultId }, multiplayerResult);
        }

        // DELETE: api/MultiplayerResults/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MultiplayerResult>> DeleteMultiplayerResult(int id)
        {
            var multiplayerResult = await _context.MultiplayerResult.FindAsync(id);
            if (multiplayerResult == null)
            {
                return NotFound();
            }

            _context.MultiplayerResult.Remove(multiplayerResult);
            await _context.SaveChangesAsync();

            return multiplayerResult;
        }

        private bool MultiplayerResultExists(int id)
        {
            return _context.MultiplayerResult.Any(e => e.MultiplayerResultId == id);
        }
    }
}
