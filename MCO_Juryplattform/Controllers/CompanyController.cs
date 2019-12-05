using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCO_Juryplattform.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Index()
        {
            return View(GetAllCustomers());
        }
        [Authorize]
        public List<Company> GetAllCustomers()
        {
            using (JuryModel db = new JuryModel())
            {
                return db.Company.ToList();
            }
        }
    }
}