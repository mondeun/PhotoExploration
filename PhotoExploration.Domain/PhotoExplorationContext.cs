using System.Data.Entity;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Domain
{
    public class PhotoExplorationContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }

        public PhotoExplorationContext() : base("PhotoExplorationContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PhotoExplorationContext>());
        }
    }
}