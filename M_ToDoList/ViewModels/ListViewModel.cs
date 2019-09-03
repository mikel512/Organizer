using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using M_ToDoList.Models;
using DataAccessLibrary.DataAccess;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Specialized;

namespace M_ToDoList.ViewModels
{
    public class ListViewModel : CalendarViewModel
    {
        #region Fields
        private ObservableCollection<TaskModel> _list;
        private TaskModel _selected;
        private bool _isSelected;
        #endregion

        #region Constructor
        public ListViewModel()
        {
            this.InitList();
        }
        #endregion

		public event EventHandler ListRefreshRequested;

        #region Properties
        public ObservableCollection<TaskModel> Tasks
        {
            get { return _list; }
            set
            {
                base.RaisePropertyChangingEvent("Tasks");
                _list = value;
                NotifyOfPropertyChange(() => Tasks);
                base.RaisePropertyChangedEvent("Tasks");
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
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }
        #endregion
		private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
            // Ignore properties other than DisplayDate
            // Populate month
            SetTaskList();

		}
        
        #region Methods
		public void ListRequestRefresh()
		{
			if (this.ListRefreshRequested != null)
			{
				this.ListRefreshRequested(this, new EventArgs());
			}
		}
        private void InitList()
        {
            // Initializes the TaskList collection field
            SetTaskList();
            PropertyChanged += OnPropertyChanged;
        }
        public ObservableCollection<TaskModel> SetTaskList()
        {
            var sql = new TaskData();
            _list = ConvertList((sql.GetAllTasks()));
            return _list;
        }
        public void DeleteTasks()
        {
            IEnumerable<int> list = this.Tasks.Where(d => d.IsSelected)
                .Select(d => (int)d.ID);

            var sql = new TaskData();
            foreach(int id in list)
            {
                sql.DeleteTask(id);
            }
            SetTaskList();
            this.ListRequestRefresh();
            // MessageBox.Show(msg);
        }
        private ObservableCollection<TaskModel> ConvertList(List<DataAccessLibrary.Models.TaskModel> toConv)
        {
            var newList = new ObservableCollection<TaskModel>();
            foreach(var task in toConv)
            {
                newList.Add(ConvertModel(task));
            }
            return newList;
        }
        private TaskModel ConvertModel(DataAccessLibrary.Models.TaskModel taskModel)
        {
            var newModel = new Models.TaskModel()
            {
                ID = (int)taskModel.ID,
                Title = taskModel.Title,
                Priority = taskModel.Priority,
                Description = taskModel.Description,
                DueDate = taskModel.DueDate,
                IsDone = taskModel.IsDone
            };

            return newModel;
        }

        #endregion
    }
}
