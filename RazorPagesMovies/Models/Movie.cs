using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovies.Models
{
    public class Movie
    {
        public int ID { get; set; } //primary key
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)] //attribute hints to the database to store as a Date
        public DateTime ReleaseDate { get; set; }
        public string genre { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
