using SQLite;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caliburn.Micro;

namespace DataAccessLibrary.Models
{
    public class TaskModel
    {
        private bool _isSelected;
        [PrimaryKey, AutoIncrement]
        public int? ID { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
        public bool IsSelected { set; get; }

    }
}
