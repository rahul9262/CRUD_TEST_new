using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_TEST.Models
{
    public class UserModel
    {

        public int Userid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string MobIle { get; set; }

        public int ForgetPassword { get; set; }
    }
}