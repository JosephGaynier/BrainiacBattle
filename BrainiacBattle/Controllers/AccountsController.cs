using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrainiacBattle.Data;
using BrainiacBattle.Models;
using BrainiacBattle.Services;

namespace BrainiacBattle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountsController(AccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Accounts/{id}
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Accounts>> GetAccount(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // PUT: api/Accounts/{id}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAccount(Accounts account)
        {
            try
            {
                await _accountService.UpdateAccountAsync(account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_accountService.AccountsExists(account.AccountId))
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

        // DELETE: api/Accounts/{id}
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Accounts>> DeleteAccounts(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            await _accountService.DeleteAccountAsync(account);

            return account;
        }
    }
}
