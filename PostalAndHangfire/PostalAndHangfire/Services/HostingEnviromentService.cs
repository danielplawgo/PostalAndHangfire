using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace PostalAndHangfire.Services
{
    public class HostingEnviromentService : IHostingEnviromentService
    {
        public string MapPath(string path)
        {
            return HostingEnvironment.MapPath(path);
        }
    }

    public interface IHostingEnviromentService
    {
        string MapPath(string path);
    }
}