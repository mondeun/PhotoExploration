using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PhotoExploration.Areas.Administration.Controllers
{
    public class ManagementController : Controller
    {
        [Authorize]
        // GET: Administration/Management
        public ActionResult Index()
        {
            using (var db = new PhotoExplorationContext())
            {
                var userId = User.Identity.GetUserId<int>();
                var comments = db.Comments.Include(i => i.Photo).Where(x => x.UserId == userId);

                return View(comments.ToList());
            }
        }
    }
}