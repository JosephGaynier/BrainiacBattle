using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class AccountCategoryStatisticService
    {
        private readonly BrainiacBattleContext _context;

        public AccountCategoryStatisticService(BrainiacBattleContext context)
        {
            _context = context;
        }
    }
}
