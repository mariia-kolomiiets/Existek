using KolomiietsM_HomeWork10.Context;
using KolomiietsM_HomeWork10.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork10.Repository
{
    public class DishRepository
    {
        private readonly DORMContext context;
        public DishRepository(DORMContext context)
        {
            this.context = context;
        }
        public void Create(Dish item)
        {
            context.Dishes.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Dish dish = context.Dishes.Find(id);
            if (dish != null)
                context.Dishes.Remove(dish);
            context.SaveChanges();
        }

        public IEnumerable<Dish> Find(Func<Dish, bool> predicate)
        {
            return context.Dishes.Where(predicate).ToList();
        }

        public Dish Get(int id)
        {
            return context.Dishes.Find(id);
        }

        public async Task<IEnumerable<Dish>> GetAll()
        {
            var allDishes = await context.Dishes.ToListAsync();
            return allDishes;
        }

        public void Update(Dish item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
