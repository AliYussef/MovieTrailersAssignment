using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace MovieTrailersAssignment.Models
{
    public class Video
    {
        [JsonPropertyName("i")]
        public Image Image { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("l")]
        public string Title { get; set; }

        [JsonPropertyName("s")]
        public string Duration { get; set; }
    }
}
