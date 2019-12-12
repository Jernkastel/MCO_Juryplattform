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
        
        //[HttpGet]
        public ActionResult Index(/*int id*/)
        {
            return View(Viewqestionmodel(2));
        }
        
        [HttpPost]
        public ActionResult Getting(CompanyQuestions anwsers)
        {
            addresults(anwsers);
            //addsubmitvote(anwsers);
            return RedirectToAction("Index", "Company");
        }
        private void addresults(CompanyQuestions test)
        {
            using (JuryModel db = new JuryModel())
            {
                for (int i = 0; i < test.Grades.Count; i++)
                {
                    Result newResult = new Result();
                    newResult.CompanyId = test.CompanyId;
                    newResult.QuestionId = test.Grades[i].QuestionId;
                    newResult.Grade = test.Grades[i].Answer;
                db.Result.Add(newResult);
                }
                db.SaveChanges();
            }
        }
        private void addsubmitvote(CompanyQuestions test)
        {
            using (JuryModel db = new JuryModel())
            {
                VoteCheck temp = new VoteCheck();
                temp.CompanyId = test.CompanyId;
                temp.IsVoted = true;
                //temp.UserId= 

                db.VoteCheck.Add(temp);
                //db.SaveChanges();
            }
        } 
        public List<FormQuestions> questions()
        {
            
            using (JuryModel db = new JuryModel())
            {

                return db.FormQuestions.ToList();
            }
        }
        private CompanyQuestions Viewqestionmodel(int cosencompany)
        {
            var tempform = new List<Grade>();
            CompanyQuestions form;
            using (JuryModel db = new JuryModel())
            {
                foreach (var item in db.FormQuestions.ToList())
                {
                    var temp = new Grade();
                    
                    temp.Question = item.Question;
                    temp.QuestionId = item.Id;
                    tempform.Add(temp);
                }
                form = new CompanyQuestions
                {
                    Companyname = db.Company.Find(cosencompany).Name,
                    CompanyId = cosencompany,
                    Grades = tempform
                };
                return form;
            }
           
        }
    }
}