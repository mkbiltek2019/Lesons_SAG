using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Principal;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Service_WithSecurity
{
    [ServiceContract]
    public interface ISamples {
        [OperationContract]
        string GetSecretCode();
        [OperationContract]
        string GetMemberCode();
        [OperationContract]
        string GetPublicCode();
    }

    public class Samples : ISamples {

        //дозволяємо доступ лише учасникам групи Sample
        [PrincipalPermission(SecurityAction.Demand, Role="Sample")]
        public string GetSecretCode()
        {
            DisplaySecurityDetails();
            return "The secret code";
        }

        //дозволяємо доступ користувачам peter і jessica
        [PrincipalPermission(SecurityAction.Demand, Name = @"MICROSOF-6A33BE\peter")]
        [PrincipalPermission(SecurityAction.Demand, Name = @"MICROSOF-6A33BE\jessica")]
        public string GetMemberCode()
        {
            DisplaySecurityDetails();
            return "The member-only code";
        }

        public string GetPublicCode()
        {
            DisplaySecurityDetails();
            return "The public code";
        }

        private static void DisplaySecurityDetails() {
            Console.WriteLine("Windows Identity : " + WindowsIdentity.GetCurrent().Name);
            Console.WriteLine("Thread CurrentPrincipal Identity : " + Thread.CurrentPrincipal.Identity.Name);
            Console.WriteLine("ServiceSecurityContext Windows Identity : " + 
                               ServiceSecurityContext.Current.WindowsIdentity.Name);
            Console.WriteLine("\n\n");
        }
    }
     
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Samples));
            host.Open();
            Console.WriteLine("Enter any key...");
            Console.ReadLine();
            host.Close();
        }
    }
}
