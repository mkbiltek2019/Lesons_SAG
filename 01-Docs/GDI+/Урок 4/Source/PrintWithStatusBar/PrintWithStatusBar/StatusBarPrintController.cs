//
// StatusBarPrintController.cs
//
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrintWithStatusBar
{
    class StatusBarPrintController : StandardPrintController
    {
        StatusBarPanel statpanel;
        int iPageNumber;
        string strSaveText;

        public StatusBarPrintController(StatusBarPanel sbp): base()
        {
            statpanel = sbp;
        }

        public override void OnStartPrint(PrintDocument prndoc,
                                            PrintEventArgs pea)
        {
            strSaveText = statpanel.Text;
            statpanel.Text = "Starting printing";
            iPageNumber = 1;
            base.OnStartPrint(prndoc, pea);
        }

        public override Graphics OnStartPage(PrintDocument prndoc,
                                                PrintPageEventArgs ppea)
        {
            statpanel.Text = "Printing page " + iPageNumber++;
            return base.OnStartPage(prndoc, ppea);
        }
        public override void OnEndPage(PrintDocument prndoc,
                                        PrintPageEventArgs ppea)
        {
            base.OnEndPage(prndoc, ppea);
        }

        public override void OnEndPrint(PrintDocument prndoc,
                                        PrintEventArgs pea)
        {
            statpanel.Text = strSaveText;
            base.OnEndPrint(prndoc, pea);
        }
    }
}
