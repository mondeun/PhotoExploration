using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoExploration.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Path { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public int? UserId { get; set; }
        [ForeignKey(name: "UserId")]
        public virtual User User { get; set; }

        public Photo()
        {
            Comments = new HashSet<Comment>();
        }
    }
}