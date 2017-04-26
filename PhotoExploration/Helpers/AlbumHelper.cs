using System;
using System.Collections.Generic;
using System.Linq;
using PhotoExploration.Domain.Models;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Models;

namespace PhotoExploration.Helpers
{
    public static class AlbumHelper
    {
        public static void MapAlbums(this List<AlbumViewModel> viewAlbums, List<Album> albums)
        {
            albums.ForEach(x => viewAlbums.Add(new AlbumViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Creator = UserRepository.GetUserName(x.UserId)
            }));
        }

        public static Album MapAlbum(this AlbumCreateViewModel viewModel)
        {
            var album = new Album
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                UserId = UserRepository.GetUserId(viewModel.Creator)
            };

            return album;
        }

        public static void MapPhoto(this AlbumViewModel detailsAlbum, Album album)
        {
            detailsAlbum.Id = album.Id;
            detailsAlbum.Name = album.Name;
            detailsAlbum.Creator = album.User.Name;
            
            album.Photos.ToList().ForEach(x => detailsAlbum.Photos.Add(
                new DetailsPhotoViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    UploadedBy = x.User.Name,
                    Description = x.Description,
                    FileName = x.FileName
                }));
        }
    }
}