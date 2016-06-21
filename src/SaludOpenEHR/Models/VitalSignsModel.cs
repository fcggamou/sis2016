using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaludOpenEHR.Models
{
    public class PatientEhr
    {
        public string uid { get; set; }
        public string organizationUid { get; set; }        
    }

    public class Entry
    {
        public string key { get; set; }
        public string Value { get; set; }
        public List<Entry> Entries { get; set; }
        public List<Map> maps { get; set; }
    }

    public class Map
    {
        public List<Entry> Entries { get; set; }
    }
    public class VitalSignsModel
    {
        public Entry entry;
        public PatientList.Patient patient;
    }
}