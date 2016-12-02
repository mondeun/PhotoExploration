using System;
using System.Collections.Generic;
using System.Linq;
using PhotoExploration.Domain.Interfaces;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Domain.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        public void Add(Comment item)
        {
            throw new NotImplementedException();
        }

        public void Edit(Comment item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetItems()
        {
            throw new NotImplementedException();
        }

        public Comment FindById(Guid id)
        {
            throw new NotImplementedException();
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
