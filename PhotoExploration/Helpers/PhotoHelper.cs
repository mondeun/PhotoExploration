using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PhotoExploration.Models;

namespace PhotoExploration.Helpers
{
    public class PhotoHelper
    {
        public static List<Photo> GetAllPhotos()
        {
            using (var ctx = new PhotoExplorationContext())
            {
                return ctx.Photos.ToList();
            }
        }

        public static Photo GetPhoto(int id)
        {
            using (var ctx = new PhotoExplorationContext())
            {
                return ctx.Photos.Include(i => i.Comments).Include(i => i.User).FirstOrDefault(x => x.Id == id);
            }
        }
    }
}