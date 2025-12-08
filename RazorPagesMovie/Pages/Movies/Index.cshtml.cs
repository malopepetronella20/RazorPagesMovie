using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        public List<Movie> Movies { get; set; } = new();
        public List<Movie> FeaturedMovies { get; set; } = new();
        public List<SelectListItem> Genres { get; set; } = new();
        public string SearchString { get; set; } = string.Empty;
        public string MovieGenre { get; set; } = string.Empty;

        public void OnGet()
        {
            Movies = new List<Movie>
            {
                new Movie { Title = "Inception", Genre = "Sci-Fi", ImagePath = "/images/inception.jpg", StarRating = "PG-13", ReleaseDate = DateTime.Parse("2010-07-16") },
                new Movie { Title = "Interstellar", Genre = "Sci-Fi", ImagePath = "/images/interstellar.jpg", StarRating = "PG-13", ReleaseDate = DateTime.Parse("2014-11-07") }
            };

            FeaturedMovies = Movies.Take(1).ToList();

            Genres = Movies
                .Select(m => m.Genre)
                .Distinct()
                .Select(g => new SelectListItem { Value = g, Text = g })
                .ToList();
        }
    }
}
