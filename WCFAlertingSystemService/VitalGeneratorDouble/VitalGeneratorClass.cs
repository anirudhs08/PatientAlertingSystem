using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalReferenceDouble;
using RandomDoubleGenerator;


namespace VitalGeneratorDouble
{
    public class TemperatureGeneratorDouble : VitalReferenceDouble.VitalReferenceDouble
    {
        public double GenerateVitalDouble(double minVal, double maxVal)
        {
            return RandomDoubleGenerator.RandomDoubleGenerator.GenerateRandomDouble(minVal, maxVal);
        }
    }

    public class Spo2GeneratorDouble : VitalReferenceDouble.VitalReferenceDouble
    {
        public double GenerateVitalDouble(double minVal, double maxVal)
        {
            return RandomDoubleGenerator.RandomDoubleGenerator.GenerateRandomDouble(minVal, maxVal);
        }
    }

    public class PulseRateGeneratorDouble : VitalReferenceDouble.VitalReferenceDouble
    {
        public double GenerateVitalDouble(double minVal, double maxVal)
        {
            return RandomDoubleGenerator.RandomDoubleGenerator.GenerateRandomDouble(minVal, maxVal);
        }
    }
}
