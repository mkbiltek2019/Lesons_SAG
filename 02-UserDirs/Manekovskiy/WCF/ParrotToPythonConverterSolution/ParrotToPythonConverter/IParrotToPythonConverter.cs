using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParrotToPythonConverter
{
    [ServiceContract]
    public interface IParrotToPythonConverter
    {
        [OperationContract]
        double ConvertParrotsToPythons(double parrots);

        [OperationContract]
        double ConvertPythonsToParrots(double pythons);
    }
}
