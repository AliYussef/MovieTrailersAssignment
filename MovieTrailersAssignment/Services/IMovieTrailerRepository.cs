using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieTrailersAssignment.Models;

namespace MovieTrailersAssignment.Services
{
    public interface IMovieTrailerRepository
    {
        Task<Trailer> GetMovieTrailers(string movieDetails);
        Task<IEnumerable<Trailer>> GetMovieTrailers(IEnumerable<string> movieDetails);
    }
}
