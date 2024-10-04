using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.UseCases.Commands.MembershipFees;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Exceptions;
using Gym.Implementation.Validators.MembershipFee;

namespace Gym.Implementation.UseCases.Commands.MembershipFees
{
    public class EfUpdateMembershipFeeCommand : EfUseCase, IUpdateMembershipFeeCommand
    {
        private UpdateMembershipFeeDTOValidator validator;
        public EfUpdateMembershipFeeCommand(GymContext context, UpdateMembershipFeeDTOValidator _validator) : base(context)
        {
            this.validator = _validator;
        }

        public int Id => 8;

        public string Name => "MembershipFee Update";

        public void Execute(UpdateMembershipFeeDTO data)
        {
            MembershipFee target = Context.MembershipFees.FirstOrDefault(x => x.Id == data.Id && x.IsActive);

            if (target == null)
            {
                throw new NotFoundException();
            }

            var old = Context.MembershipFees.FirstOrDefault(x => x.TypeOfMembership == data.TypeOfMembership && x.Id != data.Id);


            if (old != null )
            {
                old.IsActive = true;
                target.IsActive = false;
            }
            validator.ValidateAndThrow(data);
            if (old == null)
            {
                target.TypeOfMembership = data.TypeOfMembership;
                target.Description = data.Description;
                target.Price = data.Price;
                target.IsActive = true;
            }

            Context.SaveChanges();
        }
    }
}
