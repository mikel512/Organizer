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
        private List<TaskModel> _tasklist;
        private TaskModel _selected;
        private string _itemPr;
        private string _itemDescr;
        private DateTime _itemDate;
        public TaskListViewModel() { }

        #region Properties
        public string ListItemPriority
        {
            get { return _itemPr; }
            set
            {
                _itemPr = value;
                NotifyOfPropertyChange(() => ListItemPriority);
            }
        }
        public string ListItemDescription
        {
            get { return _itemDescr; }
            set
            {
                _itemDescr = value;
                NotifyOfPropertyChange(() => ListItemDescription);
            }
        }
        public DateTime ListItemDate
        {
            get { return _itemDate; }
            set
            {
                _itemDate = value;
                NotifyOfPropertyChange(() => ListItemDate);
            }
        }
        public List<TaskModel> Tasks
        {
            get
            {
                TaskData query = new TaskData();

                return query.GetAllTasks();
            }
            set
            {
                _tasklist = value;
                NotifyOfPropertyChange(() => Tasks);
            }
        }

        public TaskModel SelectedTask
        {
            get { return _selected; }
            set
            {
                ListItemPriority = SelectedTask.Priority;
                ListItemDescription = SelectedTask.Description;
                ListItemDate = SelectedTask.DueDate;
                NotifyOfPropertyChange(() => SelectedTask);
            }
        }
        #endregion
    }
}
