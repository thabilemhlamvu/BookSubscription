using BookSubscription.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QorusDocs_Interview.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserId"] == null || (Session["UserId"] != null && Session["UserId"].ToString() == string.Empty))
                return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult SaveBookSubscription()
        {
            if (Session["UserId"] == null || (Session["UserId"] != null && Session["UserId"].ToString() == string.Empty))
                return RedirectToAction("Index", "Home");

            return View();
        }
        
        [HttpPost]
        public ActionResult saveBookSubscription(Book saveSubscription)
        {
            List<BookSubscription.Models.Book> list = new List<BookSubscription.Models.Book>();


            #region save contact

            foreach( var item in list)
            {
                BookSubscription.DataAccess.Books.SaveBook(item);
            }

            #endregion

            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult _BookList(string username,string password)
        {
            List<BookSubscription.Models.Book> model = new List<BookSubscription.Models.Book>();

            model = BookSubscription.DataAccess.Books.GetBookList(username,password);

            return PartialView(model);
        }
    }
}