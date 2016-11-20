using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoExploration.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Path { get; set; }
        public DateTime DateAdded { get; set; }
        [Required]
        public virtual ICollection<Comment> Comments { get; set; }

        public Photo()
        {
            Comments = new HashSet<Comment>();
        }
    }
}