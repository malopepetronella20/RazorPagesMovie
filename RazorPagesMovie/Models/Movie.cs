using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; } = string.Empty;

        // Content rating like "PG", "R", etc.
        [StringLength(5)]
        public string ContentRating { get; set; } = string.Empty;

        // Star rating (numeric, e.g. 4.5 out of 5)
        [Range(0.0, 5.0)]
        public double StarRating { get; set; }

        // Poster image file name or URL
        public string PosterUrl { get; set; } = string.Empty;
    }
}
