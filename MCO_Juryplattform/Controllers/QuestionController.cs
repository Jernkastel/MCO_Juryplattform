using MCO_Juryplattform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCO_Juryplattform.Controllers
{
    public class QuestionController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index(int id)
        {
            return View(test(id));
        }

        [HttpPost]
        public ActionResult Getting(CompanyQuestions test)
        {
            Console.Write("dlökjf");
            return View();
        }

        public List<FormQuestions> questions()
        {
            
            using (JuryModel db = new JuryModel())
            {

                return db.FormQuestions.ToList();
            }
        }
        private CompanyQuestions test(int cosencompany)
        {
            var tempform = new List<Form>();
            CompanyQuestions form;
            using (JuryModel db = new JuryModel())
            {
                foreach (var item in db.FormQuestions.ToList())
                {
                    tempform.Add(new Form
                    {
                        Question = item.Question,
                        FormId = item.Id
                    });
                }
                form = new CompanyQuestions
                {
                    Companyname = db.Company.Find(cosencompany).Name,
                    CompanyId = cosencompany,
                    Forms = tempform
                };
                return form;
            }
           
        }
    }
}