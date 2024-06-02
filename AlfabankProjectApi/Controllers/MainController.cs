using AlfabankProjectApi.App.DTO.LocationsDTO.Request;
using AlfabankProjectApi.App.DTO.LocationsDTO.Response;
using AlfabankProjectApi.App.Services;
using AlfabankProjectApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.ComponentModel.DataAnnotations;

namespace AlfabankProjectApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {

        private readonly ILogger<MainController> _logger;

        private ApiService _restaurantsService;

        public MainController(ILogger<MainController> logger,
            ApiService restaurantsService)
        {
            _logger = logger;
            _restaurantsService = restaurantsService;
        }

        [HttpGet()]
        [Route("locations/restaurants")]
        [ProducesDefaultResponseType(typeof(NearestRestaurantsResonse))]
        [OutputCache]
        public async Task<ActionResult> GetNearestRestaurants([FromQuery] NearestRestaurantsRequest coordinates)
        {
            var result = await _restaurantsService.GetNearestRestaurantsAsync(coordinates.Point, coordinates.Radius);

            return Ok(result);
        }

        [HttpGet()]
        [Route("restaurant/menu")]
        [ProducesDefaultResponseType(typeof(List<MenuByCategoriesResponse>))]
        [OutputCache]
        public async Task<ActionResult> GetRestaurantMenu([FromQuery] [Required] string orgId)
        {
            var result = await _restaurantsService.GetMenuAsync(orgId);

            return Ok(result);
        }
        [HttpGet()]
        [Route("restaurant/menu/random")]
        [ProducesDefaultResponseType(typeof(List<ApiMenuProductWithOffer>))]
        [OutputCache]
        public async Task<ActionResult> GetRestaurantMenu([FromQuery] [Required] string orgId, [FromQuery] List<string> categories)
        {
            var result = await _restaurantsService.SelectRandomMenuByCategories(orgId, categories);

            return Ok(result);
        }

    }
}
