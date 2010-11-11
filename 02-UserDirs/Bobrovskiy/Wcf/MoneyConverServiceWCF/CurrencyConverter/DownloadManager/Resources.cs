
using System.Windows.Forms;

namespace MoneyConverServiceWCF.DownloadManager
{
    public static class Resources
    {
        public static readonly string SourceName = "http://www.bank.gov.ua/Fin_ryn/OF_KURS/Currency/FindByDate.aspx";
        public static readonly string DestinationName = Application.UserAppDataPath + ".\\site.tmp";
    }
}