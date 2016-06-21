using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SaludOpenEHR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPatients()
        {
            return View();
        }
    }
}
