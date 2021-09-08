using KolomiietsM_HomeWork10.OwnValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork10.Models
{
    [OwnValidationClassAttribute]
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public float Price { get; set; }
        public int Persons { get; set; }
        public DateTime Date { get; set; }
        public Restaurant Place { get; set; } //one to many ORDER->RESTAURANT =
                                              //the exact order has just one exact place(restaurant) but restaurant has many orders
    }
}
