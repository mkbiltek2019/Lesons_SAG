using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WpfDiary.NET
{
    class Tasks:ObservableCollection<Task>
    {
        //protected ObservableCollection<Task> _tasks = new ObservableCollection<Task>();
        //public ObservableCollection<Task> TasksCollection { get { return _tasks; } set { _tasks = value; } }

        public Tasks(ListTask listTask)
        {
            foreach (Task task in listTask.TaskList)
            {
                Add(task);
            }
        }
    }
}
