using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoExploration.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public int? UserId { get; set; }
        [ForeignKey(name: "UserId")]
        public virtual User User { get; set; }

        public Comment()
        {
            Photos = new HashSet<Photo>();
        }

    }
}