using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork8.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public Menu Menu { get; set; }
        public List<Order> Orders { get; set; }  //one to many ORDER->RESTAURANT =
                                                 //the exact order has just one exact place(restaurant) but restaurant has many orders
    }
}
