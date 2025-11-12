using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieListTestPlatform9.Services.Integrations.MovieSearchAPI.DTO
{
    public class MovieSearchDTO
    {
        [JsonProperty("ok")] public Boolean IsOk { get; set; }
        [JsonProperty("description")] public List<MovieItem> MovieItems { get; set; }
    }

    public class MovieItem
    {
        [JsonProperty("#TITLE")]
        public string Title { get; set; }

        [JsonProperty("#YEAR")]
        public int Year { get; set; }

        [JsonProperty("#IMDB_ID")]
        public string ImdbId { get; set; }

        [JsonProperty("#RANK")]
        public int Rank { get; set; }

        [JsonProperty("#ACTORS")]
        public string Actors { get; set; }

        [JsonProperty("#AKA")]
        public string AlsoKnownAs { get; set; }

        [JsonProperty("#IMDB_URL")]
        public string ImdbUrl { get; set; }

        [JsonProperty("#IMDB_IV")]
        public string ImdbIvUrl { get; set; }

        [JsonProperty("#IMG_POSTER")]
        public string PosterUrl { get; set; }

        [JsonProperty("photo_width")]
        public int PhotoWidth { get; set; }

        [JsonProperty("photo_height")]
        public int PhotoHeight { get; set; }
    }
}
