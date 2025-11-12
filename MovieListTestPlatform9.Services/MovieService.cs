using Microsoft.Extensions.Configuration;
using MovieListTestPlatform9.Domains.Entities;
using MovieListTestPlatform9.Services.Integrations.MovieSearchAPI.DTO;
using MovieListTestPlatform9.Services.Interfaces;
using MovieListTestPlatform9.Services.Mappers;
using Newtonsoft.Json;

namespace MovieListTestPlatform9.Services
{
    public class MovieService : IMovieService
    {
        public IConfiguration _Configuration;
        public String? ApiBaseUrl;
        
        public MovieService(IConfiguration configuration)
        {
            _Configuration = configuration;
            ApiBaseUrl = _Configuration["MovieApiBaseUrl"];

        }
        public async Task<MovieSearchDTO> SearchMovieDTOAsync(string zoekterm)
        {
            try
            {
                using (var Client = new HttpClient())
                {
                    String Url = $"{ApiBaseUrl}/search?q={zoekterm}";

                    using (var Response = await Client.GetAsync(Url))
                    {
                        var ApiResponse = await Response.Content.ReadAsStringAsync();
                        var items = JsonConvert.DeserializeObject<MovieSearchDTO>(ApiResponse);
                        return items;
                    }
                }
            }
            catch (Exception ex) {
                return null;
            }
        } //Ruwe data API call (DTO)

        public async Task<List<Movie>> SearchMoviesAsync(string zoekterm) //domeinmodellen van Movie
        {
            var result = await SearchMovieDTOAsync(zoekterm);
            if (result.MovieItems == null)
            {
                return new List<Movie>();
            }

            return result.MovieItems.Select(x => x.ToDomain()).ToList();
        }
    }
}
