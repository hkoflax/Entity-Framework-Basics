using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicBookGalleryModel.Models
{
    //to rename the table
    //[Table("Talent")]
    public class Artist
    {
        public Artist()
        {
            ComicBooks = new List<ComicBookArtist>();
        }
        public int Id { get; set; }
        //To rename the column and set the string Lenght
        //[Required, StringLength(100), Column("FullName")]
        public string Name { get; set; }

        //To ignore any settable property by EF
        //[NotMapped]
        public string Test { get; set; }
        public ICollection<ComicBookArtist> ComicBooks { get; set; }
    }
}
