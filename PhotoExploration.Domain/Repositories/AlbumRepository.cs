﻿using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public static Guid GetUserId(string name)
        {
            using (var db = new PhotoExplorationContext())
            {
                return db.Users.Single(x => x.Name == name).Id;
            }
        }
    }
}
