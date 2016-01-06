using Repository.Controllers.Decorator;
using Repository.Controllers.Decorator.Ingredients;
using Repository.Models;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Controllers
{
    public class FoodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IngredientsController ingCon = new IngredientsController();
        private Ingredients ingredient = new Ingredients();
        private Food food;

        public ActionResult EtliSacKavurma()
        {
            IngredientsViewModel ListOfIngredients = new IngredientsViewModel();
            return View(ListOfIngredients);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EtliSacKavurma(IngredientsViewModel ingredients)
        {

            if (ModelState.IsValid || ingredients != null)
            {
                // Here I added Ciger as Food.

                food = new EtliSacKavurma();

                calculateBiber(ingredients.Biber);
                calculateDomates(ingredients.Domates);
                calculateEt(ingredients.Et);
                calculatePatlican(ingredients.Patlican);
                calculateSalca(ingredients.Salca);
                calculateSiviYag(ingredients.Siviyag);
                calculateSu(ingredients.Su);
                calculateZeytinyagi(ingredients.Zeytinyagi);

            }

            if (db.Warning.FirstOrDefault() == null)
            {
                TempData["ingredientList"] = food.getDescription + " " + food.cost().ToString() + "Tl";
            }

            return RedirectToAction("Index", "Food");
        }

        public ActionResult Nohut()
        {
            IngredientsViewModel ListOfIngredients = new IngredientsViewModel();
            return View(ListOfIngredients);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nohut(IngredientsViewModel ingredients)
        {

            if (ModelState.IsValid || ingredients != null)
            {
                // Here I added Ciger as Food.

                food = new Nohut();

                calculateBiber(ingredients.Biber);
                calculateDomates(ingredients.Domates);
                calculateEt(ingredients.Et);
                calculatePatlican(ingredients.Patlican);
                calculateSalca(ingredients.Salca);
                calculateSiviYag(ingredients.Siviyag);
                calculateSu(ingredients.Su);
                calculateZeytinyagi(ingredients.Zeytinyagi);

            }
            if(db.Warning.FirstOrDefault() == null)
            {
                TempData["ingredientList"] = food.getDescription + " " + food.cost().ToString() + "Tl";
            }

            return RedirectToAction("Index", "Food");
        }

        public ActionResult Ciger()
        {
            IngredientsViewModel ListOfIngredients = new IngredientsViewModel();
            return View(ListOfIngredients);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ciger(IngredientsViewModel ingredients)
        {

            if (ModelState.IsValid || ingredients != null)
            {
                // Here I added Ciger as Food.

                food = new Ciger();

                calculateBiber(ingredients.Biber);
                calculateDomates(ingredients.Domates);
                calculateEt(ingredients.Et);
                calculatePatlican(ingredients.Patlican);
                calculateSalca(ingredients.Salca);
                calculateSiviYag(ingredients.Siviyag);
                calculateSu(ingredients.Su);
                calculateZeytinyagi(ingredients.Zeytinyagi);
                
            }

            if (db.Warning.FirstOrDefault() == null)
            {
                TempData["ingredientList"] = food.getDescription + " " + food.cost().ToString() + "Tl";
            }
            return RedirectToAction("Index", "Food");
        }

        public ActionResult Index()
        {
            ViewBag.msg = db.Warning.Select(e => e.State).ToList();
            return View();
        }

        public void calculateZeytinyagi(int ing)
        {
            if (ing > 0)
            {
                for (int counter = 0; counter < ing; counter++)
                {
                    food = new Zeytinyagi(food);
                }
            }
        }

        public void calculateSu(int ing)
        {
            if (ing > 0)
            {
                for (int counter = 0; counter < ing; counter++)
                {
                    food = new Su(food);
                }
            }
        }

        public void calculateSiviYag(int ing)
        {
            if (ing > 0)
            {
                for (int counter = 0; counter < ing; counter++)
                {
                    food = new Siviyag(food);
                }
            }
        }

        public void calculateSalca(int ing)
        {
            if (ing > 0)
            {
                for (int counter = 0; counter < ing; counter++)
                {
                    food = new Salca(food);
                }
            }
        }

        public void calculatePatlican(int ing)
        {
            if (ing > 0)
            {
                for (int counter = 0; counter < ing; counter++)
                {
                    food = new Patlican(food);
                }
            }
        }

        public void calculateEt(int ing)
        {
            if (ing > 0)
            {
                for (int counter = 0; counter < ing; counter++)
                {
                    food = new Et(food);
                }
            }
        }

        public void calculateDomates(int ing)
        {
            if (ing > 0)
            {
                for (int counter = 0; counter < ing; counter++)
                {
                    food = new Domates(food);
                }
            }
        }

        public void calculateBiber(int ing)
        {
            if (ing > 0)
            {
                for (int counter = 0; counter < ing; counter++)
                {
                    food = new Biber(food);
                }
            }
        }

    }
}