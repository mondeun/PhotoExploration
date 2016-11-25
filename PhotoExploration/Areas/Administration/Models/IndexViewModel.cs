using System.Collections.Generic;

namespace PhotoExploration.Areas.Administration.Models
{
    public class IndexViewModel
    {
        public ICollection<UserViewModel> UserViewModels { get; set; }
        public ICollection<CommentViewModel> CommentViewModels { get; set; }
        public ICollection<AlbumViewModel> AlbumViewModels { get; set; }
        public ICollection<PhotoViewModel> PhotoViewModels { get; set; }

        public IndexViewModel()
        {
            UserViewModels = new HashSet<UserViewModel>();
            CommentViewModels = new HashSet<CommentViewModel>();
            AlbumViewModels = new HashSet<AlbumViewModel>();
            PhotoViewModels = new HashSet<PhotoViewModel>();
        }
    }
}