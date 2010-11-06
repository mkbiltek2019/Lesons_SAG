using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParrotToPythonConverter
{
    public class ParrotToPythonConverter : IParrotToPythonConverter
    {
        const double conversionCoefficient = 38;

        public double ConvertParrotsToPythons(double parrots)
        {
            return parrots / conversionCoefficient;
        }

        public double ConvertPythonsToParrots(double pythons)
        {
            return pythons * conversionCoefficient;
        }
    }
}
