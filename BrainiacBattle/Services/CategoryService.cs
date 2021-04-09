using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainiacBattle.Services
{
    public class CategoryService
    {
        private readonly BrainiacBattleContext _context;
        
        public CategoryService(BrainiacBattleContext context)
        {
            _context = context;
        }
    }
}
