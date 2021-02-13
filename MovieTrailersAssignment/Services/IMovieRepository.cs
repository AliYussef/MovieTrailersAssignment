using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieTrailersAssignment.Models;

namespace MovieTrailersAssignment.Services
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesByTitle(string movieTitle);
    }
}
