using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork11.Models
{
    public class Register
    {
        [Required(ErrorMessage = "No email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "No password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password incorrect!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "No role!")]
        public string Role { get; set; }

        [Required(ErrorMessage = "No access data!")]
        public string Access { get; set; }
    }
}
