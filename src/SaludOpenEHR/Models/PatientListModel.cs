using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaludOpenEHR.Models
{

    public class PatientList
    {

        public Pagination pagination { get; set; }
        public List<Patient> patients { get; set; }

        public class Patient
        {
            public string uid { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public long dob { get; set; }
            public string sex { get; set; }
            public string idCode { get; set; }
            public string idType { get; set; }
            public string organizationUid { get; set; }
        }

        public class Pagination
        {
            int max { get; set; }
            int offset { get; set; }
            int nextOffset { get; set; }
            int prevOffset { get; set; }
        }
    }
    public class PatientListModel
    {
        public PatientList patientList { get; set; }
    }
}