using System;
using System.Collections.Generic;
using System.Linq;
using PhotoExploration.Domain.Models;
using PhotoExploration.Models;

namespace PhotoExploration.Helpers
{
    public static class PhotoHelper
    {
        public static void MapPhoto(this DetailsPhotoViewModel detailsPhoto, Photo photo)
        {
            detailsPhoto.Id = photo.Id;
            detailsPhoto.Name = photo.Name;
            detailsPhoto.Description = photo.Description;
            detailsPhoto.FileName = photo.FileName;
            detailsPhoto.UploadedBy = photo.User.Name;

            photo.Comments.ToList().ForEach(x => detailsPhoto.Comments.Add(
                new CommentViewModel
                {
                    Commenter = x.User.Name,
                    Comment = x.Text,
                    Date = x.Date
                }
                ));
        }

        public static void MapPhotos(this List<GalleryPhotoViewModel> galleryPhotos, List<Photo> photos)
        {
            photos.ForEach(x => galleryPhotos.Add(new GalleryPhotoViewModel
            {
                Id = x.Id,
                Name = x.Name,
                FileName = x.FileName
            }));
        }

        public static Photo MapPhoto(this GalleryPhotoViewModel viewModel, string fileName, Guid uploader)
        {
            var photo = new Photo()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Description = viewModel.Description,
                DateAdded = DateTime.Now,
                FileName = fileName,
                AlbumId = viewModel.AlbumId,
                UserId = uploader
            };

            return photo;
        }

        public static void MapPhoto(this GalleryPhotoViewModel galleryPhoto, Photo photo)
        {
            galleryPhoto.Id = photo.Id;
            galleryPhoto.Name = photo.Name;
            galleryPhoto.FileName = photo.FileName;
            galleryPhoto.Description = photo.Description;
            galleryPhoto.UploadedBy = photo.User.Name;
        }
    }
}