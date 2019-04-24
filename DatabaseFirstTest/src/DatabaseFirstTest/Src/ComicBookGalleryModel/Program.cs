using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);

                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .OrderByDescending(cb => cb.IssueNumber)
                //    .ThenBy(cb => cb.PublishedOn)
                //    .ToList();


                var comicbooksQuery = context.ComicBooks
                    .Include(cb => cb.Series)
                    .OrderByDescending(cb => cb.IssueNumber);

                var comicBooks = comicbooksQuery.ToList();

                var comicbooksQuery2 = comicbooksQuery
                    .Where(cb => cb.AverageRating < 7)
                    .ToList();

                foreach (var comicBook in comicBooks)
                {
                    Console.WriteLine(comicBook.Displaytext);
                }

                //var comicBooksQuery = from cb in context.ComicBooks select cb;
                //var comicBooks = comicBooksQuery.ToList();

                Console.WriteLine();
                Console.WriteLine("# of comic books: {0}", comicBooks.Count);
                Console.WriteLine("--------------------------------------");
                foreach (var comicBook in comicbooksQuery2)
                {
                    Console.WriteLine(comicBook.Displaytext);
                }

                Console.WriteLine();
                Console.WriteLine("# of comic books: {0}", comicbooksQuery2.Count);


                //var comicBooks = context.ComicBooks
                //    .Include(cb => cb.Series)
                //    .Include(cb => cb.Artists.Select(a => a.Artist))
                //    .Include(cb => cb.Artists.Select(a => a.Role))
                //    .ToList();

                //foreach (var comicBook in comicBooks)
                //{
                //    var artistRoleNames = comicBook.Artists
                //        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();

                //    var artistRoleDisplaytext = string.Join(", ", artistRoleNames);

                //    Console.WriteLine(comicBook.Displaytext);
                //    Console.WriteLine(artistRoleDisplaytext);
                //}
            }
        }
    }
}
