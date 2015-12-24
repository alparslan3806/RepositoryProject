using Repository.Controllers.Observer;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Decorator
{
    public class Nohut : Food
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IngredientsController ingCon = new IngredientsController();
        private Models.Ingredients ingredient = new Models.Ingredients();
        private ConcreteSubject subject = new ConcreteSubject();



        public Nohut()
        {
            subject.Attach(new ConcreteObserver(subject, "Nohut"));
            dbOperations();
        }

        public override int cost()
        {
            return 5;
        }

        public override string getDescription
        {
            get
            {
                return "Nohut";
            }
        }
        public void dbOperations()
        {
            int number = ((db.Ingredient.Where(e => e.Name.Equals("Nohut")).Select(i => i.Quantity).FirstOrDefault()) - 5);
            if (number > 100)
            {
                var ingredients = new Models.Ingredients
                {
                    Id = 3,
                    Name = "Nohut",
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
                subject.SubjectState = "Nohut";
                subject.Notify();
            }
        }
    }
}