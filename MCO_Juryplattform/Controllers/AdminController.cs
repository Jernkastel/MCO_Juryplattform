using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCO_Juryplattform.Controllers
{
    public class AdminController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult AdminCompany()
        {
            return View();
        }
        [Authorize]
        public ActionResult AdminQuestions()
        {
            return View();
        }
        [Authorize]
        public ActionResult AdminForm()
        {
            return View();
        }
    }
}