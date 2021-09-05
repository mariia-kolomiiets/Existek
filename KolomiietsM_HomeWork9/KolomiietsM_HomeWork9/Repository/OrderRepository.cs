using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KolomiietsM_HomeWork9.Context;
using KolomiietsM_HomeWork9.Models;
using Microsoft.EntityFrameworkCore;

namespace KolomiietsM_HomeWork9.Repository
{
    public class OrderRepository
    {
        private readonly DORMContext context;
        public OrderRepository(DORMContext context)
        {
            this.context = context;
        }
        public void Create(Order item)
        {
            context.Orders.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = context.Orders.Find(id);
            if (order != null)
                context.Orders.Remove(order);
            context.SaveChanges();
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            GetAll().Result.ToList().Select(predicate);//
            return context.Orders.Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return context.Orders.Find(id);
        }

        public IEnumerable<Order> GetByCustomer(string customer)
        {
            return Find(o => o.Customer.Equals(customer));
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            var allOrders = await context.Orders.Select(o => new Order
            {
                Date = o.Date,
                Customer = o.Customer,
                Persons = o.Persons,
                Price = o.Price,
                Id = o.Id,
                Place = o.Place

            }).ToListAsync();

            return allOrders;
        }

        public void Update(Order item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
