﻿using System;
using System.Collections.Generic;
using System.Linq;
using PhotoExploration.Domain.Models;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Models;

namespace PhotoExploration.Helpers
{
    public static class PhotoHelper
    {
        public static DetailsPhotoViewModel MapPhoto(this DetailsPhotoViewModel detailsPhoto, Photo photo)
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

            return detailsPhoto;
        }

        public static List<GalleryPhotoViewModel> MapPhotos(this List<GalleryPhotoViewModel> galleryPhotos, List<Photo> photos)
        {
            photos.ForEach(x => galleryPhotos.Add(new GalleryPhotoViewModel
            {
                Id = x.Id,
                Name = x.Name,
                FileName = x.FileName
            }));

            return galleryPhotos;
        }

        public static Photo MapPhoto(this GalleryPhotoViewModel viewModel, string fileName)
        {
            var photo = new Photo()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                Description = viewModel.Description,
                DateAdded = DateTime.Now,
                FileName = fileName,
                AlbumId = viewModel.AlbumId
            };

            return photo;
        }
    }
}