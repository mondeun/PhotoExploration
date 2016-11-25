namespace PhotoExploration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Domain;
    using Domain.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoExplorationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhotoExplorationContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new User { Id = Guid.Parse("fbbf6db0-d7c7-4519-ad9b-fca8c889c5f8"), Name = "Kenneth G", Email = "kg@kg.se", Password = "qwerty", Admin = true,},
                new User { Id = Guid.Parse("652eaedf-a246-4d94-b976-57be95cabbd2"), Name = "Steve O", Email = "roudy@yahoo.com", Password = "qazwsx1", Admin = false, }
                );

            context.Albums.AddOrUpdate(x => x.Id,
                new Album { Id = Guid.Parse("fbbf6db0-d7c7-4719-ac9b-5ca8c889c5f8"), Name = "Maldives", UserId = Guid.Parse("fbbf6db0-d7c7-4519-ad9b-fca8c889c5f8") }
                );

            context.Photos.AddOrUpdate(x => x.Id,
                new Photo
                {
                    Id = Guid.Parse("432f6db0-d7c7-4519-ad9b-fca8c889c5f8"),
                    Name = "Beach",
                    Description = "A beach",
                    UserId = Guid.Parse("fbbf6db0-d7c7-4519-ad9b-fca8c889c5f8"),
                    DateAdded = DateTime.Now.AddHours(-5),
                    FileName = "img1.jpg",
                    AlbumId = Guid.Parse("fbbf6db0-d7c7-4719-ac9b-5ca8c889c5f8")
                },
                new Photo
                {
                    Id = Guid.Parse("432f6db0-b5c7-4519-ad9b-fca8c889c5f8"),
                    Name = "Hotel beach",
                    Description = "A hotel beach",
                    UserId = Guid.Parse("fbbf6db0-d7c7-4519-ad9b-fca8c889c5f8"),
                    DateAdded = DateTime.Now,
                    FileName = "img2.jpg",
                    AlbumId = Guid.Parse("fbbf6db0-d7c7-4719-ac9b-5ca8c889c5f8")
                }
                );

            context.Comments.AddOrUpdate(x => x.Id,
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Text = "Looks beautiful",
                    PhotoId = Guid.Parse("432f6db0-d7c7-4519-ad9b-fca8c889c5f8"),
                    Date = DateTime.Now.AddDays(-15),
                    UserId = Guid.Parse("fbbf6db0-d7c7-4519-ad9b-fca8c889c5f8")
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Text = "Yes it does!",
                    PhotoId = Guid.Parse("432f6db0-d7c7-4519-ad9b-fca8c889c5f8"),
                    Date = DateTime.Now.AddDays(-12),
                    UserId = Guid.Parse("652eaedf-a246-4d94-b976-57be95cabbd2")
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Text = "My next vacation destination",
                    PhotoId = Guid.Parse("432f6db0-b5c7-4519-ad9b-fca8c889c5f8"),
                    Date = DateTime.Now.AddDays(-12),
                    UserId = Guid.Parse("652eaedf-a246-4d94-b976-57be95cabbd2")
                }
                );
        }
    }
}
