using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Postal;
using PostalAndHangfire.Models;
using PostalAndHangfire.Services;
using PostalAndHangfire.ViewModels.Users;

namespace PostalAndHangfire.Mailer
{
    public class UsersMailer : BaseMailer, IUserMailer
    {
        public UsersMailer(Lazy<IEmailServiceFactory> emailServiceFactory) 
            : base(emailServiceFactory)
        {
        }

        public void SendRegisterEmail(User user)
        {
            var email = new RegisterEmail()
            {
                Email = user.Email,
                FirstName = user.FirstName
            };

            //email.Send();
            Send(email);
        }
    }

    public interface IUserMailer
    {
        void SendRegisterEmail(User user);
    }
}