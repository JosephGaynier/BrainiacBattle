using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class ResultService
    {
        private readonly BrainiacBattleContext _context;

        public ResultService(BrainiacBattleContext context)
        {
            _context = context;
        }
    }
}
