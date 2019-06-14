﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLibrary.Logic;
using SQLite;

namespace DataAccessLibrary.Models
{
    public class TaskModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}