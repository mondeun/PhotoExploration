using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoExploration.Domain.Interfaces;
using PhotoExploration.Domain.Models;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Helpers;
using PhotoExploration.Models;

namespace PhotoExploration.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IRepository<Photo> _photoRepository;
        private readonly IRepository<Comment> _commentRepository;

        public GalleryController()
        {
            _photoRepository = new PhotoRepository();
            _commentRepository = new CommentRepository();
        }

        // GET: Gallery
        [AllowAnonymous]
        public ActionResult Index()
        {
            var photos = new List<GalleryPhotoViewModel>();
            photos.MapPhotos(_photoRepository.GetItems().ToList());

            return View(photos);
        }

        [AllowAnonymous]
        public ActionResult Details(DetailsPhotoViewModel photo)
        {
            var picture = _photoRepository.FindById(photo.Id);
            photo.MapPhoto(picture);

            return View(photo);
        }

        [HttpGet]
        [Authorize]
        public ActionResult UploadPhoto()
        {
            var photo = new GalleryPhotoViewModel();
            var albums = AlbumRepository.GetAlbumsByUserId(UserRepository.GetUserId(User.Identity.Name));
            albums.ForEach(x => photo.Albums.Add(new SelectListItem {Text = x.Name, Value = x.Id.ToString()}));

            return PartialView(photo);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPhoto(GalleryPhotoViewModel model, HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            _photoRepository.Add(model.MapPhoto(photo.FileName, UserRepository.GetUserId(User.Identity.Name)));

            photo.SaveAs(Path.Combine(Server.MapPath("~/Photos"), photo.FileName));
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Comments(ICollection<CommentViewModel> comments)
        {
            return PartialView(comments);
        }

        [HttpGet]
        public ActionResult AddComment(GalleryPhotoViewModel model)
        {
            var comment = new CommentViewModel {PhotoId = model.Id};

            return PartialView(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentViewModel model)
        {
            model.Commenter = User.Identity.Name;
            _commentRepository.Add(model.MapComment());

            var photo = new DetailsPhotoViewModel();
            var picture = _photoRepository.FindById(model.PhotoId);
            photo.MapPhoto(picture);

            return PartialView("Comments", photo.Comments);
        }
    }
}