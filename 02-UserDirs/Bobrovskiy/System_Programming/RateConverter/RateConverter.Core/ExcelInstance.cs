using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace RateConverter.Core
{
    public class ExcelApp
    {
        private static ExcelApp instance = null;

        private static object sync = new object();

        public AppDomain ExcelDomain
        {
            get; set;
        }

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
                LogManager.Instance.PutMessage("ExcelApp.CreateWorkSheet:> Error: Worksheet could not be created.");
            }
        }

        public void FillHead()
        {
            string[] name = { "Банк", "Валюта", "Дата", "Курс" };

            for (int i = 0; i < name.Length; i++)
            {
                aRange = ws.get_Range("A1","D1");

                aRange.GetType().InvokeMember("Value", 
                    BindingFlags.SetProperty, 
                    null, 
                    aRange, 
                    new object[] { name });
            }
        }

        public void Write (List<RateItem> items, int rowIndex)
        {
            for (int i = 0; i < items.Count; i++)
            {
                aRange = ws.get_Range("A" + rowIndex, "D" + rowIndex);

                string[] name = { items[i].Bank.ToString(), 
                                  items[i].Currency, 
                                  items[i].Date.ToShortDateString(), 
                                  items[i].Value.ToString() };

                aRange.GetType().InvokeMember("Value", 
                    BindingFlags.SetProperty, 
                    null, 
                    aRange,
                    new object[] { name });
           }
        }
    }
}
