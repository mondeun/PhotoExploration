using System;
using System.Collections.Generic;

namespace PhotoExploration.Domain.Models
{
    public sealed class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public ICollection<Album> Albums { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Photo> Photos { get; set; }

        public User()
        {
            Albums = new HashSet<Album>();
            Comments = new HashSet<Comment>();
            Photos = new HashSet<Photo>();
        }
    }
}
