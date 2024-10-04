using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gym.Application.DTO.Email;

namespace Gym.Application.Email
{
    public interface IEmailSender
    {
        void SendEmail(EmailDTO email);
    }
    public interface IUserEmailSender
    {
        void SendUserEmail(UserEmailDTO email);
    }
}
