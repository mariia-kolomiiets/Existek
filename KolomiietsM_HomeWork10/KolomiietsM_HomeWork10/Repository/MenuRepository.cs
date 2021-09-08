using KolomiietsM_HomeWork10.Context;
using KolomiietsM_HomeWork10.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork10.Repository
{
    public class MenuRepository
    {
        private readonly DORMContext context;
        public MenuRepository(DORMContext context)
        {
            this.context = context;
        }
        public void Create(Menu item)
        {
            context.Menus.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Menu menu = context.Menus.Find(id);
            if (menu != null)
                context.Menus.Remove(menu);
            context.SaveChanges();
        }

        public IEnumerable<Menu> Find(Func<Menu, bool> predicate)
        {
            return context.Menus.Where(predicate).ToList();
        }

        public Menu Get(int id)
        {
            return context.Menus.Find(id);
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            var allMenus = await context.Menus.ToListAsync();
            return allMenus;
        }

        public void Update(Menu item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
