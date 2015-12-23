using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers
{
    //Food plays role of beverage in the book. 
    public abstract class Food
    {
        private string description = "Unknown Description";

        public virtual string getDescription
        {
            get{ return description; }
        }

        public abstract int cost();
    }
}