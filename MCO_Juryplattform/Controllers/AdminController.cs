using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCO_Juryplattform.Controllers
{
    public class AdminController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }
        #region Company
        //[Authorize]
        public ActionResult AdminCompany()
        {
            return View(GetAllCustomers());
        }
        private List<Company> GetAllCustomers()
        {
            using (JuryModel db = new JuryModel())
            {
                return db.Company.ToList();
            }
        }

        //[Authorize]
        [HttpGet]
        public ActionResult AdminCompanyEdit(int id)
        {
            return View(GetCompany(id));
        }
        private Company GetCompany(int pk)
        {
            using (JuryModel db = new JuryModel())
            {
                return db.Company.Find(pk);
            }
        }
        //[Authorize]
        [HttpPost]
        public ActionResult AdminCompanyEdit(Company company)
        {
            using (JuryModel db = new JuryModel())
            {
                var updatedeCustomer = db.Company.Find(company.Id);
                updatedeCustomer.Name = company.Name;
                updatedeCustomer.Href = company.Href;
                db.SaveChanges();
            }
            return RedirectToAction("AdminCompany", "Admin");
        }
        public ActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            using (JuryModel db = new JuryModel())
            {
                db.Company.Add(company);
                db.SaveChanges();
            }
            return RedirectToAction("AdminCompany", "Admin");
        }
        public ActionResult DeletCompany(int companyId)
        {
            using (JuryModel db = new JuryModel())
            {
                
                //db.Company
                //    .Find(companyId)
                //    .product
                //    .ToList()
                //    .ForEach(item => db.product
                //                       .Find(item.pk)
                //                       .customer
                //                       .Remove(db.customer.Find(customerPK)));

                //db.customer.Remove(db.customer.Find(customerPK));
                //db.SaveChanges();
            }
            return RedirectToAction("AdminCompany", "Admin");
        }

        #endregion
        #region Questions
        [Authorize]
        public ActionResult AdminQuestions()
        {
            return View(questions());
        }
        [HttpGet]
        public ActionResult AdminQuestionsEdit(int id)
        {
            return View(GetQuestions(id));
        }

        private FormQuestions GetQuestions(int pk)
        {
            using (JuryModel db = new JuryModel())
            {
                return db.FormQuestions.Find(pk);
            }
        }
        [HttpPost]
        public ActionResult AdminQuestionsEdit(FormQuestions formQuestions)
        {
            using (JuryModel db = new JuryModel())
            {
                var updateQuestion = db.FormQuestions.Find(formQuestions.Id);
                //updateQuestion.Category = formQuestions.Category;
                updateQuestion.Category = db.FormQuestions.Find(formQuestions.Id).Category;
                updateQuestion.Question = formQuestions.Question;
                db.SaveChanges();
            }
            return RedirectToAction("AdminQuestions", "Admin");
        }
        public List<FormQuestions> questions()
        {

            using (JuryModel db = new JuryModel())
            {

                return db.FormQuestions.ToList();
            }
        }

        #endregion
        [Authorize]
        public ActionResult AdminForm()
        {
            return View();
        }
    }
}