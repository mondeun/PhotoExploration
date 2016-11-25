using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoExploration.Domain.Interfaces;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Domain.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        public void Add(Photo photo)
        {
            throw new NotImplementedException();
        }

        public void Edit(Photo photo)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> GetPhotos()
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
                var photo = db.Photos.Include("User").Include( i => i.Comments).Include("Album").FirstOrDefault(x => x.Id == id);
                photo.Comments = db.Comments.Include("User").Where(x => x.PhotoId == photo.Id).ToList();

                return photo;
            }
        }
    }
}
