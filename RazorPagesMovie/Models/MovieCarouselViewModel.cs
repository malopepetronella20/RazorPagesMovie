using System;
using System.Collections.Generic;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Models
{
    public class MovieCarouselViewModel
    {
        public string Title { get; set; } = string.Empty; // ✅ Initialized
        public List<Movie> Movies { get; set; } = new();  // ✅ Initialized
    }

}

