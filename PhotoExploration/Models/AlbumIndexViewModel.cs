using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Models
{
    public class AlbumIndexViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}