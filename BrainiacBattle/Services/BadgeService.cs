using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class BadgeService
    {
        private readonly BrainiacBattleContext _context;

        public BadgeService(BrainiacBattleContext context)
        {
            _context = context;
        }
    }
}
