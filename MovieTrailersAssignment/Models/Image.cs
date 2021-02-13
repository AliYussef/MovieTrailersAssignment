using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MovieTrailersAssignment.Models
{
    public class Image
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
