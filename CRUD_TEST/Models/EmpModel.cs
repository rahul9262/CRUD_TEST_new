using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_TEST.Models
{
    public class EmpModel
    {

        public int Emp_Id { get; set; }
        [Required]
        public string Emp_Name { get; set; }
        [Required]
        public string Emp_Dept_Name { get; set; }
        [Required]
        public string Emp_Comp_Name { get; set; }
        [Required]
        public string Emp_Sal { get; set; }
        [Required]
        public string Emp_Mob { get; set; }

        public int ForgetPassword { get; set; }
    }
}