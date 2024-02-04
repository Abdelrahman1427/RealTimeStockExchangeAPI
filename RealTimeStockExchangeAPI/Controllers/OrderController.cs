using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealTimeStockExchangeAPI.Entitiy;
using RealTimeStockExchangeAPI.IService;

namespace RealTimeStockExchangeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [Authorize]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderservice;

        public OrderController(IOrderService orderservice)
        {
            this.orderservice = orderservice;
        }
        [HttpPost("/API/orders")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
                if (IsValidOrder(order))
            {
                orderservice.AddOrder(order);
                return Ok("Order created successfully");
            }

            return BadRequest("Invalid order");
        }

        [HttpGet("/API/orders")]
        public IActionResult GetOrders()
        {
            var orders = orderservice.GetOrders();
            return Ok(orders);
        }

        private bool IsValidOrder(Order order)
        {
            return !string.IsNullOrEmpty(order.StockSymbol) && order.Quantity > 0;
        }

    }
}
