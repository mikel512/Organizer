using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using M_ToDoList.Views;

namespace M_ToDoList.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
        private TaskViewModel _taskView;
        private TaskListViewModel _taskListView;
        private CalendarViewModel _calendarView;
        public ShellViewModel()
        {
            TaskView = new TaskViewModel();
            TaskListView = new TaskListViewModel();
            CalendarView = new CalendarViewModel();
        }

        // Bindings for child views
        public TaskViewModel TaskView
        {
            get { return _taskView; }
            set
            {
                _taskView = value;
                NotifyOfPropertyChange(() => TaskView);
            }
        }
        public TaskListViewModel TaskListView
        {
            get { return _taskListView; }
            set
            {
                _taskListView = value;
                NotifyOfPropertyChange(() => TaskListView);
            }
        }
        public CalendarViewModel CalendarView
        {
            get { return _calendarView; }
            set
            {
                _calendarView = value;
                NotifyOfPropertyChange(() => CalendarView);
            }
        }
    }
}
