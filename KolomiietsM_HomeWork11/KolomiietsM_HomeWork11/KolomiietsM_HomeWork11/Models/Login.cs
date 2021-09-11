using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork11.Models
{
    public class Login
    {
        [Required(ErrorMessage = "No email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "No password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
