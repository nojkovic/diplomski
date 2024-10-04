using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Gym.Application.DTO.Contact;
using Gym.Application.UseCases.Commands.Contact;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Contact;
using Microsoft.EntityFrameworkCore;

namespace Gym.Implementation.UseCases.Commands.Contact
{
    public class EfDeleteContactCommand : EfUseCase, IDeleteContactCommand
    {
        private DeleteContactDTOValidator validator;
        public EfDeleteContactCommand(GymContext context,DeleteContactDTOValidator _validator) : base(context)
        {
            this.validator = _validator;
        }

        public int Id => 5;
        public string Name => "Contact Delete";

        public void Execute(BaseContactDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.Contact contact = Context.Contacts
                                    .First(x => x.Id == data.Id);

           
            contact.IsActive = false;
            Context.SaveChanges();
        }
    }
}
