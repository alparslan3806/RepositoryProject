using Repository.Controllers.Observer;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Decorator.Ingredients
{
    public class Domates : IngredientsDecorator
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IngredientsController ingCon = new IngredientsController();
        private Models.Ingredients ingredient = new Models.Ingredients();
        private ConcreteSubject subject = new ConcreteSubject();
        private Food food;

        public Domates(Food food)
        {
            this.food = food;
            subject.Attach(new ConcreteObserver(subject, "Domates"));
            dbOperations();
        }

        public override string getDescription
        {
            get
            {
                return food.getDescription + ", Domates";
            }
        }

        public override int cost()
        {
            return (food.cost() + 1);
        }
        public void dbOperations()
        {
            int number = ((db.Ingredient.Where(e => e.Name.Equals("Domates")).Select(i => i.Quantity).FirstOrDefault()) - 5);
            var ingredients = new Models.Ingredients
            {
                Id = 7,
                Name = "Domates",
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