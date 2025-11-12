using MovieListTestPlatform9.Domains.Entities;

namespace MovieListTestPlatform9.ViewModels
{
    public class MovieSearchVM
    {
        public String zoekterm { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new();
        public String ErrorMessage { get; set; } = String.Empty;
        public List<Movie> SavedMovies { get; set; } = new();
    }
}
