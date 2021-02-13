using System;
using System.Collections.Generic;
using AutoMapper;
using MovieTrailersAssignment.Dtos;
using MovieTrailersAssignment.Models;

namespace MovieTrailersAssignment.Profiles
{
    public class TrailerProfile : Profile
    {
        public TrailerProfile()
        {
            CreateMap<Trailer, TrailerReadDto>();
            CreateMap<Movie, MovieReadDto>();
        }
    }
}
