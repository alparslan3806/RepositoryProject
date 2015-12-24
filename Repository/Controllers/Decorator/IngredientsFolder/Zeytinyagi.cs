using Repository.Controllers.Observer;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Decorator.Ingredients
{
    public class Zeytinyagi : IngredientsDecorator
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IngredientsController ingCon = new IngredientsController();
        private Models.Ingredients ingredient = new Models.Ingredients();
        private ConcreteSubject subject = new ConcreteSubject();
        private Food food;

        public Zeytinyagi(Food food)
        {
            this.food = food;
            subject.Attach(new ConcreteObserver(subject, "Sıvı Yağ"));
            dbOperations();
        }

        public override string getDescription
        {
            get
            {
                return food.getDescription + ", Zeytinyağı";
            }
        }

        public override int cost()
        {
            return (3 + food.cost());
        }
        public void dbOperations()
        {
            int number = ((db.Ingredient.Where(e => e.Name.Equals("Zeytinyağı")).Select(i => i.Quantity).FirstOrDefault()) - 5);
            if (number > 100)
            {
                var ingredients = new Models.Ingredients
                {
                    Id = 1,
                    Name = "Zeytinyağı",
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
                subject.SubjectState = "Zeytinyağı";
                subject.Notify();
            }
        }
    }
}