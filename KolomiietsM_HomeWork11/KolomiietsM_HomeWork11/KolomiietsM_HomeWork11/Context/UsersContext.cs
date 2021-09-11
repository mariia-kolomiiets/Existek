using KolomiietsM_HomeWork11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork11.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            base.OnModelCreating(modelBuilder);
        }
    }
}
