﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Helpers;
using PhotoExploration.Models;

namespace PhotoExploration.Controllers
{
    public class HomeController : Controller
    {
        private PhotoRepository PhotoRepository { get; set; }

        public HomeController()
        {
            PhotoRepository = new PhotoRepository();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var photos = new List<GalleryPhotoViewModel>();
            photos.MapPhotos(PhotoRepository.GetItems().ToList());

            return View(photos);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Our goal is to let you explore everything from the abstract to the raw reality with this photo gallery site.";

            return View();
        }
    }
}