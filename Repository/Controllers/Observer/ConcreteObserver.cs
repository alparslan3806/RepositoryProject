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
        private HomeController home = new HomeController();

        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            _subject = subject;
            _name = name;
        }
        
        public override void Update()
        {
            _observerState = _subject.SubjectState;
            /// SEND NAME AND SUBJECT TO VIEW
            Warnings warning = new Warnings();
            int number = 0;
            if(db.Warning.Select(e => e.Id).FirstOrDefault() != 0)
            {
                number = (db.Warning.Select(e => e.Id).FirstOrDefault() + 1);
            }
            warning.Id = number;
            warning.State = _subject.SubjectState;
            //Eğer Database de aynı satır varsa ekleme. yoksa ekle.
            if((db.Warning.Where(e => e.State == _subject.SubjectState)).FirstOrDefault() == null)
            {
                db.Warning.Add(warning);
                db.SaveChanges();
            }
        }

        public ConcreteSubject Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

    }
}