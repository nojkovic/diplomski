using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.Status;
using Gym.Application.DTO.Training;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Training
{
    public class EfGetTrainingsQuery : EfUseCase, IGetTrainingsQuery
    {
        private readonly IMapper _mapper;
        public EfGetTrainingsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 46;

        public string Name => "Trainings Search";

        public PagedResponse<ResponseTrainingDTO> Execute(SearchTraining search)
        {
            var query = Context.Trainings.Where(x => x.IsActive).AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.TrainingType.ToLower().Contains(search.Keyword.ToLower()));
            }
            var st = query.ToList();

            return query.AsPagedReponse<Domain.Training, ResponseTrainingDTO>(search, _mapper);
        }
    }
}
