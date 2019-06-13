using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;

namespace todolistTests
{
    [TestClass]
    public class SqlAccessTests
    {
        private TaskModel testModel = new TaskModel
        {
            Title = "smokecrack",
            Priority = "Low",
            Description = "do the needly",
            DueDate = new DateTime(2019, 8, 8),
            IsDone = false
        };

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
        }
    }
}
