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
using System.Windows;

namespace M_ToDoList.ViewModels
{
    public class TaskListViewModel : ExtViewModel
    {
        #region Fields
        private BindableCollection<TaskModel> _list;
        private TaskModel _selected;
        private bool _isSelected;
        #endregion

        #region Constructor

        public TaskListViewModel()
        {
            this.InitList();
        }
        #endregion

        #region Properties
        public BindableCollection<TaskModel> Tasks
        {
            get { return _list; }
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
                base.RaisePropertyChangedEvent("IsSelected");
                _isSelected = value;
                base.RaisePropertyChangingEvent("IsSelected");
            }
        }
        #endregion

        #region Methods
        private void InitList()
        {
            // Initializes the TaskList collection field
            TaskData query = new TaskData();
            _list = new BindableCollection<TaskModel>( query.GetAllTasks());

        }
        public void DeleteButton()
        {
            //List<int> list = new List<int>();
            IEnumerable<int> list = this.Tasks.Where(d => d.IsSelected)
                .Select(d => (int)d.ID);
            var sql = new TaskData();
            foreach(int id in list)
            {
                sql.DeleteTask(id);
            }
            _list = new BindableCollection<TaskModel>(sql.GetAllTasks());
            
            // MessageBox.Show(msg);

        }

        #endregion
    }
}
