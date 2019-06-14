using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DataAccessLibrary.Models;
using DataAccessLibrary.DataAccess;

namespace M_ToDoList.ViewModels
{
    public class TaskListViewModel : PropertyChangedBase
    {
        private TaskModel _selected;
        public TaskListViewModel() { }

        #region Properties
        public BindableCollection<TaskModel> Tasks
        {
            get
            {
                TaskData query = new TaskData();
                return new BindableCollection<TaskModel>( query.GetAllTasks());
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
