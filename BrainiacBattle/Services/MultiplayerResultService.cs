using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class MultiplayerResultService
    {
        private readonly BrainiacBattleContext _context;

        public MultiplayerResultService(BrainiacBattleContext context)
        {
            _context = context;
        }
    }
}
