using System;

namespace RandomDoubleGenerator
{
    static public class RandomDoubleGenerator
    {
        static public  double GenerateRandomDouble(double minVal, double maxVal)
        {
            Random random = new Random();
            return random.NextDouble() * (maxVal - minVal) + minVal;
        }
    }
}
