using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork9.Models
{
    public class OrderDTO
    {
        public string customer { get; set; }
        public float price { get; set; }
        public int persons { get; set; }
        public string place { get; set; }
    }
}
