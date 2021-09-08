using KolomiietsM_HomeWork10.Context;
using KolomiietsM_HomeWork10.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork10.Repository
{
    public class RestaurantRepository
    {
        private readonly DORMContext context;
        public RestaurantRepository(DORMContext context)
        {
            this.context = context;
        }
        public void Create(Restaurant item)
        {
            context.Restaurants.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Restaurant restaurant = context.Restaurants.Find(id);
            if (restaurant != null)
                context.Restaurants.Remove(restaurant);
            context.SaveChanges();
        }

        public IEnumerable<Restaurant> Find(Func<Restaurant, bool> predicate)
        {
            return context.Restaurants.Where(predicate).ToList();
        }

        public Restaurant Get(int id)
        {
            return context.Restaurants.Find(id);
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            var allRestaurants = await context.Restaurants.ToListAsync();
            return allRestaurants;
        }

        public void Update(Restaurant item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
