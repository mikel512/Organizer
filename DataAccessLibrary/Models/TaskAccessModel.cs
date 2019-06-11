using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLibrary.Logic;

namespace DataAccessLibrary.Models
{
    public class TaskLibraryModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }

    public class TaskAccessModel
    {
        public List<TaskLibraryModel> ListOfTasks()
        {
            return SqlDataAccess.TaskQuery();
        }
        public int InsertTask(string title, string priority, string descr,
                              DateTime duedate, bool isDone = false)
        {
            TaskLibraryModel model = new TaskLibraryModel
            {
                Title = title,
                Priority = priority,
                Description = descr,
                DueDate = duedate,
                IsDone = isDone
            };
            return SqlDataAccess.AddTaskRow(model);
        }
    }
}
