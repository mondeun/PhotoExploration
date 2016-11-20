using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoExploration.Helpers;
using PhotoExploration.Models;

namespace PhotoExploration.Controllers
{
    public class GalleryController : Controller
    {
        PhotoExplorationContext db = new PhotoExplorationContext();
        // GET: Gallery
        [AllowAnonymous]
        public ActionResult Index()
        {
            var photos = db.Photos.ToList();
            return View(photos);
        }

        public ActionResult Show(Photo item)
        {
            return View(PhotoHelper.GetPhoto(item.Id));
        }
    }
}