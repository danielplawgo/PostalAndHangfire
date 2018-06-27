using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostalAndHangfire.Services;

namespace PostalAndHangfire.Tests.Mailer
{
    public class TestHostingEnviromentService : IHostingEnviromentService
    {
        public string MapPath(string path)
        {
            var basePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
            return path.Replace("~", Path.Combine(basePath, "PostalAndHangfire")).Replace("/", "\\");
        }
    }
}
