using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace WpfDiary.NET
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Process process = RunningInstance();
            if (process != null)
            {
                MessageBox.Show("Программа уже запущена", "Ошибка", MessageBoxButton.OK);
                //this.MainWindow.Close();
                //base.OnStartup(e);
                //this.MainWindow.Close(););
                //return;
            }
            WpfSingleInstance.Make();

            //base.OnStartup(e);
        }
    }
}