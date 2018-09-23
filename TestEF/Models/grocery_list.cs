using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestEF.Models
{
    public class grocery_list
    {
        [Key]
        public int grocery_id { get; set; }
        public string grocery_item { get; set; }
        public string grocery_amount { get; set; }
    }
}