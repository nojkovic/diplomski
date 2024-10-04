using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Application.DTO.User
{
    public class RegisterUserDTO : BaseUserDto
    {
        public string Password { get; set; }
    }
}
