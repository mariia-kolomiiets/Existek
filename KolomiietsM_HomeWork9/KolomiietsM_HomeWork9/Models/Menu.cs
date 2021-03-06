using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork9.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Dish> Dishes{ get; set; } //many to many DISH->MENU = menu consist of many dishes and the same dish can be present in many menus
    }
}
