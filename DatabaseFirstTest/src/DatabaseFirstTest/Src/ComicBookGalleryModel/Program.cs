using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ComicBookGalleryModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                //series
                var series1 = new Series()
                {
                    Title = "the Amazing Spider-Man"
                };
                var series2 = new Series()
                {
                    Title = "the invicible Iron Man"
                };
                //artist
                var artist1 = new Artist()
                {
                    Name = "Stan Lee"
                };
                var artist2 = new Artist()
                {
                    Name = "Steve Ditke"
                };
                var artist3 = new Artist()
                {
                    Name = "jack kirby"
                };
                //Role
                var role1 = new Role()
                {
                    Name = "Script"
                };
                var role2 = new Role()
                {
                    Name = "Pencils"
                };
                //comicbook
                var comicbook1 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };
                comicbook1.AddArtist(artist1, role1);
                comicbook1.AddArtist(artist2, role2);

                var comicbook2 = new ComicBook()
                {
                    Series = series1,
                    IssueNumber = 2,
                    PublishedOn = DateTime.Today
                };
                comicbook2.AddArtist(artist1, role1);
                comicbook2.AddArtist(artist2, role2);

                var comicbook3 = new ComicBook()
                {
                    Series = series2,
                    IssueNumber = 1,
                    PublishedOn = DateTime.Today
                };
                comicbook3.AddArtist(artist1, role1);
                comicbook3.AddArtist(artist3, role2);

                context.ComicBooks.Add(comicbook1);
                context.ComicBooks.Add(comicbook2);
                context.ComicBooks.Add(comicbook3);

                context.SaveChanges();

                var comicBooks = context.ComicBooks
                    .Include(cb => cb.Series)
                    .Include(cb => cb.Artists.Select(a => a.Artist))
                    .Include(cb => cb.Artists.Select(a => a.Role))
                    .ToList();

                foreach (var comicBook in comicBooks)
                {
                    var artistRoleNames = comicBook.Artists
                        .Select(a => $"{a.Artist.Name} - {a.Role.Name}").ToList();

                    var artistRoleDisplaytext = string.Join(", ", artistRoleNames);

                    Console.WriteLine(comicBook.Displaytext);
                    Console.WriteLine(artistRoleDisplaytext);
                }
            }
        }
    }
}
