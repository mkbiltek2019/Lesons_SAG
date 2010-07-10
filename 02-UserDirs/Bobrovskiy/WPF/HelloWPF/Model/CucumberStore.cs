using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;
using System.Windows.Media;

namespace HelloWPF.Model
{
    public class CucumberStore
    {
        public static IEnumerable<Cucumber> LoadCucumbers()
        {
            string cucumberFileName = ConfigurationManager.AppSettings["CucumberStore"];
            XDocument document = XDocument.Load(cucumberFileName);
            IEnumerable<XElement> cucumberElements = document.Root.Elements("Cucumber");

            foreach (XElement cucumberElement in cucumberElements)
            {
                Cucumber cucumber = new Cucumber()
                {
                    DotsCount = Convert.ToInt32(cucumberElement.Element("DotsCount").Value),
                    PricePerDot = Convert.ToInt32(cucumberElement.Element("PricePerDot").Value),
                    Color = (Color)ColorConverter.ConvertFromString(cucumberElement.Element("Color").Value)
                };

                yield return cucumber;
            }
        }
    }
}
