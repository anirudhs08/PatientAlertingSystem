

namespace doubleVitalValidator
{
    public class TemperatureValidator : VitalReferenceDouble.VitalReferenceDouble
    {
        public int ValidateVital(double minval, double maxVal, double vitalVal)
        {
            double subMin = minval + 1.0;
            double subMax = maxVal - 1.0;
            if(vitalVal > maxVal || vitalVal < minval)
            {
                return 2;
            } else if(vitalVal > subMin && vitalVal < subMax)
            {
                return 0;
            }
            return 1;
        }
    }

    public class PulseRateValidator : VitalReferenceDouble.VitalReferenceDouble
    {
        public int ValidateVital(double minval, double maxVal, double vitalVal)
        {
            double subMin = minval + 20;
            double subMax = maxVal - 120;
            if (vitalVal > maxVal || vitalVal < minval)
            {
                return 2;
            }
            else if (vitalVal > subMin && vitalVal < subMax)
            {
                return 0;
            }
            return 1;
        }
    }

    public class Spo2Validator : VitalReferenceDouble.VitalReferenceDouble
    {
        public int ValidateVital(double minval, double maxVal, double vitalVal)
        {
            double suMin = minval + 10;
            if(vitalVal < minval)
            {
                return 2;
            } else if(vitalVal < suMin)
            {
                return 1;
            }
            return 0;
        }
    }
}
