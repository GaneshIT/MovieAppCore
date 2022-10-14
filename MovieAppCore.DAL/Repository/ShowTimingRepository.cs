using Microsoft.EntityFrameworkCore;
using MovieAppCore.DAL.Data;
using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieAppCore.DAL.Repository
{
    public class ShowTimingRepository : IShowTimingRepository
    {
        MovieDbContext _movieDbContext;
        public ShowTimingRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public IEnumerable<MovieShowTimings> GetShowTimings()
        {
            return _movieDbContext.movieShowTimings.Include(o => o.movie).ToList();
        }
    }
}
