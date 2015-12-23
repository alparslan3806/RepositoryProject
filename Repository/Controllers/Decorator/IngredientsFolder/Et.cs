using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Decorator.Ingredients
{
    public class Et : IngredientsDecorator
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IngredientsController ingCon = new IngredientsController();
        private Models.Ingredients ingredient = new Models.Ingredients();
        private Food food;

        public Et (Food food)
        {
            this.food = food;
            dbOperations();
        }

        public override string getDescription
        {
            get
            {
                return food.getDescription + ", Et";
            }
        }

        public override int cost()
        {
            return (1 + food.cost());
        }
        public void dbOperations()
        {
            int number = ((db.Ingredient.Where(e => e.Name.Equals("Et")).Select(i => i.Quantity).FirstOrDefault()) - 5);
            var ingredients = new Models.Ingredients
            {
                Id = 4,
                Name = "Et",
                Quantity = number
            };

            using (var db = new ApplicationDbContext())
            {
                db.Ingredient.Attach(ingredients);
                db.Entry(ingredients).Property(e => e.Quantity).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}