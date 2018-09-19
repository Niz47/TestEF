using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestEF.Models;

namespace TestEF.ViewModels
{
    public class RecipeIngredientInstructionVM
    {
        public RecipeIngredientInstructionVM()
        {

        }
        public RecipeIngredientInstructionVM(Recipe recipe, List<Ingredient> ingredients, List<Instruction> instructions)
        {
            this.recipe_id = recipe.recipe_id;
            this.recipe_name = recipe.recipe_name;
            this.Image = recipe.Image;
            this.ingredients = ingredients;
            this.instructions = instructions;
        }

        public int recipe_id { get; set; }
        public string Image { get; set; }
        public string recipe_name { get; set; }

        public List<Ingredient> ingredients { get; set; }
        public List<Instruction> instructions { get; set; }
    }
}