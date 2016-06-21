using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaludOpenEHR.Controllers
{

    public class PatientListController : Controller
    {
        // GET: PatientList
        public ActionResult Index()
        {
            var client = new RestClient(Session["Client"].ToString());
            var request = new RestRequest("rest/patientList");
            request.AddParameter("format", "xml");
            request.AddHeader("Authorization", "Bearer " + Session["Token"].ToString());
            IRestResponse<Models.PatientList> response = client.Execute<Models.PatientList>(request);
            return View(new Models.PatientListModel { patientList = response.Data });         
        }

        public ActionResult LogOff()
        {
            Session["Token"] = null;
            Session["organization"] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}