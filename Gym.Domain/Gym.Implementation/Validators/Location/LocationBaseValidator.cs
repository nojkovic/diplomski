using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.GroupTraining;
using Gym.Application.DTO.Location;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Location
{
    public class LocationBaseValidator<T> : AbstractValidator<T>
        where T : BaseLocationDTO
    {
       

        public LocationBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.City)
               .NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
           


        }
       
    }
}
