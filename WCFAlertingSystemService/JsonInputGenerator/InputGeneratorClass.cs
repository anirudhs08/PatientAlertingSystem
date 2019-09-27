using Newtonsoft.Json;
using VitalsObject;
using VitalGeneratorDouble;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace JsonInputGenerator
{
    public class GenerateJsonInput
    {
        public string _jsonInputString { get; set; }
        public string GenerateJsonInputString(int currentPatientID)
        {
            PulseRateGeneratorDouble pulseRateGeneratorDouble = new PulseRateGeneratorDouble();
            Spo2GeneratorDouble spo2GeneratorDouble = new Spo2GeneratorDouble();
            TemperatureGeneratorDouble temperatureGeneratorDouble = new TemperatureGeneratorDouble();
            pulseRateGeneratorDouble._minValue = 20;
            pulseRateGeneratorDouble._maxValue = 240;
            spo2GeneratorDouble._minValue = 60;
            spo2GeneratorDouble._maxValue = 110;
            temperatureGeneratorDouble._minValue = 95;
            temperatureGeneratorDouble._maxValue = 106;

            double tempTemperature = temperatureGeneratorDouble.GenerateVitalDouble(temperatureGeneratorDouble._minValue, temperatureGeneratorDouble._maxValue);
            double tempPulseRate = pulseRateGeneratorDouble.GenerateVitalDouble(pulseRateGeneratorDouble._minValue, pulseRateGeneratorDouble._maxValue);
            double tempSpo2 = spo2GeneratorDouble.GenerateVitalDouble(spo2GeneratorDouble._minValue, spo2GeneratorDouble._maxValue);

            PatientVitals healthparameters = new PatientVitals()
            {
                
                patientID = currentPatientID,
                spo2 = tempSpo2,
                pulserate = tempPulseRate,
                temperature = tempTemperature
            };
            try
            {
                _jsonInputString = JsonConvert.SerializeObject(healthparameters);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex);
            }
            

            
            return _jsonInputString;
        }
    }
}
