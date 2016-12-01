using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoExploration.Domain.Models;
using PhotoExploration.Domain.Repositories;
using PhotoExploration.Models;

namespace PhotoExploration.Helpers
{
    public static class AlbumHelper
    {
        public static List<AlbumIndexViewModel> MapAlbums(this List<AlbumIndexViewModel> indexAlbums, List<Album> albums)
        {
            albums.ForEach(x => indexAlbums.Add(new AlbumIndexViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }));

            return indexAlbums;
        }

        public static Album MapAlbum(this AlbumCreateViewModel viewModel)
        {
            var album = new Album
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name,
                UserId = AlbumRepository.GetUserId(viewModel.Creater)
            };

            return album;
        }
    }
}