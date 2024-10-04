using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Contact;

namespace Gym.Application.UseCases.Commands.Contact
{
    public interface IDeleteContactCommand : ICommand<BaseContactDTO>
    {
    }
}
