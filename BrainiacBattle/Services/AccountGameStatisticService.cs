using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class AccountGameStatisticService
    {
        private readonly BrainiacBattleContext _context;

        public AccountGameStatisticService(BrainiacBattleContext context)
        {
            _context = context;
        }
    }
}
