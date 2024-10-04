using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Status;
using Gym.Application.UseCases.Commands.Locations;
using Gym.Application.UseCases.Commands.Status;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Exceptions;
using Gym.Implementation.Validators.Status;

namespace Gym.Implementation.UseCases.Commands.Status
{
    public class EfUpdateStatusCommand : EfUseCase, IUpdateStatusCommand
    {
        private UpdateStatusDTOValidator validator;
        public EfUpdateStatusCommand(GymContext context, UpdateStatusDTOValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 28;

        public string Name => "Status Update";

        public void Execute(UpdateStatusDTO data)
        {
            Domain.Status st = Context.Status.First(x => x.Id == data.Id);
            if (st == null)
            {
                throw new NotFoundException();
            }
            var old=Context.Status.FirstOrDefault(x=>x.Name==data.Name);
            if(old !=null )
            {
                old.IsActive = true;
                st.IsActive = false;
            }
            validator.ValidateAndThrow(data);

            if(old==null){
                st.Name = data.Name;
                st.IsActive = true;
            }


            Context.SaveChanges();
        }
    }
}
