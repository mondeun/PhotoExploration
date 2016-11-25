using System;
using System.Collections.Generic;

namespace PhotoExploration.Domain.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid UserId { get; set; }
        public Guid? AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Photo()
        {
            Comments = new HashSet<Comment>();
        }
    }
}
