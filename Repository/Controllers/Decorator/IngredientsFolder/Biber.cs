using Repository.Controllers.Observer;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Decorator.Ingredients
{
    public class Biber : IngredientsDecorator
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IngredientsController ingCon = new IngredientsController();
        private Models.Ingredients ingredient = new Models.Ingredients();
        private ConcreteSubject subject = new ConcreteSubject();
        private Food food;

        public Biber(Food food)
        {
            this.food = food;
            subject.Attach(new ConcreteObserver(subject, "Biber"));
            dbOperations();
        }

        public override string getDescription
        {
            get
            {
                return food.getDescription + ", Biber";
            }
        }

        public override int cost()
        {
            //if(db.Ingredients.Select(m => m.Biber) <= 5){} Observer a haber gönder.
            return (food.cost() + 1);
        }
        public void dbOperations()
        {
            int number = ((db.Ingredient.Where(e => e.Name.Equals("Biber")).Select(i => i.Quantity).FirstOrDefault()) - 5);
            if (number > 100)
            {
                var ingredients = new Models.Ingredients
                {
                    Id = 8,
                    Name = "Biber",
                    Quantity = number
                };

                using (var db = new ApplicationDbContext())
                {
                    db.Ingredient.Attach(ingredients);
                    db.Entry(ingredients).Property(e => e.Quantity).IsModified = true;
                    db.SaveChanges();
                }
            }
            else
            {
                subject.SubjectState = "Biber";
                subject.Notify();
            }
        }
    }
}