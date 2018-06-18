using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;
using Postal;

namespace PostalAndHangfire.Mailer
{
    public class BaseMailer
    {
        protected void Send(Email email)
        {
            var mailerName = GetType().Name.Replace("Mailer", string.Empty);

            var viewsPath = Path.GetFullPath(string.Format(HostingEnvironment.MapPath(@"~/Views/Emails/{0}"), mailerName));
            var engines = new ViewEngineCollection();
            engines.Add(new FileSystemRazorViewEngine(viewsPath));

            var emailService = new EmailService(engines);

            emailService.Send(email);
        }
    }
}