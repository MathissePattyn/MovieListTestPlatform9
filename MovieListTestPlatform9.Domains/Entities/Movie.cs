using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Domains.Entities
{
    public class Movie
    {
        public String Id { get; set; }
        public String Title { get; set; }
        public int Year { get; set; }
        public String? Actors { get; set; }
        public string? PosterUrl { get; set; }

        // Extra interne velden die jij wil gebruiken
        public bool? IsWatched { get; set; } = false;
    }
}
