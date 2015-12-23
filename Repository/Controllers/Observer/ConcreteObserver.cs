using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Observer
{
    class ConcreteObserver : Observer
    {
        private string _name;
        private string _observerState;
        private ConcreteSubject _subject;

        private ApplicationDbContext db = new ApplicationDbContext();
        private IngredientsController ingCon = new IngredientsController();
        private Ingredients ingredient = new Ingredients();
        private ConcreteSubject subject = new ConcreteSubject();

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            var observerList = subject._observers; 
            foreach(var item in observerList)
            {
                var quantity = db.Ingredient.Where(e => e.Name.Equals(item)).Select(i => i.Quantity).FirstOrDefault();
                if (quantity < 10)
                {
                    
                }
            }
            



            _subject = subject;
            _name = name;
        }
        
        public override void Update()
        {
            _observerState = _subject.SubjectState;
        }

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

    }
}