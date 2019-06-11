using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using M_ToDoList.Models;
using DataAccessLibrary.Models;

namespace M_ToDoList.ViewModels
{
    public class TaskViewModel : Screen
    {
        public string TaskTitle { get; set; }
        public string TaskPriority { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDueDate { get; set; }
        public bool IsDone { get; set; }

    }
}
