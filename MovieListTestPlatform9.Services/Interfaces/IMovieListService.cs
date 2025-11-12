using MovieListTestPlatform9.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Services.Interfaces
{
    public interface IMovieListService
    {
        Task AddMovieAsync(Movie movie);
        Task RemoveMovieAsync(Movie movie);
        Task<List<Movie>> GetAllMoviesAsync();
    }
}
