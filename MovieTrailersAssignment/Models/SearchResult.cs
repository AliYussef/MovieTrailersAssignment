using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MovieTrailersAssignment.Models
{
    public class SearchResult
    {
        [JsonPropertyName("d")]
        public IEnumerable<Movie> Movies { get; set; }

        [JsonPropertyName("q")]
        public string Query { get; set; }

        [JsonPropertyName("v")]
        public int Version { get; set; }
    }
}
