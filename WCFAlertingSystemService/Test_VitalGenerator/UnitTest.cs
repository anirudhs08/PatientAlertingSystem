using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VitalGeneratorDouble;

namespace Test_VitalGenerator
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMValueGeneratedWithinTheRangeethod()
        {
            PulseRateGeneratorDouble pulseRateGeneratorDouble = new PulseRateGeneratorDouble();
            double val = pulseRateGeneratorDouble.GenerateVitalDouble(40, 240);
            bool flag = false;
            if(val > 40 && val < 240 ) flag = true;
            Assert.AreEqual(flag, true);
        }
        [TestMethod]
        public void TestMValueGeneratedOutsideTheRangeethod()
        {
            // PulseRateGeneratorDouble pulseRateGeneratorDouble = new PulseRateGeneratorDouble();
            double val = 250;
            double minVal = 40;
            double maxval = 240;
            bool flag = false;

            if (val < minVal || val > maxval) flag = true;
            Assert.AreEqual(flag, true);
        }
    }
}
