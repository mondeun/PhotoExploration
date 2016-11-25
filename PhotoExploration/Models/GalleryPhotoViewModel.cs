using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoExploration.Models
{
    public class GalleryPhotoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
    }
}