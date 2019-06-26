using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DataAccessLibrary.Models;
using DataAccessLibrary.DataAccess;
using System.Windows;

namespace M_ToDoList.ViewModels
{
    public class TaskViewModel : PropertyChangedBase
    {
        #region Fields
        private string _taskTitle;
        private string _taskPriority;
        private string _taskDescr;
        private DateTime _dueDate = DateTime.Today;
        private bool _isDone;
        #endregion

        // Constructor
        public TaskViewModel() { }

        #region Properties
        public BindableCollection<string> TaskPriorityStrings
        {
            get
            {
                return new BindableCollection<string>(
                    new string[] { "Low", "Medium", "High" });
            }
        }
        public string SelectedTaskPriorityString
        {
            get { return _taskPriority; }
            set
            {
                _taskPriority = value;
                NotifyOfPropertyChange(() => SelectedTaskPriorityString);
            }
        }
        public string TaskTitle
        {
            get { return _taskTitle; }
            set
            {
                _taskTitle = value;
                NotifyOfPropertyChange(() => TaskTitle);
            }
        }
        public string TaskDescription
        {
            get { return _taskDescr; }
            set
            {
                _taskDescr = value;
                NotifyOfPropertyChange(() => TaskDescription);
            }
        }
        public DateTime TaskDueDate
        {
            get { return _dueDate; }
            set
            {
                _dueDate = value;
                NotifyOfPropertyChange(() => TaskDueDate);
            }
        }
        public bool IsDone
        {
            set
            {
                _isDone = value;
            }
        }
        #endregion

        #region Methods
        public int AddTask()
        {
            TaskModel addModel = new TaskModel
            {
                Title = _taskTitle,
                Priority = _taskPriority,
                Description = _taskDescr,
                DueDate = _dueDate,
                IsDone = false
            };

            TaskData sql = new TaskData();
            int result = sql.CreateTask(addModel);
            if(result == 1)
            {
                ClearForms();
            }
            return result;
        }
        internal void ClearForms()
        {
            TaskTitle = "";
            TaskDescription = "";
            TaskDueDate = DateTime.Today;
        }
        public void ShowSuccessDiag()
        {
            MessageBoxResult result =
                MessageBox.Show("Task added.");
        }
        #endregion

    }
}
