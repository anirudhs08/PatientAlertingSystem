using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceContract
{
    public interface IValidator
    {
        int VitalValidator(double minVal, double maxVal, double vitalVal);
    }
}
