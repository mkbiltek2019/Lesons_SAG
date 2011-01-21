using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace WpfKenoWithListView
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        //public MyClass ClassKeno { get; set; }
        protected ObservableCollection<MyKeno> _classKeno = new ObservableCollection<MyKeno>();
        public ObservableCollection<MyKeno> ClassKeno { get { return _classKeno; } set { _classKeno = value; } }
        
        
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Keno keno = new Keno();
            MyKeno myKeno = new MyKeno();
            MyKeno myKeno1 = new MyKeno();
            keno.ReadFile();
            foreach (Keno k in keno.ArrayListKeno)
            {
                myKeno = new MyKeno(k.Num.ToString(),k.Date, k.Numberloto, k.Numberballs.ToString(), k.NumberToString(k.Number));
                myKeno1.ListKeno.Add(myKeno);
                //myKeno.MyKenoAddList(myKeno);
            }
            Listview.Items.Clear();
           
            ClassKeno.Clear();
            foreach (MyKeno keno1 in myKeno1.ListKeno  )
            {
                ClassKeno.Add(keno1);
                Listview.Items.Add(keno1);
            }
            
            //ClassKeno = new MyClass(myKeno1);
            //ListView listView = new ListView();
            //GridView gridView = new GridView();
            //gridView.AllowsColumnReorder = true;
            //gridView.ColumnHeaderToolTip = "Информация Кено";
            //GridViewColumn gridViewColumn = new GridViewColumn();
            //gridViewColumn.DisplayMemberBinding = new Binding("num");
            //gridViewColumn.Header = "Номер тиража";
            //gridViewColumn.Width = 100;
            //gridView.Columns.Add(gridViewColumn);

            //listView.ItemsSource = new MyClass(myKeno);
            //listView.View = gridView;
            //StackPanel1.Children.Add(listView);
            //Listviev.DataContext = Keno;
        }
       public class MyKeno
       {
            private string num;
            private string date;
            private string numberloto;
            private string numbersballs;
            private string number ;

        public string Num
        {
            get
            {
                return num;
            }
            set
            { num = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Numberloto
        {
            get { return numberloto; }
            set { numberloto = value; }
        }
        public string Numberballs
        {
            get { return numbersballs; }
            set { numbersballs = value; }
        }
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                //for (int i = 0; i < size; i++)
                //{
                //    number[i] = value[i];   
                //}
                number = value;
            }
            
        }

        public MyKeno()
        {
            num = "";
            date = "00.00.0000";
            numberloto = "A";
            numbersballs = "";
            
        }
        public MyKeno(string num, string date, string nl,string nb,string number)
        {
            Num = num;
            Date = date;
            Numberloto = nl;
            Numberballs = nb;
            Number = number;
        }
        //public ArrayList ArrayListKeno = new ArrayList();
           public List<MyKeno> ListKeno = new List<MyKeno>();
           public void MyKenoAddList(MyKeno myKeno)
           {
               ListKeno.Add(myKeno);
           }
       }

       //public class MyClass : ObservableCollection<MyKeno>
       //{
       //    public ObservableCollection<MyKeno> ClassKeno { get; set; }
       //    public MyClass(){}
       //    public MyClass(MyKeno myKeno):base(myKeno.ArrayListKeno.Cast<MyKeno>())
       //    {
               
       //        foreach (MyKeno keno in myKeno.ArrayListKeno)
       //        {
       //            Add(keno);
       //        }
       //    }
       //}
    }
}
