using JsonInputGenerator;
using JsonInputProcessor;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;
using System.Threading;

namespace WCFAlertingSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
        public class Service1 : IService1
    {
        public List<PatientDetails> MonitorPatientVitals()
        {
            

            GenerateJsonInput generateJsonInput = new GenerateJsonInput();
            JsonInputProcessor.JsonInputProcessor jsonInputProcessor = new JsonInputProcessor.JsonInputProcessor();
            const string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=PatientDB;Integrated Security=True"; 

            const string strReg = "Select * from PatientDataTable";
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand(strReg, con);
            List<PatientDetails> patients = new List<PatientDetails>();
            SqlDataReader reader;
            


            try
            {
                con.Open();
                reader = cmd.ExecuteReader();//For inserting data....
                while(reader.Read())
                {
                    PatientDetails patient = new PatientDetails();
                    patient.PatientID = Convert.ToInt32(reader["PatientID"]);
                    patient.PatientName = reader["PatientName"].ToString();
                    patient.BloodGroup = reader["BloodGroup"].ToString();
                    patient.Address = reader["Address"].ToString();
                    patient.Contact = Convert.ToInt32(reader["Contact"].ToString());
                    patient.BedNo = Convert.ToInt32(reader["BedNo"].ToString());                    
                    patient.Doctor = reader["Doctor"].ToString();
                   
                    
                    string _jsonInputString = generateJsonInput.GenerateJsonInputString(patient.PatientID);
                    string patientAlert = "";
                    patientAlert = jsonInputProcessor.ProcessJsonInput(_jsonInputString);
                    
                    if(patientAlert != String.Empty)
                    {
                        patient.Diagnosis = patientAlert;
                        patients.Add(patient);
                    }

                   
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                
                con.Close();
            }
            return patients;
            

        }
    }
}
