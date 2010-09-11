using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace RateConverter.Core
{
    public class ExcelApp
    {
        private static ExcelApp instance = null;

        private static object sync = new object();

        public static ExcelApp Instance
        {
            get
            {
                lock (sync)
                {
                    if (instance == null)
                    {
                        instance = new ExcelApp();
                    }
                    return instance;
                }
            }
        }


        private Microsoft.Office.Interop.Excel.Application excelApp;
        private Range aRange;
        private Workbook wb;
        private Worksheet ws;
        Object[] args;

        private ExcelApp ()
        {
            this.excelApp = new Microsoft.Office.Interop.Excel.Application();
        }
        
        public void CreateWorkbook()
        {
            excelApp.Visible = true;
            wb = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            CreateWorkSheet();
        }

        public void CreateWorkSheet()
        {
            ws = (Worksheet)wb.Worksheets[1];
            if (ws == null)
            {
                Console.WriteLine("Worksheet could not be created.");
            }
        }

        public void FillHead()
        {
            string[] name = { "Rate", "Bank", "Date", "Value" };

            for (int i = 0; i < name.Length; i++)
            {
                aRange = ws.get_Range((char)((int)'A' + i) + "1");
                aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, new object[] { name[i] });
            }
        }

        public void Write (List<RateItem> items )
        {
            aRange = ws.get_Range("B1", "B4");

            if (aRange == null)
            {
                Console.WriteLine("Error");
            }
            
            for (int i =0; i < 4; i++)
            {
                args = new Object [1];
                args[0] = (Object)items[i];

                aRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, aRange, args);
            }
        }
    }
}
