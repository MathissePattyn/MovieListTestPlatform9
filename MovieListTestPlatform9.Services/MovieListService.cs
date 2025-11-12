using MovieListTestPlatform9.Domains.Entities;
using MovieListTestPlatform9.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Services
{
    public class MovieListService : IMovieListService
    {
        private readonly List<Movie> _MovieList = new();
        
        public Task AddMovieAsync(Movie movie)
        {
            if(!_MovieList.Any(m => m.Id == movie.Id))
            {
                _MovieList.Add(movie);
            }
            return Task.CompletedTask;
        }

        public Task<List<Movie>> GetAllMoviesAsync()
        {
            return Task.FromResult(_MovieList.ToList());
        }

        public Task RemoveMovieAsync(Movie movie)
        {
            _MovieList.RemoveAll(m => m.Id == movie.Id);
            return Task.CompletedTask;
        }
    }
}
