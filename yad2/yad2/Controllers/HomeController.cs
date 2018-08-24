using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using yad2.Models;

namespace yad2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult Contact()
        {

           return View();
            
        }
    }
}