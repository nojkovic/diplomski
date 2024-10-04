using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly GymContext _context;

        protected EfUseCase(GymContext context)
        {
            _context = context;
        }

        protected GymContext Context => _context;
    }
}
