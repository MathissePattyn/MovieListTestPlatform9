using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MovieListTestPlatform9.Services.Integrations.MovieSearchAPI.DTO
{
    public class MovieSearchDTO
    {
        [JsonProperty("ok")]
        public bool IsOk { get; set; }

        [JsonProperty("description")]
        public List<MovieItem> MovieItems { get; set; } = new List<MovieItem>();
    }

    public class MovieItem
    {
        [JsonProperty("#TITLE")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("#YEAR")]
        public int Year { get; set; }

        [JsonProperty("#IMDB_ID")]
        public string ImdbId { get; set; } = string.Empty;

        [JsonProperty("#RANK")]
        public int Rank { get; set; }

        [JsonProperty("#ACTORS")]
        public string Actors { get; set; } = string.Empty;

        [JsonProperty("#AKA")]
        public string AlsoKnownAs { get; set; } = string.Empty;

        [JsonProperty("#IMDB_URL")]
        public string ImdbUrl { get; set; } = string.Empty;

        [JsonProperty("#IMDB_IV")]
        public string ImdbIvUrl { get; set; } = string.Empty;

        [JsonProperty("#IMG_POSTER")]
        public string PosterUrl { get; set; } = string.Empty;

        [JsonProperty("photo_width")]
        public int PhotoWidth { get; set; }

        [JsonProperty("photo_height")]
        public int PhotoHeight { get; set; }
    }
}
