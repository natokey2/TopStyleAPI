using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopStyleAPI.Repos.Entities;

namespace TopStyleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ProductContext _db;
        public OrderController(ProductContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult PlaceOrder(int customerId, int productId)
        {
            // Check if the customer exists
            var customer = _db.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            // Check if the product exists
            var product = _db.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            // Create a new order
            var order = new Order
            {
                CustomerId = customerId,
                Name = "ordername",
                ProductId = productId,
                OrderDate = DateTime.UtcNow
            };

            // Add the order to the DbContext
            _db.Orders.Add(order);

            // Save changes to the database
            _db.SaveChanges();

            return Ok("Order placed successfully.");
        }

    }
}
