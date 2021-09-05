using KolomiietsM_HomeWork9.Context;
using KolomiietsM_HomeWork9.Models;
using KolomiietsM_HomeWork9.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork9.Controllers
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
        [Route("[action]/{customer}-{price}-{persons}-{place}")]
        public async Task AddOrder(string customer, float price, int persons, string place)
        {
            orderRepository.Create(new Models.Order
            {
                Customer = customer,
                Date = DateTime.Today,
                Persons = persons,
                Price = price,
                Place = context.Restaurants.FirstOrDefault(r => r.Title.Contains(place))
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
        public async Task GetOrder(string customer)
        {
            string allOrders = "";
            List <Order> orders =  orderRepository.GetByCustomer(customer).ToList();
            orders.ForEach(o => allOrders += $"{o.Date}: {o.Customer} at {o.Place.Title} restaurant. For {o.Persons} persons. Price {o.Price}$\n");
            await HttpContext.Response.WriteAsync(allOrders);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task ChangeOrder(int id, Order newOrder)
        {
            newOrder.Id = id;
            orderRepository.Update(newOrder);
            await HttpContext.Response.WriteAsync("Order updated.");
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task DeleteOrder(int id)
        {
            orderRepository.Delete(id);
            await HttpContext.Response.WriteAsync("Order deleted.");
        }

    }
}
