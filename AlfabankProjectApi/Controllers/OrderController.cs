using AlfabankProjectApi.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlfabankProjectApi.App.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrderController : ControllerBase
    {
        [HttpGet("cart/{id}")]
        public IActionResult GetCart(Guid id)
        {
            return Ok();
        }

        [HttpPost("cart")]
        public IActionResult AddToCart(Guid itemId)
        {
            return Ok();
        }
        [HttpPost("buy")]
        public IActionResult BuyCart(Guid orderId)
        {
            return Ok();
        }
    }
}