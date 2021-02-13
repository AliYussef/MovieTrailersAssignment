using System;
using System.Collections.Generic;
using MovieTrailersAssignment.Models;

namespace MovieTrailersAssignment.Dtos
{
    public class MovieReadDto
    {
        public Image Image { get; set; }

        public string Title { get; set; }

        public int Rank { get; set; }

        public string Cast { get; set; }

        public int Year { get; set; }

    }
}
