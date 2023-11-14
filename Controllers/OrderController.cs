using CargoCompany.Models;
using Microsoft.AspNetCore.Mvc;
using CargoCompany.Repositories;

namespace CargoCompany.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Orders> _orderRepository;

        public OrderController(IRepository<Orders> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderRepository.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var p = await _orderRepository.GetById(id);
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Orders orders)
        {
            var result = await _orderRepository.AddAsync(orders);
            if (!result)
            {
                return NotFound();
            }
            return CreatedAtAction("GetById", new { id = orders.OrderId }, orders);
        }

        [HttpPut]
        public IActionResult UpdateOrder([FromBody] Orders updatedOrder)
        {
            var result = _orderRepository.Update(updatedOrder);

            if (result)
            {
                return Ok(new { Message = "Order updated successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Failed to update order." });
            }
        }

        [HttpDelete]
        public IActionResult DeleteOrder([FromBody] Orders orderToDelete)
        {
            var result = _orderRepository.Delete(orderToDelete);

            if (result)
            {
                return Ok(new { Message = "Order deleted successfully." });
            }
            else
            {
                return BadRequest(new { Message = "Failed to delete order." });
            }
        }
    }
}
