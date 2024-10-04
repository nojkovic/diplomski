using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Location;
using Gym.Application.UseCases.Commands.GroupTrainings;
using Gym.Application.UseCases.Commands.Locations;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Location;

namespace Gym.Implementation.UseCases.Commands.Locations
{
    public class EfUpdateLocationCommand : EfUseCase, IUpdateLocationCommand
    {
        private UpdateLocationDTOValidator _validator;
        public EfUpdateLocationCommand(GymContext context, UpdateLocationDTOValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Location Update";

        public void Execute(UpdateLocationDTO data)
        {
            _validator.ValidateAndThrow(data);
            Location loc = Context.Locations.First(x => x.Id == data.Id);
            loc.Address= data.Address;
            loc.City= data.City;
            loc.IsActive = true;


            Context.SaveChanges();
        }
    }
}
