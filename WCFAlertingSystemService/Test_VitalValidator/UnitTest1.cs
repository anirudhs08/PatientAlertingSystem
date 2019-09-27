using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using doubleVitalValidator;

namespace Test_VitalValidator
{
    [TestClass]
    public class TestTemperature
    {
        [TestMethod]
        public void Test_Temperature_OutOfRange()
        {
            TemperatureValidator temperatureValidator = new TemperatureValidator();
            int retVal = temperatureValidator.ValidateVital(97, 104, 105);
            Assert.AreEqual(retVal, 2);
        }

        [TestMethod]
        public void Test_Temperature_WithinRange_Warning()
        {
            TemperatureValidator temperatureValidator = new TemperatureValidator();
            int retVal = temperatureValidator.ValidateVital(97, 104, 103.4);
            Assert.AreEqual(retVal, 1);
        }

        [TestMethod]
        public void Test_Temperature_WithinRange_Normal()
        {
            TemperatureValidator temperatureValidator = new TemperatureValidator();
            int retVal = temperatureValidator.ValidateVital(97, 104, 99);
            Assert.AreEqual(retVal, 0);
        }
    }
    [TestClass]
    public class TestPulseRate
    {
        [TestMethod]
        public void Test_PulseRate_OutOfRange()
        {
            PulseRateValidator pulseRateValidator = new PulseRateValidator();
            int retVal = pulseRateValidator.ValidateVital(40, 220, 20);
            Assert.AreEqual(retVal, 2);
        }

        [TestMethod]
        public void Test_PulseRate_WithinRange_Warning()
        {
            PulseRateValidator pulseRateValidator = new PulseRateValidator();
            int retVal = pulseRateValidator.ValidateVital(40,220 , 200);
            Assert.AreEqual(retVal, 1);
        }

        [TestMethod]
        public void Test_PulseRate_WithinRange_Normal()
        {
            PulseRateValidator pulseRateValidator = new PulseRateValidator();
            int retVal = pulseRateValidator.ValidateVital(40, 220, 90);
            Assert.AreEqual(retVal, 0);
        }
    }
    [TestClass]
    public class TestSpo2
    {
        [TestMethod]
        public void Test_Spo2_OutOfRange()
        {
            Spo2Validator spo2Validator = new Spo2Validator();
            int retVal = spo2Validator.ValidateVital(70, 95, 50);
            Assert.AreEqual(retVal, 2);
        }

        [TestMethod]
        public void Test_Spo2_WithinRange_Warning()
        {
            Spo2Validator spo2Validator = new Spo2Validator();
            int retVal = spo2Validator.ValidateVital(70, 95, 73);
            Assert.AreEqual(retVal, 1);
        }

        [TestMethod]
        public void Test_Spo2_WithinRange_Normal()
        {
            Spo2Validator spo2Validator = new Spo2Validator();
            int retVal = spo2Validator.ValidateVital(70, 95, 100);
            Assert.AreEqual(retVal, 0);
        }
    }
}
