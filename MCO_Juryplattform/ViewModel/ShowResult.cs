using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCO_Juryplattform.Models
{
    public class ShowResult
    {
        public int Id { get; set; }
        public string Companyname { get; set; }

        public int totallpoints { get; set; }

        public double totallpointspercentage { get; set; }

        public int howMenyVoted { get; set; }

        

    }
}