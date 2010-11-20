using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Net;

namespace Client_WithSecurity
{
    
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.SamplesClient proxy = new Client_WithSecurity.ServiceReference1.SamplesClient("netTcp");
            
            //proxy.ClientCredentials.Windows.ClientCredential = new NetworkCredential(@"MICROSOF-6A33BE\peter",
            //                                                                            "123");
            
            try
            {
                Console.WriteLine(proxy.GetMemberCode());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine(proxy.GetPublicCode());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine(proxy.GetSecretCode());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
           
        }
    }
}
