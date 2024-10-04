using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application.DTO;
using Gym.Application.DTO.PersonalTraining;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation;

namespace Gym.Implementation.UseCases.Queries.PersonalTraining
{
    public class EfGetPersonalTrainingsQuery : EfUseCase, IGetPersonalTrainingsQuery
    {
        private readonly IMapper _mapper;
        public EfGetPersonalTrainingsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 21;

        public string Name => "PersonalTrainings Search";

        public PagedResponse<ResponsePersonalTrainingDTO> Execute(SearchPersonalTraining search)
        {
            var query = Context.PersonalTrainings.Where(x => x.IsActive).AsQueryable();


            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= search.MinPrice);
            }

            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= search.MaxPrice);
            }
            if (search.NumberOfTerm.HasValue)
            {
                query = query.Where(x => x.NumberOfTerms == search.NumberOfTerm);
            }
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.PersonalTraining, ResponsePersonalTrainingDTO>(search, _mapper);
        }
    }
}
