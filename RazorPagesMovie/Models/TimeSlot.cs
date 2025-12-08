using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }

        public int MovieId { get; set; } // foreign key
        public Movie Movie { get; set; } = new Movie();

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Location { get; set; } = string.Empty;
    }

}

