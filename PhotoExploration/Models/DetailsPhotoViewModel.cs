using System;
using System.Collections.Generic;

namespace PhotoExploration.Models
{
    public class DetailsPhotoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string UploadedBy { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public DetailsPhotoViewModel()
        {
            Comments = new HashSet<CommentViewModel>();
        }
    }
}