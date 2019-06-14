using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using System.Collections.Generic;

namespace todolistTests
{
    [TestClass]
    public class SqlAccessTests
    {
        private TaskModel testModel = new TaskModel
        {
            ID = 0,
            Title = "smokecrack",
            Priority = "Low",
            Description = "do the needly",
            DueDate = new DateTime(2019, 8, 8),
            IsDone = false
        };

        [TestMethod]
        public void DeleteTaskTest()
        {
            var task = new TaskData();
            int result = task.DeleteTask(0);

            Assert.AreEqual(1, result);

        }

        [TestMethod]
        public void CreateTaskTest()
        {
            var task = new TaskData();

            int result = task.CreateTask(testModel);

            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void UpdateTaskTest()
        { 
            TaskModel updtModel = new TaskModel
            {
                ID = 1,
                Title = "dostuff",
                Priority = "High",
                Description = "do the stuff",
                DueDate = new DateTime(2019, 10, 10),
                IsDone = false
            };
            var task = new TaskData();

            int result = task.UpdateTask(updtModel);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetAllTasksTest()
        {
            var task = new TaskData();

            List<TaskModel> tasks = task.GetAllTasks();

            Assert.AreEqual(1, tasks.Count);
        }

        [TestMethod]
        public void GetUndoneTasksTest()
        {
            var task = new TaskData();

            List<TaskModel> tasks = task.GetUndoneTasks();

            Assert.AreEqual(1, tasks.Count);
        }
    }
}
