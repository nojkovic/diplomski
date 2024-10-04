using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.User;

namespace Gym.Application.UseCases.Commands.Users
{
    public interface IUpdateUserCommand : ICommand<UpdateUserDto>
    {
    }
}
