using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DataAccessLibrary.Models;

namespace M_ToDoList.ViewModels
{
    public class TaskListViewModel : PropertyChangedBase
    {
        private List<TaskModel> _tasklist;
        public TaskListViewModel() { }
        
        public List<TaskModel> TaskList
        {
            get { return _tasklist; }
            set
            {
                _tasklist = value;
                NotifyOfPropertyChange(() => TaskList);
            }
        }
    }
}
