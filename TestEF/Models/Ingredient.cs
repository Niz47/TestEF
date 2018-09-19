using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestEF.Models
{
    public class Ingredient
    {
        [Key]
        public int ingredient_id { get; set; }
        public Nullable<int> recipe_id { get; set; }
        public string ingredient_name { get; set; }
        public string ingredient_amount { get; set; }

        public virtual Recipe recipe { get; set; }
    }
}