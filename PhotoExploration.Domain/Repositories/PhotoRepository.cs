using System;
using System.Collections.Generic;
using System.Linq;
using PhotoExploration.Domain.Interfaces;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Domain.Repositories
{
    public class PhotoRepository : IRepository<Photo>
    {
        public void Add(Photo item)
        {
            using (var db = new PhotoExplorationContext())
            {
                db.Photos.Add(item);

                db.SaveChanges();
            }
        }

        public void Edit(Photo item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetItems()
        {
            using (var db = new PhotoExplorationContext())
            {
                return db.Photos.Include("Comments").Include("Album").Include("User").ToList();
            }
        }

        public Photo FindById(Guid id)
        {
            using (var db = new PhotoExplorationContext())
            {
                var photo = db.Photos.Include("User").Include("Comments").Include("Album").FirstOrDefault(x => x.Id == id);
                if (photo != null)
                    photo.Comments = db.Comments.Include("User").Where(x => x.PhotoId == photo.Id)?.ToList();

                return photo;
            }
        }

        public static Photo GetLastUploadedPhoto()
        {
            using (var db = new PhotoExplorationContext())
            {
                var photo =
                    db.Photos.Include("User")
                        .Include("Comments")
                        .Include("Album")
                        .OrderByDescending(x => x.DateAdded)
                        .FirstOrDefault();
                if(photo != null)
                    photo.Comments = db.Comments.Include("User").Where(x => x.PhotoId == photo.Id).ToList();

                return photo;
            }
        }
    }
}
