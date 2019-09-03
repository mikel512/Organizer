using System;
using System.Windows;
using System.Windows.Controls;
using M_ToDoList.ViewModels;

namespace M_ToDoList.Views
{
    /// <summary>
    /// Interaction logic for TaskListView.xaml
    /// </summary>
    public partial class ListView : UserControl
    {
        #region Constructor
        public ListView()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Subscribes to the view model's RefreshRequested event.
        /// </summary>
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var listViewModel = (ListViewModel)DataContext;
            listViewModel.ListRefreshRequested += OnRefreshRequested;
        }

        /// <summary>
        /// Refreshes the calendar.
        /// </summary>
        private void OnRefreshRequested(object sender, EventArgs e)
        {
            var getList = new ListViewModel();
            this.Tasks.ItemsSource = getList.SetTaskList();
        }
        #endregion
    }
}
