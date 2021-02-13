using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieTrailersAssignment.Models;

namespace MovieTrailersAssignment.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IConfiguration _configuration;

        public MovieRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByTitle(string movieTitle)
        {
            var fullURL = new StringBuilder(_configuration.GetValue<string>("Imdb-Url"));
            fullURL.Append(movieTitle);

            var client = new HttpClient();

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(fullURL.ToString()),
                Headers =
                {
                    { "x-rapidapi-key", _configuration.GetValue<string>("X-RapidAPI-Key") },
                    { "x-rapidapi-host", _configuration.GetValue<string>("X-RapidAPI-Host") },
                },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            var results = JsonSerializer.Deserialize<SearchResult>(body, options);
            IEnumerable<Movie> movies = results.Movies;

            return movies;
        }


    }
}
