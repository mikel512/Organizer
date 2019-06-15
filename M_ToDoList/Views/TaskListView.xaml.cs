﻿using System;
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

namespace M_ToDoList.Views
{
    /// <summary>
    /// Interaction logic for TaskListView.xaml
    /// </summary>
    public partial class TaskListView : UserControl
    {
        public TaskListView()
        {
            InitializeComponent();

            TaskData query = new TaskData();
            var list = new List<TaskModel>( query.GetAllTasks());
            var dates = new ObservableCollection<DateTime>();
            foreach(var task in list)
            {
                dates.Add(task.DueDate);
            }
            CalendarCtrl.SelectedDates = dates;
        }
    }
}
