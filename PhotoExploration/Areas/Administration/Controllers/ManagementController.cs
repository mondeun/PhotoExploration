using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PhotoExploration.Areas.Administration.Models;
using PhotoExploration.Models;

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

        [Authorize]
        public ActionResult UploadPhoto()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult UploadPhoto(UploadPhotoModel model, HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (var db = new PhotoExplorationContext())
            {
                db.Photos.Add(new Photo
                {
                    Title = model.Title,
                    Description = model.Description,
                    DateAdded = DateTime.Now,
                    Path = photo.FileName
                });

                db.SaveChanges();
            }

            photo.SaveAs(Path.Combine(Server.MapPath("~/Photos"), photo.FileName));
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DeleteComment(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            using (var db = new PhotoExplorationContext())
            {
                var comment = db.Comments.Include(i => i.Photo).FirstOrDefault(x => x.Id == id);
                return comment == null ? (ActionResult) HttpNotFound() : View(comment);
            }
        }

        [Authorize]
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(int id)
        {
            using (var db = new PhotoExplorationContext())
            {
                var comment = db.Comments.Include(i => i.Photo).FirstOrDefault(x => x.Id == id);
                db.Comments.Remove(comment);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}