using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Postal;

namespace PostalAndHangfire.App_Start.AutofacModules
{
    public class EmailModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailService>()
                .AsImplementedInterfaces();
        }
    }
}