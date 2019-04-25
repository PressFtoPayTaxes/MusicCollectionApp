using LINQ.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Console
{
    class Program
    {
        private static int _secondsInMinutes = 60;

        static void ShowSongs()
        {
            var songs = new List<Song>();
            var handler = new SongsTableHandler();

            while (true)
            {
                System.Console.WriteLine("Показать все аудио, или воспользоваться поиском? (1 - все, 2 - поиск)");
                int answer = int.Parse(System.Console.ReadLine());

                switch (answer)
                {
                    case 1: songs = handler.GetAllSongs(); break;
                    case 2:
                        System.Console.Write("Введите название песни: ");
                        string letters = System.Console.ReadLine();
                        songs = handler.GetSongsByName(letters); break;
                    default:
                        System.Console.WriteLine("Такого варианта нет");
                        continue;
                }
                break;
            }

            while (true)
            {
                System.Console.WriteLine("Выберите тип сортировки (1 - прямая, 2 - обратная, 3 - нет)");
                int answer = int.Parse(System.Console.ReadLine());
                switch (answer)
                {
                    case 1: songs = handler.SortSongsByRatingAscending(songs); break;
                    case 2: songs = handler.SortSongsByRatingDescending(songs); break;
                    case 3: break;
                    default:
                        System.Console.WriteLine("Такого варианта нет");
                        continue;
                }
                break;
            }

            foreach (var song in songs)
            {
                System.Console.WriteLine("Название:\t\tДлительность:\t\tРейтинг:");
                System.Console.WriteLine($"{song.Name}\t\t{song.Duration / 60}:{song.Duration % 60}\t\t{song.Rating}");
                System.Console.WriteLine("Текст:" + song.Text);
            }
        }

        static void ShowPerformers()
        {
            var performers = new List<Performer>();
            var handler = new PerformersTableHandler();

            while (true)
            {
                System.Console.WriteLine("Показать всех исполнителей, или воспользоваться поиском? (1 - все, 2 - поиск)");
                int answer = int.Parse(System.Console.ReadLine());

                switch (answer)
                {
                    case 1: performers = handler.GetAllPerformers(); break;
                    case 2:
                        System.Console.Write("Введите имя исполнителя: ");
                        string letters = System.Console.ReadLine();
                        performers = handler.GetPerformersByName(letters); break;
                    default:
                        System.Console.WriteLine("Такого варианта нет");
                        continue;
                }
                break;
            }

            foreach (var performer in performers)
            {
                System.Console.WriteLine("Имя:" + performer.Name);
                System.Console.WriteLine("Песни:");
                foreach(var song in performer.Songs)
                {
                    System.Console.WriteLine(song.Name);
                }
            }
        }

        static void AddSong()
        {
            var handler = new SongsTableHandler();

            System.Console.Write("Введите название песни: ");
            string name = System.Console.ReadLine();
            System.Console.Write("Введите длительность песни: ");
            int duration = int.Parse(System.Console.ReadLine());

            double rating;
            while (true)
            {
                System.Console.Write("Введите рейтинг (от 0 до 5):");
                rating = double.Parse(System.Console.ReadLine());
                if(rating < 0 || rating > 5)
                {
                    System.Console.WriteLine("Некорректное значение");
                    continue;
                }
                break;
            }

            System.Console.WriteLine("Введите текст песни (если хотите):");
            string text = System.Console.ReadLine();

            string performerName;
            while (true)
            {
                System.Console.Write("Введите имя исполнителя: ");
                performerName = System.Console.ReadLine();

                if (performerName == string.Empty)
                {
                    System.Console.WriteLine("Вы ничего не ввели");
                    continue;
                }
                break;
            }

            handler.AddSong(name, text, duration, rating, new Performer { Name = performerName });
        }

        static void AddPerformer()
        {
            string performerName = string.Empty;
            while (performerName == string.Empty)
            {
                System.Console.Write("Введите название исполнителя: ");
                performerName = System.Console.ReadLine();
            }

            var handler = new PerformersTableHandler();
            handler.AddPerformer(performerName);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                System.Console.WriteLine("Выберите действие:\n1 - Просмотреть аудиозаписи\n2 - Просмотреть исполнителей\n3 - Добавить аудиозапись\n4 - Добавить исполнителя\n5 - Выход");
                int answer = int.Parse(System.Console.ReadLine());
                switch (answer)
                {
                    case 1: ShowSongs(); break;
                    case 2: ShowPerformers(); break;
                    case 3: AddSong(); break;
                    case 4: AddPerformer(); break;
                    case 5: Environment.Exit(0); break;
                    default: System.Console.WriteLine("Такого варианта нет"); break ;
                }
            }

        }
    }
}
