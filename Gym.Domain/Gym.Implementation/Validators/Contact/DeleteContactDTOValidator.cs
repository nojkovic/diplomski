﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Contact;
using Gym.DataAccess;

namespace Gym.Implementation.Validators.Contact
{
    public class DeleteContactDTOValidator:AbstractValidator<BaseContactDTO>
    {
        public DeleteContactDTOValidator(GymContext ctx) 
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;


            RuleFor(x => x.Id).Must(x => ctx.Contacts.Any(u => u.Id == x))
                .WithMessage("Id must exists");
        }
    }
}
