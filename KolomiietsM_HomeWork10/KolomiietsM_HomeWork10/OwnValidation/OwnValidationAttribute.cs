using KolomiietsM_HomeWork10.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork10.OwnValidation
{
    public class OwnValidationModelAttribute : ValidationAttribute
    {
        private static string[] myAuthors;

        public OwnValidationModelAttribute(string[] Authors)
        {
            myAuthors = Authors;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                for (int i = 0; i < myAuthors.Length; i++)
                {
                    if (strval == myAuthors[i])
                        return true;
                }
            }
            return false;
        }
    }

    public class OwnValidationClassAttribute : ValidationAttribute
    {
        public OwnValidationClassAttribute()
        {

        }
        public override bool IsValid(object value)
        {

            if (value.GetType() == typeof(Menu))
            {

            }
            else if (value.GetType() == typeof(Dish))
            {

            }
            else if (value.GetType() == typeof(Order))
            {

            }
            else if (value.GetType() == typeof(Restaurant))
            {

            }

            return false;
        }
    }
}
