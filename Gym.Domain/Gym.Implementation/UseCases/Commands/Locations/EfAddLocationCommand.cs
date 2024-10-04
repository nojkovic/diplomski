using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Location;
using Gym.Application.UseCases.Commands.Locations;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Location;

namespace Gym.Implementation.UseCases.Commands.Locations
{
    public class EfAddLocationCommand : EfUseCase, IAddLocationCommand
    {
        private AddLocationDTOValidator validator;
        public EfAddLocationCommand(GymContext context, AddLocationDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id =>22;

        public string Name =>"Location Add";

        public void Execute(LocationDTO data)
        {
            validator.ValidateAndThrow(data);

            Location loc = new Location
            {
               Address = data.Address,
               City= data.City

            };

            Context.Locations.Add(loc);
            Context.SaveChanges();
        }
    }
}
