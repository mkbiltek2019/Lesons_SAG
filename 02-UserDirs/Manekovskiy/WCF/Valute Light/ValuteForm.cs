using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.Remoting;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace Valute_Light
{
    public partial class ValuteForm : Form
    {
        //кількість валют
        private const int valuteNumber = 29;
        
        //Адреса скрипта НБУ
        private string siteURL = "http://www.bank.gov.ua/Fin_ryn/OF_KURS/Currency/FindByDate.aspx";
        
        //массив кількості одиниць для кожної валюти
        private string[] valuteAmount = 
            { "100", "100", "100", "10", "100", "100", "100", "100", "100", 
              "100", "100", "100", "100", "100", "100", "100", "10", "100", "100", 
              "100", "100", "100", "100", "100", "10", "100", "100", "100", "100", 
              "10000", "1000", "100", "100", "100", "100", "100", "1000"};
        //массив назв валют
        private string[] valutes = 
            { "австралійських доларів", "азербайджанських манатів", "англійських фунтів стерлінгів", 
              "білоруських рублів", "датських крон", "доларів США", "естонських крон", 
              "євро", "ісландських крон", "казахстанських тенге", "канадських доларів", 
              "латвійських латів", "литовських літів", "молдовських леїв", 
              "норвезьких крон", "польських злотих", "російських рублів", 
              "сінгапурських доларів", "словацьких крон", "СПЗ", "турецьких лір",
              "туркменських манатів", "угорських форинтів", "узбецьких сумів", "чеських крон",
              "шведських крон", "швейцарських франків", "юанів женьміньбі(Китай)", "японських єн"};
        //массиви валютних кодів
        //цифрові коди
        private string[] intValuteIndexes = 
            { "036", "031", "826", "974", "208", "840", "233", "978", "352",
              "398", "124", "428", "440", "498", "578", "985", "643", "702", 
              "703", "960", "792", "795", "348", "860", "203", "752", "756", 
              "156", "392" };
        //стрічкові коди
        private string[] strValuteIndexes = 
            { "AUD", "AZM", "GBP", "BYR", "DKK", "USD", "EEK", "EUR", "ISK", 
              "KZT", "CAD", "LVL", "LTL", "MDL", "NOK", "PLN", "RUB", "SGD", 
              "SKK", "XDR", "TRL", "TMM", "HUF", "UZS", "CZK", "SEK", "CHF", 
              "CNY", "JPY" };

        //змінні для роботи з датами
        private static DateTime today = DateTime.Now;        //сегодня
        private static DateTime tomorrow = today.AddDays(1); //завтра 
        
        //масиви курсів валют
        private double[] todayCurrency = new double[valuteNumber];
        private double[] tomorrowCurrency = new double[valuteNumber];
        
        //флаг доступності курсів в масивах
        private bool todayCurrencyAvailable = false;
        private bool tomorrowCurrencyAvailable = false;
        
        //конструктор головної форми
        public ValuteForm()
        {
            InitializeComponent();
            linkLabel.Links[0].LinkData = "www.bank.gov.ua";
            radioToday.Text += string.Format("({0}.{1}.{2})", today.Day, today.Month, today.Year);
            radioTomorrow.Text += string.Format("({0}.{1}.{2})", tomorrow.Day, tomorrow.Month, tomorrow.Year);
            //инициализация таблицы курсов на сегодня
            backgroundWorker.DoWork +=
                new DoWorkEventHandler(BackgroundWorkerDoWork);
            backgroundWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(BackgroundWorkerRunWorkerCompleted);
            RefillCurrencyTable(today);
        }

        //робить неактивними/активними деякі компоненти на головній формі
        private void GrayControls(bool hide)
        {
            if (hide)
            {
                statusStrip.Items["toolStripStatusLabel"].Visible = true;
                radioToday.Enabled = false;
                radioTomorrow.Enabled = false;
                toolbar.Enabled = false;
                //mainMenu.Enabled = false;
                //todayTomorrowCurrencyTable.Enabled = false;
            }
            else
            {
                statusStrip.Items["toolStripStatusLabel"].Visible = false;
                radioToday.Enabled = true;
                radioTomorrow.Enabled = true;
                toolbar.Enabled = true;
               //mainMenu.Enabled = true;
               //todayTomorrowCurrencyTable.Enabled = true;
            }
        }

        //Обновляет информацию в таблице курсов
        private void RefillCurrencyTable(DateTime date)
        {
            todayTomorrowCurrencyTable.RowCount = 1;
            for (int i = 0; i < valuteNumber; i++)
                todayTomorrowCurrencyTable.Rows.Add(
                    intValuteIndexes[i],
                    strValuteIndexes[i],
                    valuteAmount[i],
                    valutes[i],
                    Currency(date, i));
        }
        
        //возвращает курс валюты по порядковому номеру(valuteIndex) и дате(date)
        //используется только для получения сегодняшнего/завтрашнего курса
        private double Currency(DateTime date, int valuteIndex)
        {
            if (date == today)
                if (todayCurrencyAvailable)
                    return Convert.ToDouble(todayCurrency[valuteIndex]);
            if (date == tomorrow)
                if (tomorrowCurrencyAvailable)
                    return Convert.ToDouble(tomorrowCurrency[valuteIndex]);
            return 0;
        }

        //експрес розрахунок 
        //обробляється зміна radiotoday, radioTomorrow и exprExchValutePicker
        private void AmountOrDateChanged(object sender, EventArgs e)
        {
            double amount = 0;          //к-во валюты
            double exchangeResult = 0;  //результат экспресс расчета

            if (double.TryParse(exprExchValuteAmount.Text, out amount))
            {
                if (radioToday.Checked)
                    if (exprExchValutePicker.SelectedIndex >= 0)
                        exchangeResult = (amount * Currency(today, exprExchValutePicker.SelectedIndex) 
                            / Convert.ToDouble(valuteAmount[exprExchValutePicker.SelectedIndex]));
                if(radioTomorrow.Checked)
                    if (exprExchValutePicker.SelectedIndex >= 0)
                        exchangeResult = (amount * Currency(tomorrow, exprExchValutePicker.SelectedIndex))
                            / Convert.ToDouble(valuteAmount[exprExchValutePicker.SelectedIndex]);
            }
            exprExchValuteResult.Text = Convert.ToString(exchangeResult);
        }

        //обработчик події OnCheckedChanged объектов radioToday и radioTomorrow
        private void RequestedDateChanged(object sender, EventArgs e)
        {
            if (sender == radioToday)
                RefillCurrencyTable(today);    
            else
                RefillCurrencyTable(tomorrow);
            AmountOrDateChanged(sender, null);
        }

        //формування дати у форматі дд.мм.рррр
        private string DateToString(DateTime date)
        {
            if (date.Day < 10)
                if (date.Month < 10)
                    return string.Format("0{0}.0{1}.{2}", date.Day, date.Month, date.Year);
                else
                    return string.Format("0{0}.{1}.{2}", date.Day, date.Month, date.Year);
            else
                if (date.Month < 10)
                    return string.Format("{0}.0{1}.{2}", date.Day, date.Month, date.Year);
                else
                    return string.Format("{0}.{1}.{2}", date.Day, date.Month, date.Year);
        }

        //завантаження та обробка сторінки з таблицею курсів
        private bool DownloadAndParseCurrencyPage(DateTime date)
        {
            System.Net.CookieContainer cookies = new System.Net.CookieContainer();
            //отримання __VIEWSTATE зі сторінки
            string responseData = GetUrlContent(siteURL, null, ref cookies, true);
            if (responseData == string.Empty)
            {
                GrayControls(false);
                return false;
            }
            
            //извлекаем вьюстейт та створюємо запит
            string viewState = ExtractViewState(responseData);
            
            //формування стрічки параметрів
            string req = String.Format(
                @"curr_gr={0}&Text1={1}&__VIEWSTATE={2}",
                System.Web.HttpUtility.UrlEncode("Gr1"),
                System.Web.HttpUtility.UrlEncode(DateToString(date)),
                viewState);
            //стрічка параметрів - в массив байт
            byte[] buffer = System.Text.Encoding.GetEncoding(1251).GetBytes(req);
            
            //отримуємо стрінку з курсом на дату date
            string response = GetUrlContent(siteURL, buffer, ref cookies, false);
            if (response == string.Empty) //перевірка на відповідь нульової довжини
            {
                GrayControls(false);
                return false;
            }
            else //блок виконується якщо отримана "допустима відповідь"
            {
                using (StreamWriter writer = new StreamWriter(@"temp.tmp", false, System.Text.Encoding.GetEncoding(1251)))
                {
                    writer.WriteLine(response); //збереження "відповіді" у тимчасовий файл  
                }
                
                //збереження поточних регіональних налаштувань
                System.Globalization.CultureInfo oldCultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                //встановлення нейтральных регіональних налаштувань
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("");
                
                int valuteIndex = 0; //счетчик валюти
                string line = "";    //стрічка яку отримує TextReader з тимчасового файла
                int lastIdx = 0;     //вик. при аналізі стрічки   
                double curr;         //"курс" отриманий зі стрічки
                
                TextReader reader = new StreamReader("temp.tmp", Encoding.UTF8);
                while (valuteIndex < 29 && line !=null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        lastIdx = line.LastIndexOf("</td>");
                        if (lastIdx >= 0)
                            line = line.Remove(lastIdx);
                        lastIdx = line.LastIndexOf(">");
                        if (lastIdx >= 0)
                        {
                            line = line.Substring(lastIdx + 1);
                            if (Double.TryParse(line, out curr))
                            {
                                if (date == today)
                                   todayCurrency[valuteIndex] = curr;
                                else
                                    tomorrowCurrency[valuteIndex] = curr;
                                valuteIndex++;
                            }
                        }
                    }
                }
                reader.Close();
                System.Threading.Thread.CurrentThread.CurrentCulture = oldCultureInfo;
            }
            return true;
        }

        //розкодування __VIEWSTATE
        static private string ExtractViewState(string content)
        {
            System.Text.RegularExpressions.Regex _regex =
                new Regex(@"<input[\s\S]+?name=""__VIEWSTATE""[\s\S]+?value=""(?<value>[\s\S]+?)\""[\s\S]*?/>",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);
            System.Text.RegularExpressions.Match _match = _regex.Match(content);
            return System.Web.HttpUtility.UrlEncodeUnicode(_match.Success ? _match.Groups["value"].Value : string.Empty);
        }
        
        //отримує зміст сторінки - створює запит - отримує відповідь у string
        static private string GetUrlContent(string url, byte[] paramString, ref CookieContainer cooks, bool useGet)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322; .NET CLR 2.0.40607)";
            req.CookieContainer = cooks;
            if (!useGet)
            {
                req.Method = "POST";
                // укажем серверу, что мы будем передавать параметры
                req.ContentType = "application/x-www-form-urlencoded";
                // добавим наши параметры в запрос
                using (Stream reqst = req.GetRequestStream())
                {
                    reqst.Write(paramString, 0, paramString.Length);
                }
            }

            // отправляем запрос, получаем ответ
            string response;
            try
            {
                using (Stream resst = ((HttpWebResponse)req.GetResponse()).GetResponseStream())
                {
                    response = new StreamReader(resst, Encoding.GetEncoding(1251)).ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Перевірте з'єднання з Інтеренет та повторіть спробу");
                return string.Empty;
            }
            return response;
        }
        
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if(todayCurrencyAvailable != true)
                if (DownloadAndParseCurrencyPage(today))
                    todayCurrencyAvailable = true;
            if (tomorrowCurrencyAvailable != true)
                if(DownloadAndParseCurrencyPage(tomorrow))
                    tomorrowCurrencyAvailable = true;
        }
              
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                string msg = String.Format("Помилка: {0}", e.Error.Message);
                MessageBox.Show(msg);
            }
            else
            {
                if (radioToday.Checked == true)
                    RefillCurrencyTable(today);
                else
                    RefillCurrencyTable(tomorrow);
            }
            GrayControls(false);    
        }

        //відкриває сайт НБУ, браузером "по-замовчуванню" 
        private void linkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.bank.gov.ua");
        }

        //запуск backgroundWorker'a
        private void RefreshClick(object sender, EventArgs e)
        {
            GrayControls(true);
            backgroundWorker.RunWorkerAsync();
        }

        //Про...
        private void ShowAboutBox(object sender, EventArgs e)
        {
            char retKey = Convert.ToChar(Keys.Return);
            MessageBox.Show("Інформаційно - довідкова система \"Курси валют\"" + retKey + retKey +
                            "Автор: " + retKey +
                            "студент другого курсу ФПМ і КІС " + retKey +
                            "група ПМ - 23 " + retKey +
                            "Манековський Олександр Сергійович", 
                            "Інформація", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
        }
        
        //збереження інф. в XML
        private void ExportXML(object sender, CancelEventArgs e)
        {
            XmlTextWriter writer = new XmlTextWriter(exportFileDialog.FileName, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();
            writer.WriteStartElement("CurrencyTable");
            for (int i = 0; i < valuteNumber; i++)
            {
                writer.WriteStartElement("valute");
                writer.WriteAttributeString("index", intValuteIndexes[i]);
                writer.WriteAttributeString("strindex", strValuteIndexes[i]);
                writer.WriteValue(todayTomorrowCurrencyTable.Rows[i].Cells[4].Value.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndDocument();
            writer.Close();
        }
        
        //завантаження інф. з XML
        private void ImportXML(object sender, CancelEventArgs e)
        {
            todayTomorrowCurrencyTable.RowCount = 1;
            //double currency;
            int i = 0;
            TextReader r = new StreamReader(importFileDialog.FileName, Encoding.UTF8);
            XmlTextReader reader = new XmlTextReader(r);
            reader.ReadToFollowing("valute");
            while(reader.Read())
                if (reader.NodeType == XmlNodeType.Text)
                {
                    //currency = reader.ReadElementContentAsDouble();
                    todayTomorrowCurrencyTable.Rows.Add(
                        intValuteIndexes[i],
                        strValuteIndexes[i],
                        valuteAmount[i],
                        valutes[i],
                        reader.Value);
                    i++;
                }
            reader.Close();
            r.Close();
        }
        
        //Експорт в XML
        private void FileExportMenuItemClick(object sender, EventArgs e)
        {
            exportFileDialog.ShowDialog();
        }

        //Імпорт в XML
        private void FileImportMenuItemClick(object sender, EventArgs e)
        {
            importFileDialog.ShowDialog();
        }

        //Друк
        private void FilePrintMenuItemClick(object sender, EventArgs e)
        {
            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK)
                printDocument.Print();
        }
        
        //Вихід
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //формування сторінки на друк
        private void PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font printFont = new Font("Courier New", 10, FontStyle.Regular);
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            e.Graphics.DrawString("Цифровий код  Літерний код  Кількість одиниць  Назва валюти                   Курс", printFont, Brushes.Black,10,20);
            e.Graphics.DrawString("36            AUD           100                австралійських доларів         " + todayTomorrowCurrencyTable.Rows[0].Cells[4].Value,printFont,Brushes.Black, 10, 25);
            e.Graphics.DrawString("31            AZM           100                азербайджанських манатів       " + todayTomorrowCurrencyTable.Rows[1].Cells[4].Value,printFont,Brushes.Black, 10, 30);
            e.Graphics.DrawString("826           GBP           100                англійських фунтів стерлінгів  " + todayTomorrowCurrencyTable.Rows[2].Cells[4].Value,printFont,Brushes.Black, 10, 35);
            e.Graphics.DrawString("974           BYR           10                 білоруських рублів             " + todayTomorrowCurrencyTable.Rows[3].Cells[4].Value,printFont,Brushes.Black, 10, 40);
            e.Graphics.DrawString("208           DKK           100                датських крон                  " + todayTomorrowCurrencyTable.Rows[4].Cells[4].Value,printFont,Brushes.Black, 10, 45);
            e.Graphics.DrawString("840           USD           100                доларів США                    " + todayTomorrowCurrencyTable.Rows[5].Cells[4].Value,printFont,Brushes.Black, 10, 50);
            e.Graphics.DrawString("233           EEK           100                естонських крон                " + todayTomorrowCurrencyTable.Rows[6].Cells[4].Value,printFont,Brushes.Black, 10, 55);
            e.Graphics.DrawString("978           EUR           100                ЄВРО                           " + todayTomorrowCurrencyTable.Rows[7].Cells[4].Value,printFont,Brushes.Black, 10, 60);
            e.Graphics.DrawString("352           ISK           100                ісландських крон               " + todayTomorrowCurrencyTable.Rows[8].Cells[4].Value,printFont,Brushes.Black, 10, 65);
            e.Graphics.DrawString("398           KZT           100                казахстанських тенге           " + todayTomorrowCurrencyTable.Rows[9].Cells[4].Value,printFont,Brushes.Black, 10, 70);
            e.Graphics.DrawString("124           CAD           100                канадських доларів             " + todayTomorrowCurrencyTable.Rows[10].Cells[4].Value,printFont,Brushes.Black, 10, 75);
            e.Graphics.DrawString("428           LVL           100                латвійських латів              " + todayTomorrowCurrencyTable.Rows[11].Cells[4].Value,printFont,Brushes.Black, 10, 80);
            e.Graphics.DrawString("440           LTL           100                литовських літів               " + todayTomorrowCurrencyTable.Rows[12].Cells[4].Value,printFont,Brushes.Black, 10, 85);
            e.Graphics.DrawString("498           MDL           100                молдовських леїв               " + todayTomorrowCurrencyTable.Rows[13].Cells[4].Value,printFont,Brushes.Black, 10, 90);
            e.Graphics.DrawString("578           NOK           100                норвезьких крон                " + todayTomorrowCurrencyTable.Rows[14].Cells[4].Value,printFont,Brushes.Black, 10, 95);
            e.Graphics.DrawString("985           PLN           100                польських злотих               " + todayTomorrowCurrencyTable.Rows[15].Cells[4].Value,printFont,Brushes.Black, 10, 100);
            e.Graphics.DrawString("643           RUB           10                 російських рублів              " + todayTomorrowCurrencyTable.Rows[16].Cells[4].Value,printFont,Brushes.Black, 10, 105);
            e.Graphics.DrawString("702           SGD           100                сінгапурських доларів          " + todayTomorrowCurrencyTable.Rows[17].Cells[4].Value,printFont,Brushes.Black, 10, 110);
            e.Graphics.DrawString("703           SKK           100                словацьких крон                " + todayTomorrowCurrencyTable.Rows[18].Cells[4].Value, printFont, Brushes.Black, 10, 115);
            e.Graphics.DrawString("960           XDR           100                СПЗ                            " + todayTomorrowCurrencyTable.Rows[19].Cells[4].Value, printFont, Brushes.Black, 10, 120);
            e.Graphics.DrawString("792           TRL           100                турецьких лір                  " + todayTomorrowCurrencyTable.Rows[20].Cells[4].Value, printFont, Brushes.Black, 10, 125);
            e.Graphics.DrawString("795           TMM           10000              туркменських манатів           " + todayTomorrowCurrencyTable.Rows[21].Cells[4].Value, printFont, Brushes.Black, 10, 130);
            e.Graphics.DrawString("348           HUF           1000               угорських форинтів             " + todayTomorrowCurrencyTable.Rows[22].Cells[4].Value, printFont, Brushes.Black, 10, 135);
            e.Graphics.DrawString("860           UZS           100                узбецьких сумів                " + todayTomorrowCurrencyTable.Rows[23].Cells[4].Value, printFont, Brushes.Black, 10, 140);
            e.Graphics.DrawString("203           CZK           100                чеських крон                   " + todayTomorrowCurrencyTable.Rows[24].Cells[4].Value, printFont, Brushes.Black, 10, 145);
            e.Graphics.DrawString("752           SEK           100                шведських крон                 " + todayTomorrowCurrencyTable.Rows[25].Cells[4].Value, printFont, Brushes.Black, 10, 150);
            e.Graphics.DrawString("756           CHF           100                швейцарських франків           " + todayTomorrowCurrencyTable.Rows[26].Cells[4].Value, printFont, Brushes.Black, 10, 155);
            e.Graphics.DrawString("156           CNY           100                юанів женьміньбі (Китай)       " + todayTomorrowCurrencyTable.Rows[27].Cells[4].Value, printFont, Brushes.Black, 10, 160);
            e.Graphics.DrawString("392           JPY           1000               японських єн                   " + todayTomorrowCurrencyTable.Rows[28].Cells[4].Value, printFont, Brushes.Black, 10, 165);

        }
    }
}