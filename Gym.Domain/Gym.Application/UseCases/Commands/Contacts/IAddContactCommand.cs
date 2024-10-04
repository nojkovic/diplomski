using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Contact;

namespace Gym.Application.UseCases.Commands.Contacts
{
    public interface IAddContactCommand:ICommand<ContactDTO>
    {
    }
}
