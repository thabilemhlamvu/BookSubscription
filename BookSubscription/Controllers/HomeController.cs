using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookSubscription.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Sign In

        [HttpPost]
        public ActionResult SignIn(string emailAddress, string password)
        {
            Models.User login = DataAccess.User.GetUserForSignOn(emailAddress, password);

            if (login.emailAddress == emailAddress)
            {
                Session.Add("UserId", login.UserId);

                HttpCookie cookie = new HttpCookie("SignedIn", "true");

                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                Session.Add("Error", "Login Failed");
            }

            return View("Index");
        }

        public ActionResult SignOut()
        {
            Session.Clear();
            return RedirectToAction("SignIn", "Home");
        }

        #endregion
    }
}
