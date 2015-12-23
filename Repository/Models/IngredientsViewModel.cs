using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class IngredientsViewModel
    {
       
        public int Biber { get; set; }

        public int Domates { get; set; }

        public int Et { get; set; }

        public int Patlican { get; set; }

        public int Salca { get; set; }

        public int Siviyag { get; set; }

        public int Su { get; set; }

        public int Zeytinyagi { get; set; }
            
     
        public IngredientsViewModel()
        {
            Biber = 0;
            Domates = 0;
            Et = 0;
            Patlican = 0;
            Salca = 0;
            Siviyag = 0;
            Su = 0;
            Zeytinyagi = 0;
        }
           
    }
}