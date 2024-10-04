﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Location;
using Gym.Application.DTO.MembershipFee;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Location
{
    public class DeleteLocationDTOValidator : AbstractValidator<BaseLocationDTO>
    {
        public DeleteLocationDTOValidator(GymContext ctx)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id).Must(x => ctx.Locations.Any(u => u.Id == x))
                .WithMessage("Id must exists");

        }
    }
}