using KolomiietsM_HomeWork9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork9.Context
{
    public class InitializationContext
    {
        private DORMContext context;
        private static bool doInit = true;
        public InitializationContext(DORMContext context)
        {
            this.context = context;
            if (doInit)
            {
                ClearDbValues();
                InitDbValues();
                doInit = false;
            }
        }

        private void InitDbValues()
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

        private void ClearDbValues()
        {
            context.Restaurants.RemoveRange(context.Restaurants);
            context.Menus.RemoveRange(context.Menus);
            context.Dishes.RemoveRange(context.Dishes);
            context.Orders.RemoveRange(context.Orders);

            context.SaveChanges();
        }
    }
}
