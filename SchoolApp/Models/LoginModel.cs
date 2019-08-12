using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Web.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    internal class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Password)]
        internal string Password { get; set; }
    }
}
