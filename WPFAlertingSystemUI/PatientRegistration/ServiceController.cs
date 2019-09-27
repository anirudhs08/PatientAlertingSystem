using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistration
{
    class ServiceController
    {
        public string PatientBedNo { get; set; }
        public PatientRegistration.PatientRegistrationDischarge.PatientDetails[] Load_data()
        {

            PatientRegistrationDischarge.Service1Client PatientRegisterDischarge = new PatientRegistrationDischarge.Service1Client();
            var result = PatientRegisterDischarge.SelectAllPatient();
           
            return result;
        }

        public string DeletePatient(string patientId)
        {
           
            PatientRegistrationDischarge.Service1Client PatientRegisterDischarge = new PatientRegistrationDischarge.Service1Client();
            PatientRegisterDischarge.DischargePatient(patientId);


           
            return "Successful";
        }

    }

 

}

