using KolomiietsM_HomeWork8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork8.Context
{
    public class DORMContext : DbContext
    {
        public DORMContext(DbContextOptions<DORMContext> options)
            : base(options)
        {

        }
        internal DbSet<Dish> Dishes { get; set; }
        internal DbSet<Order> Orders { get; set; }
        internal DbSet<Restaurant> Restaurants { get; set; }
        internal DbSet<Menu> Menus { get; set; }
    }
}
