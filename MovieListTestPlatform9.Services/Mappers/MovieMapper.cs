using MovieListTestPlatform9.Domains.Entities;
using MovieListTestPlatform9.Services.Integrations.MovieSearchAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Services.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToDomain(this MovieItem dto)
        {
            if(dto == null)
            {
                return null!;
            }

            return new Movie
            {
                Actors = dto.Actors,
                Id = dto.ImdbId,
                PosterUrl = dto.PosterUrl,
                Title = dto.Title,
                Year = dto.Year
            };
        }
    }
}
