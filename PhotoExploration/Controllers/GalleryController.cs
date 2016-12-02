﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Helpers;
using PhotoExploration.Models;

namespace PhotoExploration.Controllers
{
    public class GalleryController : Controller
    {
        private PhotoRepository photoRepository;

        public GalleryController()
        {
            photoRepository = new PhotoRepository();
        }

        // GET: Gallery
        [AllowAnonymous]
        public ActionResult Index()
        {
            var photos = new List<GalleryPhotoViewModel>();
            photos.MapPhotos(photoRepository.GetItems().ToList());

            return View(photos);
        }

        [AllowAnonymous]
        public ActionResult Details(DetailsPhotoViewModel photo)
        {
            var picture = photoRepository.FindById(photo.Id);
            photo.MapPhoto(picture);

            return View(photo);
        }

        [HttpGet]
        public ActionResult UploadPhoto()
        {
            var photo = new GalleryPhotoViewModel();
            return PartialView(photo);
        }
        
        [HttpPost]
        public ActionResult UploadPhoto(GalleryPhotoViewModel model, HttpPostedFileBase photo)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            photoRepository.Add(model.MapPhoto(photo.FileName));

            photo.SaveAs(Path.Combine(Server.MapPath("~/Photos"), photo.FileName));
            return View("Index");
        }
    }
}