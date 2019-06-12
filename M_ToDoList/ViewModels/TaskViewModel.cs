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
    public class TaskViewModel : PropertyChangedBase
    {
        private string _taskTitle;
        private string _taskPriority;
        private string _taskDescr;
        private DateTime _dueDate;
        private bool _isDone;
        public TaskViewModel() { }

        public string TaskTitle
        {
            set
            {
                _taskTitle = value;
                //NotifyOfPropertyChange(() => TaskTitle);
            }
        }
        public string TaskPriority
        {
            set
            {
                _taskPriority = value;
            }
        }
        public string TaskDescription
        {
            set
            {
                _taskDescr = value;
            }
        }
        public DateTime TaskDueDate
        {
            set
            {
                _dueDate = value;
            }
        }
        public bool IsDone
        {
            set
            {
                _isDone = value;
            }
        }

    }
}
