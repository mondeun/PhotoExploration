using System;
using System.Collections.Generic;

namespace PhotoExploration.Domain.Models
{
    public sealed class Photo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid UserId { get; set; }
        public Guid? AlbumId { get; set; }

        public Album Album { get; set; }
        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public Photo()
        {
            Comments = new HashSet<Comment>();
        }
    }
}
