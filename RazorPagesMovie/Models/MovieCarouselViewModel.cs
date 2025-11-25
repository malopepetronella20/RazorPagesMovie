using System.Collections.Generic;

namespace RazorPagesMovie.Models
{
    public class MovieCarouselViewModel
    {
        public string Title { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new();
    }
}


