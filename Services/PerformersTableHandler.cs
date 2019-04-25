using LINQ.DataAccess;
using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PerformersTableHandler
    {
        public void AddPerformer(string name)
        {
            var performer = new Performer()
            {
                Name = name
            };

            using (var context = new MusicContext())
            {
                context.Performers.Add(performer);
                context.SaveChanges();
            }
        }

        public List<Performer> GetAllPerformers()
        {
            var performers = new List<Performer>();

            using (var context = new MusicContext())
            {
                performers = context.Performers.ToList();
            }

            return performers;
        }

        public List<Performer> GetPerformersByName(string letters)
        {
            var performers = new List<Performer>();

            using (var context = new MusicContext())
            {
                performers = (from performer
                              in context.Performers
                              where performer.Name.ToLower().Contains(letters.ToLower())
                              select performer).ToList();
            }

            return performers;
        }
    }
}
