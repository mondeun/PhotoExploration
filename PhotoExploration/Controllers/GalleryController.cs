using System.Collections.Generic;
using System.Web.Mvc;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Helpers;
using PhotoExploration.Models;
using WebGrease.Css.Extensions;

namespace PhotoExploration.Controllers
{
    public class GalleryController : Controller
    {
        public PhotoRepository PhotoRepository { get; set; }

        public GalleryController()
        {
            PhotoRepository = new PhotoRepository();
        }

        // GET: Gallery
        [AllowAnonymous]
        public ActionResult Index()
        {
            var dbPhotos = PhotoRepository.GetPhotos();
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
    }
}