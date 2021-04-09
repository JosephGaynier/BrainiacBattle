using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class GameService
    {
        private readonly BrainiacBattleContext _context;

        public GameService(BrainiacBattleContext context)
        {
            _context = context;
        }
    }
}
