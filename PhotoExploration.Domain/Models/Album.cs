using System;
using System.Collections.Generic;

namespace PhotoExploration.Domain.Models
{
    public sealed class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public Album()
        {
            Photos = new HashSet<Photo>();
        }
    }
}
