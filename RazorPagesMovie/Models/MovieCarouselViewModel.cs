using System;
using System.Collections.Generic;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Models
{
    public class MovieCarouselViewModel
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}

