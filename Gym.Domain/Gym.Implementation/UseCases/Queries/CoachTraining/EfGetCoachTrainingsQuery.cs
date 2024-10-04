using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.CoachTraining
{
    public class EfGetCoachTrainingsQuery : EfUseCase, IGetCoachTrainingsQuery
    {
        private readonly IMapper _mapper;
        public EfGetCoachTrainingsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 51;

        public string Name => "CoachTrainings Search";

        public PagedResponse<ResponseCoachTrainingDTO> Execute(SearchCoachTraining search)
        {
            var query = Context.CoachTrainings.Where(x => x.IsActive).AsQueryable();


            if (search.CoachId.HasValue)
            {
                query = query.Where(x => x.CoachId==search.CoachId);
            }
            if (search.TrainingId.HasValue)
            {
                query = query.Where(x => x.TrainingId == search.TrainingId);
            }

            if (search.GymId.HasValue)
            {
                query = query.Where(x => x.GymId == search.GymId);
            }
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.CoachTraining, ResponseCoachTrainingDTO>(search, _mapper);
        }
    }
}
