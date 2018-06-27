using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostalAndHangfire.Mailer;
using PostalAndHangfire.Services;

namespace PostalAndHangfire.Tests.Mailer
{
    public class BaseIntegrationTests
    {
        protected Lazy<IEmailServiceFactory> CreateEmailServiceFactory()
        {
            return new Lazy<IEmailServiceFactory>(() =>
                new EmailServiceFactory(new Lazy<IHostingEnviromentService>(() => new TestHostingEnviromentService())));
        }
    }
}
