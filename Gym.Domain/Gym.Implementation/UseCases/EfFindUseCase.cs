using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Exceptions;

namespace Gym.Implementation.UseCases
{
    public abstract class EfFindUseCase<TResult, TEntity> : EfUseCase, IQuery<TResult, int>
       where TResult : class
       where TEntity : Entity
    {
        private readonly IMapper _mapper;

        protected EfFindUseCase(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public abstract int Id { get; }
        public abstract string Name { get; }

        public TResult Execute(int search)
        {
            var item = Context.Set<TEntity>().Find(search);

            if (item == null || !item.IsActive)
            {
                throw new NotFoundException(nameof(TEntity), search);
            }

            return _mapper.Map<TResult>(item);
        }
    }
}
