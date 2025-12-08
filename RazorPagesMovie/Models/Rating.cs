using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Stars { get; set; }

        public int MovieId { get; set; } // ? foreign key
        public Movie Movie { get; set; } = default!; // ? navigation property
    }
}
