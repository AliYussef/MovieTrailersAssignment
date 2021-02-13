using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Configuration;
using MovieTrailersAssignment.Models;
using Polly;

namespace MovieTrailersAssignment.Services
{
    public class MovieTrailerRepository : IMovieTrailerRepository
    {
        private readonly IConfiguration _configuration;

        public MovieTrailerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Trailer> GetMovieTrailers(string movieDetails)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _configuration.GetValue<string>("YoutubeAPI-Key"),
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = movieDetails + "official trailer";
            searchListRequest.MaxResults = 1;

            var searchListResponse = await searchListRequest.ExecuteAsync();

            var trailers = new Trailer();

            foreach (var searchResult in searchListResponse.Items)
            {
                if (searchResult.Id.Kind.Equals("youtube#video"))
                {
                    trailers.Title = searchResult.Snippet.Title;
                    trailers.MovieDetails = movieDetails;
                    trailers.VideoId = searchResult.Id.VideoId;
                }
            }

            return trailers;
        }

        /* alternative method. 
         * this method can be used to retrieve trailers per list of titles
         * the process is done synchronously usin bulkhead pollly nuget package
         */
        public async Task<IEnumerable<Trailer>> GetMovieTrailers(IEnumerable<string> movieDetails)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _configuration.GetValue<string>("YoutubeAPI-Key"),
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");

            var bulkhead = Policy.BulkheadAsync(4, Int32.MaxValue);
            var tasks = new List<Task<SearchListResponse>>();
            var searchListResponses = new List<SearchResource.ListRequest>();

            foreach (var title in movieDetails)
            {
                searchListRequest.Q = title;
                searchListRequest.MaxResults = 1;

                var t = bulkhead.ExecuteAsync<SearchListResponse>(async () =>
                {
                    return await searchListRequest.ExecuteAsync();

                });
                tasks.Add(t);
            }
            await Task.WhenAll(tasks);

            List<Trailer> trailers = new List<Trailer>();
            var index = 0;
            foreach (var searchResult in tasks)
            {
                foreach (var searchResultItem in searchResult.Result.Items)
                {
                    if (searchResultItem.Id.Kind.Equals("youtube#video"))
                    {
                        trailers.Add(new Trailer
                        {
                            Title = searchResultItem.Snippet.Title,
                            MovieDetails = movieDetails.ElementAt(index),
                            VideoId = searchResultItem.Id.VideoId
                        });

                        index++;
                    }
                }
            }

            return trailers;
        }

    }
}
