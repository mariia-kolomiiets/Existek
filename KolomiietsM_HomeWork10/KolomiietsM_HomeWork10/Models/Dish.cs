using KolomiietsM_HomeWork10.OwnValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork10.Models
{
    [OwnValidationClassAttribute]
    public class Dish : IValidatableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Menu> Menus { get; set; } //many to many DISH->MENU =
                                             //menu consist of many dishes and the same dish can be present in many menus

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Description))
            {
                errors.Add(new ValidationResult("Add the description to your dish."));
            }
            if (string.IsNullOrWhiteSpace(this.Title))
            {
                errors.Add(new ValidationResult("There is no dish title. Error!"));
            }
            if (this.Menus.Count == 0)
            {
                errors.Add(new ValidationResult("There is no menu! Please add your dish to some menu."));
            }

            return errors;
        }
        
    }
}
