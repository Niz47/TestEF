using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestEF.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [Display(Name= "Profile Picture")]
        public string Photo { get; set; }
        public string Address { get; set; }
    }
}