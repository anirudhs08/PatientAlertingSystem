using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace PatientRegistrationandDischarge
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string DischargePatient(string patientId)
        {
            string flag;
            int patientid = int.Parse(patientId);
            const string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=PatientDB;Integrated Security=True";

            const string strReg = "DELETE FROM PatientDataTable WHERE PatientID = @patientid";
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand(strReg, con);
            cmd.Parameters.AddWithValue("@patientid", patientid);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();//For inserting data....
                flag = "true";
            }
            catch (Exception )
            {
                flag = "false";
                throw new Exception("The Patient ID not found in the database");
               
            }
            finally
            {
                
                con.Close();
               
            }
            return flag;

        }

        public string RegisterPatient(string inputString)
        {
            string  flag;
            const string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=PatientDB;Integrated Security=True";

            const string strReg = "Insert into PatientDataTable Values(@id, @name,@bloodgroup,@Address, @Contact,@BedNo, @Doctor,@Diagnosis)";
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand(strReg, con);
            PatientDetails patientdetails = new PatientDetails();
            try
            {
                patientdetails = JsonConvert.DeserializeObject<PatientDetails>(inputString);
               
            } catch(Exception ex )
            {
                flag = ex.Message.ToString();
                throw new Exception("Cannot Convert the input string to PatientDetails");
            }
            

            cmd.Parameters.AddWithValue("@id", patientdetails.PatientID);
            cmd.Parameters.AddWithValue("@name", patientdetails.PatientName);
            cmd.Parameters.AddWithValue("@bloodgroup", patientdetails.BloodGroup);
            cmd.Parameters.AddWithValue("@Address", patientdetails.Address);
            cmd.Parameters.AddWithValue("@contact", patientdetails.Contact);
            cmd.Parameters.AddWithValue("@Bedno", patientdetails.BedNo);
            cmd.Parameters.AddWithValue("@Doctor", patientdetails.Doctor);
            cmd.Parameters.AddWithValue("@Diagnosis", patientdetails.Diagnosis);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();//For inserting data....
                flag = "Successfully saved";
            }
            catch (Exception ex )
            {
                throw ex;
                flag = "Could not saved";
            }
            finally
            {
                con.Close();
            }
            return flag;
        }

        public List<PatientDetails> SelectAllPatient()
        {
            const string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=PatientDB;Integrated Security=True";
            //int patientid = int.Parse(patientId);
            SqlConnection con = new SqlConnection(strCon);
           
            SqlCommand cmd= new SqlCommand("Select * from PatientDataTable ", con);
            //SqlDataReader reader = command.ExecuteReader();

            List<PatientDetails> patients = new List<PatientDetails>();
            SqlDataReader reader;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PatientDetails patient = new PatientDetails();
                    patient.PatientID = Convert.ToInt32(reader["PatientID"]);
                    patient.PatientName = reader["PatientName"].ToString();
                    patient.BloodGroup = reader["BloodGroup"].ToString();
                    patient.Address = reader["Address"].ToString();
                    patient.Contact = Convert.ToInt32(reader["Contact"].ToString());
                    patient.BedNo = Convert.ToInt32(reader["BedNo"].ToString());
                    patient.Doctor = reader["Doctor"].ToString();
                    patient.Diagnosis = reader["Diagnosis"].ToString();
                    patients.Add(patient);
                                      
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();
            }
            return patients;

        }


      
        string IService1.SelectPatient(string patientId)
        {

            const string strCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=PatientDB;Integrated Security=True";
            int patientid = int.Parse(patientId);
            SqlConnection conn = new SqlConnection(strCon);
            try
            {

                conn.Open();

                SqlCommand command = new SqlCommand("Select PatientID from PatientDataTable where PatientID = @patientid ", conn);

                command.Parameters.AddWithValue("@patientid", patientid);
                int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return "false";
                    }
                    else
                        return "true";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                conn.Close();
            }
        }
    }

   
}
