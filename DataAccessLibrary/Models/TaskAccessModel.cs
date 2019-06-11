using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    class TaskLibraryModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }

    class TaskAccessModel
    {
        List<TaskLibraryModel> ListOfTasks { get; set; }
        public TaskAccessModel()
        {
            ListOfTasks = new List<TaskLibraryModel>();
        }
    }
}
