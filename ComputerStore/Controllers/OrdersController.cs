using ComputerStore.Api.Repositories;
using ComputerStore.Lib.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComputerStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerCrudBase<Order, OrderRepository>
    {
        public OrdersController(OrderRepository ordersRepository) : base(ordersRepository)
        {
        }
    }
}
