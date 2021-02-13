using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieTrailersAssignment.Dtos;
using MovieTrailersAssignment.Services;

namespace MovieTrailersAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper, ILoggerFactory log)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _log = log.CreateLogger<MoviesController>();
        }


        [HttpGet("{movieTitle}")]
        public async Task<ActionResult<IEnumerable<MovieReadDto>>> GetMoviesByTitle(string movieTitle)
        {
            if (movieTitle == null) return BadRequest();

            try
            {
                var movies = await _movieRepository.GetMoviesByTitle(movieTitle);
                if (movies != null)
                {
                    var movieReadDtos = _mapper.Map<IEnumerable<MovieReadDto>>(movies);

                    return Ok(movieReadDtos);
                }
            }
            catch (Exception ex)
            {
                _log.LogError($"IMDB Service error: {ex.Message}");
            }

            return NotFound();
        }


    }
}
