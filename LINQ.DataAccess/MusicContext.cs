namespace LINQ.DataAccess
{
    using LINQ.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MusicContext : DbContext
    {
        public MusicContext()
            : base("name=MusicContext")
        {
        }

        public DbSet<Performer> Performers { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}