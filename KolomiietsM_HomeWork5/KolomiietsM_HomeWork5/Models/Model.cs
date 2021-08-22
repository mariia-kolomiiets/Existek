using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork5.Models
{
    public class Model
    {
        public Model()
        {
            this.ids = new List<long> { 1, 2, 3, 4 };
        }
        public List<long> ids { get; set; }
    }
}
