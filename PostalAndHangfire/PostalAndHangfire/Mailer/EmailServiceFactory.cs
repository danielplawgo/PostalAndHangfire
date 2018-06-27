using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Postal;
using PostalAndHangfire.Services;

namespace PostalAndHangfire.Mailer
{
    public class EmailServiceFactory : IEmailServiceFactory
    {
        private Lazy<IHostingEnviromentService> _hostingEnviromentService;

        protected IHostingEnviromentService HostingEnviromentService
        {
            get { return _hostingEnviromentService.Value; }
        }

        public EmailServiceFactory(Lazy<IHostingEnviromentService> hostingEnviromentService)
        {
            _hostingEnviromentService = hostingEnviromentService;
        }

        public IEmailService Create(Type mailerType)
        {
            var mailerName = mailerType.Name.Replace("Mailer", string.Empty);

            var viewsPath = Path.GetFullPath(string.Format(HostingEnviromentService.MapPath(@"~/Views/Emails/{0}"), mailerName));
            var engines = new ViewEngineCollectionWithoutResolver();
            engines.Add(new FileSystemRazorViewEngine(viewsPath));

            return new EmailService(engines);
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

    public interface IEmailServiceFactory
    {
        IEmailService Create(Type mailerType);
    }
}