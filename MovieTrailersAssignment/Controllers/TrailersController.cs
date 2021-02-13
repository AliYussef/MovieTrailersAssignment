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
    public class TrailersController : ControllerBase
    {
        private readonly IMovieTrailerRepository _movieTrailerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public TrailersController(IMovieTrailerRepository movieTrailerRepository, IMapper mapper, ILoggerFactory log)
        {
            _movieTrailerRepository = movieTrailerRepository;
            _mapper = mapper;
            _log = log.CreateLogger<TrailersController>();
        }

        [HttpGet("{movieDetails}")]
        public async Task<ActionResult<TrailerReadDto>> GetTrailersByTitle(string movieDetails)
        {
            if (movieDetails == null) return BadRequest();

            try
            {
                var trailers = await _movieTrailerRepository.GetMovieTrailers(movieDetails);

                if (trailers != null)
                {
                    var trailerReadDtos = _mapper.Map<TrailerReadDto>(trailers);

                    return Ok(trailerReadDtos);
                }
            }
            catch (Exception ex)
            {
                _log.LogError($"Youtube service Error: {ex.Message}");
            }

            return NotFound();
        }
    }
}
