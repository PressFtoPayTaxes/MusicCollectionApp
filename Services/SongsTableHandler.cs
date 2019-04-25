using LINQ.DataAccess;
using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Services
{
    public class SongsTableHandler
    {
        public void AddSong(string name, string text, int duration, double rating, Performer performer)
        {
            var song = new Song
            {
                Name = name,
                Text = text,
                Duration = duration,
                Rating = rating,
                Performer = performer
            };

            using (var context = new MusicContext())
            {
                context.Songs.Add(song);
                context.SaveChanges();
            }
        }

        public List<Song> GetAllSongs()
        {
            var songs = new List<Song>();
            using (var context = new MusicContext())
            {
                songs = context.Songs.ToList();
            }
            return songs;
        }

        public List<Song> GetSongsByName(string letters)
        {
            var songs = new List<Song>();

            using (var context = new MusicContext())
            {
                songs = (from song 
                         in context.Songs
                         where song.Name.ToLower().Contains(letters.ToLower())
                         select song).ToList();
            }

            return songs;
        }

        public List<Song> SortSongsByRatingAscending(List<Song> songs)
        {
            var sortedSongs = (from song
                               in songs
                               orderby song.Rating ascending
                               select song).ToList();
            return sortedSongs;
        }

        public List<Song> SortSongsByRatingDescending(List<Song> songs)
        {
            var sortedSongs = (from song
                               in songs
                               orderby song.Rating descending
                               select song).ToList();
            return sortedSongs;
        }
    }
}
