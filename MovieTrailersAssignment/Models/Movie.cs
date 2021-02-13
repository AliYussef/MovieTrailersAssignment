using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MovieTrailersAssignment.Models
{
    public class Movie
    {
        [JsonPropertyName("i")]
        public Image Image { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("l")]
        public string Title { get; set; }

        [JsonPropertyName("q")]
        public string Type { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("s")]
        public string Cast { get; set; }

        [JsonPropertyName("v")]
        public IEnumerable<Video> Videos { get; set; }

        [JsonPropertyName("vt")]
        public int Vt { get; set; }

        [JsonPropertyName("y")]
        public int Year { get; set; }

        [JsonPropertyName("yr")]
        public string YearAnother { get; set; }

    }
}
