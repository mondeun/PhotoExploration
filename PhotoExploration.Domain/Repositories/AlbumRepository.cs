using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PhotoExploration.Domain.Interfaces;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Domain.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        public void Add(Album item)
        {
            using (var db = new PhotoExplorationContext())
            {
                db.Albums.Add(item);

                db.SaveChanges();
            }
        }

        public void Edit(Album photo)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetItems()
        {
            using (var db = new PhotoExplorationContext())
            {
                return db.Albums.Include("User").Include("Photos").ToList();
            }
        }

        public Album FindById(Guid id)
        {
            using (var db = new PhotoExplorationContext())
            {
                var album = db.Albums.Include("User").Include("Photos").FirstOrDefault(x => x.Id == id);
                if (album != null)
                {
                    album.Photos =
                        db.Photos.Include("User")
                            .Include("Album")
                            .Include("Comments")
                            .Where(x => x.AlbumId == album.Id)
                            .ToList();
                }
                return album;
            }
        }

        public static Guid GetUserId(string name)
        {
            using (var db = new PhotoExplorationContext())
            {
                return db.Users.Single(x => x.Name == name).Id;
            }
        }

        public static string GetUserName(Guid id)
        {
            using (var db = new PhotoExplorationContext())
            {
                return db.Users.Single(x => x.Id == id).Name;
            }
        }
    }
}
