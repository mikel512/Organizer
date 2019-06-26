using System;
using System.Collections.Generic;
using DataAccessLibrary.Models;
using DataAccessLibrary.DataAccess;

namespace M_ToDoList.ViewModels
{
	public class CalendarViewModel : ViewModelBase
	{
		#region Fields

		// Property variables
		private DateTime p_DisplayDate;
		private string[] p_HighlightedDateText;
        private Dictionary<int, List<DateTime>> _taskListByMonth;

		// Member variables
		private DateTime m_OldDisplayDate;

		#endregion

		#region Constructor

		public CalendarViewModel()
		{
			this.Initialize();
		}

		#endregion

		#region Events

		/// <summary>
		/// Notifies subscriubers that a UI refresh has been requested.
		/// </summary>
		/// <remarks>
		/// We use this event because this view model has no knowledge of the view that
		/// uses it. That keeps the view model from being dependent on the view. But it
		/// means that this view model can't directly invoke a refresh method on the view.
		/// So, it raises this event, and the view subscribes to it. The view invokes any
		/// refresh method that may be implemented there.
		/// </remarks>
		public event EventHandler RefreshRequested;

		#endregion


		#region Properties

		/// The DisplayDate in the calendar.
		public DateTime DisplayDate
		{
			get { return p_DisplayDate; }

			set
			{
				base.RaisePropertyChangingEvent("DisplayDate");
				p_DisplayDate = value;
				base.RaisePropertyChangedEvent("DisplayDate");
			}
		}
		/// The text to be shown in tool tips for highlighted dates.
		public string[] HighlightedDateText
		{
			get { return p_HighlightedDateText; }

			set
			{
				base.RaisePropertyChangingEvent("HighlightedDateText");
				p_HighlightedDateText = value;
				base.RaisePropertyChangedEvent("HighlightedDateText");
			}
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Updates the HighlightedDateText property when the calendar is changed to a different month.
		/// </summary>
		private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			// Ignore properties other than DisplayDate
			if (e.PropertyName != "DisplayDate") return;

			// Ignore change if date is DateTime.MinValue
			if (p_DisplayDate == DateTime.MinValue) return;

			// Ignore change if month is the same
			if (p_DisplayDate.IsSameMonthAs(m_OldDisplayDate)) return;

			// Populate month
			this.SetMonthHighlighting();

			// Update OldDisplayDate
			m_OldDisplayDate = p_DisplayDate;
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Initializes the view model.
		/// </summary>
		private void Initialize()
		{
			// Initialize highlight text array
			p_HighlightedDateText = new String[31];
            _taskListByMonth = new Dictionary<int, List<DateTime>>();

			// Set the display date to today
			p_DisplayDate = DateTime.Today;

            this.SetTaskDictionary();

			// Set month highlighting
			this.SetMonthHighlighting();

			// Subscribe to PropertyChanged event
			this.PropertyChanged += OnPropertyChanged;
		}

		/// <summary>
		/// Requests a Refresh from the view.
		/// </summary>
		private void RequestRefresh()
		{
			if (this.RefreshRequested != null)
			{
				this.RefreshRequested(this, new EventArgs());
			}
		}
        private void SetTaskDictionary()
        {
            // Get all date times
            var connection = new TaskData();
            List<TaskModel> dateTimes = connection.GetUndoneTasks();

            // Initialize list for each month
            for(int i = 0; i< 12; i++)
            {
                _taskListByMonth[i] = new List<DateTime>();
            }
            
            foreach(var task in dateTimes)
            {
                int monthInt = task.DueDate.Month;
                _taskListByMonth[monthInt].Add(task.DueDate);
            }
        }
		/// <summary>
		/// Sets highlighting for a month.
		/// </summary>
		private void SetMonthHighlighting()
		{
			var displayMonth = this.DisplayDate.Month;
			var displayYear = this.DisplayDate.Year;

			// Get the last day of the display month
			var month = this.DisplayDate.Month;
			var year = this.DisplayDate.Year;
			var lastDayOfMonth = DateTime.DaysInMonth(year, month);

            // Get task list for current month
            var list = _taskListByMonth[month];

			// Set the highlighted date text
			for (var i = 0; i < 31; i++)
			{
				// First set this array element to null
				p_HighlightedDateText[i] = null;

				// If element is out of range, skip to next
				if (i >= lastDayOfMonth) continue;

				// Set highlight date text
                foreach(var date in list)
                {
                    if(i == date.Day - 1)
                    {
                        p_HighlightedDateText[i] = date.ToLongDateString();
                    }
                }
			}
            // Causes infinite loop:
            // Refresh the calendar
			//this.RequestRefresh();
		}
		#endregion
	}
}