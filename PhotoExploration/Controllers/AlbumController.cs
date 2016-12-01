using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoExploration.Domain;
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
            var albums = new List<AlbumIndexViewModel>();
            albums.MapAlbums(AlbumRepository.GetItems().ToList());
            return View(albums);
        }

        // GET: Album/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Album/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                AlbumRepository.Add(model.MapAlbum());

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Album/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Album/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Album/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Album/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
