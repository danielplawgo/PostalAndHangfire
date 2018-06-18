using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Postal;

namespace PostalAndHangfire.ViewModels.Users
{
    public class RegisterEmail : Email
    {
        public string FirstName { get; set; }

        public string Email { get; set; }
    }
}