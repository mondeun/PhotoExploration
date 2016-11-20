using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PhotoExploration.Models;

namespace PhotoExploration
{
    public class PhotoExplorationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public PhotoExplorationContext() : base("PhotoExplorationContext") { }
    }
}