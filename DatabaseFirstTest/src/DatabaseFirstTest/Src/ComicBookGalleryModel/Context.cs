using ComicBookGalleryModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {
        //public Context(): base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComicBookGallerytest1;Integrated Security=True;MultipleActiveResultSets=True")
        //{

        //}
        //public Context() : base("ComicBookGallery")
        //{

        //}

        public Context()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }
        public DbSet<ComicBook> ComicBooks { get; set; }
    }
}
