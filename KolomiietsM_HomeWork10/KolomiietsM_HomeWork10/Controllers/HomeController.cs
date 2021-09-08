using KolomiietsM_HomeWork10.Context;
using KolomiietsM_HomeWork10.Models;
using KolomiietsM_HomeWork10.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork10.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private DORMContext context;
        OrderRepository orderRepository;
        public HomeController(DORMContext context, DishRepository dishRepository, MenuRepository menuRepository,
            OrderRepository orderRepository, RestaurantRepository restaurantRepository)
        {
            this.context = context;
            new InitializationContext(context);
            this.orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task AddOrder([FromBody] OrderDTO orderDTO)
        {
            var aaa = HttpContext.Request.Body;
            var bbb = Request.Body;
            var ccc = Request;
            orderRepository.Create(new Models.Order
            {
                Customer = orderDTO.customer,
                Date = DateTime.Today,
                Persons = orderDTO.persons,
                Price = orderDTO.price,
                Place = context.Restaurants.FirstOrDefault(r => r.Title.Contains(orderDTO.place))
            });

            await HttpContext.Response.WriteAsync("Order added.");
        }

        [HttpGet]
        [Route("[action]")]
        public async Task GetOrders()
        {
            string allOrders = "";
            List<Order> orders = (await orderRepository.GetAll()).ToList();
            orders.ForEach(o => allOrders += $"{o.Date}: {o.Customer} at {o.Place.Title} restaurant. For {o.Persons} persons. Price {o.Price}$\n");
            await HttpContext.Response.WriteAsync(allOrders);
        }

        [HttpGet]
        [Route("[action]/{customer}")]
        public async Task GetOrder([FromRoute] string customer)
        {
            string allOrders = "";
            List <Order> orders =  orderRepository.GetByCustomer(customer).ToList();
            orders.ForEach(o => allOrders += $"{o.Date}: {o.Customer} at {o.Place.Title} restaurant. For {o.Persons} persons. Price {o.Price}$\n");
            await HttpContext.Response.WriteAsync(allOrders);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task ChangeOrder([FromQuery] int id,[FromBody] Order newOrder)
        {
            newOrder.Id = id;
            orderRepository.Update(newOrder);
            await HttpContext.Response.WriteAsync("Order updated.");
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task DeleteOrder([FromHeader] int id)
        {
            orderRepository.Delete(id);
            await HttpContext.Response.WriteAsync("Order deleted.");
        }

    }
}
