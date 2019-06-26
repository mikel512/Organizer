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
using System.Windows.Shapes;
using DataAccessLibrary.Models;
using DataAccessLibrary.DataAccess;
using System.Collections.ObjectModel;
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
