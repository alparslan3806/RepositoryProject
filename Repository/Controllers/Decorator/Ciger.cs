using Repository.Controllers.Observer;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Decorator
{
    public class Ciger : Food
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IngredientsController ingCon = new IngredientsController();
        private Models.Ingredients ingredient = new Models.Ingredients();


        private ConcreteSubject subject = new ConcreteSubject();

        //Nohut Ciger and EtliSacKavurma classes are playing Espresso and HouseBlend

        public Ciger()
        {
            subject.Attach(new ConcreteObserver(subject, "Ciğer"));
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
                return "Ciğer";
            }
        }
        public void dbOperations()
        {
            int number = ((db.Ingredient.Where(e => e.Name.Equals("Ciger")).Select(i => i.Quantity).FirstOrDefault()) - 5);
            var ingredients = new Models.Ingredients
            {
                Id = 2,
                Name = "Ciger",
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