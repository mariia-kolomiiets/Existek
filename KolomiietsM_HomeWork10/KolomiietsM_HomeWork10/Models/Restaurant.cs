using KolomiietsM_HomeWork10.OwnValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork10.Models
{
    [OwnValidationClassAttribute]
    public class Restaurant
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [OwnValidationModelAttribute]
        public string Address { get; set; }
        public Menu Menu { get; set; }
        public List<Order> Orders { get; set; }  //one to many ORDER->RESTAURANT =
                                                 //the exact order has just one exact place(restaurant) but restaurant has many orders
    }
}
