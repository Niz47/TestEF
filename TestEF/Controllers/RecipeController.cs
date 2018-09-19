using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestEF.Models;
using TestEF.ViewModels;

namespace TestEF.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipe
        public ActionResult Index()
        {
            return View(db.Recipe.ToList());
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int? id)
        {
            List<Ingredient> ingredientList;

            using (db)
            {
                if (id != null)
                {
                    Recipe recipe = db.Recipe.Find(id);
                    ViewBag.RecipeName = recipe.recipe_name;
                    ingredientList = db.Ingredient.ToArray().Where(x => x.recipe_id == recipe.recipe_id).ToList();
                }
                else
                {
                    ViewBag.RecipeName = "All Items";

                    ingredientList = db.Ingredient.Include(x => x.recipe).ToList();
                }
            }

            return View(ingredientList);
        }

        // GET: Recipe/Details/5
        public ActionResult RecipeDetails(int? id)
        {
            List<Ingredient> ingredientList;
            List<Instruction> instructionList;
            RecipeIngredientInstructionVM recipeVM;

            using (db)
            {
                if (id != null)
                {
                    Recipe recipe = db.Recipe.Find(id);
                    ViewBag.RecipeName = recipe.recipe_name;
                    ingredientList = db.Ingredient.ToArray().Where(x => x.recipe_id == recipe.recipe_id).ToList();
                    instructionList = db.Instruction.ToArray().Where(x => x.recipe_id == recipe.recipe_id).ToList();
                    recipeVM = new RecipeIngredientInstructionVM(recipe, ingredientList, instructionList);
                }
                else
                {
                    return Redirect("Index");
                }
            }

            return View(recipeVM);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recipe_id,Image,recipe_name")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipe.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recipe_id,Image,recipe_name")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipe.Find(id);
            db.Recipe.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
