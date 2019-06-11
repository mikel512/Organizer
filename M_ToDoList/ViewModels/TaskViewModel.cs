using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

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
