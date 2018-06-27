using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Postal;
using PostalAndHangfire.Mailer;

namespace PostalAndHangfire.Tests.Mailer
{
    public class BaseUnitTests
    {
        protected Mock<IEmailServiceFactory> EmailServiceFactory { get; set; }

        protected Mock<IEmailService> EmailService { get; set; }

        protected void CreateMocks()
        {
            EmailServiceFactory = new Mock<IEmailServiceFactory>();

            EmailService = new Mock<IEmailService>();

            EmailServiceFactory.Setup(s => s.Create(It.IsAny<Type>()))
                .Returns(EmailService.Object);
        }
    }
}
