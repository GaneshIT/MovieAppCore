using MovieAppCore.DAL.Repository;
using MovieAppCore.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAppCore.BAL.services
{
    public class ShowTimingService
    {
        IShowTimingRepository _showTimingRepository;
        public ShowTimingService(IShowTimingRepository showTimingRepository)
        {
            _showTimingRepository = showTimingRepository;
        }
        public IEnumerable<MovieShowTimings> GetMovieShowTimings()
        {
            return _showTimingRepository.GetShowTimings();
        }
    }
}
