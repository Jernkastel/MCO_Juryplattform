using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCO_Juryplattform.Models
{
    public class Grade
    {

        public int QuestionId { get; set; }

        public string Question { get; set; }

        public int Answer { get; set; }
    }
}