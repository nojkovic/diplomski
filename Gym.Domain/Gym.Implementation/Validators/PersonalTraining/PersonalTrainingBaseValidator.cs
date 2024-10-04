using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.PersonalTraining;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.PersonalTraining
{
    public class PersonalTrainingBaseValidator<T> : AbstractValidator<T>
        where T : BasePersonalTrainingDTO
    {

        public PersonalTrainingBaseValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.NumberOfTerms)
               .NotEmpty().GreaterThan(0).LessThanOrEqualTo(20);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0);


        }
       
    }
}
