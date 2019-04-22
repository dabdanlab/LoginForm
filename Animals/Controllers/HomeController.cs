using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Configuration;
using Animals.App_Start;
using Animals.Models;
using MongoDB.Driver;

namespace Animals.Controllers
{
    public class HomeController : Controller
    {
        private LoginContext LoginContext;

        private IMongoCollection<LoginModels> loginCollection;

        public HomeController()
        {
            LoginContext = new LoginContext();
            loginCollection = LoginContext.database.GetCollection<LoginModels>("logins");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModels login)
        {
            try
            {
                // TODO: Add insert logic here

                loginCollection.InsertOne(login);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}