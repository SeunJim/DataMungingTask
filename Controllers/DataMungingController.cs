using DataMunging.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataMunging.Controllers
{
    [Route("api/data_munging")]
    [ApiController]
    public class DataMungingController : ControllerBase
    {
        private readonly IMungingService _mungingService;

        public DataMungingController(IMungingService mungingService)
        {
            _mungingService = mungingService;
        }
        [HttpGet("weather/smallest_spread_day")]
        public IActionResult GetSmallestWeather() { 
        return Ok(_mungingService.SmallestSpreadDayTemp());
        }
        [HttpGet("weather/smallest_goal_for_in")]
        public IActionResult GetSmallestGoalDifference()
        {
            return Ok(_mungingService.LeaguesForAndAgainst());
        }

    }
}
