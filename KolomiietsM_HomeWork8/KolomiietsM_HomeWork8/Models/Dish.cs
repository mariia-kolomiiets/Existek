using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork8.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Menu> Menus { get; set; } //many to many DISH->MENU =
                                              //menu consist of many dishes and the same dish can be present in many menus
    }
}
