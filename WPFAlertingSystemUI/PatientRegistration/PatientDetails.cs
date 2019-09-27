using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PatientRegistration
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

        public string runService(object patient)
        {
            var inputString = JsonConvert.SerializeObject(patient);
            ServiceReference2.Service1Client service1Client = new ServiceReference2.Service1Client();
            service1Client.RegisterPatient(inputString);
            Console.WriteLine("Successfull");
            return "ter";

        }
        
    }
}
