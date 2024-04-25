using AlfabankProjectApi.App.DTO.LocationsDTO.Request;
using AlfabankProjectApi.App.DTO.LocationsDTO.Response;
using AlfabankProjectApi.App.Services;
using AlfabankProjectApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlfabankProjectApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;

        //private ILocationsService _locationsService;

        private ApiService _restaurantsService;

        public MainController(ILogger<MainController> logger,
            //ILocationsService service,
            ApiService restaurantsService)
        {
            _logger = logger;
            //_locationsService = service;
            _restaurantsService = restaurantsService;
        }

        [HttpGet()]
        [Route("locations/restaurants")]
        [ProducesDefaultResponseType(typeof(NearestRestaurantsResonse))]
        public async Task<ActionResult> GetNearestRestaurants([FromQuery] NearestRestaurantsRequest coordinates)
        {
            var result = await _restaurantsService.GetNearestRestaurantsAsync(coordinates.Point, coordinates.Radius);

            return Ok(result);
        }

        [HttpGet()]
        [Route("restaurant/menu")]
        [ProducesDefaultResponseType(typeof(NearestRestaurantsResonse))]
        public async Task<ActionResult> GetRestaurantMenu([FromQuery] string orgId)
        {
            var result = await _restaurantsService.GetMenuAsync(orgId);

            return Ok(result);
        }
    }
}