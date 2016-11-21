using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using PhotoExploration.Models;

namespace PhotoExploration.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel user)
        {
            if (!ModelState.IsValid)
                return View(user);

            using (var db = new PhotoExplorationContext())
            {
                foreach (var dbUser in db.Users)
                {
                    if (user.Email == dbUser.Email && user.Password == dbUser.Password)
                    {
                        var identity = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, dbUser.Name),
                            new Claim(ClaimTypes.Email, dbUser.Email),
                            new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
                        }, "AppCookie");

                        var ctx = Request.GetOwinContext();
                        var login = ctx.Authentication;
                        login.SignIn(identity);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Wrong email or password");
            return View(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new PhotoExplorationContext())
                {
                    db.Users.Add(new User
                    {
                        Email = user.Email,
                        Name = user.Name,
                        Password = user.Password,
                        Admin = false
                    });

                    db.SaveChanges();
                }
            }
            else
                ModelState.AddModelError("", "Missing information");

            return RedirectToAction("Index", "Home");
        }
    }
}