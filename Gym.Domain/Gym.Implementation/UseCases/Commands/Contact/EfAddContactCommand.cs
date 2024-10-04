using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Smtp;
using FluentValidation;
using Gym.Application.DTO.Contact;
using Gym.Application.DTO.Email;
using Gym.Application.Email;
using Gym.Application.UseCases.Commands.Contacts;
using Gym.DataAccess;
using Gym.Domain;
using Gym.Implementation.Validators.Contact;
using IEmailSender = Gym.Application.Email.IEmailSender;

namespace Gym.Implementation.UseCases.Commands.Contact
{
    public class EfAddContactCommand : EfUseCase, IAddContactCommand
    {
        private IUserEmailSender userEmailSender;
        private ContactValidator validator;

        public EfAddContactCommand(GymContext context, ContactValidator validator,IUserEmailSender userEmailSender) : base(context)
        {
            this.validator = validator;
            this.userEmailSender = userEmailSender;
        }

        public int Id => 67;

        public string Name => "Contact Add";

        public void Execute(ContactDTO data)
        {
            validator.ValidateAndThrow(data);
            Domain.Contact message = new Domain.Contact
            {
                Name = data.Name,
                Subject = data.Subject,
                Message = data.Message,
                Email = data.Email,
               
            };

            Context.Contacts.Add(message);
            Context.SaveChanges();

            UserEmailDTO dto = new UserEmailDTO
            {
                Email = data.Email,
                Subject = data.Subject,
                SendTo = "nojkovicsara23@gmail.com",
                Body = data.Message
            };

            userEmailSender.SendUserEmail(dto);


        }
    }
}
