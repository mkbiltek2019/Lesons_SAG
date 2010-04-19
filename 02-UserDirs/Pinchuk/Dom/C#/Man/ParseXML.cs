using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Man
{
    class ParseXML
    {
        static public void CreateXML(Man man)
        {
            XmlTextWriter writer = null;
            writer =new XmlTextWriter("Man.xml",System.Text.Encoding.Unicode);
            writer.Formatting= Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Man");
            
            for (int i = 0; i < man.ListStudent.Count; i++)
            {
                writer.WriteStartElement("Student");
                writer.WriteElementString("Name",man.ListStudent[i].Name );
                writer.WriteElementString("LastName", man.ListStudent[i].LastName);
                writer.WriteElementString("AverageBall", man.ListStudent[i].AverageBall);
                writer.WriteElementString("YearBirth", man.ListStudent[i].YearBirth);
                writer.WriteEndElement();
            }

            writer.WriteStartElement("School");
            for (int i = 0; i < man.ListStudent.Count; i++)
            {
                writer.WriteStartElement("Teacher");
                
                writer.WriteElementString("Name", man.ListTeacher[i].Name);
                writer.WriteElementString("LastName", man.ListTeacher[i].LastName);
                writer.WriteElementString("Salary", man.ListTeacher[i].Salary);
                writer.WriteElementString("Shool", man.ListTeacher[i].NameShool);
                writer.WriteEndElement();
            }
            
            
            for (int i = 0; i < man.ListStudent.Count; i++)
            {
                writer.WriteStartElement("Accountant");

                writer.WriteElementString("Name", man.ListAccountant[i].Name);
                writer.WriteElementString("LastName", man.ListAccountant[i].LastName);
                writer.WriteElementString("Salary", man.ListAccountant[i].Salary);
                writer.WriteElementString("Shool", man.ListAccountant[i].NameShool);
                writer.WriteEndElement();
            }
            
            writer.WriteEndElement();
            writer.WriteEndElement();

            if (writer != null)
                writer.Close();
            Print.Proces("XML Parse");
        }
    }
}
