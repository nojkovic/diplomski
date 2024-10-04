using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.UseCases.Commands.Contact;
using Gym.Application.UseCases.Commands.MembershipFees;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.MembershipFee;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.MembershipFees
{
    public class EfDeleteMembershipFeeCommand : EfUseCase, IDeleteMembershipFeeCommand
    {
        private DeleteMembershipFeeDTOValidator validator;
        public EfDeleteMembershipFeeCommand(GymContext context, DeleteMembershipFeeDTOValidator _validator) : base(context)
        {
            this.validator = _validator;
        }

        public int Id => 9;

        public string Name => "MembershipFee Delete";

        public void Execute(BaseMembershipFeeDTO data)
        {
            validator.ValidateAndThrow(data);
            MembershipFee mbf = Context.MembershipFees.First(x => x.Id == data.Id);

            mbf.IsActive = false;
            Context.SaveChanges();

        }
    }
}
