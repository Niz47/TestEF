using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestEF.Models
{
    public class Recipe
    {
        [Key]
        public int recipe_id { get; set; }
        public string Image { get; set; }
        public string recipe_name { get; set; }

        public virtual ICollection<Ingredient> ingredients { get; set; }
        public virtual ICollection<Instruction> instructions { get; set; }
    }
}