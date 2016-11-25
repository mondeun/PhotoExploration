using System;
using System.Collections.Generic;

namespace PhotoExploration.Domain.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public Album()
        {
            Photos = new HashSet<Photo>();
        }
    }
}
