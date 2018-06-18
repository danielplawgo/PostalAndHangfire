using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PostalAndHangfire.Mailer;
using PostalAndHangfire.Models;

namespace PostalAndHangfire.Logics
{
    public class UserLogic : IUserLogic
    {
        protected IUserMailer UserMailer { get; set; }

        public UserLogic(IUserMailer userMailer)
        {
            UserMailer = userMailer;
        }

        public void Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            //walidacja danych

            //zapis danych w bazie

            //wysyłka maila
            UserMailer.SendRegisterEmail(user);
        }
    }

    public interface IUserLogic
    {
        void Add(User user);
    }
}