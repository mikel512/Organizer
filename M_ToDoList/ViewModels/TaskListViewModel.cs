using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using vhCalendar;
using DataAccessLibrary.Models;
using DataAccessLibrary.DataAccess;
using System.Collections.ObjectModel;

namespace M_ToDoList.ViewModels
{
    public class TaskListViewModel : ExtViewModel
    {
        private TaskModel _selected;
        public TaskListViewModel() { }

        #region Properties
        public BindableCollection<TaskModel> Tasks
        {
            get
            {
                TaskData query = new TaskData();
                var tst = new BindableCollection<TaskModel>( query.GetAllTasks());
                return tst;
            }
        }
        public TaskModel SelectedTask
        {
            get { return _selected; }
            set
            {
                _selected = value;
                NotifyOfPropertyChange(() => SelectedTask);
            }
        }
        #endregion
    }
}
