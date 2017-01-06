using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PhotoExploration.Helpers;
using PhotoExploration.Models;
using PhotoExploration.Domain.Repositories;

namespace PhotoExploration.Controllers
{
    public class AlbumController : Controller
    {
        private AlbumRepository AlbumRepository { get; set; }

        public AlbumController()
        {
            AlbumRepository = new AlbumRepository();
        }

        // GET: Album
        [AllowAnonymous]
        public ActionResult Index()
        {
            var albums = new List<AlbumViewModel>();
            albums.MapAlbums(AlbumRepository.GetItems().ToList());
            return View(albums);
        }

        [AllowAnonymous]
        public ActionResult List(List<AlbumViewModel> model)
        {
            var albums = new List<AlbumViewModel>();
            albums.MapAlbums(AlbumRepository.GetItems().ToList());

            return PartialView(albums);
        }

        // GET: Album/Details/5
        [AllowAnonymous]
        public ActionResult Details(AlbumViewModel model)
        {
            var album = AlbumRepository.FindById(model.Id);
            model.MapPhoto(album);

            return View(model);
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                AlbumRepository.Add(model.MapAlbum());

                var albums = new List<AlbumViewModel>();
                albums.MapAlbums(AlbumRepository.GetItems().ToList());

                return PartialView("List", albums);
            }
            return PartialView(model);
        }
    }
}
