using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAppCore.BAL.services;
using MovieAppCore.Entity.Models;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimingController : ControllerBase
    {
        private ShowTimingService _showTimingService;
        public ShowTimingController(ShowTimingService showTimingService)
        {
            _showTimingService = showTimingService;
        }

        [HttpGet("GetShowTimings")]
        public IEnumerable<MovieShowTimings> GetShowTimings()
        {
            return _showTimingService.GetMovieShowTimings();
        }
    }
}
