using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDumbster.smtp;
using PostalAndHangfire.Mailer;
using PostalAndHangfire.Models;
using PostalAndHangfire.Services;
using Xunit;

namespace PostalAndHangfire.Tests.Mailer
{
    public class UsersMailerIntegrationTests : BaseIntegrationTests
    {
        protected User User = new User()
        {
            FirstName = "Daniel",
            Email = "daniel@plawgo.pl"
        };

        protected UsersMailer Create()
        {
            return new UsersMailer(CreateEmailServiceFactory());
        }

        [Fact]
        public void SendRegisterEmail()
        {
            using (var server = SimpleSmtpServer.Start(25))
            {
                var usersMailer = Create();

                usersMailer.SendRegisterEmail(User);

                Assert.Equal(1, server.ReceivedEmailCount);

                var email = server.ReceivedEmail.FirstOrDefault();

                Assert.NotNull(email);
                Assert.Equal("daniel@plawgo.pl", email.ToAddresses[0].Address);
                Assert.Equal("test@email.com", email.FromAddress.Address);
                Assert.Equal("Nowe konto", email.Headers["Subject"]);

                var body = email.MessageParts[0].BodyData.FromBase64();

                Assert.Contains("Witaj Daniel!", body);
                Assert.Contains("Dziękujemy za założenie konta.", body);
            }
        }
    }
}
