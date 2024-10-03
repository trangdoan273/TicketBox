using System;
using System.Collections.Generic;

namespace TICKETBOX.Models.Tables
{
    public partial class Movie
    {
        public Movie()
        {
            Showdates = new HashSet<Showdate>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? Content { get; set; }
        public string? Genre { get; set; }
        public string? Label { get; set; }
        public string? MovieFormat { get; set; }
        public string? Director { get; set; }
        public string? Actor { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public string? Duration { get; set; }
        public string? MovieLanguage { get; set; }
        public string? MovieImage { get; set; }
        public string? MoviePoster { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual ICollection<Showdate> Showdates { get; set; }
    }
}
