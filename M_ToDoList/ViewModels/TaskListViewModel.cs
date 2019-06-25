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
        private TaskModel _selected;
        private bool _isSelected;
        private BindableCollection<TaskModel> _list;

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
        public BindableCollection<TaskModel> IsCheckedList
        {
            get { return _list; }
            set
            {
                _list = value;
                NotifyOfPropertyChange(() => IsCheckedList);
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
        public void DeleteButton()
        {
            //List<int> list = new List<int>();
            IEnumerable<int> list = this.Tasks.Where(d => d.IsSelected)
                .Select(d => (int)d.ID);
            
            MessageBox.Show(list.Count<int>().ToString());

        }

        #endregion
    }
}
