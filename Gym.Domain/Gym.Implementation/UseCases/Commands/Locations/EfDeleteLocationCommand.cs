using System;
using System.Collections.Generic;
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
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Locations
{
    public class EfDeleteLocationCommand : EfUseCase, IDeleteLocationCommand
    {
        private DeleteLocationDTOValidator validator;
        public EfDeleteLocationCommand(GymContext context, DeleteLocationDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 24;

        public string Name => "Location Delete";

        public void Execute(BaseLocationDTO data)
        {
            validator.ValidateAndThrow(data);
            Location loc = Context.Locations.Include(x=>x.Gyms).First(x => x.Id == data.Id);

            var gymLocations = loc.Gyms;

            foreach (var g in gymLocations)
            {
                g.IsActive = false;

            }
            loc.IsActive = false;
            Context.SaveChanges();
        }
    }
}
