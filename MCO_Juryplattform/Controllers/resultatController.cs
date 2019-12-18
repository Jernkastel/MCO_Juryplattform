using MCO_Juryplattform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCO_Juryplattform.Controllers
{
    public class ResultatController : Controller
    {
        // GET: resultat
        public ActionResult Index()
        {
            List<ShowResult> viewModel = new List<ShowResult>();
            using (JuryModel db = new JuryModel())
            {
                //"select CompanyId form Result whare"
                //"select CompanyId form Result whare Result.CompanyId=i"
                
               
                List<Company> allCompanys = db.Company.ToList();
                List<FormQuestions> allQuestions = db.FormQuestions.ToList();
                for (int i = 0; i < allCompanys.Count; i++)
                {
                    ShowResult foo = new ShowResult();
                    for (int j = 0; j < allQuestions.Count; j++)
                    {
                        
                        List<Result> test = db.Result.ToList().Where(result =>result.CompanyId == allCompanys[i].Id && result.QuestionId == allQuestions[j].Id).ToList();
                        if (test == null) continue;
                        if (foo.howMenyVoted == 0)
                        {
                            foo.howMenyVoted = test.Count;
                        }
                        foreach (var item in test)
                        {
                            foo.totallpoints += item.Grade;
                        }
                       
                    }
                    foo.totallpointspercentage =  100.0*foo.totallpoints / (5*allQuestions.Count*foo.howMenyVoted);

                    foo.Companyname = allCompanys[i].Name;
                    foo.Id = i;
                    viewModel.Add(foo);
                }
                //foreach (var item in cmopanyid)
                //{
                //    var allResult2 = db.Result.ToList().Where(e => e.CompanyId == item);
                //}
                //select graid form Result Where Result.CompanyId == cmtanyid[i], Result.QuestionId == QuestionId[j]
                //Where(e => e.QuestionId == parameter)
                //var test = new Result();
                //test.CompanyId
                //List< Result > name = db.Result.ToList().Where;
            }
            return View(viewModel);
            
        }
    }
}