using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Decorator
{
    public abstract class IngredientsDecorator : Food
    {
        public abstract override string getDescription{ get; }
    }
}