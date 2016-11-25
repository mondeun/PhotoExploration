using System;
using System.Collections.Generic;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Domain.Interfaces
{
    public interface IPhotoRepository
    {
        void Add(Photo photo);
        void Edit(Photo photo);
        void Remove(Guid id);
        IEnumerable<Photo> GetPhotos();
        Photo FindById(Guid id);

    }
}
