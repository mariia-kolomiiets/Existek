using KolomiietsM_HomeWork10.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace KolomiietsM_HomeWork10.OwnValidation
{
    public class OwnValidationModelAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                Restaurant restaurant = value as Restaurant;
                if (restaurant != null)
                {
                    if (!Regex.Match(restaurant.Address, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success) return true;
                }
            }
            return false;
        }
    }

    public class OwnValidationClassAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            if (value.GetType() == typeof(Menu))
            {
                Menu menu = value as Menu;
                if (menu != null)
                {
                    if (menu.Dishes.Count != 0) return true;
                }
            }
            else if (value.GetType() == typeof(Dish))
            {
                Dish dish = value as Dish;
                if (dish != null)
                {
                    if (dish.Menus.Count != 0) return true;
                }
            }
            else if (value.GetType() == typeof(Order))
            {
                Order order = value as Order;
                if (order != null)
                {
                    if (order.Persons <= 5) return true;
                }
            }
            else if (value.GetType() == typeof(Restaurant))
            {
                Restaurant restaurant = value as Restaurant;
                if (restaurant != null)
                {
                    if (!Regex.Match(restaurant.Address, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success) return true;
                }
            }

            return false;
        }
    }
}
