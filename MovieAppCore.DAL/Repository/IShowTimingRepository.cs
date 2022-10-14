using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAppCore.DAL.Repository
{
    public interface IShowTimingRepository
    {
        IEnumerable<MovieShowTimings> GetShowTimings();
    }
}
