using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace wiki.business.View_Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Wrong email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Wrong password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Display(Name = "Remember?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
