using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.MembershipFee;
using Gym.Application.UseCases.Commands.MembershipFees;
using Gym.Application.UseCases.Commands.Users;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Exceptions;
using Gym.Implementation.Validators.MembershipFee;

namespace Gym.Implementation.UseCases.Commands.MembershipFees
{
    public class EfAddMembershipFeeCommand : EfUseCase, IAddMembershipFeeCommand
    {
        private AddMembershipFeeDTOValidator validator;
        public EfAddMembershipFeeCommand(GymContext context, AddMembershipFeeDTOValidator _validator) : base(context)
        {
            this.validator = _validator;
        }

        public int Id => 7;

        public string Name =>"MembershipFee Add";

        public void Execute(MembershipFeeDTO data)
        {
            var old = Context.MembershipFees.FirstOrDefault(x => x.TypeOfMembership == data.TypeOfMembership);
            if (old == null)
            {
                MembershipFee mb = new MembershipFee
                {
                    TypeOfMembership = data.TypeOfMembership,
                    Description = data.Description,
                    Price = data.Price,

                };
                Context.MembershipFees.Add(mb);
            }
            if (old != null)
            {
                old.IsActive = true;
                old.Price= data.Price;

            }
            validator.ValidateAndThrow(data);
            

            
            Context.SaveChanges();
        }
    }
}
