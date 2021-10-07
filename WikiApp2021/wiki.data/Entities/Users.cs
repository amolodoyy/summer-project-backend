using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace wiki.data
{
    [Table("AspNetUsers")]
    public class Users : IdentityUser
    {
        public string Path { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
    }
}
