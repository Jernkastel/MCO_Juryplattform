using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCO_Juryplattform.Controllers
{
    public class LoginController : Controller
    {
        JuryModel db = new JuryModel();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Login logg)
        {
            
            if (logg.UserName == null || logg.Password == null)
            {
                ModelState.AddModelError("", "Du måste ange användarnamn och lösenord");
                return View();
            }

            bool validUser = false;
            validUser = ValidateUser(logg.UserName, logg.Password);

            if (validUser)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(logg.UserName, false);
            }
            ModelState.AddModelError("", "Inloggningen misslyckades, vänligen försök igen");
            return View();
        }

        [Authorize]
        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Login");
        }

        private bool ValidateUser(string username, string password)
        {
            var user = from row in db.Login
                       where row.UserName.ToUpper() == username.ToUpper()
                       && row.Password == password
                       select row;

            if (user.Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}