using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCO_Juryplattform.Models
{
    public class CompanyQuestions
    {
        public int CompanyId { get; set; }
        public string Companyname { get; set; }

        public List<Form> Forms{ get; set;}
    }
}