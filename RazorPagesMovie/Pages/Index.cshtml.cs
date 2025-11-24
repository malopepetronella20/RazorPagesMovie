using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models; // Assuming your Movie model is here
using System.Collections.Generic;

namespace RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Movie> Movie { get; set; } = new List<Movie>();

        public void OnGet()
        {
            // Example: Populate Movie list with data
            // Movie = ... fetch movies from database or service
        }
    }
}
