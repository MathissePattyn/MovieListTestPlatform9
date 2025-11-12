using MovieListTestPlatform9.Domains.Entities;
using MovieListTestPlatform9.Services.Integrations.MovieSearchAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieSearchDTO> SearchMovieDTOAsync(String zoekterm);

        Task <List<Movie>> SearchMoviesAsync(String zoekterm);
    }
}
