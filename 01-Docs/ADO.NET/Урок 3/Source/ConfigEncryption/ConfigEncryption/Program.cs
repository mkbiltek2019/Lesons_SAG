using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ConfigEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            ToggleConfigEncryption(@"ConfigEncryption.exe");
            Console.ReadKey(true);
        }

        static void ToggleConfigEncryption(string exeConfigName)
        {
            try
            {

                Configuration config = ConfigurationManager.
                    OpenExeConfiguration(exeConfigName);

                ConnectionStringsSection section =
                    config.GetSection("connectionStrings")
                    as ConnectionStringsSection;

                if (section.SectionInformation.IsProtected)
                {
                    section.SectionInformation.UnprotectSection();
                }
                else
                {
                    section.SectionInformation.ProtectSection(
                        "DataProtectionConfigurationProvider");
                }

                config.Save();

                Console.WriteLine("Protected={0}",
                    section.SectionInformation.IsProtected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}