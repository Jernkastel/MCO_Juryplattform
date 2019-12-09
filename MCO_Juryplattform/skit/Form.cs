using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCO_Juryplattform.Models
{
    public class Form
    {
        public int FormId { get; set; }

        public string Question { get; set; }

        public List<Grade> Grade { get; set; }
    }
}