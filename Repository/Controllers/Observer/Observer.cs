using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Observer
{
    public abstract class Observer
    {
        public abstract void Notify();
    }
}