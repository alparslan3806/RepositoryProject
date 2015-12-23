using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Controllers.Observer
{
    class ConcreteSubject : Subject
    {
        private string _subjectState;
        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }

    }
}