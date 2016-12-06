using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoExploration.Domain.Models;
using PhotoExploration.Models;

namespace PhotoExploration.Helpers
{
    public static class UserHelper
    {
        public static User MapUser(this RegistrationModel registrationUser )
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = registrationUser.Name,
                Admin = false,
                Email = registrationUser.Email,
                Password = registrationUser.Password
            };

            return user;
        }

        public static LoginModel MapUser(this LoginModel loginModel, User user)
        {
            loginModel.Id = user.Id;
            loginModel.Name = user.Name;
            loginModel.Email = user.Email;
            loginModel.Password = user.Password;
            loginModel.Admin = user.Admin;

            return loginModel;
        }
    }
}