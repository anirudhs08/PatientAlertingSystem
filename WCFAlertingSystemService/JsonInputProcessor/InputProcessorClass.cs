using System;
using VitalsObject;
using Newtonsoft.Json;

namespace JsonInputProcessor
{
    public class JsonInputProcessor
    {
        public string ProcessJsonInput(string _jsonString)
        {
            
            string patientAlert = "";
            try
            {
                PatientVitals parseddata = JsonConvert.DeserializeObject<PatientVitals>(_jsonString);
                
                if(parseddata.pulserate < 150)
                {
                    patientAlert += "pulse,low,";
                }
                else if (parseddata.pulserate > 200)
                {
                    patientAlert += "pulse,high,";

                }
                if (parseddata.spo2 < 70)
                {
                    patientAlert += "spo2,low,";
                }
                else if (parseddata.spo2 > 90)
                {
                    patientAlert += "spo2,high,";
                }
                if (parseddata.temperature < 97)
                {
                    patientAlert += "temperature,low";
                }
                else if (parseddata.temperature > 101)
                {
                    patientAlert += "temperature,high";
                }
                char lastCharacter = patientAlert[patientAlert.Length - 1];
                if (lastCharacter == ',')
                {
                    patientAlert = patientAlert.Substring(0, patientAlert[patientAlert.Length - 1]);
                }
                
            } catch(Exception ex)
            {
                
                Console.WriteLine(ex);
            }
            return patientAlert;
        }
    }
}
