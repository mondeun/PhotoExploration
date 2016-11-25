using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoExploration.Areas.User.Controllers
{
    public class UserController : Controller
    {
        // GET: User/Account
        public ActionResult Index()
        {
            return View();
        }
    }
}