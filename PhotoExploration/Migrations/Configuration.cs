using PhotoExploration.Models;

namespace PhotoExploration.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoExploration.PhotoExplorationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PhotoExploration.PhotoExplorationContext";
        }

        protected override void Seed(PhotoExploration.PhotoExplorationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(x => x.Id,
                new User { Id = 1,Name = "Kenneth G", Email = "kg@kg.se",Password = "qwerty1", Admin = true},
                new User { Id = 2, Name = "Coolio", Email = "coolcat@yahoo.com", Password = "asdf123", Admin = false}
                );

            context.Photos.AddOrUpdate(x => x.Id,
                new Photo { Id = 1, Title = "Beach", Description = "A beach", Path = "img1.jpg", DateAdded = DateTime.Now},
                new Photo { Id = 2, Title = " Hotel Beach", Description = "A beach at a hotel", Path = "img2.jpg", DateAdded = DateTime.Now },
                new Photo { Id = 3, Title = "Buildings", Description = "Buildings in Maldives", Path = "img3.jpg", DateAdded = DateTime.Now },
                new Photo { Id = 4, Title = "Port", Description = "A port", Path = "img4.jpg", DateAdded = DateTime.Now },
                new Photo { Id = 5, Title = "Bungalow", Description = "A bungalow at the coast", Path = "img5.jpg", DateAdded = DateTime.Now },
                new Photo { Id = 6, Title = "Jungle beach", Description = "A jungle beach", Path = "img6.jpg", DateAdded = DateTime.Now }
                );

            context.Comments.AddOrUpdate(x => x.Id,
                new Comment { Id = 1, Text = "Stunning", DateAdded = DateTime.Now.AddDays(-4), PhotoId = 1, UserId = 1},
                new Comment { Id = 2, Text = "That looks beautiful", DateAdded = DateTime.Now.AddDays(-2), PhotoId = 1, UserId = 2 },
                new Comment { Id = 3, Text = "Yes it does!", DateAdded = DateTime.Now, PhotoId = 1, UserId = 1 },
                new Comment { Id = 4, Text = "Terrible", DateAdded = DateTime.Now, PhotoId = 3, UserId = 2 }
                );
        }
    }
}
