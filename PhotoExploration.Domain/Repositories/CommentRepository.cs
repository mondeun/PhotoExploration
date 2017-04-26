using System;
using System.Collections.Generic;
using PhotoExploration.Domain.Interfaces;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Domain.Repositories
{
    public class CommentRepository : IRepository<Comment>
    {
        public void Add(Comment item)
        {
            using (var db = new PhotoExplorationContext())
            {
                db.Comments.Add(new Comment
                {
                    Id = item.Id,
                    Text = item.Text,
                    Date = item.Date,
                    PhotoId = item.PhotoId,
                    UserId = item.UserId
                });

                db.SaveChanges();
            }
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
    }
}
