using RestSharp;
using SaludOpenEHR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaludOpenEHR.Controllers
{

    public class VitalSignsController : Controller
    {
        // GET: VitalSigns
        public ActionResult Index(string uid, string firstName, string lastName, long dob, string idCode, string idType, string organizationId, string sex)
        {
            var client = new RestClient(Session["Client"].ToString());

            var request = new RestRequest("rest/ehrs/subjectUid/" + uid);
            request.AddParameter("format", "xml");
            request.AddHeader("Authorization", "Bearer " + Session["Token"].ToString());
            IRestResponse<Models.PatientEhr> response = client.Execute<Models.PatientEhr>(request);

            request = new RestRequest("rest/queries/" + "7e604d8d-b31d-4d50-bbfb-b60706fe0699" + "/execute");
            request.AddParameter("format", "xml");
            request.AddParameter("type", "datavalue");
            request.AddParameter("ehrUid", response.Data.uid);
            request.AddParameter("organizationUid", response.Data.organizationUid);
            request.AddParameter("retrieveData", true);
            request.AddParameter("group", "path");
            request.AddHeader("Authorization", "Bearer " + Session["Token"].ToString());
            IRestResponse<Models.Entry> res = client.Execute<Models.Entry>(request);
            PatientList.Patient patient = new PatientList.Patient { uid = uid, firstName = firstName, lastName = lastName, dob = dob, idCode = idCode, idType = idType, organizationUid = organizationId, sex = sex };
            return View(new Models.VitalSignsModel { entry = res.Data, patient = patient });
        }
    }
}