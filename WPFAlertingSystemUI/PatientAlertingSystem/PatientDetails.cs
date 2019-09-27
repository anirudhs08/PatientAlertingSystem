using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAlertingSystem
{
    public class PatientDetails
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string Address { get; set; }
        public int Contact { get; set; }
        public int BedNo { get; set; }
        public string BloodGroup { get; set; }

        public string Diagnosis { get; set; }
        public string Doctor { get; set; }


        
    }
}
