using AlfabankProjectApi.App.Services;
using AlfabankProjectApi.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlfabankProjectApi.App.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrderController : ControllerBase
    {
        private OrderService _service;
        public OrderController(OrderService service)
        {
            _service = service;
        }

        [HttpPost("buy")]
        public IActionResult BuyCart(List<MenuItem> menus)
        {
            return Ok(_service.ProcessCart(menus));
        }
    }
}