using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using PostalAndHangfire.Mailer;
using PostalAndHangfire.Models;
using PostalAndHangfire.ViewModels.Users;
using Xunit;

namespace PostalAndHangfire.Tests.Mailer
{
    public class UsersMailerUnitTests : BaseUnitTests
    {
        protected User User = new User()
        {
            FirstName = "Daniel",
            Email = "daniel@plawgo.pl"
        };

        protected UsersMailer Create()
        {
            CreateMocks();

            return new UsersMailer(new Lazy<IEmailServiceFactory>(() => EmailServiceFactory.Object));
        }

        [Fact]
        public void Invoke_EmailService()
        {
            var usersMailer = Create();

            usersMailer.SendRegisterEmail(User);

            EmailService.Verify(s => s.Send(It.Is<RegisterEmail>(e => e.Email == "daniel@plawgo.pl" || e.FirstName == "Daniel")));
        }
    }
}
