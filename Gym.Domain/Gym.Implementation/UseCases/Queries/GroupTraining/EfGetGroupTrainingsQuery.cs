using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation;

namespace Gym.Implementation.UseCases.Queries.GroupTraining
{
    public class EfGetGroupTrainingsQuery : EfUseCase, IGetGroupTrainingsQuery
    {
        private readonly IMapper _mapper;
        public EfGetGroupTrainingsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "GroupTrainings Search";

        public PagedResponse<ResponseGroupTrainingDTO> Execute(SearchGroupTraining search)
        {
            var query = Context.GroupTrainings.Where(x => x.IsActive).AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.TypeOfTraining.ToLower().Contains(search.Keyword.ToLower()));
            }
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.GroupTraining, ResponseGroupTrainingDTO>(search, _mapper);
        }
    }
}
