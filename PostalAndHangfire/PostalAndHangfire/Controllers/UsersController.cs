using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using PostalAndHangfire.Logics;
using PostalAndHangfire.Models;
using PostalAndHangfire.ViewModels.Users;

namespace PostalAndHangfire.Controllers
{
    public class UsersController : Controller
    {
        protected IMapper Mapper { get; set; }

        protected IUserLogic UserLogic { get; set; }

        public UsersController(IMapper mapper,
            IUserLogic userLogic)
        {
            Mapper = mapper;
            UserLogic = userLogic;
        }

        public ActionResult Create()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(viewModel);
            }

            var user = Mapper.Map<User>(viewModel);

            UserLogic.Add(user);

            return Content("Added");
        }
    }
}