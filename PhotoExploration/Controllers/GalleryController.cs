using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Helpers;
using PhotoExploration.Models;
using WebGrease.Css.Extensions;

namespace PhotoExploration.Controllers
{
    public class GalleryController : Controller
    {
        private PhotoRepository PhotoRepository { get; set; }

        public GalleryController()
        {
            PhotoRepository = new PhotoRepository();
        }

        // GET: Gallery
        [AllowAnonymous]
        public ActionResult Index()
        {
            var dbPhotos = PhotoRepository.GetItems();
            var photos = new List<GalleryPhotoViewModel>();
            dbPhotos.ForEach(x => photos.Add(new GalleryPhotoViewModel
            {
                Id = x.Id,
                Name = x.Name,
                FileName = x.FileName
            }));
            return View(photos);
        }

        [AllowAnonymous]
        public ActionResult Details(DetailsPhotoViewModel photo)
        {
            //var picture = db.Photos.Include(i => i.Comments).FirstOrDefault(x => x.Id == item.Id);
            var picture = PhotoRepository.FindById(photo.Id);
            photo.MapPhoto(picture);

            return View(photo);
        }

        [HttpGet]
        public ActionResult UploadPhoto()
        {
            return PartialView();
        }
        
        [HttpPost]
        public ActionResult UploadPhoto(UploadPhotoViewModel model, HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            PhotoRepository.Add(model.MapPhoto(photo.FileName, Guid.NewGuid()));

            photo.SaveAs(Path.Combine(Server.MapPath("~/Photos"), photo.FileName));
            return PartialView("Index");
        }
    }
}