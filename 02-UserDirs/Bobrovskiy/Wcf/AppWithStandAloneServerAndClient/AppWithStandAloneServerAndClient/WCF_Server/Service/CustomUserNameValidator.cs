using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace AppWithStandAloneServerAndClient.WCF_Server.Service
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        private const string validationError = "Username or Password are Incorrect";
        // This method validates users. It allows in two users, test1 and test2 
        // with passwords 1tset and 2tset respectively.
        // This code is for illustration purposes only and 
        // MUST NOT be used in a production environment becuase it is NOT secure.	
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
              //  throw new ArgumentNullException();
                throw new FaultException<ServiceFault>(new ServiceFault(validationError));
            }

            if (!(userName == "test" && password == "test") && !(userName == "test1" && password == "test1"))
            {
               // throw new SecurityTokenException("Unknown Username or Incorrect Password");
                throw new FaultException<ServiceFault>(new ServiceFault(validationError));
            }
        }
    }
}
