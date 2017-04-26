using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PhotoExploration.Areas.Administration.Models;
using PhotoExploration.Domain;

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
                //var userId = User.Identity.GetUserId<Guid>();
                //var comments = db.Comments.Include(i => i.Photo);

                var data = new IndexViewModel();

                db.Albums.ToList().ForEach(x => data.AlbumViewModels.Add(new AlbumViewModel
                {
                   Id = x.Id,
                   Name = x.Name,
                }));

                db.Comments.Include("User").Include("Photo").ToList().ForEach(x => data.CommentViewModels.Add(new CommentViewModel
                {
                    Id = x.Id,
                    Commenter = x.User.Name,
                    Comment = x.Text,
                    Date = x.Date,
                    PhotoName = x.Photo.Name
                }));

                db.Photos.Include("User").Include("Album").ToList().ForEach(x => data.PhotoViewModels.Add(new PhotoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    FileName = x.FileName,
                    Album = x.Album.Name,
                    Uploader = x.User.Name,
                    Description = x.Description,
                    DateAdded = x.DateAdded
                }));

                db.Users.ToList().ForEach(x => data.UserViewModels.Add(new UserViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                }));

                return View(data);
            }
        }

        [Authorize]
        public ActionResult DeleteComment(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new PhotoExplorationContext())
            {
                var comment = db.Comments.Include(i => i.Photo).FirstOrDefault(x => x.Id == id);
                if (comment == null)
                {
                    return HttpNotFound();
                }
                var viewComment = new CommentViewModel
                {
                    Id = comment.Id,
                    Commenter = comment.User.Name,
                    Date = comment.Date,
                    PhotoName = comment.Photo.Name,
                    Comment = comment.Text
                };
                return View(viewComment);
            }
        }

        [Authorize]
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCommentConfirmed(Guid id)
        {
            using (var db = new PhotoExplorationContext())
            {
                var comment = db.Comments.Include(i => i.Photo).FirstOrDefault(x => x.Id == id);
                if (comment == null)
                {
                    return new HttpNotFoundResult();
                }
                db.Comments.Remove(comment);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}