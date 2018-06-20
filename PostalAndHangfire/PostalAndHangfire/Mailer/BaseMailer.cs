using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var engines = new ViewEngineCollectionWithoutResolver();
            engines.Add(new FileSystemRazorViewEngine(viewsPath));

            var emailService = new EmailService(engines);

            emailService.Send(email);
        }

        private class ViewEngineCollectionWithoutResolver : ViewEngineCollection
        {
            public ViewEngineCollectionWithoutResolver()
            {
                var resolverField = typeof(ViewEngineCollection).GetField("_dependencyResolver",
                    BindingFlags.NonPublic | BindingFlags.Instance);

                var resolver = new EmptyResolver();
                resolverField.SetValue(this, resolver);
            }

            private class EmptyResolver : IDependencyResolver
            {
                public object GetService(Type serviceType)
                {
                    return null;
                }

                public IEnumerable<object> GetServices(Type serviceType)
                {
                    return Enumerable.Empty<object>();
                }
            }
        }
    }
}