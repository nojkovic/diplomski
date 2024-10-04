using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Status;
using Gym.Application.UseCases.Commands.Status;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Exceptions;
using Gym.Implementation.Validators.Status;

namespace Gym.Implementation.UseCases.Commands.Status
{
    public class EfAddStatusCommand : EfUseCase, IAddStatusCommand
    {
        private AddStatusDTOValidator validator;
        public EfAddStatusCommand(GymContext context, AddStatusDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 27;

        public string Name => "Status Add";

        public void Execute(StatusDTO data)
        {
            
            
            var old = Context.Status.FirstOrDefault(x => x.Name == data.Name);
            
            if (old != null)
            {
                old.IsActive = true;
             
            }
            validator.ValidateAndThrow(data);
            if(old==null)
            {
                Domain.Status s = new Domain.Status
                {
                    Name = data.Name

                };

                Context.Status.Add(s);
            }
           
            Context.SaveChanges();
        }
    }
}
