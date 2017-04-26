using System;
using System.Collections.Generic;
using System.Linq;
using PhotoExploration.Domain.Interfaces;
using PhotoExploration.Domain.Models;

namespace PhotoExploration.Domain.Repositories
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User item)
        {
            using (var db = new PhotoExplorationContext())
            {
                db.Users.Add(new User
                {
                    Id = item.Id,
                    Email = item.Email,
                    Name = item.Name,
                    Password = item.Password,
                    Admin = false
                });

                db.SaveChanges();
            }
        }

        public void Edit(User item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetItems()
        {
            throw new NotImplementedException();
        }

        public User FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public static User GetUserByCredentials(string email, string password)
        {
            using (var db = new PhotoExplorationContext())
            {
                return db.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            }
        }

        public static Guid GetUserId(string name)
        {
            using (var db = new PhotoExplorationContext())
            {
                return db.Users.Single(x => x.Name == name).Id;
            }
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
