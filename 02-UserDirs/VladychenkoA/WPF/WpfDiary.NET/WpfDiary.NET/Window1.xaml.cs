using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfDiary.NET
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 
    {
       //protected override void OnStartup(StartupEventArgs e)
       //{
       //    WpfSingleInstance.Make();
       //    //base.OnStartup(e);
       //    //Process process = RunningInstance();
       //    //if (process != null)
       //    //{
       //    //    MessageBox.Show("Программа уже запущена", "Ошибка", MessageBoxButton.OK);
       //    //    this.Close();
       //    //    return;
       //    //}
       //}
       //protected  void OnStartup(StartupEventArgs e) 
       //{     
       //     WpfSingleInstance.Make();

       //     base.OnStartup(e);
       //}


          

        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
 
            //Просматриваем все процессы 
            foreach (Process process in processes)
            {
                //Игнорируем текущий процесс
                if (process.Id != current.Id)
                {
                    //Проверяем, что процесс запущен из того же файла 
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Да, это и есть копия нашего приложения
                        return process;
                    }
                }
            }
            //Нет, таких же процессов не найдено
            return null;
        }   


        enum BeepFlag
        {
            MB_OK = 0, MB_ICONHAND = 0x00000010, MB_ICONQUESTION = 0x00000020, MB_ICONEXCLAMATION = 0x00000030,  MB_ICONASTERISK = 0x00000040
        }; 

        [DllImport("user32.dll")]
        public static extern int MessageBeep(uint BeepType);

        [DllImport("Kernel32.dll")]
        private static extern bool Beep(uint dwFreq, uint dwDuration);

        [DllImport("User32.dll")]
        private static extern bool MessageBeep1(BeepFlag uType);


        private int index = 0;
        private int index1 = 0;
        private int index2 = 0;
        private int index3 = 0;
        private int ok = 0;
        private int close = 0;
        private int process = 0;
        private int total = 0;

        private Task task = new Task();
        private Tasks tasks;
        private ListTask lt = new ListTask();
        private void RibbonCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void RibbonApplicationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }

        private void RibbonApplicationMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Grid2.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Star);
            Grid2.RowDefinitions[1].Height = new GridLength(900, GridUnitType.Star);
        }

        private void RibbonApplicationMenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //Task task1 = new Task();
            //lt = new ListTask(task1);
            //txtDate.Text = task1.Date;
            lt.WriteXmlFile("Tasks.xml");
            Tasks tasks = new Tasks(lt);
        }

        private void RibbonApplicationMenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Grid2.RowDefinitions[0].Height = new GridLength(900, GridUnitType.Star);
            Grid2.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Star);
        }

        private void RibbonApplicationMenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Grid2.RowDefinitions[0].Height = new GridLength(250, GridUnitType.Star);
            Grid2.RowDefinitions[1].Height = new GridLength(250, GridUnitType.Star);
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            txtDate.Text = Calendar.SelectedDate.Value.ToShortDateString();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            txtDate.Text = null;
            txtTitle.Text = null;
            txtContent.Document.Blocks.Clear();
            txtStatus.Text = null;
            txtComment.Text = null;
            MessageBeep(0x00000000);
            //Beep(150, 150);
         }

        private void buttonAppend_Click(object sender, RoutedEventArgs e)
        {
            Task task2 = new Task();
            task2.Date = txtDate.Text;
            task2.Title = txtTitle.Text;
            task2.Content =new TextRange( txtContent.Document.ContentStart,txtContent.Document.ContentEnd).Text;
            task2.Status = txtStatus.Text;
            task2.Comment = txtComment.Text;
           
            lt.Append(task2, "Tasks.xml");
            
            MessageBeep(0x00000040);
          
           Load();
           lbOk.Content = "Выполнено" + "  " + ok;
           lbPr.Content = "Выполняется" + "  " + process;
           lbCl.Content = "Отменено" + "  " + close;
           lbTo.Content = "Всего" + "  " + total;
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Microsoft.VisualBasic.Interaction.Beep();
            Load();   
            
        }

        private void Load()
        {
            ok = 0;
            close = 0;
            process = 0;
            total = 0;
            lt.TaskList.Clear();
            lt.LoadXmlFile("Tasks.xml");
            //tasks = new Tasks(lt);
            ListView.Items.Clear();
            foreach (Task task in lt.TaskList)
            {
                ListView.Items.Add(task);
                if (task.Status == "Выполнено")
                {
                    ok++;
                }
                if (task.Status == "Выполняется")
                {
                    process++;
                }
                if (task.Status == "Отменено")
                {
                    close++;
                }
                total++;
            }
            Task taskcm3 = lt.TaskList[lt.TaskList.Count - 3];
            lbcm3.Content = taskcm3.Date + "  " + taskcm3.Title + " " + taskcm3.Content;
            Task taskcm2 = lt.TaskList[lt.TaskList.Count - 2];
            lbcm2.Content = taskcm2.Date + "  " + taskcm2.Title + " " + taskcm2.Content;
            Task taskcm1 = lt.TaskList[lt.TaskList.Count - 1];
            lbcm1.Content = taskcm1.Date + "  " + taskcm1.Title + " " + taskcm1.Content;
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            ListView.Items.Clear();
        }

        private void RibbonApplicationMenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Load();
        }

       

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            task = (Task)ListView.SelectedItem;
            index = ListView.Items.IndexOf(ListView.SelectedItem);
           
            if (task != null)
            {
                txtDate.Text = task.Date;
                txtTitle.Text = task.Title;
                FlowDocument fd = new FlowDocument();
                Paragraph para = new Paragraph();
                para.Inlines.Add(new Run(task.Content));
                fd.Blocks.Add(para);
                txtContent.Document = fd;
                txtStatus.Text = task.Status;
                txtComment.Text = task.Comment;
            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            index1 = index;
            index2 = index;
            index3 = index;
            ListView.Items.RemoveAt(index);
            lt.TaskList.RemoveAt(index2);
            task = new Task();
            task.Date = txtDate.Text;
            task.Title = txtTitle.Text;
            task.Content = new TextRange(txtContent.Document.ContentStart, txtContent.Document.ContentEnd).Text;
            task.Status = txtStatus.Text;
            task.Comment = txtComment.Text;
            
            ListView.Items.Insert(index1, task);
            lt.TaskList.Insert(index3, task);
            lt.WriteXmlFile("Tasks.xml");
            Load();
            MessageBeep(0x00000030);
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtStatus.Text = comboBox1.Text;
        }

        private void txtStatus_Loaded(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = comboBox1.Text;
        }

        private void lbOk_Loaded(object sender, RoutedEventArgs e)
        {
            lbOk.Content = lbOk.Content + "  " + ok;
        }

        private void lbPr_Loaded(object sender, RoutedEventArgs e)
        {
            lbPr.Content = lbPr.Content + "  " + process;
        }

        private void lbCl_Loaded(object sender, RoutedEventArgs e)
        {
            lbCl.Content = lbCl.Content + "  " + close;
        }

        private void lbTo_Loaded(object sender, RoutedEventArgs e)
        {
            lbTo.Content = lbTo.Content + "  " + total;
        }

        private void RibbonButton_Click_1(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void RibbonButton_Click_2(object sender, RoutedEventArgs e)
        {
          lt.Sort();
            lt.WriteXmlFile("Tasks.xml");
            Load();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            EnterSound.Play();
        }

        private void SaveAll_Click(object sender, RoutedEventArgs e)
        {
            lt.WriteXmlFile("Tasks.xml");
        }

        //private void RibbonWindow_Activated(object sender, EventArgs e)
        //{
        //    Process process = RunningInstance();
        //    if (process != null)
        //    {
        //        MessageBox.Show("Программа уже запущена", "Ошибка", MessageBoxButton.OK);
        //        this.Close();
        //        return;
        //    }
        //}

    }
}
