using M_ToDoList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M_ToDoList.Views
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView : UserControl
    {
        public CalendarView()
        {
            InitializeComponent();
        }

        #region Event Handlers
        /// <summary>
        /// Subscribes to the view model's RefreshRequested event.
        /// </summary>
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var calendarViewModel = (CalendarViewModel)DataContext;
            calendarViewModel.RefreshRequested += OnRefreshRequested;
        }

        /// <summary>
        /// Refreshes the calendar.
        /// </summary>
        private void OnRefreshRequested(object sender, EventArgs e)
        {
            this.TaskCalendar.Refresh();
        }
        #endregion
    }
}
