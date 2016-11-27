using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Models
{
    public class AlbumDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public AlbumDetailsViewModel()
        {
            Photos = new HashSet<Photo>();
        }
    }
}