using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PostalAndHangfire.Models;
using PostalAndHangfire.ViewModels.Users;

namespace PostalAndHangfire.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserViewModel>()
                .ReverseMap();
        }
    }
}