using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Hosting;
using System.Web.Mvc;
using Postal;
using PostalAndHangfire.Services;

namespace PostalAndHangfire.Mailer
{
    public class BaseMailer
    {
        private Lazy<IEmailServiceFactory> _emailServiceFactory;

        protected IEmailServiceFactory EmailServiceFactory
        {
            get { return _emailServiceFactory.Value; }
        }

        public BaseMailer(Lazy<IEmailServiceFactory> emailServiceFactory)
        {
            _emailServiceFactory = emailServiceFactory;
        }

        protected void Send(Email email)
        {
            var emailService = EmailServiceFactory.Create(GetType());

            emailService.Send(email);
        }
    }
}