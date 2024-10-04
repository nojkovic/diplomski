using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.CoachTraining;
using Gym.Application.DTO.GymTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.GymTraining
{
    public class EfGetGymTrainingsQuery : EfUseCase, IGetGymTrainingsQuery
    {
        private readonly IMapper _mapper;
        public EfGetGymTrainingsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 80;

        public string Name => "Gym training search";

        public PagedResponse<ResponseGymTrainingDTO> Execute(SearchGymTraining search)
        {
            var query = Context.GymTrainings.Where(x => x.IsActive).AsQueryable();

            if (search.TrainingId.HasValue)
            {
                query = query.Where(x => x.TrainingId == search.TrainingId);
            }

            if (search.GymId.HasValue)
            {
                query = query.Where(x => x.GymId == search.GymId);
            }
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.GymTraining, ResponseGymTrainingDTO>(search, _mapper);
        }
    }
}
