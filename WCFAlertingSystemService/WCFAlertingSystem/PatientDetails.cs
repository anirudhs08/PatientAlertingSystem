using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFAlertingSystem
{
    [DataContract]
    public class PatientDetails
    {
        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public string PatientName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int Contact { get; set; }
        [DataMember]
        public int BedNo { get; set; }
        [DataMember]
        public string BloodGroup { get; set; }
        [DataMember]
        public string Diagnosis { get; set; }
        [DataMember]
        public string Doctor { get; set; }
    }
}