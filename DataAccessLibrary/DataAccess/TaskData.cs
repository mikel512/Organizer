using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DataAccessLibrary.Logic;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.DataAccess
{
    public class TaskData
    {
        public int CreateTask(TaskModel model)
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.AddTaskRow<TaskModel>(model);

        }
        public int DeleteTask(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.DeleteTaskRow<TaskModel>(id);

        }
        
        // Gets all rows
        public List<TaskModel> GetAllTasks()
        {
            SqlDataAccess sql = new SqlDataAccess();
            using(var conn = sql.GetConnection())
            {
                return conn.Table<TaskModel>().ToList();
            }
        }
        // Gets all rows where IsDone= false
        public List<TaskModel> GetUndoneTasks()
        {
            SqlDataAccess sql = new SqlDataAccess();
            using(var conn = sql.GetConnection())
            {
                return conn.Table<TaskModel>().Where(v => v.IsDone == false)
                    .ToList();
            }
        }
    }
}
