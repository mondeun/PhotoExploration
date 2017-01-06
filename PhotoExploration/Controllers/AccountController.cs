using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using PhotoExploration.Domain;
using PhotoExploration.Domain.Models;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Helpers;
using PhotoExploration.Models;

namespace PhotoExploration.Controllers
{
    public class AccountController : Controller
    {
        private UserRepository userRepository;

        public AccountController()
        {
            userRepository = new UserRepository();
        }

        // GET: User
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user)
        {
            if (!ModelState.IsValid)
                return PartialView(user);

            var dbUser = new LoginModel();
            dbUser.MapUser(userRepository.GetUserByCredentials(user.Email, user.Password));

            if (dbUser.Email != null && dbUser.Password != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, dbUser.Name),
                    new Claim(ClaimTypes.Email, dbUser.Email),
                    new Claim(ClaimTypes.Role, dbUser.Admin ? "Admin" : "User"),
                    new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
                }, "AppCookie");

                var ctx = Request.GetOwinContext();
                var auth = ctx.Authentication;
                auth.SignIn(identity);

                return RedirectToAction("Index", "Home");
            }

            return PartialView(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationModel user)
        {
            if (ModelState.IsValid)
                userRepository.Add(user.MapUser());
            else
            {
                ModelState.AddModelError("", "Missing information");
                return PartialView(user);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var auth = ctx.Authentication;

            auth.SignOut("AppCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}