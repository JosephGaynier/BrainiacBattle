using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class BenefitService
    {
        private readonly BrainiacBattleContext _context;

        public BenefitService(BrainiacBattleContext context)
        {
            _context = context;
        }
    }
}
