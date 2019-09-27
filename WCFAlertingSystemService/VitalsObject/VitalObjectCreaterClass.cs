using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsObject
{
    public class PatientVitals
    {
        public int patientID { get; set; }
        public double spo2 { get; set; }
        public double pulserate { get; set; }
        public double temperature { get; set; }
    }
}
