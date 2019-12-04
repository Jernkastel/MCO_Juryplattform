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
        
        public ActionResult Index()
        {
            return View(questions());
        }
        public List<FormQuestions> questions()
        {
            
            using (JuryModel db = new JuryModel())
            {

                return db.FormQuestions.ToList();
            }
        }





        public CompanyQuestions test(int cosencompany)
        {
            var tempform = new List<Form>();
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
            }
            var form = new CompanyQuestions
            {
                CompanyId = cosencompany,
                Forms = tempform
            };
            
        return form;

        }
    }
}