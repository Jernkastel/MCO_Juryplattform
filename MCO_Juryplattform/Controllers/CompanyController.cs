using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCO_Juryplattform.Controllers
{
    public class CompanyController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View(GetAllCustomers());
        }
        public List<Company> GetAllCustomers()
        {
            using (JuryModel db = new JuryModel())
            {

                int id = (int)(Session["id"]);
                var temp = db.VoteCheck.Where(e => e.UserId == id)
                                       .Select(e => e.CompanyId).ToList();
                return db.Company.Where(e => !temp.Contains(e.Id)).ToList();

            }
        }
        [Authorize]
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
            return Redirect(href);
        }
    }
}