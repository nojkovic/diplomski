using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Gym.Application;
using Gym.Application.DTO;
using Gym.Application.DTO.Contact;
using Gym.Application.DTO.Gym;
using Gym.Application.UseCases.Queries;
using Gym.DataAccess;

namespace Gym.Implementation.UseCases.Queries.Contact
{
    public class EfGetContactsQuery : EfUseCase, IGetContactsQuery
    {
        private readonly IMapper _mapper;
        public EfGetContactsQuery(GymContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Contact Search";

        public PagedResponse<ResponseContact> Execute(ContactSearch search)
        {
            var query = Context.Contacts.Where(x => x.IsActive).AsQueryable();


            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Keyword.ToLower()) || x.Subject.ToLower().Contains(search.Keyword.ToLower()) || x.Email.ToLower().Contains(search.Keyword.ToLower()));
            }
           
            var groupt = query.ToList();

            return query.AsPagedReponse<Domain.Contact, ResponseContact>(search, _mapper);
        }
    }
}

