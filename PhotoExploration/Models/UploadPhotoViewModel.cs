using System.ComponentModel.DataAnnotations;

namespace PhotoExploration.Models
{
    public class UploadPhotoViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}