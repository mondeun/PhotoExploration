using System;
using System.Collections.Generic;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Models
{
    public class AlbumViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }

        public ICollection<DetailsPhotoViewModel> Photos { get; set; }

        public AlbumViewModel()
        {
            Photos = new HashSet<DetailsPhotoViewModel>();
        }
    }
}