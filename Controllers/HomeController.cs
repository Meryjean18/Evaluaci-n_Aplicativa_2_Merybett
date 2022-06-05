using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using DapperMerybettAvila.Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;


namespace DapperMerybettAvila.Controllers
{
    public class HomeController : Controller
    {
        private string connection = "Server=Meryjean18; Database=Tienda; Integrated Security = true";
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
    }
}