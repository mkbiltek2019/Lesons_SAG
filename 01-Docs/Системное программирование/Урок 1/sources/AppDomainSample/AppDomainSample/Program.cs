using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace UsingAppDomains
{

    static class Program
    {
        static AppDomain Drawer;        //будет хранить объект домена приложения TextDrawer
        static AppDomain TextWindow;    //будет хранить домена приложения TextWindow
        static Assembly DrawerAsm;      //будет хранить объект сборки TextDrawer.exe
        static Assembly TextWindowAsm;  //будет хранить объект сборки TextWindow.exe
        static Form DrawerWindow;       //будет хранить объект окна TextDrawer
        static Form TextWindowWnd       //будет хранить объект окна TextWindow
            ;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomain)]
        static void Main()
        {
            //включаем визуальные стили для прилжения, поскольку оно является оконным
            Application.EnableVisualStyles();
            /*создаём необходимые домены приложений с дружественными именами и 
             * сохраняем ссылки на них в соответствующие переменные*/
            Drawer = AppDomain.CreateDomain("Drawer");
            TextWindow = AppDomain.CreateDomain("TextWindow");
            /*загружаем сборки с оконными приложениями в соответствующие домены приложений*/
            DrawerAsm = Drawer.Load(AssemblyName.GetAssemblyName("TextDrawer.exe"));
            TextWindowAsm = Drawer.Load(AssemblyName.GetAssemblyName("TextWindow.exe"));
            /*создаём объекты окон на сонове оконных типов данных из загруженных сборок*/
            DrawerWindow = Activator.CreateInstance(DrawerAsm.GetType("TextDrawer.Form1")) as Form;
            TextWindowWnd = Activator.CreateInstance(
                TextWindowAsm.GetType("TextWindow.Form1"), 
                new object[]
                    {
                        DrawerAsm.GetModule("TextDrawer.exe"),
                        DrawerWindow
                    }) as Form;
            /*запускаем потоки*/
            (new Thread(new ThreadStart(RunVisualizer))).Start();
            (new Thread(new ThreadStart(RunDrawer))).Start();
            /*добавляем обработчик события DomainUnload*/
            Drawer.DomainUnload += new EventHandler(Drawer_DomainUnload);
        }

        static void Drawer_DomainUnload(object sender, EventArgs e)
        {
            /*открываем MessageBox в котором выводим имя текущего домена приложения*/
            MessageBox.Show("Domain with name " + (sender as AppDomain).FriendlyName + " yas been succesfully unloeded!");
        }
        static void RunDrawer()
        {
            /*запускаем окно модально в текущем потоке*/
            DrawerWindow.ShowDialog();  
            /*отгружаем домен приложения*/
            AppDomain.Unload(Drawer);
        }
        static void RunVisualizer()
        {
            /*запускаем окно модально в текущем потоке*/
            TextWindowWnd.ShowDialog();
            /*завершаем работу приложения, следствием чего станет закрытие потока*/
            Application.Exit();
        }
    }
}
