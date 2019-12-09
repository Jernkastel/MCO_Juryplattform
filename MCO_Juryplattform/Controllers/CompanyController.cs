using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCO_Juryplattform.Controllers
{
    public class CompanyController : Controller
    {
        
        // GET: Company
        public ActionResult Index()
        {
            return View(GetAllCustomers());
        }
        public List<Company> GetAllCustomers()
        {
            using (JuryModel db = new JuryModel())
            {
                return db.Company.ToList();
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (JuryModel db = new JuryModel())
            {
                
                return RedirectToAction("Index", "Question",(db.Company.Where(x => x.Id == id).FirstOrDefault()));
            }
        }
        [HttpGet]
        public ActionResult Link(string href)
        {
            return Redirect("http://www.google.com");
        }
    }
}