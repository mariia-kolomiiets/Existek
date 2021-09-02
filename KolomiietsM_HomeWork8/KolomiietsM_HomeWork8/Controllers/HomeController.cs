using KolomiietsM_HomeWork8.Context;
using KolomiietsM_HomeWork8.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork8.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private DORMContext context;
        public HomeController(DORMContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("[action]/{customer}-{price}-{persons}-{place}")]
        public async Task AddOrder(string customer, float price, int persons, Restaurant place)
        {
            context.Orders.Add(new Models.Order
            {
                Customer = customer,
                Date = DateTime.Today,
                Persons = persons,
                Price = price,
                Place = context.Restaurants.FirstOrDefault(r => r.Title.Contains(place.Title))
            });
            context.SaveChanges();
        }

        [HttpGet]
        [Route("Init")]
        public async Task InitValues()
        {
            initDbValues();
        }

        [HttpGet]
        private void initDbValues()
        {
            Menu seaMenu = new Menu
            {
                Title = "SeaFood"
            };
            Menu italMenu = new Menu
            {
                Title = "ItalianFood"
            };

            context.Menus.Add(seaMenu);
            context.Menus.Add(italMenu);

            context.Dishes.Add(new Dish
            {
                Title = "Fish-polo",
                Description = "Fried fish with chips",
                Menus = new List<Menu>() { seaMenu, italMenu }
            });
            context.Dishes.Add(new Dish
            {
                Title = "Spaghetti aroma",
                Description = "Spaghetti with tomatoes and cheese",
                Menus = new List<Menu>() { italMenu }
            });
            context.Dishes.Add(new Dish
            {
                Title = "Rala vollo",
                Description = "Raviolli with cream sauce",
                Menus = new List<Menu>() { italMenu }
            });
            context.Dishes.Add(new Dish
            {
                Title = "Kioto",
                Description = "Red fish with onion",
                Menus = new List<Menu>() { seaMenu }
            });

            context.Restaurants.Add(new Restaurant
            {
                Title = "SeaFree",
                Address = "Desbr street, 7",
                Menu = seaMenu
            });

            context.Restaurants.Add(new Restaurant
            {
                Title = "ElFojo",
                Address = "Tropio street, 23",
                Menu = italMenu
            });

            context.SaveChanges();
        }

    }
}
