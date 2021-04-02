using BrainiacBattle.Data;
using BrainiacBattle.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class AccountService
    {
        private readonly BrainiacBattleContext _context;

        public AccountService(BrainiacBattleContext context)
        {
            _context = context;
        }

        public async Task<Accounts> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts
                                    .Include(a => a.AccountGameStatistics)
                                    .Include(a => a.AccountCategoryStatistics)
                                    .Include(a => a.Game)
                                    .Include(a => a.AccountsBadges)
                                    .ThenInclude(ab => ab.Badge)
                                    .Where(a => a.AccountId == id)
                                    .FirstOrDefaultAsync();
        }

        public async Task UpdateAccountAsync(Accounts account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddAccountAsync(Accounts account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(Accounts accounts)
        {
            _context.Accounts.Remove(accounts);
            await _context.SaveChangesAsync();
        }

        public bool AccountsExists(int id)
        {
            return _context.Accounts.Any(a => a.AccountId == id);
        }

        public bool UsernameTaken(string username)
        {
            return _context.Accounts.Any(a => a.Username == username);
        }
    }
}
